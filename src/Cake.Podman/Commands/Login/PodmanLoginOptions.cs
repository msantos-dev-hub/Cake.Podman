#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Login
{
    /// <summary>
    /// Options for Podman Login command
    /// </summary>
    public sealed class PodmanLoginOptions : PodmanOptions
    {
        /// <summary>
        /// Path of the authentication file. 
        /// Default is ${XDG_RUNTIME_DIR}/containers/auth.json on Linux, and $HOME/.config/containers/auth.json on Windows/macOS. 
        /// The file is created by podman login. 
        /// If the authorization state is not found there, $HOME/.docker/config.json is checked, which is set using docker login.
        /// </summary>
        [PodmanOption(Name = "authfile")]
        public string? Authfile { get; set; }
        /// <summary>
        /// Use certificates at path (*.crt, *.cert, *.key) to connect to the registry. 
        /// (Default: /etc/containers/certs.d) For details, see containers-certs.d(5). 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "cert-dir")]
        public string? CertDir { get; set; }
        /// <summary>
        /// Use certificates at path (*.crt, *.cert, *.key) to connect to the registry. 
        /// (Default: /etc/containers/certs.d) For details, see containers-certs.d(5). 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "compat-auth-file")]
        public string? CompatAuthFile { get; set; }
        /// <summary>
        /// Return the logged-in user for the registry. Return error if no login is found.
        /// </summary>
        [PodmanOption(Name = "get-login")]
        public bool? GetLogin { get; set; }
        /// <summary>
        /// Password for registry
        /// </summary>
        [PodmanOption(Name = "password", Secret = true)]
        public string Password { get; set; } = "";
        /// <summary>
        /// Take the password from stdin
        /// </summary>
        [PodmanOption(Name = "password-stdin")]
        public bool? PasswordStdin { get; set; }
        /// <summary>
        /// Read the password for the registry from the podman secret name. 
        /// If --username is not specified --username=name is used.
        /// </summary>
        [PodmanOption(Name = "secret")]
        public string? Secret { get; set; }
        /// <summary>
        /// Require HTTPS and verify certificates when contacting registries (default: true). 
        /// If explicitly set to true, TLS verification is used. 
        /// If set to false, TLS verification is not used.
        /// </summary>
        [PodmanOption(Name = "tls-verify")]
        public bool? TlsVerify { get; set; }
        /// <summary>
        /// Username for registry
        /// </summary>
        [PodmanOption(Name = "username")]
        public string Username { get; set; } = "";

        //protected override string[]? CollectSecretProperties => [nameof(Password)];
    }
}