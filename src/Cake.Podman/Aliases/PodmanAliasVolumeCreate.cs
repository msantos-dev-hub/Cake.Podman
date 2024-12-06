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
    /// Alias for working with volume create command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run volume create command with default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="name">The volume name</param>
        [CakeMethodAlias]
        public static void PodmanVolumeCreate(this ICakeContext context, string name)
        {
            PodmanVolumeCreate(context, name);
        }

        /// <summary>
        /// Run volume create command with custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="name">The volume name</param>
        [CakeMethodAlias]
        public static void PodmanVolumeCreate(this ICakeContext context, Commands.Volume.Create.PodmanVolumeCreateOptions options, string name)
        {
             ArgumentNullException.ThrowIfNull(context, nameof(context));
             ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

             new PodmanRunnerFactory().CreateRunner<Commands.Volume.Create.PodmanVolumeCreateOptions>(context)
                .Run("volume create",
                    options ?? new(),
                    new List<string>()
                        .Add<string>(name));
        }
    }
}