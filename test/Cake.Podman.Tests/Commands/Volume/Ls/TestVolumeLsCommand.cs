using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Volume.Ls
{
    public class TestVolumeLsCommand
    {
        [Fact]
        public void Test_Options()
        {
            var fixture = new PodmanVolumeLsFixture
            {
                Settings = new Podman.Commands.Volume.Ls.PodmanVolumeLsOptions
                {
                    Filter = ["dangling", "driver"],
                    Format = ".GID"
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"volume ls --filter dangling --filter driver --format .GID", actual.Args);
        }
    }
}