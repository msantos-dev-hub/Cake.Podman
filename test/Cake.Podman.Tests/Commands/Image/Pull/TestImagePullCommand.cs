using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Image.Pull
{
    public class TestImagePullCommand
    {
        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanImagePullFixture
            {
                Sources = ["S1", "S2"]
            };

            var actual = fixture.Run();
            Assert.Equal($"image pull S1 S2", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanImagePullFixture
            {
                Sources = ["S1", "S2"],
                Settings = new Podman.Commands.Image.Pull.PodmanImagePullOptions
                {
                    AllTags = true,
                    Arch = "arm",
                    Retry = 2,
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"image pull --all-tags  --arch arm --retry 2 S1 S2", actual.Args);
        }
    }
}