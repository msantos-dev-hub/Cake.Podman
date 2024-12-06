using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Volume.Inspect
{
    public class TestVolumeInspectCommand
    {
        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanVolumeInspectFixture
            {
                Volume = ["V1", "V2"]
            };

            var actual = fixture.Run();
            Assert.Equal($"volume inspect V1 V2", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanVolumeInspectFixture
            {
                Volume = ["V1", "V2"],
                Settings = new Podman.Commands.Volume.Inspect.PodmanVolumeInspectOptions
                {
                    All = true,
                    Format = ".Driver"
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"volume inspect --all  --format .Driver V1 V2", actual.Args);
        }
    }
}