using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Network.Rm
{
    /// <summary>
    /// Options for Podman Network Rm command
    /// </summary>
    public sealed class PodmanNetworkRmOptions : PodmanOptions
    {
        /// <summary>
        /// The force option removes all containers that use the named network. 
        /// If the container is running, the container is stopped and removed.
        /// </summary>
        [PodmanOption(Name = "force")]
        public bool? Force { get; set; }
        /// <summary>
        /// Seconds to wait before forcibly stopping the running containers that are using the specified network. 
        /// The --force option must be specified to use the --time option. 
        /// Use -1 for infinite wait.
        /// </summary>
        [PodmanOption(Name = "time")]
        public int? Time { get; set; }
    }
}