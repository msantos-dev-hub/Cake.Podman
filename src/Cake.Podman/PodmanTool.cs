using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Podman
{
    /// <summary>
    /// Base class for Podeman Tool
    /// </summary>
    /// <typeparam name="TOptions">Settings type</typeparam>
    public abstract class PodmanTool<TOptions> : Tool<TOptions> where TOptions : ToolSettings
    {
        private readonly ICakeEnvironment environment;
        private readonly IFileSystem fileSystem;

        /// <summary>
        /// Initialize a new instence of the <see cref="PodmanTool{TOptions}"/> class
        /// </summary>
        /// <param name="fileSystem">The file system</param>
        /// <param name="environment">The environment</param>
        /// <param name="processRunner">The process runner</param>
        /// <param name="tools">The tool</param>
        protected PodmanTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
            this.fileSystem = fileSystem;
            this.environment = environment;
        }
        /// <summary>
        /// Get the tool names according the platform
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return environment.Platform.IsUnix() ? new List<string>() {"podman", "podman.exe"} : new List<string> {"podman.exe", "podman"};
        }
        /// <summary>
        /// Get the Tool name
        /// </summary>
        /// <returns></returns>
        protected override string GetToolName()
        {
            return "Podman";
        }
    }
}