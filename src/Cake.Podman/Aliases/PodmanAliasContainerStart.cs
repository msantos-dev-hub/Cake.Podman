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
    /// 
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run start command using default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="container">The container name or ID</param>
        [CakeMethodAlias]
        public static void PodmanContainerStart(this ICakeContext context, string container)
        {
            PodmanContainerStart(context, new(), container);
        }

        /// <summary>
        /// Run start command using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="container">The container name or ID</param>
        [CakeMethodAlias]
        public static void PodmanContainerStart(this ICakeContext context, Commands.Container.Start.PodmanContainerStartOptions options, string container)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentNullException.ThrowIfNullOrEmpty(container, nameof(container));

            new PodmanRunnerFactory().CreateRunner<Commands.Container.Start.PodmanContainerStartOptions>(context)
                .Run("container start",
                     options ?? new(),
                     new List<string>()
                         .Add<string>(container));
        }
    }
}