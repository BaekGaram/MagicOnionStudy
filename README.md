# MagicOnionStudy

## Server and Unity Client Setup

### 1. Unity Project - Modify `manifest.json`

Add the following dependencies to your `manifest.json` file located in the Unity project:

```json
{
  "dependencies": {
    "com.cysharp.magiconion": "https://github.com/Cysharp/MagicOnion.git?path=src/MagicOnion.Client.Unity/Assets/Scripts/MagicOnion#7.0.0-preview.10",
    "com.cysharp.yetanotherhttphandler": "https://github.com/Cysharp/YetAnotherHttpHandler.git?path=src/YetAnotherHttpHandler#1.6.0",
    "com.github-glitchenzo.nugetforunity": "https://github.com/GlitchEnzo/NuGetForUnity.git?path=/src/NuGetForUnity",
    "com.magiconion-myproject-server.shared": "file:../../../MagicOnionStudy/MyProjectServer/Shared/",

    "com.unity.adaptiveperformance.google.android": "1.3.1",
    "com.unity.adaptiveperformance.samsung.android": "5.0.0",
    "com.unity.collab-proxy": "2.5.2",
    "com.unity.ide.visualstudio": "2.0.22",
    "com.unity.multiplayer.center": "1.0.0",
    "com.unity.modules.unityanalytics": "1.0.0",
    "com.unity.modules.unitywebrequest": "1.0.0"
    // Add more dependencies as needed
  }
}
```

> **Key Dependencies:**
> - `com.cysharp.magiconion`: MagicOnion framework
> - `com.cysharp.yetanotherhttphandler`: gRPC support
> - `com.github-glitchenzo.nugetforunity`: NuGetForUnity installation
> - `com.magiconion-myproject-server.shared`: Shared project for server and client

### 2. NuGet Configuration Setup

Once `NuGetForUnity` is installed, two configuration files are added: `Nuget.Config` and `packages.config`.

#### 2.1 Update `Nuget.Config`

Replace or edit `Nuget.Config` with the following:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
  <disabledPackageSources />
  <activePackageSource>
    <add key="All" value="(Aggregate source)" />
  </activePackageSource>
  <config>
    <add key="packageInstallLocation" value="CustomWithinAssets" />
    <add key="repositoryPath" value="./Packages" />
    <add key="PackagesConfigDirectoryPath" value="." />
    <add key="slimRestore" value="true" />
  </config>
</configuration>
```

#### 2.2 Update `packages.config`

Add the following packages to `packages.config`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Grpc.Core.Api" version="2.63.0" />
  <package id="Grpc.Net.Client" version="2.63.0" manuallyInstalled="true" />
  <package id="Grpc.Net.Common" version="2.63.0" />
  <package id="MemoryPack" version="1.21.1" manuallyInstalled="true" />
  <package id="MemoryPack.Core" version="1.21.1" />
  <package id="MemoryPack.Generator" version="1.21.1" />
  <package id="MessagePack" version="2.5.140" manuallyInstalled="true" />
  <package id="MessagePack.Annotations" version="2.5.140" />
  <package id="Microsoft.Bcl.AsyncInterfaces" version="8.0.0" />
  <package id="Microsoft.Extensions.DependencyInjection.Abstractions" version="8.0.1" />
  <package id="Microsoft.Extensions.Logging.Abstractions" version="8.0.1" />
  <package id="Microsoft.NET.StringTools" version="17.6.3" />
  <package id="Newtonsoft.Json" version="13.0.3" manuallyInstalled="true" />
  <package id="System.Collections.Immutable" version="6.0.0" />
  <package id="System.Diagnostics.DiagnosticSource" version="8.0.0" />
  <package id="System.IO.Pipelines" version="8.0.0" manuallyInstalled="true" />
  <package id="System.Runtime.CompilerServices.Unsafe" version="6.0.0" />
  <package id="System.Threading.Channels" version="8.0.0" manuallyInstalled="true" />
</packages>
```

> **Result:** A new `MagicOnion` gRPC channel will appear in the Unity editor under **Window > MagicOnion > gRPC Channel**.

---

### 3. Add AssemblyDefinition File for Shared Project

1. In the shared folder (`Shared/`), add a new **AssemblyDefinition** file.
2. Reference `MagicOnion.Abstractions` in the AssemblyDefinition dependencies.

```json
{
  "name": "MyProject.Shared",
  "references": [
    "MagicOnion.Abstractions"
  ]
}
```

---

### 4. Folder Structure Example

```
MagicOnionStudy/
├── MyProjectServer/
│   ├── Shared/      <- Shared project with AssemblyDefinition
│   └── Server/      <- Server-side code
└── MyProjectClient/
    └── UnityProject/ <- Unity Client project
```

> If the folder structure requires an absolute path, use:
> ```json
> "com.magiconion-myproject-server.shared": "file:D:/BaekGaram_git/MagicOnionStudy/MyProjectServer/Shared/"
> ```

---

### 5. Summary
- **MagicOnion** is set up for both Server and Client.
- **NuGet** support is added to Unity via `NuGetForUnity`.
- Shared projects are connected via AssemblyDefinitions.

Your Unity client is now ready to interact with the MagicOnion server!

---

### Notes
- Make sure to restore NuGet packages after modifying configurations.
- The folder structure can vary, but paths in `manifest.json` must be accurate.

> **Next Step:** Implement MagicOnion services and test the gRPC connection between the Server and Unity Client.
