using System;

namespace Cake.Podman.Tests.Commands.Container.Exec;

public class TestContainerExecCommand
{
    private const string CONTAINER = "container";
    private const string COMMAND = "command";
    private const string ARGUMENT = "argument";

    [Fact]
    public void Test_Argument()
    {
        var fixture = new PodmanContainerExecFixture
        {
            Container = CONTAINER,
            Command = COMMAND,
            Argument = ARGUMENT
        };

        var actual = fixture.Run();
        Assert.Equal($"container exec {CONTAINER} {COMMAND} {ARGUMENT}", actual.Args);
    }

    [Fact]
    public void Test_Option_With_Argument()
    {
        var fixture = new PodmanContainerExecFixture
        {
            Container = CONTAINER,
            Command = COMMAND,
            Argument = ARGUMENT,
            Settings = new Podman.Commands.Container.Exec.PodmanContainerExecOptions
            {
                Env = ["E1", "E2"],
                User = "TstUser",
                Latest = true
            }
        };

        var actual = fixture.Run();
        Assert.Equal($"container exec --env E1 --env E2 --latest  --user TstUser {CONTAINER} {COMMAND} {ARGUMENT}", actual.Args);
    }

}
