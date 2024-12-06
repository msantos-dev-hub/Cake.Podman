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
    /// Alias for working with run command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run container run command with default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="image">The image anem</param>
        /// <param name="command">The command to run</param>
        public static void PodmanContainerRun(this ICakeContext context, string image, string command)
        {
            PodmanContainerRun(context, new(), image, command);
        }

        /// <summary>
        /// Run container run command with custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="image">The image anem</param>
        /// <param name="command">The command to run</param>
        public static void PodmanContainerRun(this ICakeContext context, Commands.Container.Run.PodmanContainerRunOptions options, string image, string command)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentException.ThrowIfNullOrEmpty(image, nameof(image));
            ArgumentException.ThrowIfNullOrEmpty(command, nameof(command));

            new PodmanRunnerFactory().CreateRunner<Commands.Container.Run.PodmanContainerRunOptions>(context)
                .Run("container run",
                    options ?? new(),
                    new List<string>()
                        .Add<string>(image)
                        .Add<string>(command));
        }
    }
}