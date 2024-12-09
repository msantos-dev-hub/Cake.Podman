#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Container.Start
{
    /// <summary>
    /// Options for Podman Container Start command
    /// </summary>
    public sealed class PodmanContainerStartOptions : PodmanOptions
    {
        /// <summary>
        /// Start all the containers, default is only running containers.
        /// </summary>
        [PodmanOption(Name = "all")]
        public bool? All { get; set; }
        /// <summary>
        /// Attach container’s STDOUT and STDERR. The default is false. 
        /// This option cannot be used when starting multiple containers.
        /// </summary>
        [PodmanOption(Name = "attach")]
        public bool? Attach { get; set; }
        /// <summary>
        /// Specify the key sequence for detaching a container. 
        /// Format is a single character [a-Z] or one or more ctrl-(value) characters where (value) is one of: a-z, @, ^, [, , or _. 
        /// Specifying “” disables this feature. 
        /// The default is ctrl-p,ctrl-q.
        /// </summary>
        [PodmanOption(Name = "detach-keys")]
        public string? DetachKeys { get; set; }
        /// <summary>
        /// Filter what containers are going to be started from the given arguments. 
        /// Multiple filters can be given with multiple uses of the --filter flag. 
        /// Filters with the same key work inclusive with the only exception being label which is exclusive. 
        /// Filters with different keys always work exclusive.
        /// </summary>
        [PodmanOption(Name = "filter", Format = FormatType.Multiple)]
        public string[]? Filter { get; set; }
        /// <summary>
        /// Instead of providing the container name or ID, use the last created container. 
        /// Note: the last started container can be from other users of Podman on the host machine. 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "latest")]
        public bool? Latest { get; set; }
        /// <summary>
        /// Proxy received signals to the container process. SIGCHLD, SIGURG, SIGSTOP, and SIGKILL are not proxied.
        /// The default is true when attaching, false otherwise.
        /// </summary>
        [PodmanOption(Name = "sig-proxy")]
        public bool? SigProxy { get; set; }
    }
}