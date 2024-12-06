using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Image.Load
{
    public class TestImageLoadCommand
    {
        [Fact]
        public void Test_Option()
        {
            var fixture = new PodmanImageLoadFixture
            {
                Settings = new Podman.Commands.Image.Load.PodmanImageLoadOptions
                {
                    Input = "https://server.com/archive.tar"
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"image load --input \"https://server.com/archive.tar\"",actual.Args);
        }
    }
}