using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Volume.Rm
{
    public class TestVolumeRmCommand
    {
        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanVolumeRmFixture
            {
                Volume = ["V1", "V2"]
            };

            var actual = fixture.Run();
            Assert.Equal("volume rm V1 V2", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanVolumeRmFixture
            {
                Volume = ["V1", "V2"],
                Settings = new Podman.Commands.Volume.Rm.PodmanVolumeRmOptions
                {
                    All = true,
                    Force = true,
                    Time = 2
                }
            };

            var actual = fixture.Run();
            Assert.Equal("volume rm --all  --force  --time 2 V1 V2", actual.Args);            
        }
    }
}