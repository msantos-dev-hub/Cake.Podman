# Cake.Podman

A Cake Addin for [Podman](https://podman.io/) that extends the command line tools

## Usage
#### Including the addin
To include the addin, add the following instruction to the beginning of the ```cake``` script:

```
#addin "Cake.Podman"
```

#### Use the addin
```
Task("Pull Image")
     .Does(() =>
     {
         Information("Pulling image...");
         PodmanImagePull("mcr.microsoft.com/dotnet/runtime");
     });
	
RunTarget("Pull Image");
```

## Notes
Ensure that Docker command line tool can be located using the PATH.
Tested only on Windows environment.

Please check the [Release Notes](ReleaseNotes.md) to see the supported commands.