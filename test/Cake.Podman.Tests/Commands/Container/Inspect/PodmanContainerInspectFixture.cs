using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Podman.Aliases;
using Cake.Podman.Commands.Container.Inspect;
using Cake.Podman.Extensions;
using Cake.Testing.Fixtures;

namespace Cake.Podman.Tests.Commands.Container.Inspect
{
    public class PodmanContainerInspectFixture : ToolFixture<PodmanContainerInspectOptions, ToolFixtureResult>, ICakeContext
    {
        public PodmanContainerInspectFixture() : base("podman"){}
        
        public string? Container { get; set; }

        public ICakeLog Log => Log;

        public ICakeArguments Arguments => throw new NotImplementedException();

        public IRegistry Registry => Registry;

        public ICakeDataResolver Data => throw new NotImplementedException();

        IFileSystem ICakeContext.FileSystem => FileSystem;

        ICakeEnvironment ICakeContext.Environment => Environment;

        IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;

        ICakeConfiguration ICakeContext.Configuration => throw new NotImplementedException();

        protected override ToolFixtureResult CreateResult(FilePath path, ProcessSettings process)
        {
            var processArguments = new ProcessArgumentBuilder()
                .Append("container inspect")
                .Append(Settings)
                .Append(new List<string>()
                        .Add<string>(Container!));

            return new ToolFixtureResult("container inspect", new ProcessSettings
            {
                RedirectStandardOutput = true,
                Arguments = processArguments
            });
        }

        protected override void RunTool()
        {
            ProcessRunner.Process.SetStandardOutput([""]);
            this.PodmanContainerInspect(Settings, Container!);
        }
    }
}