# Avalonia High CPU Repro

This sample demonstrates the scenario that once caused very high CPU usage when using Avalonia on the Linux frame buffer. The problem has been resolved in newer versions of Avalonia, but the project remains here as a minimal repro.

## Build and run

From the repository root run:

```bash
dotnet restore
# the sample project is in the `Sample` folder
 dotnet run --project Sample
```

It should launch a simple window without the excessive CPU usage seen in the original bug.
