using System;

namespace Cake.Podman.Tests.Commands.Container.List;

public class TestContainerListCommand
{
    [Fact]
    public void Test_Option()
    {
        var fixture = new PodmanContainerListFixture
        {
            Settings = new Podman.Commands.Container.List.PodmanContainerListOptions
            {
                Latest = true,
                Sort = "sort-test"
            }
        };

        var actual = fixture.Run();
        Assert.Equal($"container list --latest  --sort sort-test", actual.Args);
    }
}
