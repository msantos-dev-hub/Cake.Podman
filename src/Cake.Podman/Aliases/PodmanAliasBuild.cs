using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cake.Core.Annotations;
using Cake.Core;
using Cake.Podman.Extensions;
using Cake.Podman.Factory;

namespace Cake.Podman.Aliases
{
    /// <summary>
    /// Alias for working with build command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run build command using default options
        /// </summary>
        /// <param name="context">The cake context</param>
        /// <param name="target">The target</param>
        [CakeMethodAlias]
        public static void PodmanBuild(this ICakeContext context, string target)
        {
            PodmanBuild(context, new(), target);
        }
        /// <summary>
        /// Run build command using custom options
        /// </summary>
        /// <param name="context">The cake context</param>
        /// <param name="options">The options</param>
        /// <param name="target">The target</param>
        [CakeMethodAlias]
        public static void PodmanBuild(this ICakeContext context, Commands.Build.PodmanBuildOptions options, string target)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            new PodmanRunnerFactory().CreateRunner<Commands.Build.PodmanBuildOptions>(context)
                .Run("build", 
                     options ?? new(), 
                     new List<string>()
                        .Add<string>(target));
        }
    }
}