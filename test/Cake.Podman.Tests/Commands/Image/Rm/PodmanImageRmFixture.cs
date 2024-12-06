using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Podman.Aliases;
using Cake.Podman.Commands.Image.Rm;
using Cake.Testing.Fixtures;

namespace Cake.Podman.Tests.Commands.Image.Rm
{
    public class PodmanImageRmFixture : ToolFixture<PodmanImageRmOptions>, ICakeContext
    {
        public PodmanImageRmFixture() : base("podman"){}

        public string[]? Images { get; set; }

        public ICakeLog Log => Log;

        public ICakeArguments Arguments => throw new NotImplementedException();

        public IRegistry Registry => Registry;

        public ICakeDataResolver Data => throw new NotImplementedException();

        IFileSystem ICakeContext.FileSystem => FileSystem;

        ICakeEnvironment ICakeContext.Environment => Environment;

        IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;

        ICakeConfiguration ICakeContext.Configuration => throw new NotImplementedException();

        protected override void RunTool()
        {
            this.PodmanImageRm(Settings, Images!);
        }
    }
}