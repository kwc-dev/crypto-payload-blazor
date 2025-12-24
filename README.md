# CryptoPayload Blazor App

A Blazor Server application for decrypting and displaying AES‑encrypted payloads.  
The app now retrieves its encryption key directly from Azure Key Vault.  
This project demonstrates using a custom `CryptoConsumer` service to restore and render decrypted maps in the UI.

---

## 🚀 Features
- Blazor Server front‑end with Razor components
- Custom `CryptoConsumer` service for AES/CBC/PKCS5Padding decryption
- Azure Key Vault integration for securely fetching the AES key
- Displays decrypted payloads both in the browser and console output
- Cross‑platform: runs on Windows, Linux, and macOS

---

## 🔐 Azure Key Vault Integration
The application now loads the AES secret key from Azure Key Vault at startup.
### **How it works**
- The app uses the Azure SDK (`Azure.Security.KeyVault.Secrets` + `Azure.Identity`)
- Authentication is handled through **DefaultAzureCredential**, supporting:
  - Managed Identity (recommended for Azure App Service / VMs)
  - Azure CLI login (local development)
  - Visual Studio / VS Code identity
 
## Required configuration
Add the following setting to the `appsettings.json`:  
```json
"KeyVaultName": "<your-key-vault-name>"
```
Ensure your identity has **Get** permissions on the secret in Azure Key Vault.

## 🛠️ Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio / VS Code / Rider
- Azure Key Vault with the AES key stored as a secret

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
