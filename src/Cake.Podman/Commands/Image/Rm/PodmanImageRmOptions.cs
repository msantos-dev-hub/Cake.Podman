using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Image.Rm
{
    /// <summary>
    /// Options for Podman Image Rm command
    /// </summary>
    public sealed class PodmanImageRmOptions : PodmanOptions
    {
        /// <summary>
        /// Remove all images in the local storage.
        /// </summary>
        [PodmanOption(Name = "all")]
        public bool? All { get; set; }
        /// <summary>
        /// This option causes Podman to remove all containers that are using the image before removing the image from the system.
        /// </summary>
        [PodmanOption(Name = "force")]
        public bool? Force { get; set; }
        /// <summary>
        /// If a specified image does not exist in the local storage, ignore it and do not throw an error.
        /// </summary>
        [PodmanOption(Name = "ignore")]
        public bool? Ignore { get; set; }
        /// <summary>
        /// This option does not remove dangling parents of the specified image.
        /// </summary>
        [PodmanOption(Name = "no-prune")]
        public bool? NoPrune { get; set; }
    }
}