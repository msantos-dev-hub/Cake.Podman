#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Container.Rm
{
    /// <summary>
    /// Options for Podmand Container Rm command
    /// </summary>
    public sealed class PodmanContainerRmOptions : PodmanOptions
    {
        /// <summary>
        /// Remove all containers. Can be used in conjunction with -f as well.
        /// </summary>
        [PodmanOption(Name = "all")]
        public bool? All { get; set; }
        /// <summary>
        /// Read container ID from the specified file and rm the container. 
        /// Can be specified multiple times.
        /// </summary>
        [PodmanOption(Name = "cidfile", Quoted = true, Format = FormatType.Multiple)]
        public string[]? CidFile { get; set; }
        /// <summary>
        /// Remove selected container and recursively remove all containers that depend on it.
        /// </summary>
        [PodmanOption(Name = "depend")]
        public bool? Depend { get; set; }
        /// <summary>
        /// Filter what containers remove. 
        /// Multiple filters can be given with multiple uses of the --filter flag. 
        /// Filters with the same key work inclusive with the only exception being label which is exclusive. 
        /// Filters with different keys always work exclusive.
        /// </summary>
        [PodmanOption(Name = "filter", Format = FormatType.Multiple)]
        public string[]? Filter { get; set; }
        /// <summary>
        /// Force the removal of running and paused containers. 
        /// Forcing a container removal also removes containers from container storage even if the container is not known to Podman.
        /// </summary>
        [PodmanOption(Name = "force")]
        public bool? Force { get; set; }
        /// <summary>
        /// Ignore errors when specified containers are not in the container store. 
        /// </summary>
        [PodmanOption(Name = "ignore")]
        public bool? Ignore { get; set; }
        /// <summary>
        /// Instead of providing the container name or ID, use the last created container.
        /// </summary>
        [PodmanOption(Name = "latest")]
        public bool? Latest { get; set; }
        /// <summary>
        /// Seconds to wait before forcibly stopping the container. 
        /// Use -1 for infinite wait.
        /// The --force option must be specified to use the --time option.
        /// </summary>
        [PodmanOption(Name = "time")]
        public int? Time { get; set; }
        /// <summary>
        /// Remove anonymous volumes associated with the container. 
        /// This does not include named volumes created with podman volume create, or the --volume option of podman run and podman create.
        /// </summary>
        [PodmanOption(Name = "volumes")]
        public bool? Volumes { get; set; }
    }
}