using System;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Podman.Aliases;
using Cake.Podman.Commands.Logout;
using Cake.Testing.Fixtures;

namespace Cake.Podman.Tests.Commands.Logout;

public class PodmanLogoutFixture : ToolFixture<PodmanLogoutOptions>, ICakeContext
{
    public PodmanLogoutFixture() : base("podman")
    {
    }

    public string? Server { get; set; }

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
        this.PodmanLogout(Settings, Server);
    }
}
