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
    /// Alias for working with container exec command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run container exec command using default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="container">The container name or ID</param>
        /// <param name="command">The command to exec</param>
        /// <param name="args">The arguments</param>
        [CakeMethodAlias]
        public static void PodmanContainerExec(this ICakeContext context, string container, string command, params string[] args)
        {
            PodmanContainerExec(context, new(), container, command, args);
        }

        /// <summary>
        /// Run container exec command using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="container">The container name or ID</param>
        /// <param name="command">The command</param>
        /// <param name="args">The args</param>
        [CakeMethodAlias]
        public static void PodmanContainerExec(this ICakeContext context, Commands.Container.Exec.PodmanContainerExecOptions options, string container, string command, params string[] args)
        {
             ArgumentNullException.ThrowIfNull(context, nameof(context));
             ArgumentException.ThrowIfNullOrEmpty(container, nameof(container));
             ArgumentException.ThrowIfNullOrEmpty(command, nameof(command));
             ArgumentOutOfRangeException.ThrowIfEqual(0, args.Length, nameof(args));

             new PodmanRunnerFactory().CreateRunner<Commands.Container.Exec.PodmanContainerExecOptions>(context)
                .Run("container exec", 
                     options ?? new(), 
                     new List<string>()
                        .Add<string>(container)
                        .Add<string>(command)
                        .AddRange<string>(args));
        }
    }
}