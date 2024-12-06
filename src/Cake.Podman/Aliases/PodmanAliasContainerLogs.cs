using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Podman.Extensions;
using Cake.Podman.Factory;

namespace Cake.Podman.Aliases
{
    /// <summary>
    /// Alias for working with log command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run log command using default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="containers">The name or ID of containers</param>
        /// <returns>The log lines</returns>
        [CakeMethodAlias]
        public static IEnumerable<string> PodmanContainerLogs(this ICakeContext context, params string[] containers)
        {
            return PodmanContainerLogs(context, new(), containers);
        }

        /// <summary>
        /// Run log command using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="containers">The name or ID of containers</param>
        /// <returns>The log lines</returns>
        [CakeMethodAlias]
        public static IEnumerable<string> PodmanContainerLogs(this ICakeContext context, Commands.Container.Logs.PodmanContainerLogOptions options, params string[] containers)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentNullException.ThrowIfNull(containers, nameof(containers));

            return new PodmanRunnerFactory().CreateRunner<Commands.Container.Logs.PodmanContainerLogOptions>(context)
                .RunWithResult("container logs", 
                               options ?? new(),
                               proc => proc.ToArray(),
                               new List<string>()
                                    .AddRange<string>(containers));
        }
    }
}