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
    /// Alais for working with network disconnect command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run network disconnect command with default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="network">The network name</param>
        /// <param name="container">The container name</param>
        [CakeMethodAlias]
        public static void PodmanNetworkDisconnect(this ICakeContext context, string network, string container)
        {
            PodmanNetworkDisconnect(context, new(), network, container);
        }

        /// <summary>
        /// Run network disconnect command with custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="network">The network name</param>
        /// <param name="container">The container name</param>
        [CakeMethodAlias]
        public static void PodmanNetworkDisconnect(this ICakeContext context, Commands.Network.Disconnect.PodmanNetworkDisconnectOptions options, string network, string container)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentException.ThrowIfNullOrEmpty(network, nameof(network));
            ArgumentException.ThrowIfNullOrEmpty(container, nameof(container));

            new PodmanRunnerFactory().CreateRunner<Commands.Network.Disconnect.PodmanNetworkDisconnectOptions>(context)
                .Run("network disconnect",
                    options ?? new(),
                    new List<string>()
                        .Add<string>(network)
                        .Add<string>(container));
        }
    }
}