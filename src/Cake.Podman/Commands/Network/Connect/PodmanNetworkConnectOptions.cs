using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Network.Connect
{
    /// <summary>
    /// Options for Podman Network Connect command
    /// </summary>
    public sealed class PodmanNetworkConnectOptions : PodmanOptions
    {
        /// <summary>
        /// Add network-scoped alias for the container. 
        /// If the network has DNS enabled, these aliases can be used for name resolution on the given network. 
        /// Multiple --alias options may be specified as input.
        /// </summary>
        [PodmanOption(Name = "alias", Format = FormatType.Multiple)]
        public string[]? Alias { get; set; }
        /// <summary>
        /// Set a static ipv4 address for this container on this network.
        /// </summary>
        [PodmanOption(Name = "ip")]
        public string? Ip { get; set; }
        /// <summary>
        /// Set a static ipv6 address for this container on this network.
        /// </summary>
        [PodmanOption(Name = "ip6")]
        public string? Ip6 { get; set; }
        /// <summary>
        /// Set a static mac address for this container on this network.
        /// </summary>
        [PodmanOption(Name = "mac-address")]
        public string? MacAddress { get; set; }
    }
}