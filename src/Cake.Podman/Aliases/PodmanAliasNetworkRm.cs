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
    /// Alias for working with network rm command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run network rm command using default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="network">The network name</param>
        [CakeMethodAlias]
        public static void PodmanNetworkRm(this ICakeContext context, params string[] network)
        {
            PodmanNetworkRm(context, new(), network);
        }

        /// <summary>
        /// Run network commando using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="network">The network name</param>
        [CakeMethodAlias]
        public static void PodmanNetworkRm(this ICakeContext context, Commands.Network.Rm.PodmanNetworkRmOptions options, params string[] network)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentNullException.ThrowIfNull(network, nameof(network));
            ArgumentOutOfRangeException.ThrowIfEqual(0, network.Length, nameof(network));

            new PodmanRunnerFactory().CreateRunner<Commands.Network.Rm.PodmanNetworkRmOptions>(context)
                .Run("network rm",
                options ?? new(),
                new List<string>()
                    .AddRange<string>(network));
        }
    }
}