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
    /// Alias for working with image save command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run image save command with default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="name">The name</param>
        [CakeMethodAlias]
        public static void PodmanImageSave(this ICakeContext context, string name)
        {
            PodmanImageSave(context, name);
        }

        /// <summary>
        /// Run image save command with custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="name">The name</param>
        [CakeMethodAlias]
        public static void PodmanImageSave(this ICakeContext context, Commands.Image.Save.PodmanImageSaveOptions options, string name)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

            new PodmanRunnerFactory().CreateRunner<Commands.Image.Save.PodmanImageSaveOptions>(context)
                .Run("image save",
                    options ?? new(),
                    new List<string>()
                        .Add<string>(name));
        }
    }
}