using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Podman.Commands.Container.Inspect;
using Cake.Podman.Extensions;
using Cake.Podman.Factory;

namespace Cake.Podman.Aliases
{
    /// <summary>
    /// Alias for working with container inspect command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run container inspect command with default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="container">The container name or ID</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static IEnumerable<string> PodmanContainerInspect(this ICakeContext context, string container)
        {
            return PodmanContainerInspect(context, new(), container);
        }

        /// <summary>
        /// Run container inspect command with custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The optons</param>
        /// <param name="container">The container name or ID</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static IEnumerable<string> PodmanContainerInspect(this ICakeContext context, PodmanContainerInspectOptions options, string container)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentException.ThrowIfNullOrEmpty(container, nameof(container));
            return new PodmanRunnerFactory().CreateRunner<Commands.Container.Inspect.PodmanContainerInspectOptions>(context)
                .RunWithResult("container inspect",
                                options ?? new(),
                                proc => proc.ToArray(),
                                new List<string>()
                                    .Add<string>(container));
        }
    }
}