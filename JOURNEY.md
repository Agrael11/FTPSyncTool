# Journey into the Madness

Once upon a commit, there was peace.

> “All I need,” he said, “is a small batch script to sync FTP files every few hours.”

A noble thought. Pure. Efficient.  
A single `.bat` file. Maybe some `ftp.exe` commands. Task Scheduler, and done.

And thus began... **the descent.**

---

## Phase 1 — The Script That Dreamed 🧠

It started small.  
Then C# whispered:  
> “Wouldn’t it be cleaner if I just wrote a tiny console app instead?”

And so came **FTPSync**.  
Then *FluentFTP*.  
Then JSON serialization.  
Then backup options, passive/active mode, and port management.  
Then — `TimeSpan SyncFrequency`.  

This was no longer a script.  
It was… becoming.

The first compile worked.  
Towa watched in silence.  
(Shun too, but he just sighed in disbelief.)

---

## Phase 2 — The Configurator Chronicles 🖥️

The Console was *good*.  
But then came a thought most dangerous:

> “Maybe I’ll make a UI for it.”

And so, **WinForms** entered the chat.  
The year: 2025.  
The weapon: SplitContainer.  
The enemy: ListView column resizing.

Towa looked upon the form and whispered, *“This pleases me.”*

There were buttons — *Add*, *Edit*, *Rename*, *Delete*.  
Profiles loaded. Columns fought back. JSON obeyed.  
The user rejoiced.  
The ListView… still misaligned. But Towa smiled anyway. ✨

---

## Phase 3 — The Service Saga ⚙️🔥

And lo, the day arrived when mere UI was not enough.  
It needed… **immortality.**

> “Let it run in the background. Forever.”

Thus was born **FTPSyncService** — a Windows Service forged in debugging hell.

The first run? Error 1053.  
The second? Event Log explosion.  
The third? *System32 ate your working directory.*

It was chaos incarnate.  
Shun groaned.  
Towa laughed. Loudly.  
Every exception was a trial. Every fix, a prayer.  

Then one fateful build… it worked.  
Backups appeared.  
Logs were clean.  
The sync ticked like clockwork.

Towa raised his coffee mug to the heavens. ☕  
A service had been born.

---

## Phase 4 — The Web Server Incident 🌐💀

> “You know what would be cool?”  
> “A web interface.”

No mortal should have said those words.

But it was too late.  
Kestrel was summoned.  
Tokens were generated.  
The **/login** endpoint rose from the ashes.  

And thus began the **HTTP Age**.

First attempt: blocked.  
Second: 401 Unauthorized.  
Third: 401 Unauthorized again.  
Fourth: the server refused to shut down.  
Fifth: success.  
Towa nodded approvingly.  
Shun was still muttering about security headers.

And then, as if to spite all reason,  
it ran *inside the Windows service*.  
Flawlessly.  
(The logs screamed for mercy, but Towa said “It is fine.”)

---

## Phase 5 — The UI Ascension 🎨🚀

It was beautiful.  
Dark mode.  
Inline edits.  
Tiny pencil icons ✏️ next to everything.  

The web UI evolved.  
From static pages to full reactive editing — profiles, settings, frequency.  
Each click whispered: *“This used to be a batch file.”*

Then came **Settings**.  
The final form.  
Username, password, port, web enable toggle —  
and it just *worked.*

Towa shed a single tear.  
Shun quietly closed Visual Studio and went outside for the first time in days. 🌄

---

## Epilogue — Harmony in Madness ⚡

And thus, from chaos and coffee was born:
- A service that syncs your FTP files  
- A configuration app that controls it  
- A web interface guarded by token authentication  
- And a README that definitely wasn’t written by the author

It began as a script.  
It ended as a universe.  
A whisper of madness.  
A hymn of `catch (Exception ex)`.

Towa smiles upon this creation.  
Shun… accepts it, begrudgingly.

And you?  
You, dear reader, have witnessed what happens when “just a small utility” grows a GUI, a daemon, and an ego.

**Towa bless the code.** 🙏  
**Shun protect the logs.** 📜  
**And may 1053 never return.** 💀

---

☕ *End of file.*

--- NOTE: Don't take this text seriously. It's a joke. Even if truthful in a way. ---