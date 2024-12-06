using System;

namespace Cake.Podman.Tests.Commands.Image.Tag;

public class TestImageTagCommand
{
    private const string IMAGE = "0e3bbc2";
    private const string TAG = "so:latest";

    [Fact]
    public void Test_Argument()
    {
        var fixture = new PodmanImageTagFixture
        {
            Image = IMAGE,
            Tag = TAG
        };

        var actual = fixture.Run();

        Assert.Equal($"image tag {IMAGE} {TAG}", actual.Args);
    }    
}
