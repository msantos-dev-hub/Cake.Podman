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
    /// Alias for working with inspect command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run inspect command using default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="image">The image name</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static IEnumerable<string> PodmanImageInspect(this ICakeContext context, string image)
        {
            return PodmanImageInspect(context, new(), image);
        }

        /// <summary>
        /// Run inspect command using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="image">The image name</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static IEnumerable<string> PodmanImageInspect(this ICakeContext context, Commands.Image.Inspect.PodmanImageInspectOptions options, string image)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentException.ThrowIfNullOrEmpty(image, nameof(image));            
            return new PodmanRunnerFactory().CreateRunner<Commands.Image.Inspect.PodmanImageInspectOptions>(context)
                .RunWithResult("image inspect",
                                options ?? new(),
                                proc => proc.ToArray(),
                                new List<string>()
                                    .Add<string>(image));
        }
    }
}