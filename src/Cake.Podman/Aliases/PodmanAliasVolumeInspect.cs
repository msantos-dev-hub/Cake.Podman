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
    /// Alis for working with volume inspect command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run volume inspect command using default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="volume">The volume name</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static IEnumerable<string> PodmanVolumeInspect(this ICakeContext context, params string[] volume)
        {
            return PodmanVolumeInspect(context, volume);
        }

        /// <summary>
        /// Run voume inspect command using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="volume">The volume name</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static IEnumerable<string> PodmanVolumeInspect(this ICakeContext context, Commands.Volume.Inspect.PodmanVolumeInspectOptions options, params string[] volume)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentNullException.ThrowIfNull(volume, nameof(volume));
            ArgumentOutOfRangeException.ThrowIfEqual(0, volume.Length, nameof(volume));

            return new PodmanRunnerFactory().CreateRunner<Commands.Volume.Inspect.PodmanVolumeInspectOptions>(context)
                .RunWithResult("volume inspect",
                    options ?? new(),
                    proc => proc.ToArray(),
                    new List<string>()
                        .AddRange<string>(volume));
        }
    }
}