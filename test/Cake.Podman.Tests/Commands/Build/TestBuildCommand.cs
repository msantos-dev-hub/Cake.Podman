using System;

namespace Cake.Podman.Tests.Commands.Build;

public class TestBuildCommand
{
    private const string ARGUMENT = "arg";

    [Fact]
    public void Test_Argument()
    {
        var fixture = new PodmanBuildFixture
        {
            Argument = ARGUMENT
        };

        var actual = fixture.Run();

        Assert.Equal($"build {ARGUMENT}", actual.Args);
    }

    [Fact]
    public void Test_Option_With_Argument()
    {
        var fixture = new PodmanBuildFixture
        {
            Argument = ARGUMENT,
            Settings = new Podman.Commands.Build.PodmanBuildOptions
            {
                Arch = "A1",
                Env = ["E1", "E2"],
                Ssh = ["ssh1", "ssh2"]
            }
        };

        var actual = fixture.Run();

        Assert.Equal($"build --arch A1 --env E1 --env E2 --ssh ssh1,ssh2 {ARGUMENT}", actual.Args);
    }
}
