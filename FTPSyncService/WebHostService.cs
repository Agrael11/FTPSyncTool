using FTPSyncLib;
using FTPSyncService;
using Microsoft.Extensions.FileProviders;

public class WebHostService : BackgroundService
{
    private readonly CommonConfigFile.Config _config;
    private WebApplication? _app;

    public WebHostService(CommonConfigFile.Config config)
    {
        _config = config;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var builder = WebApplication.CreateBuilder();

        // ✅ DO NOT call AddWindowsService here — it’s already handled by the main host
        builder.WebHost.ConfigureKestrel(options =>
            options.ListenAnyIP(_config.Port));

        // optional logging setup
        builder.Logging.ClearProviders();

        // middleware & endpoints
        var app = builder.Build();

        app.Use(async (context, next) =>
        {
            var path = context.Request.Path.Value ?? "";

            if (path.StartsWith("/login")
                || path.StartsWith("/logout")
                || path.StartsWith("/static")
                || path.StartsWith("/favicon")
                || path.EndsWith(".css")
                || path.EndsWith(".js"))
            {
                await next();
                return;
            }

            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            var token = authHeader?.Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token) || !AuthTokenManager.ValidateToken(token))
            {
                if (path.StartsWith("/api") || path.EndsWith(".json"))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized");
                }
                else
                {
                    context.Response.Redirect("/static/login.html");
                }
                return;
            }

            await next();
        });

        app.MapGet("/profiles.json", () =>
            Results.File(PathInfo.ProfilesFile, "application/json"));

        app.MapPost("/profiles.json", async (HttpRequest req) =>
        {
            using var reader = new StreamReader(req.Body);
            var json = await reader.ReadToEndAsync();
            await File.WriteAllTextAsync(PathInfo.ProfilesFile, json);
            return Results.Ok();
        });

        app.MapPost("/login", async (HttpContext context) =>
        {
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var data = System.Text.Json.JsonSerializer.Deserialize<LoginRequest>(body);

            if (data is null || !CheckAuth(_config, data.username, data.password))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid credentials");
                return;
            }

            var token = AuthTokenManager.CreateToken();
            var expires = DateTime.UtcNow.AddMinutes(30);
            await context.Response.WriteAsJsonAsync(new { token, expires });
        });

        app.MapPost("/logout", (HttpContext context) =>
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            if (authHeader?.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase) != true)
            {
                context.Response.StatusCode = 401;
                return context.Response.WriteAsync("Missing token");
            }

            var token = authHeader["Bearer ".Length..].Trim();
            AuthTokenManager.InvalidateToken(token);
            return context.Response.WriteAsync("Logged out");
        });

        var thisProcessPath = AppContext.BaseDirectory;
        var pagesPath = Path.Join(thisProcessPath!, "WebPages");

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(pagesPath),
            RequestPath = ""
        });

        app.MapFallbackToFile("/static/index.html");

        _app = app;

        // ✅ Start web host manually — do not await indefinitely here
        await _app.StartAsync(stoppingToken);

        // Wait until service stop
        await Task.Delay(Timeout.Infinite, stoppingToken);

        // Stop cleanly
        await _app.StopAsync(stoppingToken);
    }

    private static bool CheckAuth(CommonConfigFile.Config config, string username, string password)
    {
        return (config.UserName == username) && (config.GetPasswordHash() == password);
    }
}
