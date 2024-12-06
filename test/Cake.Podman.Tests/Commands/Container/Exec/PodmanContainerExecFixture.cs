using System;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Podman.Aliases;
using Cake.Podman.Commands.Container.Exec;
using Cake.Testing.Fixtures;

namespace Cake.Podman.Tests.Commands.Container.Exec;

public class PodmanContainerExecFixture : ToolFixture<PodmanContainerExecOptions>, ICakeContext
{
    public PodmanContainerExecFixture() : base("podman"){}

    public string? Container { get; set; }
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

    protected override void RunTool()
    {
        this.PodmanContainerExec(Settings, Container!, Command!, Argument!);
    }
}
