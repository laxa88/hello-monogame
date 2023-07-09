# Experiments in MonoGame

## Learning materials

- MonoGame 2D tutorials: <http://rbwhitaker.wikidot.com/monogame-2d-tutorials>

## Setup

Reference: [Learn MonoGame](https://learn-monogame.github.io/how-to/get-started/)

Summary:

- Install [.NET SDK 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-3.1.32-windows-x64-installer?cid=getdotnetcore) (minimum for MonoGame)
- Install [VS Code](https://code.visualstudio.com) (IDE)
- Install [C# VS Code plugin](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)

## Run

Assuming `C#` extension and `.vscode` were configured correctyl, you can just press F5 to debug.

Otherwise, in terminal:

```bash
cd HelloMonogame
dotnet run
```

## Test

```bash
cd HelloMonogame.Tests
dotnet test
```

## Manage assets (local)

Notes:

- You won't be able to open the `.mgcb` file by double-clicking the file. This requires the global intallation (refer to section below).
- To open the MGCB editor locally, you'll have to run the command from the terminal.

Make sure global mgcb-editor is uninstalled:

```bash
dotnet tool uninstall mgcb-editor -g
```

Setup manifest (inside folder with `.csproj`):

```bash
dotnet new tool-manifest
```

Update the contents:

```json
{
  "version": 1,
  "isRoot": true,
  "tools": {
    "dotnet-mgcb-editor": {
      "version": "3.8.1.303",
      "commands": [
        "mgcb-editor"
      ]
    },
    "dotnet-mgcb-editor-windows": {
      "version": "3.8.1.303",
      "commands": [
        "mgcb-editor-windows"
      ]
    }
  }
}
```

Install MGCB editor from [Nuget](https://www.nuget.org/packages/dotnet-mgcb-editor):

```bash
dotnet tool install --local dotnet-mgcb-editor --version 3.8.1.303
```

Run from terminal:

```bash
dotnet tool run mgcb-editor Content/Content.mgcb
# or
dotnet mgcb-editor Content/Content.mgcb
```

## Manage assets (global)

You only need this if you want to open the `.mgcb` by double-clicking it.

Install [.NET 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1).

Install MGCB editor globally:

```bash
dotnet tool install -g dotnet-mgcb-editor --version 3.8.0.1641
# or
dotnet tool install -g dotnet-mgcb-editor-windows 3.8.0.1641
```

Register `.mgcb` extension in Windows:

```bash
mgcb-editor --register
```

Note: To uninstall, replace `install` with `uninstall`

Install [VSCode MGCB plugin](https://marketplace.visualstudio.com/items?itemName=mgcb-vscode.mgcb-vscode).

## Release

Release for Windows, Mac, or Linux:

```bash
dotnet publish -c Release -r win-x64 -o artifacts/windows --self-contained
dotnet publish -c Release -r osx-x64 -o artifacts/osx --self-contained
dotnet publish -c Release -r linux-x64 -o artifacts/linux --self-contained
```

## Troubleshooting

In cases dependencies do not work, try this to reinstall:

```bash
dotnet restore
```
