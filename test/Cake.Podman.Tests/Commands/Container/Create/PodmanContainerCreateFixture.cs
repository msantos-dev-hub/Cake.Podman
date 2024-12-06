using System;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Podman.Aliases;
using Cake.Podman.Commands.Container.Create;
using Cake.Testing.Fixtures;
using Cake.Podman.Extensions;

namespace Cake.Podman.Tests.Commands.Container.Create;

public class PodmanContainerCreateFixture : ToolFixture<PodmanContainerCreateOptions, ToolFixtureResult>, ICakeContext
{
    public PodmanContainerCreateFixture() : base("podman")
    {
    }

    public string? Image { get; set; }
    public string? Command { get; set; }
    public string? Argument { get; set; }
    public ICakeLog Log => Log;

    public ICakeArguments Arguments => throw new NotImplementedException();

    public IRegistry Registry => Registry;

    public ICakeDataResolver Data => throw new NotImplementedException();

    IFileSystem ICakeContext.FileSystem => FileSystem;

    ICakeEnvironment ICakeContext.Environment => Environment;

    IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;

    ICakeConfiguration ICakeContext.Configuration => throw new NotImplementedException();

    protected override ToolFixtureResult CreateResult(FilePath path, ProcessSettings process)
    {
        var processArguments = new ProcessArgumentBuilder()
                .Append("create")
                .Append(Settings)
                .Append( new List<string>()
                                .Add<string>(Image!)
                                .AddIf(_ => !string.IsNullOrEmpty(Command), Command!)
                                .AddIf(_ => !string.IsNullOrEmpty(Argument), Argument!));

        return new ToolFixtureResult("create", new ProcessSettings 
        {
            RedirectStandardOutput = true,
            Arguments = processArguments
        });
    }

    protected override void RunTool()
    {
        ProcessRunner.Process.SetStandardOutput([""]);
        this.PodmanContainerCreate(Settings, Image!, Command!, Argument!);
    }
}
