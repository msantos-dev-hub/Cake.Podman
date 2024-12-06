using System;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Podman.Aliases;
using Cake.Podman.Commands.Image.Tag;
using Cake.Testing.Fixtures;

namespace Cake.Podman.Tests.Commands.Image.Tag;

public class PodmanImageTagFixture : ToolFixture<PodmanImageTagOptions>, ICakeContext
{
    public PodmanImageTagFixture() : base("podman")
    {
    }

    public string? Image { get; set; }
    public string? Tag { get; set; }

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
        this.PodmanImageTag(Settings, Image!, Tag!);
    }
}
