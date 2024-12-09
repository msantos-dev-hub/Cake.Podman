#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Image.Push
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class PodmanImagePushOptions : PodmanOptions
    {
        /// <summary>
        /// Path of the authentication file. 
        /// Default is ${XDG_RUNTIME_DIR}/containers/auth.json on Linux, and $HOME/.config/containers/auth.json on Windows/macOS.
        /// </summary>
        [PodmanOption(Name = "authfile", Quoted = true)]
        public string? Authfile { get; set; }
        /// <summary>
        /// Use certificates at path (*.crt, *.cert, *.key) to connect to the registry. 
        /// (Default: /etc/containers/certs.d)
        /// </summary>
        [PodmanOption(Name = "cert-dir", Quoted = true)]
        public string? Certdir { get; set; }
        /// <summary>
        /// Compress tarball image layers when pushing to a directory using the ‘dir’ transport. 
        /// (default is same compression type, compressed or uncompressed, as source)
        /// Note: This flag can only be set when using the dir transport
        /// </summary>
        [PodmanOption(Name = "compress")]
        public bool? Compress { get; set; }
        /// <summary>
        /// Specifies the compression format to use. Supported values are: gzip, zstd and zstd:chunked. 
        /// The default is gzip unless overridden in the containers.conf file.
        /// </summary>
        [PodmanOption(Name = "compression-format")]
        public string? CompressionFormat { get; set; }
        /// <summary>
        /// Specifies the compression level to use. 
        /// The value is specific to the compression algorithm used, e.g. for zstd the accepted values are in the range 1-20 (inclusive) with a default of 3, while for gzip it is 1-9 (inclusive) and has a default of 5.
        /// </summary>
        [PodmanOption(Name = "compression-level")]
        public int? CompressionLevel { get; set; }
        /// <summary>
        /// The [username[:password]] to use to authenticate with the registry, if required. 
        /// If one or both values are not supplied, a command line prompt appears and the value can be entered
        /// </summary>
        [PodmanOption(Name = "creds")]
        public string? Creds { get; set; }
        /// <summary>
        /// After copying the image, write the digest of the resulting image to the file.
        /// </summary>
        [PodmanOption(Name = "digestfile", Quoted = true)]
        public string? Digestfile { get; set; }
        /// <summary>
        /// This is a Docker-specific option to disable image verification to a container registry and is not supported by Podman. 
        /// This option is a NOOP and provided solely for scripting compatibility.
        /// </summary>
        [PodmanOption(Name = "disable-content-trust")]
        public bool? DisableContentTrust { get; set; }
        /// <summary>
        /// Layer(s) to encrypt: 0-indexed layer indices with support for negative indexing 
        /// (e.g. 0 is the first layer, -1 is the last layer). 
        /// If not defined, encrypts all layers if encryption-key flag is specified.
        /// </summary>
        [PodmanOption(Name = "encrypt-layer")]
        public int? EncryptLayer { get; set; }
        /// <summary>
        /// The [protocol:keyfile] specifies the encryption protocol, which can be JWE (RFC7516), PGP (RFC4880), and PKCS7 (RFC2315) and the key material required for image encryption.
        /// </summary>
        [PodmanOption(Name = "encryption-key")]
        public string? EncryptionKey { get; set; }
        /// <summary>
        /// f set, push uses the specified compression algorithm even if the destination contains a differently-compressed variant already. 
        /// Defaults to true if --compression-format is explicitly specified on the command-line, false otherwise.
        /// </summary>
        [PodmanOption(Name = "force-compression")]
        public bool? ForceCompression { get; set; }
        /// <summary>
        /// Manifest Type (oci, v2s2, or v2s1) to use when pushing an image.
        /// </summary>
        [PodmanOption(Name = "format")]
        public string? Format { get; set; }
        /// <summary>
        /// Discard any pre-existing signatures in the image.
        /// </summary>
        [PodmanOption(Name = "remove-signatures")]
        public bool? RemoveSignatures { get; set; }
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
        /// Add a “simple signing” signature at the destination using the specified key. 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "sign-by")]
        public string? SignBy { get; set; }
        /// <summary>
        /// Add a sigstore signature based on further options specified in a container’s sigstore signing parameter file param-file. 
        /// See containers-sigstore-signing-params.yaml(5) for details about the file format.
        /// </summary>
        [PodmanOption(Name = "sign-by-sigstore")]
        public string? SignBySigstore { get; set; }
        /// <summary>
        /// Add a sigstore signature at the destination using a private key at the specified path. 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "sign-by-sigstore-private-key", Quoted = true)]
        public string? SignBySigstorePrivateKey { get; set; }
        /// <summary>
        /// If signing the image (using either --sign-by or --sign-by-sigstore-private-key), read the passphrase to use from the specified path.
        /// </summary>
        [PodmanOption(Name = "sign-passphrase-file", Quoted = true)]
        public string? SignPassphraseFile { get; set; }
        /// <summary>
        /// Require HTTPS and verify certificates when contacting registries (default: true). 
        /// If explicitly set to true, TLS verification is used. 
        /// If set to false, TLS verification is not used.
        /// </summary>
        [PodmanOption(Name = "tls-verify")]
        public bool? TlsVerify { get; set; }
    }
}