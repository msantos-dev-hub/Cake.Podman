using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Podman.Aliases;
using Cake.Podman.Commands.Volume.Ls;
using Cake.Podman.Extensions;
using Cake.Testing.Fixtures;

namespace Cake.Podman.Tests.Commands.Volume.Ls
{
    public class PodmanVolumeLsFixture : ToolFixture<PodmanVolumeLsOptions, ToolFixtureResult>, ICakeContext
    {
        public PodmanVolumeLsFixture() : base("podman") {}
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
                .Append("volume ls")
                .Append(Settings);

            return new ToolFixtureResult("volume ls", new ProcessSettings
            {
                RedirectStandardOutput = true,
                Arguments = processArguments
            });
        }

        protected override void RunTool()
        {
            ProcessRunner.Process.SetStandardOutput([""]);
            this.PodmanVolumeList(Settings);
        }
    }
}