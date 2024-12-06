using System;

namespace Cake.Podman.Tests.Commands.Logout;

public class TestLogoutCommand
{
    private const string SERVER = "quay.io";

    [Fact]
    public void Test_Argument()
    {
        var fixture = new PodmanLogoutFixture
        {
            Server = SERVER
        };

        var actual = fixture.Run();

        Assert.Equal($"logout {SERVER}", actual.Args);
    }    

    [Fact]
    public void Test_Option_With_Argument()
    {
        var fixture = new PodmanLogoutFixture
        {
            Server = SERVER,
            Settings = new Podman.Commands.Logout.PodmanLogoutOptions
            {
                All = true,
                Authfile = "auth"
            }
        };

        var actual = fixture.Run();

        Assert.Equal($"logout --all  --authfile auth {SERVER}", actual.Args);
    }    
}
