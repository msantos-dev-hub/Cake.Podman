using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Podman.Extensions;
using Cake.Podman.Factory;

namespace Cake.Podman.Aliases
{
    /// <summary>
    /// Alias for working with cp command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run cp command using default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="source">The source path</param>
        /// <param name="destination">The target path</param>
        [CakeMethodAlias]
        public static void PodmanContainerCp(this ICakeContext context, string source, string destination)
        {
            PodmanContainerCp(context, new(), source, destination);
        }

        /// <summary>
        /// Run cp command using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="source">The source path</param>
        /// <param name="destination">The target path</param>
        [CakeMethodAlias]
        public static void PodmanContainerCp(this ICakeContext context, Commands.Container.Cp.PodmanContainerCpOptions options, string source, string destination)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentException.ThrowIfNullOrEmpty(source, nameof(source));
            ArgumentException.ThrowIfNullOrEmpty(destination, nameof(destination));

            new PodmanRunnerFactory().CreateRunner<Commands.Container.Cp.PodmanContainerCpOptions>(context)
                .Run("container cp", 
                     options ?? new(), 
                     new List<string>()
                        .Add<string>(source)
                        .Add<string>(destination));
        }
    }
}