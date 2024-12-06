using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Volume.Inspect
{
    /// <summary>
    /// Options for Podman Volume Inspect command
    /// </summary>
    public sealed class PodmanVolumeInspectOptions : PodmanOptions
    {
        /// <summary>
        /// Inspect all volumes.
        /// </summary>
        [PodmanOption(Name = "all")]
        public bool? All { get; set; }
        /// <summary>
        /// Format volume output using Go templa
        /// </summary>
        [PodmanOption(Name = "format")]
        public string? Format { get; set; }
    }
}