using System;
using System.Data;

namespace Cake.Podman.Tests.Commands.Container.Stop;

public class TestContainerStopCommand
{
    private const string CONTAINER = "container";

    [Fact]
    public void Test_Argument()
    {
        var fixture = new PodmanContainerStopFixture
        {
            Container = CONTAINER
        };

        var actual = fixture.Run();
        Assert.Equal($"container stop {CONTAINER}", actual.Args);
    }

    [Fact]
    public void Test_Option_With_Argument()
    {
        var fixture = new PodmanContainerStopFixture
        {
            Container = CONTAINER,
            Settings = new Podman.Commands.Container.Stop.PodmanContainerStopOptions
            {
                All = false,
                Filter = ["id", "name"],
                Time = 10
            }
        };

        var actual = fixture.Run();
        Assert.Equal($"container stop --all  --filter id --filter name --time 10 {CONTAINER}", actual.Args);
    }         

}
