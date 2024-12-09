#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Logout
{
    /// <summary>
    /// Options for Podman Logout command
    /// </summary>
    public sealed class PodmanLogoutOptions : PodmanOptions
    {
        /// <summary>
        /// Remove the cached credentials for all registries in the auth file
        /// </summary>
        [PodmanOption(Name = "all")]
        public bool? All { get; set; }
        /// <summary>
        /// Path of the authentication file. 
        /// Default is ${XDG_RUNTIME_DIR}/containers/auth.json on Linux, and $HOME/.config/containers/auth.json on Windows/macOS. 
        /// The file is created by podman login. 
        /// If the authorization state is not found there, $HOME/.docker/config.json is checked, which is set using docker login.
        /// </summary>
        [PodmanOption(Name = "authfile")]
        public string? Authfile { get; set; }
        /// <summary>
        /// Instead of updating the default credentials file, update the one at path, and use a Docker-compatible format.
        /// </summary>
        [PodmanOption(Name = "compat-auth-file")]
        public string? CompatAuthFile { get; set; }
    }
}