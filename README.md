# Cybersecurity Awareness Bot — Part 1

![Build Status](https://github.com/Sekgatla/CyberBot/actions/workflows/dotnet.yml/badge.svg)

A C# console chatbot that educates South African citizens about online safety.

## Features

- Voice greeting on startup (WAV file via `System.Media.SoundPlayer`)
- ASCII art banner and cybersecurity-themed logo
- Personalised user interaction (asks for your name)
- Colour-coded console UI with typing effect
- Responses to cybersecurity topics: passwords, phishing, safe browsing, malware, VPN, 2FA, identity theft, and public Wi-Fi
- Input validation for empty or unrecognised queries
- Clean class structure: `Program.cs`, `Chatbot.cs`, `User.cs`, `AudioPlayer.cs`

## How to Run

### Requirements

- .NET 8 SDK installed
- Windows OS (voice playback uses `System.Media.SoundPlayer`)

### Steps

```bash
dotnet restore CyberBot.csproj
dotnet run
```

> The `greeting.wav` file must be in the project folder (it is copied to the output folder automatically).

## Project Structure

```
CyberBot/
├── Program.cs         # Entry point — creates and starts the Chatbot
├── Chatbot.cs         # Main chatbot logic, responses, console UI
├── User.cs            # User data model with automatic properties
├── AudioPlayer.cs     # Handles WAV voice greeting playback
├── greeting.wav       # Voice greeting audio file
├── CyberBot.csproj    # .NET project file
└── README.md          # This file
```

## GitHub Actions (CI)

The CI workflow is at `.github/workflows/dotnet.yml`.  
It builds and compiles the project on every push, verifying there are no syntax or build errors.

## Cybersecurity Topics Supported

| Topic              | Keywords to try                     |
|--------------------|-------------------------------------|
| Password safety    | `password`                          |
| Phishing           | `phishing`                          |
| Safe browsing      | `browsing`, `safe browsing`         |
| Malware            | `malware`, `virus`, `ransomware`    |
| VPN                | `vpn`                               |
| Two-factor auth    | `2fa`, `two factor`, `mfa`          |
| Identity theft     | `identity`, `identity theft`        |
| Public Wi-Fi       | `wifi`, `public wifi`               |
| Bot purpose        | `purpose`, `what can you do`        |
| Bot status         | `how are you`                       |
| Help/Topics list   | `what can i ask`, `help`, `topics`  |

## References

Pieterse, H. 2021. *The Cyber Threat Landscape in South Africa: A 10-Year Review.*  
The African Journal of Information and Communication, 28(28).  
https://doi.org/10.23962/10539/32213
