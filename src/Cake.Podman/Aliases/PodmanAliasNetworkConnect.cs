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
    /// Alias for working with connect command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run network connect command using default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="network">The network name</param>
        /// <param name="container">The container name</param>
        [CakeMethodAlias]
        public static void PodmanNetworkConnect(this ICakeContext context, string network, string container)
        {
            PodmanNetworkConnect(context, new(), network, container);
        }

        /// <summary>
        /// Run network connect command using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="network">The network name</param>
        /// <param name="container">The container name</param>
        [CakeMethodAlias]
        public static void PodmanNetworkConnect(this ICakeContext context, Commands.Network.Connect.PodmanNetworkConnectOptions options, string network, string container)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentException.ThrowIfNullOrEmpty(network, nameof(network));
            ArgumentException.ThrowIfNullOrEmpty(container, nameof(container));
            
            new PodmanRunnerFactory().CreateRunner<Commands.Network.Connect.PodmanNetworkConnectOptions>(context)
                .Run("network connect",
                    options ?? new(),
                    new List<string>()
                        .Add<string>(network)
                        .Add<string>(container));
        }
    }
}