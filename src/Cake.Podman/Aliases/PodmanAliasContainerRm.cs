using Cake.Core;
using Cake.Core.Annotations;
using Cake.Podman.Extensions;
using Cake.Podman.Factory;

namespace Cake.Podman.Aliases
{
    /// <summary>
    /// Alias for working with container rm command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run rm command using default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="container">The container name or ID</param>
        [CakeMethodAlias]
        public static void PodmanContainerRm(this ICakeContext context, string container)
        {
            PodmanContainerRm(context, new(), container);
        }

        /// <summary>
        /// Run rm command using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="container">The container name or ID</param>
        [CakeMethodAlias]
        public static void PodmanContainerRm(this ICakeContext context, Commands.Container.Rm.PodmanContainerRmOptions options, string container)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentException.ThrowIfNullOrEmpty(container, nameof(container));
            new PodmanRunnerFactory().CreateRunner<Commands.Container.Rm.PodmanContainerRmOptions>(context)
                .Run("container rm",
                    options ?? new(),
                    new List<string>()
                        .Add<string>(container));
        }

    }
}