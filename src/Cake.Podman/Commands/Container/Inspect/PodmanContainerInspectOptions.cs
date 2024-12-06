using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Container.Inspect
{
    /// <summary>
    /// Options for Podman Container Inspect command
    /// </summary>
    public sealed class PodmanContainerInspectOptions : PodmanOptions
    {
        /// <summary>
        /// Format the output using the given Go template. 
        /// The keys of the returned JSON can be used as the values for the --format flag
        /// </summary>
        [PodmanOption(Name = "format")]
         public string? Format { get; set; }
         /// <summary>
         /// Instead of providing the container name or ID, use the last created container. 
         /// Note: the last started container can be from other users of Podman on the host machine.
         /// </summary>
         [PodmanOption(Name = "lastest")]
         public bool? Latest { get; set; }
         /// <summary>
         /// In addition to normal output, display the total file size if the type is a container.
         /// </summary>
         [PodmanOption(Name = "size")]
         public bool? Size { get; set; }
    }
}