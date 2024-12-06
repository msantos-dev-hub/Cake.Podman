using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Network.Disconnect
{
    public class TestNetworkDisconnectCommand
    {
        private const string NETWORK = "network";
        private const string CONTAINER = "container";
        
        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanNetworkDisconnectFixture
            {
                Network = NETWORK,
                Container = CONTAINER
            };

            var actual = fixture.Run();
            Assert.Equal($"network disconnect {NETWORK} {CONTAINER}", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanNetworkDisconnectFixture
            {
                Network = NETWORK,
                Container = CONTAINER,
                Settings = new Podman.Commands.Network.Disconnect.PodmanNetworkDisconnectOptions
                {
                    Force = true
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"network disconnect --force  {NETWORK} {CONTAINER}", actual.Args);
        }
    }
}