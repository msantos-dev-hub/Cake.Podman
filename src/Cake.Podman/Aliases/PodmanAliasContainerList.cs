using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Podman.Factory;

namespace Cake.Podman.Aliases
{
    /// <summary>
    /// Alias for working with container list command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run container list command
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static IEnumerable<string> PodmanContainerList(this ICakeContext context, Commands.Container.List.PodmanContainerListOptions options)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            return new PodmanRunnerFactory().CreateRunner<Commands.Container.List.PodmanContainerListOptions>(context)
                .RunWithResult("container list",
                               options ?? new(),
                               proc => proc.ToArray(),
                               null);
        }
    }
}