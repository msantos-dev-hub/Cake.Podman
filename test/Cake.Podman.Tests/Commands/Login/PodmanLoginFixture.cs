using System;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Podman.Aliases;
using Cake.Podman.Commands.Login;
using Cake.Testing.Fixtures;

namespace Cake.Podman.Tests.Commands.Login;

public class PodmanLoginFixture : ToolFixture<PodmanLoginOptions>, ICakeContext
{
    public PodmanLoginFixture() : base("podman")
    {
    }

    public string? Server { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

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
        this.PodmanLogin(Username!, Password!, Server);
    }
}
