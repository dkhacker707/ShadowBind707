Project Purpose and Overview

ShadowBind707 is a simple yet powerful EXE binder designed for red teamers and cybersecurity enthusiasts.  
It binds a protected executable (`BinderProject.exe`) with a decoy image file (`decoy.jpg`) to create a stealthy payload delivery mechanism.  
When the decoy image is opened, the embedded EXE payload runs silently in the background.  

This project also demonstrates how to embed and execute an obfuscated PowerShell payload, enabling AV evasion and stealth during engagements.

---

## Requirements

- Windows Operating System  
- [.NET Framework 4.8 or later](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)  
- Visual Studio or MSBuild to build the project  
- [ConfuserEx](https://yck1509.github.io/ConfuserEx/) (for EXE obfuscation and protection)  

---

## How It Works

- The binder opens the `decoy.jpg` image file to distract the user.  
- Simultaneously, the embedded executable (`BinderProject.exe`) runs an obfuscated PowerShell script payload in the background.  
- This method enables stealth execution of payloads while maintaining a legitimate-looking decoy.

---

## Preparing the PowerShell Payload

1. Write your PowerShell AV evasion or bypass script (`bypass.ps1`) with your desired commands.

2. Convert the PowerShell script to Base64 format so it can be safely embedded and executed by the EXE without detection:  
   
   Open PowerShell and run:
   ```powershell```
   $b64 = [Convert]::ToBase64String([IO.File]::ReadAllBytes("C:\Path\To\powershell_AV_Evasion_payload.ps1"))
   $b64 | Out-File "C:\Path\To\bypass.b64"


## Building and Running
Open ShadowBind707 solution in Visual Studio targeting .NET Framework 4.8.

Build the solution to generate BinderProject.exe in the bin\Debug or bin\Release folder.

Place the decoy.jpg image in the same directory as the executable or adjust paths accordingly.


## Obfuscation and Protection
Use ConfuserEx to obfuscate BinderProject.exe after building to enhance stealth:

Load the EXE in ConfuserEx GUI.

Apply protections like control flow obfuscation, anti-debug, anti-tampering, and rename obfuscation.

This reduces chances of detection and reverse engineering.