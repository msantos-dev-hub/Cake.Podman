using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Container.Inspect
{
    public class TestContainerInspectCommand
    {
        private const string CONTAINER = "container";

        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanContainerInspectFixture
            {
                Container = CONTAINER
            };

            var actual = fixture.Run();
            Assert.Equal($"container inspect {CONTAINER}", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanContainerInspectFixture
            {
                Container = CONTAINER,
                Settings = new Podman.Commands.Container.Inspect.PodmanContainerInspectOptions
                {
                    Format = ".Args",
                    Latest = true
                }
            };

            var actual = fixture.Run();
            Assert.Equal($"container inspect --format .Args --lastest  {CONTAINER}", actual.Args);
        }
    }
}