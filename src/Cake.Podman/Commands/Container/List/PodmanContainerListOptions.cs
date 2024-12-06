using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Container.List
{
    /// <summary>
    /// Options for Podman Container List command
    /// </summary>
    public sealed class PodmanContainerListOptions : PodmanOptions
    {
        /// <summary>
        /// Show all the containers, default is only running containers.
        /// </summary>
        [PodmanOption(Name = "all")]
        public bool? All { get; set; }
        /// <summary>
        /// Display external containers that are not controlled by Podman but are stored in containers storage. 
        /// These external containers are generally created via other container technology such as Buildah or CRI-O and may depend on the same container images that Podman is also using. 
        /// External containers are denoted with either a ‘buildah’ or ‘storage’ in the COMMAND and STATUS column of the ps output.
        /// </summary>
        [PodmanOption(Name = "external")]
        public bool? External { get; set; }
        /// <summary>
        /// Filter what containers are shown in the output. 
        /// Multiple filters can be given with multiple uses of the --filter flag. 
        /// Filters with the same key work inclusive with the only exception being label which is exclusive. 
        /// Filters with different keys always work exclusive.
        /// </summary>
        [PodmanOption(Name = "filter", Quoted = true, Format = FormatType.Multiple)]
        public string[]? Filter { get; set; }
        /// <summary>
        /// Pretty-print containers to JSON or using a Go template
        /// </summary>
        [PodmanOption(Name = "format", Quoted = true)]
        public string? Format { get; set; }
        /// <summary>
        /// Print the n last created containers (all states)
        /// </summary>
        [PodmanOption(Name = "last")]
        public bool? Last { get; set; }
        /// <summary>
        /// Show the latest container created (all states) (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "latest")]
        public bool? Latest { get; set; }
        /// <summary>
        /// Display namespace information
        /// </summary>
        [PodmanOption(Name = "namespace")]
        public bool? Namespace { get; set; }
        /// <summary>
        /// Do not truncate the output (default false).
        /// </summary>
        [PodmanOption(Name = "no-trunc")]
        public bool? NoTrunc { get; set; }
        /// <summary>
        /// Omit the table headings from the listing of containers.
        /// </summary>
        [PodmanOption(Name = "noheading")]
        public bool? Noheading { get; set; }
        /// <summary>
        /// Display the pods the containers are associated with
        /// </summary>
        [PodmanOption(Name = "pod")]
        public bool? Pod { get; set; }
        /// <summary>
        /// Display the total file size
        /// </summary>
        [PodmanOption(Name = "size")]
        public bool? Size { get; set; }
        /// <summary>
        /// Sort by command, created, id, image, names, runningfor, size, or status”, 
        /// Note: Choosing size sorts by size of rootFs, not alphabetically like the rest of the options
        /// </summary>
        [PodmanOption(Name = "sort")]
        public string? Sort { get; set; }
        /// <summary>
        /// Force a sync of container state with the OCI runtime. 
        /// In some cases, a container’s state in the runtime can become out of sync with Podman’s state. 
        /// This updates Podman’s state based on what the OCI runtime reports. 
        /// Forcibly syncing is much slower, but can resolve inconsistent state issues.
        /// </summary>
        [PodmanOption(Name = "sync")]
        public bool? Sync { get; set; }
        /// <summary>
        /// Refresh the output with current containers on an interval in seconds.
        /// </summary>
        [PodmanOption(Name = "watch")]
        public bool? Watch { get; set; }
    }
}