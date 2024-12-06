using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Container.Rm
{
    public class TestContainerRmCommand
    {
        private const string CONTAINER = "container";

        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanContainerRmFixture
            {
                Container = CONTAINER,
            };

            var actual = fixture.Run();
            Assert.Equal($"container rm {CONTAINER}", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanContainerRmFixture
            {
                Container = CONTAINER,
                Settings = new Podman.Commands.Container.Rm.PodmanContainerRmOptions
                {
                    All = true,
                    Filter = ["id", "name"],
                    Time = 2
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"container rm --all  --filter id --filter name --time 2 {CONTAINER}", actual.Args);
        }
    }
}