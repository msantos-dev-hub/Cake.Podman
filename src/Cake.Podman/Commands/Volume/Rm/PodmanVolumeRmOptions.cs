using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Volume.Rm
{
    /// <summary>
    /// Options for Podman Volume Rm command
    /// </summary>
    public sealed class PodmanVolumeRmOptions : PodmanOptions
    {
        /// <summary>
        /// Remove all volumes.
        /// </summary>
        [PodmanOption(Name = "all")]
        public bool? All { get; set; }
        /// <summary>
        /// Remove a volume by force. 
        /// If it is being used by containers, the containers are removed first.
        /// </summary>
        [PodmanOption(Name = "force")]
        public bool? Force { get; set; }
        /// <summary>
        /// Seconds to wait before forcibly stopping running containers that are using the specified volume. 
        /// The --force option must be specified to use the --time option. 
        /// Use -1 for infinite wait.
        /// </summary>
        [PodmanOption(Name = "time")]
        public int? Time { get; set; }
    }
}