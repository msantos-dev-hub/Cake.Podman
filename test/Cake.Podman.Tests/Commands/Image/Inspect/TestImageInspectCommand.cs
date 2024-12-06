using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Image.Inspect
{
    public class TestImageInspectCommand
    {
        private const string IMAGE = "image";

        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanImageInspectFixture
            {
                Image = IMAGE
            };

            var actual = fixture.Run();
            Assert.Equal($"image inspect {IMAGE}", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanImageInspectFixture
            {
                Image = IMAGE,
                Settings = new Podman.Commands.Image.Inspect.PodmanImageInspectOptions
                {
                    Format = ".Args",
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"image inspect --format .Args {IMAGE}", actual.Args);            
        }
    }
}