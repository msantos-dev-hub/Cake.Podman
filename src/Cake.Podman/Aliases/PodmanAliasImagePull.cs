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
    /// Alias for working with image pull command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run image pull command with default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="sources">The sources</param>
        [CakeMethodAlias]
        public static void PodmanImagePull(this ICakeContext context, params string[] sources)
        {
            PodmanImagePull(context, new(), sources);
        }

        /// <summary>
        /// Run image pull command with custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="sources">The sources</param>
        [CakeMethodAlias]
        public static void PodmanImagePull(this ICakeContext context, Commands.Image.Pull.PodmanImagePullOptions options, params string[] sources)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentNullException.ThrowIfNull(sources, nameof(sources));
            ArgumentOutOfRangeException.ThrowIfEqual(0, sources.Length, nameof(sources));

            new PodmanRunnerFactory().CreateRunner<Commands.Image.Pull.PodmanImagePullOptions>(context)
                .Run("image pull",
                    options ?? new(),
                    new List<string>()
                        .AddRange<string>(sources));
        }
    }
}