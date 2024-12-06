using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Image.Save
{
    public class TestImageSaveCommand
    {
        private const string NAME = "name";

        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanImageSaveFixture
            {
                Name = NAME
            };

            var actual = fixture.Run();
            Assert.Equal("image save name", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanImageSaveFixture
            {
                Name = NAME,
                Settings = new Podman.Commands.Image.Save.PodmanImageSaveOptions
                {
                    Compress = true,
                    Format = "docker-archive",
                    Output = @"C:\teste.txt"
                }
            };

            var actual = fixture.Run();
            Assert.Equal("image save --compress  --format docker-archive --output \"C:\\teste.txt\" name", actual.Args);
        }
    }
}