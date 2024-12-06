using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Volume.Create
{
    /// <summary>
    /// Optinos for Podman Volume Create command
    /// </summary>
    public sealed class PodmanVolumeCreateOptions : PodmanOptions
    {
        /// <summary>
        /// Specify the volume driver name (default local). 
        /// There are two drivers supported by Podman itself: local and image.
        /// </summary>
        [PodmanOption(Name = "driver")]
        public string? Driver { get; set; }
        /// <summary>
        /// Don’t fail if the named volume already exists, instead just print the name. 
        /// Note that the new options are not applied to the existing volume.
        /// </summary>
        [PodmanOption(Name = "ignore")]
        public bool? Ignore { get; set; }
        /// <summary>
        /// Set metadata for a volume (e.g., --label mykey=value).
        /// </summary>
        [PodmanOption(Name = "label")]
        public string? Label { get; set; }
        /// <summary>
        /// Set driver specific options. 
        /// For the default driver, local, this allows a volume to be configured to mount a filesystem on the host.
        /// </summary>
        [PodmanOption(Name = "opt")]
        public string? Opt { get; set; }
    }
}