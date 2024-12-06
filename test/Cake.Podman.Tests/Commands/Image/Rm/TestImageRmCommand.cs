using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Image.Rm
{
    public class TestImageRmCommand
    {
        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanImageRmFixture
            {
                Images = ["I1", "I2"]
            };

            var actual = fixture.Run();
            Assert.Equal("image rm I1 I2", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanImageRmFixture
            {
                Images = ["I1", "I2"],
                Settings = new Podman.Commands.Image.Rm.PodmanImageRmOptions
                {
                    All = true
                }
            };

            var actual = fixture.Run();
            Assert.Equal("image rm --all  I1 I2", actual.Args);            
        }
    }
}