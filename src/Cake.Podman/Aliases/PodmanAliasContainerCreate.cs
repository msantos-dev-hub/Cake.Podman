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
    /// Alias for working with create command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run create command using default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="image">The image name</param>
        /// <param name="command">The command</param>
        /// <param name="args">The arguments</param>
        /// <returns>container ID</returns>
        [CakeMethodAlias]
        public static string? PodmanContainerCreate(this ICakeContext context, string image, string command, params string[] args)
        {
            return PodmanContainerCreate(context, new (), image, command, args);
        }

        /// <summary>
        /// Run create command using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="image">The image name</param>
        /// <param name="command">The command</param>
        /// <param name="args">The arguments</param>
        /// <returns>container ID</returns>
        [CakeMethodAlias]
        public static string? PodmanContainerCreate(this ICakeContext context, Commands.Container.Create.PodmanContainerCreateOptions options, string image, string command, params string[] args)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentException.ThrowIfNullOrEmpty(image, nameof(image));

            var pr = new PodmanRunnerFactory().CreateRunner<Commands.Container.Create.PodmanContainerCreateOptions>(context);
            return pr.RunWithResult("container create", 
                               options ?? new Commands.Container.Create.PodmanContainerCreateOptions(), 
                               proc => proc.ToArray(), 
                               new List<string>()
                                .Add<string>(image)
                                .AddIf(_ => !string.IsNullOrEmpty(command), command)
                                .AddRangeIf(_ => !string.IsNullOrEmpty(command) && args.Length > 0, args))
                .FirstOrDefault();

        }
    }
}