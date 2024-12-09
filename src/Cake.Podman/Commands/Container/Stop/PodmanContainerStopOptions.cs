#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Container.Stop
{
    /// <summary>
    /// Options for Podman Container Stop command
    /// </summary>
    public sealed class PodmanContainerStopOptions : PodmanOptions
    {
        /// <summary>
        /// Stop all running containers. 
        /// This does not include paused containers.
        /// </summary>
        [PodmanOption(Name = "all")]
        public bool? All { get; set; }
        /// <summary>
        /// Read container ID from the specified file and stop the container. 
        /// Can be specified multiple times.
        /// </summary>
        [PodmanOption(Name = "cidfile")]
        public string? Cidfile { get; set; }
        /// <summary>
        /// Filter what containers are going to be stopped. 
        /// Multiple filters can be given with multiple uses of the --filter flag. 
        /// Filters with the same key work inclusive with the only exception being label which is exclusive. 
        /// Filters with different keys always work exclusive.
        /// </summary>
        [PodmanOption(Name = "filter", Format = FormatType.Multiple)]
        public string[]? Filter { get; set; }
        /// <summary>
        /// Ignore errors when specified containers are not in the container store. 
        /// A user might have decided to manually remove a container which leads to a failure during the ExecStop directive of a systemd service referencing that container.
        /// </summary>
        [PodmanOption(Name = "ignore")]
        public bool? Ignore { get; set; }
        /// <summary>
        /// Instead of providing the container name or ID, use the last created container. 
        /// Note: the last started container can be from other users of Podman on the host machine. 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "latest")]
        public bool? Latest { get; set; }
        /// <summary>
        /// Seconds to wait before forcibly stopping the container. 
        /// Use -1 for infinite wait.
        /// </summary>
        [PodmanOption(Name = "time")]
        public int? Time { get; set; }
    }
}