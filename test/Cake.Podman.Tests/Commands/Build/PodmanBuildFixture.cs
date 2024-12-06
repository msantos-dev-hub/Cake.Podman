using System;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Podman.Aliases;
using Cake.Podman.Commands.Build;
using Cake.Testing.Fixtures;

namespace Cake.Podman.Tests.Commands.Build;

public class PodmanBuildFixture : ToolFixture<PodmanBuildOptions>, ICakeContext
{
    public PodmanBuildFixture() : base("podman")
    {
    }

    public string? Argument { get; set; }

    public ICakeLog Log => Log;

    public ICakeArguments Arguments => throw new NotImplementedException();

    public IRegistry Registry => Registry;

    public ICakeDataResolver Data => throw new NotImplementedException();

    IFileSystem ICakeContext.FileSystem => FileSystem;

    ICakeEnvironment ICakeContext.Environment => Environment;

    IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;

    ICakeConfiguration ICakeContext.Configuration => throw new NotImplementedException();

    protected override void RunTool()
    {
        this.PodmanBuild(Settings, Argument!);
    }
}
