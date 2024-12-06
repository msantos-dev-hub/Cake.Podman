using System;

namespace Cake.Podman.Tests.Commands.Container.Start;

public class TestContainerStartCommand
{
    private const string CONTAINER = "container";

    [Fact]
    public void Test_Argument()
    {
        var fixture = new PodmanContainerStartFixture
        {
            Container = CONTAINER
        };

        var actual = fixture.Run();
        Assert.Equal($"container start {CONTAINER}", actual.Args);
    }

    [Fact]
    public void Test_Option_With_Argument()
    {
        var fixture = new PodmanContainerStartFixture
        {
            Container = CONTAINER,
            Settings = new Podman.Commands.Container.Start.PodmanContainerStartOptions
            {
                Attach = false,
                Filter = ["id", "name"]
            }
        };

        var actual = fixture.Run();
        Assert.Equal($"container start --attach  --filter id --filter name {CONTAINER}", actual.Args);
    }         
}
