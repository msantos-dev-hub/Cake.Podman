using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Container.Cp
{
    /// <summary>
    /// Options for Podman Container Copy command
    /// </summary>
    public sealed class PodmanContainerCpOptions : PodmanOptions
    {
        /// <summary>
        /// Archive mode (copy all UID/GID information). 
        /// When set to true, files copied to a container have changed ownership to the primary UID/GID of the container. 
        /// When set to false, maintain UID/GID from archive sources instead of changing them to the primary UID/GID of the destination container. 
        /// The default is true.
        /// </summary>
        [PodmanOption(Name = "archive")]
        public bool? Archive { get; set; }
        /// <summary>
        /// Allow directories to be overwritten with non-directories and vice versa. 
        /// By default, podman cp errors out when attempting to overwrite, for instance, a regular file with a directory.
        /// </summary>
        [PodmanOption(Name = "overwrite")]
        public bool? Overwrite { get; set; }
    }
}