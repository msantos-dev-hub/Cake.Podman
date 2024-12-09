#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Volume.Ls
{
    /// <summary>
    /// Options for Podman Volume Ls command
    /// </summary>
    public sealed class PodmanVolumeLsOptions : PodmanOptions
    {
        /// <summary>
        /// Filter what volumes are shown in the output. 
        /// Multiple filters can be given with multiple uses of the --filter flag.
        /// </summary>
        [PodmanOption(Name = "filter", Format = FormatType.Multiple)]
        public string[]? Filter { get; set; }
        /// <summary>
        /// Format volume output using Go template.
        /// </summary>
        [PodmanOption(Name = "format")]
        public string? Format { get; set; }
        /// <summary>
        /// Omit the table headings from the listing.
        /// </summary>
        [PodmanOption(Name = "no-heading")]
        public bool? NoHeading { get; set; }
        /// <summary>
        /// Print volume output in quiet mode. Only print the volume names.
        /// </summary>
        [PodmanOption(Name = "quiet")]
        public bool? Quiet { get; set; }
    }
}