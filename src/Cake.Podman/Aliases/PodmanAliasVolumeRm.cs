using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Podman.Commands.Volume.Rm;
using Cake.Podman.Extensions;
using Cake.Podman.Factory;

namespace Cake.Podman.Aliases
{
    /// <summary>
    /// Alias for working with volume rm command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run volume rm command using default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="volume">The volume name</param>
        [CakeMethodAlias]
        public static void PodmanVolumeRm(this ICakeContext context, params string[] volume)
        { 
            PodmanVolumeRm(context, new(), volume);
        }

        /// <summary>
        /// Run volume rm command using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="volume">The volume name</param>
        [CakeMethodAlias]
        public static void PodmanVolumeRm(this ICakeContext context, Commands.Volume.Rm.PodmanVolumeRmOptions options, params string[] volume)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentNullException.ThrowIfNull(volume, nameof(volume));
            ArgumentOutOfRangeException.ThrowIfEqual(0, volume.Length, nameof(volume));

            new PodmanRunnerFactory().CreateRunner<Commands.Volume.Rm.PodmanVolumeRmOptions>(context)
                .Run("volume rm",
                options ?? new(),
                new List<string>()
                    .AddRange<string>(volume));
        }
    }
}