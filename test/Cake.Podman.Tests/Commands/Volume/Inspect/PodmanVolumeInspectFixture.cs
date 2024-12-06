using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Podman.Aliases;
using Cake.Podman.Commands.Volume.Inspect;
using Cake.Podman.Extensions;
using Cake.Testing.Fixtures;

namespace Cake.Podman.Tests.Commands.Volume.Inspect
{
    public class PodmanVolumeInspectFixture : ToolFixture<PodmanVolumeInspectOptions, ToolFixtureResult>, ICakeContext
    {
        public PodmanVolumeInspectFixture() : base("podman") {}

        public string[]? Volume { get; set; }

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
                .Append("volume inspect")
                .Append(Settings)
                .Append(new List<string>()
                    .AddRange<string>(Volume!));

            return new ToolFixtureResult("volume inspect", new ProcessSettings
            {
                RedirectStandardOutput = true,
                Arguments = processArguments
            });
        }

        protected override void RunTool()
        {
            ProcessRunner.Process.SetStandardOutput([""]);
            this.PodmanVolumeInspect(Settings, Volume!);
        }
    }
}