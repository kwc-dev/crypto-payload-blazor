# CryptoPayload Blazor App

A Blazor Server application for decrypting and displaying AES‑encrypted payloads.  
This project demonstrates using a custom `CryptoConsumer` service to restore and render decrypted maps in the UI.

---

## 🚀 Features
- Blazor Server front‑end with Razor components
- Custom `CryptoConsumer` service for AES/CBC/PKCS5Padding decryption
- Displays decrypted payloads both in the browser and console output
- Cross‑platform: runs on Windows, Linux, and macOS

---

## 🛠️ Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio / VS Code / Rider

### Build & Run (Windows)
```bash
dotnet build
dotnet run
```

### Build and publish for Linux
```bash
dotnet publish -c Release -r linux-x64 --self-contained false
```

#### Navigate to publish folder
```bash
cd bin/Release/net8.0/linux-x64/publish
```

#### Run the app
```bash
dotnet CryptoPayloadBlazorApp.dll
```
