using System;

namespace Cake.Podman.Tests.Commands.Image.Push;

public class TestImagePushCommand
{
    private const string IMAGE = "myimage";
    private const string DESTINATION = "quay.io/podman/stable";

    [Fact]
    public void Test_All_Arguments()
    {
        var fixture = new PodmanImagePushFixture(PodmanImagePushFixture.PodmanPushEnum.ALL_ARGUMENTS)
        {
            Image = IMAGE,
            Destination = DESTINATION
        };

        var actual = fixture.Run();

        Assert.Equal($"image push {IMAGE} {DESTINATION}", actual.Args);
    }

    [Fact]
    public void Test_Destination_Argument()
    {
        var fixture = new PodmanImagePushFixture(PodmanImagePushFixture.PodmanPushEnum.ONLY_DESTINATION_ARGUMENT)
        {
            Destination = DESTINATION
        };

        var actual = fixture.Run();

        Assert.Equal($"image push {DESTINATION}", actual.Args);
    }

    [Fact]
    public void Test_Option_With_All_Arguments()
    {
        var fixture = new PodmanImagePushFixture(PodmanImagePushFixture.PodmanPushEnum.ALL_ARGUMENTS_WITH_OPTION)
        {
            Image = IMAGE,
            Destination = DESTINATION,
            Settings = new Podman.Commands.Image.Push.PodmanImagePushOptions
            {
                Format = "format-test",
                Retry = 3,
                TlsVerify = true
            }
        };

        var actual = fixture.Run();

        Assert.Equal($"image push --format format-test --retry 3 --tls-verify  {IMAGE} {DESTINATION}", actual.Args);
    }    

    [Fact]
    public void Test_Option_With_Destination_Argument()
    {
        var fixture = new PodmanImagePushFixture(PodmanImagePushFixture.PodmanPushEnum.DESTINATION_WITH_OPTION)
        {
            Destination = DESTINATION,
            Settings = new Podman.Commands.Image.Push.PodmanImagePushOptions
            {
                Format = "format-test",
                Retry = 3,
                TlsVerify = true
            }
        };

        var actual = fixture.Run();

        Assert.Equal($"image push --format format-test --retry 3 --tls-verify  {DESTINATION}", actual.Args);
    }        
}
