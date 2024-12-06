using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Tests.Commands.Container.Run
{
    public class TestContainerRunCommand
    {
        private const string IMAGE = "image";
        private const string COMMAND = "command";

        [Fact]
        public void Test_Argument()
        {
            var fixture = new PodmanContainerRunFixture
            {
                Image = IMAGE,
                Command = COMMAND
            };

            var actual = fixture.Run();
            Assert.Equal($"container run {IMAGE} {COMMAND}", actual.Args);
        }

        [Fact]
        public void Test_Option_With_Argument()
        {
            var fixture = new PodmanContainerRunFixture
            {
                Image = IMAGE,
                Command = COMMAND,
                Settings = new Podman.Commands.Container.Run.PodmanContainerRunOptions
                {
                    Env = ["E1", "E2"],
                    User = "TstUser",
                    Timeout = 30
                }
            };

            var actual = fixture.Run();            
            Assert.Equal($"container run --env E1 --env E2 --timeout 30 --user TstUser {IMAGE} {COMMAND}", actual.Args);
        }
    }
}