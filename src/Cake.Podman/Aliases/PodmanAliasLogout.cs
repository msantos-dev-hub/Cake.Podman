#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Podman.Extensions;
using Cake.Podman.Factory;

namespace Cake.Podman.Aliases
{
    /// <summary>
    /// Alias for working with logout command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run logout command using default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="registry">The server</param>
        public static void PodmanLogout(this ICakeContext context, string? registry = null)
        {
            PodmanLogout(context, new(), registry);
        }

        /// <summary>
        /// Run logout command using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="registry">The server</param>
        public static void PodmanLogout(this ICakeContext context, Commands.Logout.PodmanLogoutOptions options, string? registry = null)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            new PodmanRunnerFactory().CreateRunner<Commands.Logout.PodmanLogoutOptions>(context)
                .Run("logout",
                     options ?? new(),
                     new List<string>()
                        .Add<string>(registry));
        }
    }
}