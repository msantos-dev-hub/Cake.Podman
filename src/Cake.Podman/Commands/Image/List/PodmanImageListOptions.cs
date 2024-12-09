#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Image.List
{
    /// <summary>
    /// Options for Podman Image list command
    /// </summary>
    public sealed class PodmanImageListOptions : PodmanOptions
    {
        /// <summary>
        /// Show all images (by default filter out the intermediate image layers). 
        /// The default is false.
        /// </summary>
        [PodmanOption(Name = "all")]
        public bool? All { get; set; }
        /// <summary>
        /// Show image digests
        /// </summary>
        [PodmanOption(Name = "digests")]
        public bool? Digests { get; set; }
        /// <summary>
        /// Provide filter values.
        /// </summary>
        [PodmanOption(Name = "filter", Format = FormatType.Multiple)]
        public string[]? Filter { get; set; }
        /// <summary>
        /// Change the default output format. 
        /// This can be of a supported type like ‘json’ or a Go template.
        /// </summary>
        [PodmanOption(Name = "format", Quoted = true)]
        public string? Format { get; set; }
        /// <summary>
        /// Display the history of image names. 
        /// If an image gets re-tagged or untagged, then the image name history gets prepended (latest image first). 
        /// This is especially useful when undoing a tag operation or an image does not contain any name because it has been untagged.
        /// </summary>
        [PodmanOption(Name = "history")]
        public bool? History { get; set; }
        /// <summary>
        /// Do not truncate the output (default false).
        /// </summary>
        [PodmanOption(Name = "no-trunc")]
        public bool? NoTrunc { get; set; }
        /// <summary>
        /// Omit the table headings from the listing.
        /// </summary>
        [PodmanOption(Name = "noheading")]
        public bool? NoHeading { get; set; }
        /// <summary>
        /// Lists only the image IDs.
        /// </summary>
        [PodmanOption(Name = "quiet")]
        public bool? Quiet { get; set; }
        /// <summary>
        /// Sort by created, id, repository, size or tag (default: created) 
        /// When sorting by repository it also sorts by the tag as second criteria to provide a stable output.
        /// </summary>
        [PodmanOption(Name = "sort")]
        public string? Sort { get; set; }
    }
}