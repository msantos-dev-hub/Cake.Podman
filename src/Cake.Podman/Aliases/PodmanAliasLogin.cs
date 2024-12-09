#nullable enable
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
    /// Alias for working with login command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run login command using username and password
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <param name="registry">The server</param>
        [CakeMethodAlias]
        public static void PodmanLogin(this ICakeContext context, string username, string password, string? registry = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(username, nameof(username));
            ArgumentException.ThrowIfNullOrEmpty(password, nameof(password));

            PodmanLogin(context, new Commands.Login.PodmanLoginOptions
            {
                Username = username,
                Password = password,
            }, registry);
        }

        /// <summary>
        /// Run login command using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="registry">The server</param>
        [CakeMethodAlias]
        public static void PodmanLogin(this ICakeContext context, Commands.Login.PodmanLoginOptions options, string? registry = null)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentNullException.ThrowIfNull(options, nameof(options));

            new PodmanRunnerFactory().CreateRunner<Commands.Login.PodmanLoginOptions>(context)
                .Run("login",
                     options,
                     new List<string>()
                         .Add<string>(registry));
        }
    }
}