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
    /// Alias for working with image tag command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run tag command using default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="image">The image</param>
        /// <param name="targetName">The target name</param>
        [CakeMethodAlias]
        public static void PodmanImageTag(this ICakeContext context, string image, params string[] targetName)
        {
            PodmanImageTag(context, new(), image, targetName);
        }

        /// <summary>
        /// Run tag command using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="image">The image</param>
        /// <param name="targetName">The targetname</param>
        [CakeMethodAlias]
        public static void PodmanImageTag(this ICakeContext context, Commands.Image.Tag.PodmanImageTagOptions options, string image, params string[] targetName)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentException.ThrowIfNullOrEmpty(image, nameof(image));
            ArgumentNullException.ThrowIfNull(targetName, nameof(targetName));

            new PodmanRunnerFactory().CreateRunner<Commands.Image.Tag.PodmanImageTagOptions>(context)
                .Run("image tag",
                     options ?? new(),
                     new List<string>()
                        .Add<string>(image)
                        .AddRange<string>(targetName));
        }
    }
}