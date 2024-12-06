using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Volume.Create
{
    public class TestVolumeCreateCommand
    {
        private const string NAME = "name";

        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanVolumeCreateFixture
            {
                Name = NAME
            };

            var actual = fixture.Run();
            Assert.Equal($"volume create {NAME}", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanVolumeCreateFixture
            {
                Name = NAME,
                Settings = new Podman.Commands.Volume.Create.PodmanVolumeCreateOptions
                {
                    Driver = "image",
                    Label = "mykey=value",
                    Opt = "type"
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"volume create --driver image --label mykey=value --opt type {NAME}", actual.Args);
        }        
    }
}