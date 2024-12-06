using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Network.Rm
{
    public class TestNetworkRmCommand
    {      
        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanNetworkRmFixture
            {
                Network = ["N1", "N2"]
            };

            var actual = fixture.Run();
            Assert.Equal($"network rm N1 N2", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanNetworkRmFixture
            {
                Network = ["N1", "N2"],
                Settings = new Podman.Commands.Network.Rm.PodmanNetworkRmOptions
                {
                    Force = true,
                    Time = 3
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"network rm --force  --time 3 N1 N2", actual.Args);
        }
    }
}