#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Podman.Extensions;
using Cake.Podman.Factory;

namespace Cake.Podman.Aliases
{
    /// <summary>
    /// Alias for working with network create command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run network create command using default options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="name">The network name</param>
        [CakeMethodAlias]
        public static void PodmanNetworkCreate(this ICakeContext context, string? name)
        {
            PodmanNetworkCreate(context, new(), name);
        }

        /// <summary>
        /// Run network create using custom options
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="options">The options</param>
        /// <param name="name">The network name</param>
        [CakeMethodAlias]
        public static void PodmanNetworkCreate(this ICakeContext context, Commands.Network.Create.PodmanNetworkCreateOptions options, string? name)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));

            var gateway = options.Gateway ?? [];
            var ipRange = options.IpRange ?? [];
            var subnet = options.Subnet ?? [];

            if (subnet.Length > gateway.Length)
                Array.Resize(ref gateway, subnet.Length);
            if (subnet.Length > ipRange.Length)
                Array.Resize(ref ipRange, subnet.Length);

            if (gateway.Length > subnet.Length)
                Array.Resize(ref subnet, gateway.Length);
            if (gateway.Length > ipRange.Length)
                Array.Resize(ref ipRange, gateway.Length);

            if (ipRange.Length > subnet.Length)
                Array.Resize(ref subnet, ipRange.Length);
            if (ipRange.Length > gateway.Length)
                Array.Resize(ref gateway, ipRange.Length);

            new PodmanRunnerFactory().CreateRunner<Commands.Network.Create.PodmanNetworkCreateOptions>(context)
                .Run("network create",
                    options ?? new(),
                    new List<string>()
                        .Add<string>(
                            string.Join(" ", 
                                subnet
                                    .Zip(gateway, (sub, gt) => (string.IsNullOrEmpty(sub) ? "" : $"--subnet {sub}") + (string.IsNullOrEmpty(gt) ? "" : $" --gateway {gt}"))
                                    .Zip(ipRange, (gt, ip) => gt + (string.IsNullOrEmpty(ip) ? "" : $" --ip-range {ip}")))
                                    .Trim()
                        )
                        .AddIf<string>(_ => !string.IsNullOrEmpty(name), name!));
        }
    }
}