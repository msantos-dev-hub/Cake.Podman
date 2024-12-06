using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Image.Load
{
    /// <summary>
    /// Options for Podman Image Load command
    /// </summary>
    public sealed class PodmanImageLoadOptions : PodmanOptions
    {
        /// <summary>
        /// Load the specified input file instead of from stdin. 
        /// The file can be on the local file system or on a server (e.g., https://server.com/archive.tar). 
        /// Also supports loading in compressed files.
        /// </summary>
        [PodmanOption(Name = "input", Quoted = true)]
        public string? Input { get; set; }
        /// <summary>
        /// Suppress the progress output
        /// </summary>
        [PodmanOption(Name = "quiet")]
        public bool? Quiet { get; set; }
    }
}