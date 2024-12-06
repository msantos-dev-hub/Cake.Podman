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
    /// Alias for working with image prune command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run image prune command
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        [CakeMethodAlias]
        public static void PodmanImagePrune(this ICakeContext context, Commands.Image.Prune.PodmanImagePruneOptions options)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            new PodmanRunnerFactory().CreateRunner<Commands.Image.Prune.PodmanImagePruneOptions>(context)
                .Run("image prune",
                    options ?? new(),
                    null!);
        }
    }
}