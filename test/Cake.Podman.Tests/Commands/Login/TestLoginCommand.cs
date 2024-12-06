using System;

namespace Cake.Podman.Tests.Commands.Login;

public class TestLoginCommand
{
    private const string SERVER = "quay.io";
    private const string USERNAME = "user";
    private const string PASSWORD = "pass";

    [Fact]
    public void Test_Argument()
    {
        var fixture = new PodmanLoginFixture
        {
            Server = SERVER,
            Username = USERNAME,
            Password = PASSWORD
        };

        var actual = fixture.Run();

        Assert.Equal($"login --password pass --username user {SERVER}", actual.Args);
    }
}
