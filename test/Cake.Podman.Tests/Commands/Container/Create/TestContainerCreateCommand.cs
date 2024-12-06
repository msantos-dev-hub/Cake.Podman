using System;

namespace Cake.Podman.Tests.Commands.Container.Create;

public class TestContainerCreateCommand
{
    private const string IMAGE = "image";
    private const string COMMAND = "command";
    private const string ARGUMENT = "argument";

    [Fact]
    public void Test_Argument()
    {
        var fixture = new PodmanContainerCreateFixture
        {
            Image = IMAGE,
            Command = COMMAND,
            Argument = ARGUMENT
        };

        var actual = fixture.Run();
        Assert.Equal($"create {IMAGE} {COMMAND} {ARGUMENT}", actual.Args);
    }

    [Fact]
    public void Test_Option_With_Argument()
    {
        var fixture = new PodmanContainerCreateFixture
        {
            Image = IMAGE,
            Command = COMMAND,            
            Argument = ARGUMENT,
            Settings = new Podman.Commands.Container.Create.PodmanContainerCreateOptions
            {
                Arch = "A1",
                Env = ["E1", "E2"],
                Tty = true
            }
        };

        var actual = fixture.Run();
        Assert.Equal($"create --arch A1 --env E1 --env E2 --tty  {IMAGE} {COMMAND} {ARGUMENT}", actual.Args);
    }        
}
