using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Network.Create
{
    public class TestNetworkCreateCommand
    {
        private const string NAME = "name";

        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanNetworkCreateFixture
            {
                Name = NAME
            };

            var actual = fixture.Run();
            Assert.Equal($"network create  {NAME}", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanNetworkCreateFixture
            {
                Name = NAME,
                Settings = new Podman.Commands.Network.Create.PodmanNetworkCreateOptions
                {
                    DisableDns = true,
                    Driver = "bridge",
                    Opt = "mtu"
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"network create --disable-dns  --driver bridge --opt mtu  {NAME}", actual.Args);
        }

        [Fact]
        public void Test_Gateway_Option_Order_With_Argument()
        {
            var fixture = new PodmanNetworkCreateFixture
            {
                Name = NAME,
                Settings = new Podman.Commands.Network.Create.PodmanNetworkCreateOptions
                {
                    Gateway = ["G1"]
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"network create --gateway G1 {NAME}", actual.Args);
        }

        [Fact]
        public void Test_Subnet_Option_Order_With_Argument()
        {
            var fixture = new PodmanNetworkCreateFixture
            {
                Name = NAME,
                Settings = new Podman.Commands.Network.Create.PodmanNetworkCreateOptions
                {
                    Subnet = ["S1"]
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"network create --subnet S1 {NAME}", actual.Args);
        }

        [Fact]
        public void Test_IpRange_Option_Order_With_Argument()
        {
            var fixture = new PodmanNetworkCreateFixture
            {
                Name = NAME,
                Settings = new Podman.Commands.Network.Create.PodmanNetworkCreateOptions
                {
                    IpRange = ["I1"]
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"network create --ip-range I1 {NAME}", actual.Args);
        }

        [Fact]
        public void Test_Gateway_Subnet_IpRange_Option_Order_With_Argument()
        {
            var fixture = new PodmanNetworkCreateFixture
            {
                Name = NAME,
                Settings = new Podman.Commands.Network.Create.PodmanNetworkCreateOptions
                {
                    Gateway = ["G1"],
                    IpRange = ["I1"],
                    Subnet = ["S1"]
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"network create --subnet S1 --gateway G1 --ip-range I1 {NAME}", actual.Args);
        }        
    }
}