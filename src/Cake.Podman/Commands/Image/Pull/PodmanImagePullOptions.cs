#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Image.Pull
{
    /// <summary>
    /// Options for Podman Image Pull command
    /// </summary>
    public sealed class PodmanImagePullOptions : PodmanOptions
    {
        /// <summary>
        /// All tagged images in the repository are pulled.
        /// </summary>
        [PodmanOption(Name = "all-tags")]
        public bool? AllTags { get; set; }
        /// <summary>
        /// Override the architecture, defaults to hosts, of the image to be pulled. 
        /// For example, arm. 
        /// Unless overridden, subsequent lookups of the same image in the local storage matches this architecture, regardless of the host.
        /// </summary>
        [PodmanOption(Name = "arch")]
        public string? Arch { get; set; }
        /// <summary>
        /// Path of the authentication file. 
        /// Default is ${XDG_RUNTIME_DIR}/containers/auth.json on Linux, and $HOME/.config/containers/auth.json on Windows/macOS.
        /// </summary>
        [PodmanOption(Name = "authfile", Quoted = true)]
        public string? AuthFile { get; set; }
        /// <summary>
        /// Use certificates at path (*.crt, *.cert, *.key) to connect to the registry.
        /// </summary>
        [PodmanOption(Name = "cert-dir", Quoted = true)]
        public string? CertDir { get; set; }
        /// <summary>
        /// The [username[:password]] to use to authenticate with the registry, if required.
        /// </summary>
        [PodmanOption(Name = "creds")]
        public string? Creds { get; set; }
        /// <summary>
        /// The [key[:passphrase]] to be used for decryption of images. 
        /// Key can point to keys and/or certificates. 
        /// Decryption is tried with all keys.
        /// </summary>
        [PodmanOption(Name = "decryption-key")]
        public string? DecryptionKey { get; set; }
        /// <summary>
        /// This is a Docker-specific option to disable image verification to a container registry and is not supported by Podman.
        /// </summary>
        [PodmanOption(Name = "disable-content-trust")]
        public bool? DisableContentTrust { get; set; }
        /// <summary>
        /// Override the OS, defaults to hosts, of the image to be pulled. For example, windows.
        /// </summary>
        [PodmanOption(Name = "os")]
        public string? Os { get; set; }
        /// <summary>
        /// Specify the platform for selecting the image. (Conflicts with --arch and --os) 
        /// The --platform option can be used to override the current architecture and operating system.
        /// </summary>
        [PodmanOption(Name = "platform")]
        public string? Platform { get; set; }
        /// <summary>
        /// Number of times to retry pulling or pushing images between the registry and local storage in case of failure. 
        /// Default is 3.
        /// </summary>
        [PodmanOption(Name = "retry")]
        public int? Retry { get; set; }
        /// <summary>
        /// Duration of delay between retry attempts when pulling or pushing images between the registry and local storage in case of failure. 
        /// The default is to start at two seconds and then exponentially back off. 
        /// The delay is used when this value is set, and no exponential back off occurs.
        /// </summary>
        [PodmanOption(Name = "retry-delay")]
        public int? RetryDelay { get; set; }
        /// <summary>
        /// Require HTTPS and verify certificates when contacting registries (default: true). 
        /// If explicitly set to true, TLS verification is used. 
        /// If set to false, TLS verification is not used.
        /// </summary>
        [PodmanOption(Name = "tls-verify")]
        public bool? TlsVerify { get; set; }
        /// <summary>
        /// Use VARIANT instead of the default architecture variant of the container image. 
        /// Some images can use multiple variants of the arm architectures, such as arm/v5 and arm/v7
        /// </summary>
        [PodmanOption(Name = "variant")]
        public string? Variant { get; set; }
    }
}