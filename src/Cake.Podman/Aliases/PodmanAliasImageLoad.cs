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
    /// Alias for working with image load command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run load command
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        [CakeMethodAlias]
        public static void PodmanImageLoad(this ICakeContext context, Commands.Image.Load.PodmanImageLoadOptions options)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            new PodmanRunnerFactory().CreateRunner<Commands.Image.Load.PodmanImageLoadOptions>(context)
                .Run("image load",
                    options ?? new(),
                    null!);
        }
    }
}