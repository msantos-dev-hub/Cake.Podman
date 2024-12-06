using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Image.List
{
    public class TestImageListCommand
    {
        private const string IMAGE = "image";

        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanImageListFixture
            {
                Image = IMAGE
            };

            var actual = fixture.Run();
            Assert.Equal($"image list {IMAGE}", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanImageListFixture
            {
                Image = IMAGE,
                Settings = new Podman.Commands.Image.List.PodmanImageListOptions
                {
                    All = true,
                    Filter = ["id=F1", "digest=A123"],
                    Sort = "id"
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"image list --all  --filter id=F1 --filter digest=A123 --sort id {IMAGE}", actual.Args);            
        }
    }
}