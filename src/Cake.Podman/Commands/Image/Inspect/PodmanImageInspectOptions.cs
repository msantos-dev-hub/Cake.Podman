using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Image.Inspect
{
    /// <summary>
    /// Options for Podman Image Inspect command
    /// </summary>
    public sealed class PodmanImageInspectOptions : PodmanOptions
    {
        /// <summary>
        /// Format the output using the given Go template.
        /// </summary>
        [PodmanOption(Name = "format")]
        public string? Format { get; set; }
    }
}