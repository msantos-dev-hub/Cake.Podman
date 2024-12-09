#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Podman.Extensions;

namespace Cake.Podman
{
    /// <summary>
    /// A class to run the podman commands
    /// </summary>
    /// <typeparam name="TOptions">The command options</typeparam>
    public class PodmanRunner<TOptions> : PodmanTool<TOptions>, IRunner<TOptions> where TOptions : PodmanOptions, new()
    {
        /// <summary>
        /// Initialize an instance for the runner
        /// </summary>
        /// <param name="fileSystem">The file system</param>
        /// <param name="environment">The environment</param>
        /// <param name="processRunner">The process runner</param>
        /// <param name="tools">The tool</param>
        public PodmanRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) : base(fileSystem, environment, processRunner, tools)
        {
        }
        /// <summary>
        /// Run the command
        /// </summary>
        /// <param name="command">The command</param>
        /// <param name="options">The custom options</param>
        /// <param name="arguments">The additional parameter</param>
        public void Run(string command, TOptions options, IEnumerable<string>? arguments)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(command, nameof(command));
            ArgumentNullException.ThrowIfNull(options, nameof(options));

            Run(options, PodmanRunner<TOptions>.GetArguments(command, options, arguments));
        }

        private static ProcessArgumentBuilder GetArguments(string command, TOptions options, IEnumerable<string>? arguments)
        {
            return arguments == null 
                ? new ProcessArgumentBuilder()
                    .Append(command)
                    .Append(options)
                : new ProcessArgumentBuilder()
                    .Append(command)
                    .Append(options)
                    .Append(arguments);
        }

        /// <summary>
        /// Runs a command and returns a result
        /// </summary>
        /// <typeparam name="T">The type of the command</typeparam>
        /// <param name="command">The command</param>
        /// <param name="options">The settings</param>
        /// <param name="processOutput">The process output</param>
        /// <param name="arguments">The arguments</param>
        /// <returns></returns>
        public T[] RunWithResult<T>(string command, TOptions options, Func<IEnumerable<string>, T[]> processOutput, IEnumerable<string>? arguments)
        {
            ArgumentException.ThrowIfNullOrEmpty(command, nameof(command));
            ArgumentNullException.ThrowIfNull(options, nameof(options));
            ArgumentNullException.ThrowIfNull(processOutput, nameof(processOutput));

            T[] result = Array.Empty<T>();
            Run(options, PodmanRunner<TOptions>.GetArguments(command, options, arguments),
            new ProcessSettings
            {
                RedirectStandardOutput = false
            },
            process => result = processOutput(process.GetStandardOutput()));
            return result;
        }
    }
}