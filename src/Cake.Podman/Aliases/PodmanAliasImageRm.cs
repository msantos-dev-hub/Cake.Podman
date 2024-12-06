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
    /// Alias for working with image rm command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run image rm command with default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="images">The image</param>
        [CakeMethodAlias]
        public static void PodmanImageRm(this ICakeContext context, params string[] images)
        {
            PodmanImageRm(context, new(), images);
        }

        /// <summary>
        /// Run image rm command with custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The optiond</param>
        /// <param name="images">The images</param>
        [CakeMethodAlias]
        public static void PodmanImageRm(this ICakeContext context, Commands.Image.Rm.PodmanImageRmOptions options, params string[] images)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentNullException.ThrowIfNull(images, nameof(images));
            ArgumentOutOfRangeException.ThrowIfEqual(0, images.Length, nameof(images));

            new PodmanRunnerFactory().CreateRunner<Commands.Image.Rm.PodmanImageRmOptions>(context)
                .Run("image rm",
                    options ?? new(),
                    new List<string>()
                        .AddRange<string>(images));
        }
    }
}