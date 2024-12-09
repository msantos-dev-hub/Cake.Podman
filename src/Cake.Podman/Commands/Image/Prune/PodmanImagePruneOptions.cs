#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Image.Prune
{
    /// <summary>
    /// Options for Podman Image Prune command
    /// </summary>
    public sealed class PodmanImagePruneOptions : PodmanOptions
    {
        /// <summary>
        /// Remove dangling images and images that have no associated containers.
        /// </summary>
        [PodmanOption(Name = "all")]
        public bool? All { get; set; }
        /// <summary>
        /// Remove persistent build cache create for --mount=type=cache.
        /// </summary>
        [PodmanOption(Name = "build-cache")]
        public bool? BuildCache { get; set; }
        /// <summary>
        /// Remove images even when they are used by external containers (e.g., build containers).
        /// </summary>
        [PodmanOption(Name = "external")]
        public bool? External { get; set; }
        /// <summary>
        /// The filters argument format is of key=value. 
        /// If there is more than one filter, then pass multiple OPTIONS: --filter foo=bar --filter bif=baz.
        /// </summary>
        [PodmanOption(Name = "filter", Format = FormatType.Multiple)]
        public string[]? Filter { get; set; }
    }
}