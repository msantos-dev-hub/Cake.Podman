#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Image.Save
{
    /// <summary>
    /// Options for Podman Image Save command
    /// </summary>
    public sealed class PodmanImageSaveOptions : PodmanOptions
    {
        /// <summary>
        /// Compress tarball image layers when pushing to a directory using the ‘dir’ transport. 
        /// (default is same compression type, compressed or uncompressed, as source)
        /// </summary>
        [PodmanOption(Name = "compress")]
        public bool? Compress { get; set; }
        /// <summary>
        /// An image format to produce
        /// </summary>
        [PodmanOption(Name = "format")]
        public string? Format { get; set; }
        /// <summary>
        /// Allow for creating archives with more than one image. 
        /// Additional names are interpreted as images instead of tags.
        /// </summary>
        [PodmanOption(Name = "multi-image-archive")]
        public bool? MultiImageArchive { get; set; }
        /// <summary>
        /// Write to a file, default is STDOUT
        /// </summary>
        [PodmanOption(Name = "output", Quoted = true)]
        public string? Output { get; set; }
        /// <summary>
        /// Accept uncompressed layers when using one of the OCI formats.
        /// </summary>
        [PodmanOption(Name = "uncompressed")]
        public bool? Uncompressed { get; set; }
    }
}