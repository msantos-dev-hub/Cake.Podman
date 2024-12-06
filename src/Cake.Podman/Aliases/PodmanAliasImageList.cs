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
    /// Alias for working with list command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run image list command with default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="image">The image name</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static IEnumerable<string> PodmanImageList(this ICakeContext context, string image)
        {
            return PodmanImageList(context, new(), image);
        }

        /// <summary>
        /// Run image list command wiht custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="image">The image name</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static IEnumerable<string> PodmanImageList(this ICakeContext context, Commands.Image.List.PodmanImageListOptions options, string image)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentException.ThrowIfNullOrEmpty(image, nameof(image));
            return new PodmanRunnerFactory().CreateRunner<Commands.Image.List.PodmanImageListOptions>(context)
                .RunWithResult("image list",
                                options ?? new(),
                                proc => proc.ToArray(),
                                new List<string>()
                                    .Add<string>(image));
        }
    }
}