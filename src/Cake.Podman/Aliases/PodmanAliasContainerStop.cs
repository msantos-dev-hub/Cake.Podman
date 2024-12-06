using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Podman.Commands.Container.Stop;
using Cake.Podman.Extensions;
using Cake.Podman.Factory;

namespace Cake.Podman.Aliases
{
    /// <summary>
    /// Alias for working with stop command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run stop command using default options
        /// </summary>
        /// <param name="context"></param>
        /// <param name="container"></param>
        [CakeMethodAlias]
        public static void PodmanContainerStop(this ICakeContext context, string container) 
        {
            PodmanContainerStop(context, new PodmanContainerStopOptions(), container);
        }

        /// <summary>
        /// Run stop command using custom options
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        /// <param name="container"></param>
        [CakeMethodAlias]
        public static void PodmanContainerStop(this ICakeContext context, Commands.Container.Stop.PodmanContainerStopOptions options, string container)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentException.ThrowIfNullOrEmpty(container, nameof(container));

            new PodmanRunnerFactory().CreateRunner<Commands.Container.Stop.PodmanContainerStopOptions>(context)
                .Run("container stop",
                     options ?? new(),
                     new List<string>()
                         .Add<string>(container));
        }
    }
}