# FTPSync Tool

**FTPSync Tool** is a Windows-based service and configuration utility that keeps local directories synchronized with remote FTP or FTPS servers.  
It supports background synchronization, web-based management, and flexible profile settings.

---

## ✨ Features

- **Multiple FTP Profiles** — Manage and sync multiple servers at once.  
- **Protocol Support** — FTP, FTPS Explicit, and FTPS Implicit.  
- **Automatic Background Sync** — Runs as a Windows service.  
- **Integrated Web Interface** — Manage profiles remotely in your browser.  
- **Desktop Configuration Tool** — Add, rename, and edit profiles easily.  
- **Flexible Backup Options** — Single folder, named folders, or zip archives.  
- **Customizable Frequency** — Sync at configurable intervals per profile.  
- **Secure Access** — Token-based authentication via username/password.

---

## 🧩 Components

### FTPSyncService  
The Windows Service that performs synchronization tasks and optionally hosts the web management interface.

### FTPSyncConfigUI  
A WinForms-based configuration utility for:
- Creating and editing profiles  
- Installing/uninstalling the service  
- Starting/stopping the service  
- Managing web interface credentials and port  

---

## 🌐 Web Interface

The embedded web server allows:
- Viewing and editing sync profiles  
- Adding, deleting, and renaming profiles  
- Monitoring synchronization times  

**Login required:** credentials are set through the Config UI.  
Default port: `5050`

---

## ⚙️ Setup

1. Launch **FTPSyncConfigUI.exe**  
2. Create or edit your FTP profiles  
3. (Optional) Enable Web Interface and set credentials  
4. Click **Install Service**  
5. Start the service  
6. Visit the web UI at `http://localhost:5050` (or other port you configure)

## 📜 License

Licensed under the **Apache License 2.0** — see `LICENSE.txt` for details.

---

## 🧾 Additional Info

If you’d like to follow the chaotic development journey of this project — from batch script idea to full service + web UI —  
check out [**Journey into the Madness**](JOURNEY.md).