using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Network.Connect
{
    public class TestNetworkConnectCommand
    {
        private const string NETWORK = "network";
        private const string CONTAINER = "container";

        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanNetworkConnectFixture
            {
                Network = NETWORK,
                Container = CONTAINER
            };

            var actual = fixture.Run();
            Assert.Equal("network connect network container", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanNetworkConnectFixture
            {
                Network = NETWORK,
                Container = CONTAINER,
                Settings = new Podman.Commands.Network.Connect.PodmanNetworkConnectOptions
                {
                    Alias = ["A1", "A2"],
                    Ip= "127.0.0.1"
                }
            };

            var actual = fixture.Run();
            Assert.Equal("network connect --alias A1 --alias A2 --ip 127.0.0.1 network container", actual.Args);
        }
    }
}