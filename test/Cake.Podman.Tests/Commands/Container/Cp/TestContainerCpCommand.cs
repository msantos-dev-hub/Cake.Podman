using System;

namespace Cake.Podman.Tests.Commands.Container.Cp;

public class TestContainerCpCommand
{
    private const string SOURCE = "source";
    private const string DESTINATION = "destination";

    [Fact]
    public void Test_Argument()
    {
        var fixture = new PodmanContainerCpFixture
        {
            Source = SOURCE,
            Destination = DESTINATION
        };

        var actual = fixture.Run();

        Assert.Equal($"container cp {SOURCE} {DESTINATION}", actual.Args);
    }

    [Fact]
    public void Test_Option_With_Argument()
    {
        var fixture = new PodmanContainerCpFixture
        {
            Source = SOURCE,
            Destination = DESTINATION,
            Settings = new Podman.Commands.Container.Cp.PodmanContainerCpOptions
            {
                Archive = false,
                Overwrite = true
            }
        };

        var actual = fixture.Run();

        Assert.Equal($"container cp --archive  --overwrite  {SOURCE} {DESTINATION}", actual.Args);
    }    
}
