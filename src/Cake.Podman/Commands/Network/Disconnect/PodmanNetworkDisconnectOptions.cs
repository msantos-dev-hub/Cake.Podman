using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Network.Disconnect
{
    /// <summary>
    /// Options for Podman Network Disconnect command
    /// </summary>
    public sealed class PodmanNetworkDisconnectOptions : PodmanOptions
    {
        /// <summary>
        /// Force the container to disconnect from a network
        /// </summary>
        [PodmanOption(Name = "force")]
        public bool? Force { get; set; }
    }
}