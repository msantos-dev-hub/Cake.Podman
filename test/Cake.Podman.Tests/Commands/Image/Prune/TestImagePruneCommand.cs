using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Cake.Podman.Tests.Commands.Image.Prune
{
    public class TestImagePruneCommand
    {
        [Fact]
        public void Test_Option()
        {
            var fixture = new PodmanImagePruneFixture
            {
                Settings = new Podman.Commands.Image.Prune.PodmanImagePruneOptions
                {
                    All = true,
                    Filter = ["foo=bar", "bif=baz"]
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"image prune --all  --filter foo=bar --filter bif=baz", actual.Args);
        }
    }
}