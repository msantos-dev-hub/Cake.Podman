using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Build
{
    /// <summary>
    /// Options for Podman Build command
    /// </summary>
    public sealed class PodmanBuildOptions : PodmanOptions
    {
        /// <summary>
        /// Add a custom host-to-IP mapping (host:ip)
        /// The option takes one or multiple semicolon-separated hostnames to be mapped to a single IPv4 or IPv6 address, separated by a colon.
        /// </summary>
        [PodmanOption(Name = "add-host")]
        public string? AddHost { get; set; }
        /// <summary>
        /// Instead of building for a set of platforms specified using the --platform option, inspect the build’s base images, and build for all of the platforms for which they are all available. 
        /// Stages that use scratch as a starting point can not be inspected, so at least one non-scratch stage must be present for detection to work usefully.
        /// </summary>
        [PodmanOption(Name = "all-platforms")]
        public bool? AllPlatforms { get; set; }
        /// <summary>
        /// Add an image annotation (e.g. annotation=value) to the image metadata.
        /// </summary>
        [PodmanOption(Name = "annotation", Format = FormatType.Multiple)]
        public string[]? Annotation { get; set; }
        /// <summary>
        /// Set the architecture of the image to be built, and that of the base image to be pulled, if the build uses one, to the provided value instead of using the architecture of the build host. 
        /// Unless overridden, subsequent lookups of the same image in the local storage matches this architecture, regardless of the host.
        /// </summary>
        [PodmanOption(Name = "arch")]
        public string? Arch { get; set; }
        /// <summary>
        /// Path of the authentication file. 
        /// Default is ${XDG_RUNTIME_DIR}/containers/auth.json on Linux, and $HOME/.config/containers/auth.json on Windows/macOS. 
        /// The file is created by podman login.
        /// </summary>
        [PodmanOption(Name = "authfile", Quoted = true)]
        public string? Authfile { get; set; }
        /// <summary>
        /// Specifies a build argument and its value, which is interpolated in instructions read from the Containerfiles in the same way that environment variables are, but which are not added to environment variable list in the resulting image’s configuration.
        /// </summary>
        [PodmanOption(Name = "build-arg", Format = FormatType.Multiple)]
        public string[]? BuildArg { get; set; }
        /// <summary>
        /// Specifies a file containing lines of build arguments of the form arg=value. The suggested file name is argfile.conf.
        /// Comment lines beginning with # are ignored, along with blank lines. All others must be of the arg=value format passed to --build-arg.
        /// If several arguments are provided via the --build-arg-file and --build-arg options, the build arguments are merged across all of the provided files and command line arguments.
        /// Any file provided in a --build-arg-file option is read before the arguments supplied via the --build-arg option.
        /// When a given argument name is specified several times, the last instance is the one that is passed to the resulting builds. This means --build-arg values always override those in a --build-arg-file.
        /// </summary>
        [PodmanOption(Name = "build-arg-file")]
        public string? BuildArgFile { get; set; }
        /// <summary>
        /// Specify an additional build context using its short name and its location. 
        /// Additional build contexts can be referenced in the same manner as we access different stages in COPY instruction.
        /// </summary>
        [PodmanOption(Name = "build-context")]
        public string? BuildContext { get; set; }
        /// <summary>
        /// Repository to utilize as a potential cache source. When specified, Buildah tries to look for cache images in the specified repository and attempts to pull cache images instead of actually executing the build steps locally. 
        /// Buildah only attempts to pull previously cached images if they are considered as valid cache hits.
        /// Use the --cache-to option to populate a remote repository with cache content.
        /// Note: --cache-from option is ignored unless --layers is specified.
        /// </summary>
        [PodmanOption(Name = "cache-from")]
        public string? CacheFrom { get; set; }
        /// <summary>
        /// Set this flag to specify a remote repository that is used to store cache images. 
        /// Buildah attempts to push newly built cache image to the remote repository.
        /// Note: Use the --cache-from option in order to use cache content in a remote repository.
        /// Note: --cache-to option is ignored unless --layers is specified.
        /// </summary>
        [PodmanOption(Name = "cache-to")]
        public string? CacheTo { get; set; }
        /// <summary>
        /// Limit the use of cached images to only consider images with created timestamps less than duration ago. 
        /// For example if --cache-ttl=1h is specified, Buildah considers intermediate cache images which are created under the duration of one hour, and intermediate cache images outside this duration is ignored.
        /// Note: Setting --cache-ttl=0 manually is equivalent to using --no-cache in the implementation since this means that the user dones not want to use cache at all.
        /// </summary>
        [PodmanOption(Name = "cache-ttl")]
        public string? CacheTtl { get; set; }
        /// <summary>
        /// When executing RUN instructions, run the command specified in the instruction with the specified capability added to its capability set. 
        /// Certain capabilities are granted by default; this option can be used to add more.
        /// </summary>
        [PodmanOption(Name = "cap-add")]
        public string? CapAdd { get; set; }
        /// <summary>
        /// When executing RUN instructions, run the command specified in the instruction with the specified capability removed from its capability set. 
        /// The CAP_CHOWN, CAP_DAC_OVERRIDE, CAP_FOWNER, CAP_FSETID, CAP_KILL, CAP_NET_BIND_SERVICE, CAP_SETFCAP, CAP_SETGID, CAP_SETPCAP, and CAP_SETUID capabilities are granted by default; this option can be used to remove them.
        /// If a capability is specified to both the --cap-add and --cap-drop options, it is dropped, regardless of the order in which the options were given.
        /// </summary>
        [PodmanOption(Name = "cap-drop")]
        public string? CapDrop { get; set; }
        /// <summary>
        /// Use certificates at path (*.crt, *.cert, *.key) to connect to the registry. 
        /// (Default: /etc/containers/certs.d) For details, see containers-certs.d(5). 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "cert-dir", Quoted = true)]
        public string? CertDir { get; set; }
        /// <summary>
        /// Path to cgroups under which the cgroup for the container is created. 
        /// If the path is not absolute, the path is considered to be relative to the cgroups path of the init process. 
        /// Cgroups are created if they do not already exist.
        /// </summary>
        [PodmanOption(Name = "cgroup-parent", Quoted = true)]
        public string? CgroupParent { get; set; }
        /// <summary>
        /// Sets the configuration for cgroup namespaces when handling RUN instructions. 
        /// The configured value can be “” (the empty string) or “private” to indicate that a new cgroup namespace is created, or it can be “host” to indicate that the cgroup namespace in which buildah itself is being run is reused.
        /// </summary>
        [PodmanOption(Name = "cgroupns")]
        public string? Cgroupns { get; set; }
        /// <summary>
        /// Handle directories marked using the VOLUME instruction (both in this build, and those inherited from base images) such that their contents can only be modified by ADD and COPY instructions. 
        /// Any changes made in those locations by RUN instructions will be reverted. 
        /// Before the introduction of this option, this behavior was the default, but it is now disabled by default.
        /// </summary>
        [PodmanOption(Name = "compat-volumes")]
        public bool? CompatVolumes { get; set; }
        /// <summary>
        /// This option is added to be aligned with other containers CLIs. 
        /// Podman doesn’t communicate with a daemon or a remote server. 
        /// Thus, compressing the data before sending it is irrelevant to Podman. 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "compress")]
        public bool? Compress { get; set; }
        /// <summary>
        /// Set additional flags to pass to the C Preprocessor cpp(1). 
        /// Containerfiles ending with a “.in” suffix is preprocessed via cpp(1). 
        /// This option can be used to pass additional flags to cpp.
        /// Note: You can also set default CPPFLAGS by setting the BUILDAH_CPPFLAGS environment variable (e.g., export BUILDAH_CPPFLAGS=”-DDEBUG”).
        /// </summary>
        [PodmanOption(Name = "cpp-flag")]
        public string? CppFlag { get; set; }
        /// <summary>
        /// Set the CPU period for the Completely Fair Scheduler (CFS), which is a duration in microseconds. 
        /// Once the container’s CPU quota is used up, it will not be scheduled to run until the current period ends. 
        /// Defaults to 100000 microseconds.
        /// This option is not supported on cgroups V1 rootless systems.
        /// </summary>
        [PodmanOption(Name = "cpu-period")]
        public Int64? CpuPeriod { get; set; }
        /// <summary>
        /// Limit the CPU Completely Fair Scheduler (CFS) quota.
        /// Limit the container’s CPU usage. By default, containers run with the full CPU resource. 
        /// The limit is a number in microseconds. 
        /// If a number is provided, the container is allowed to use that much CPU time until the CPU period ends (controllable via --cpu-period).
        /// This option is not supported on cgroups V1 rootless systems.
        /// </summary>
        [PodmanOption(Name = "cpu-quota")]
        public Int64? CpuQuota { get; set; }
        /// <summary>
        /// By default, all containers get the same proportion of CPU cycles. 
        /// This proportion can be modified by changing the container’s CPU share weighting relative to the combined weight of all the running containers. 
        /// Default weight is 1024.
        /// The proportion only applies when CPU-intensive processes are running. 
        /// When tasks in one container are idle, other containers can use the left-over CPU time. 
        /// The actual amount of CPU time varies depending on the number of containers running on the system.
        /// </summary>
        [PodmanOption(Name = "cpu-shares", Format = FormatType.CommaSeparatedValue)]
        public Int64? CpuShares { get; set; }
        /// <summary>
        /// CPUs in which to allow execution. 
        /// Can be specified as a comma-separated list (e.g. 0,1), as a range (e.g. 0-3), or any combination thereof (e.g. 0-3,7,11-15)
        /// This option is not supported on cgroups V1 rootless systems.
        /// </summary>
        [PodmanOption(Name = "cpuset-cpus")]
        public string? CpusetCpus { get; set; }
        /// <summary>
        /// Memory nodes (MEMs) in which to allow execution (0-3, 0,1). 
        /// Only effective on NUMA systems.
        /// If there are four memory nodes on the system (0-3), use --cpuset-mems=0,1 then processes in the container only uses memory from the first two memory nodes.
        /// This option is not supported on cgroups V1 rootless systems.
        /// </summary>
        [PodmanOption(Name = "cpuset-mems")]
        public string? CpusetMems { get; set; }
        /// <summary>
        /// The [username[:password]] to use to authenticate with the registry, if required. 
        /// If one or both values are not supplied, a command line prompt appears and the value can be entered. 
        /// The password is entered without echo.
        /// </summary>
        [PodmanOption(Name = "creds")]
        public string? Creds { get; set; }
        /// <summary>
        /// Produce an image suitable for use as a confidential workload running in a trusted execution environment (TEE) using krun (i.e., crun built with the libkrun feature enabled and invoked as krun). 
        /// Instead of the conventional contents, the root filesystem of the image will contain an encrypted disk image and configuration information for krun.
        /// </summary>
        [PodmanOption(Name = "cw", Format = FormatType.CommaSeparatedValue)]
        public string[]? Cw { get; set; }
        /// <summary>
        /// The [key[:passphrase]] to be used for decryption of images. Key can point to keys and/or certificates. 
        /// Decryption is tried with all keys. If the key is protected by a passphrase, it is required to be passed in the argument and omitted otherwise.
        /// </summary>
        [PodmanOption(Name = "decryption-key")]
        public string? DecryptionKey { get; set; }
        /// <summary>
        /// Add a host device to the container. 
        /// Optional permissions parameter can be used to specify device permissions by combining r for read, w for write, and m for mknod(2).
        /// </summary>
        [PodmanOption(Name = "device")]
        public string? Device { get; set; }
        /// <summary>
        /// Don’t compress filesystem layers when building the image unless it is required by the location where the image is being written. 
        /// This is the default setting, because image layers are compressed automatically when they are pushed to registries, and images being written to local storage only need to be decompressed again to be stored.
        /// </summary>
        [PodmanOption(Name = "disable-compression")]
        public bool? DisableCompression { get; set; }
        /// <summary>
        /// This is a Docker-specific option to disable image verification to a container registry and is not supported by Podman. 
        /// This option is a NOOP and provided solely for scripting compatibility.
        /// </summary>
        [PodmanOption(Name = "disable-content-trust")]
        public bool? DisableContentTrust { get; set; }
        /// <summary>
        /// Set custom DNS servers.
        /// This option can be used to override the DNS configuration passed to the container.
        /// </summary>
        [PodmanOption(Name = "dns")]
        public string? Dns { get; set; }
        /// <summary>
        /// Set custom DNS options to be used during the build.
        /// </summary>
        [PodmanOption(Name = "dns-option")]
        public string? DnsOption { get; set; }
        /// <summary>
        /// Set custom DNS search domains to be used during the build.
        /// </summary>
        [PodmanOption(Name = "dns-search")]
        public string? DnsSearch { get; set; }
        /// <summary>
        /// Add a value (e.g. env=value) to the built image.
        /// </summary>
        [PodmanOption(Name = "env", Format = FormatType.Multiple)]
        public string[]? Env { get; set; }
        /// <summary>
        /// Specifies a Containerfile which contains instructions for building the image, either a local file or an http or https URL. 
        /// If more than one Containerfile is specified, FROM instructions are only be accepted from the last specified file.
        /// </summary>
        [PodmanOption(Name = "file", Format = FormatType.Multiple, Quoted = true)]
        public string[]? File { get; set; }
        /// <summary>
        /// Always remove intermediate containers after a build, even if the build fails (default true).
        /// </summary>
        [PodmanOption(Name = "force-rm")]
        public bool? ForceRm { get; set; }
        /// <summary>
        /// Control the format for the built image’s manifest and configuration data.
        /// </summary>
        [PodmanOption(Name = "format")]
        public bool? Format { get; set; }
        /// <summary>
        /// Overrides the first FROM instruction within the Containerfile. 
        /// If there are multiple FROM instructions in a Containerfile, only the first is changed.
        /// </summary>
        [PodmanOption(Name = "from", Quoted = true)]
        public string? From { get; set; }
        /// <summary>
        /// Assign additional groups to the primary user running within the container process.
        /// </summary>
        [PodmanOption(Name = "group-add", Format = FormatType.Multiple)]
        public string[]? GroupAdd { get; set; }
        /// <summary>
        /// Each *.json file in the path configures a hook for buildah build containers
        /// </summary>
        [PodmanOption(Name = "hooks-dir", Format = FormatType.Multiple, Quoted = true)]
        public string[]? HooksDir { get; set; }
        /// <summary>
        /// By default proxy environment variables are passed into the container if set for the Podman process.
        /// </summary>
        [PodmanOption(Name = "http-proxy")]
        public bool? HttpProxy { get; set; }
        /// <summary>
        /// Adds default identity label io.buildah.version if set. (default true).
        /// </summary>
        [PodmanOption(Name = "identity-label")]
        public string? IdentityLabel { get; set; }
        /// <summary>
        /// Path to an alternative .containerignore file.
        /// </summary>
        [PodmanOption(Name = "ignorefile")]
        public string? Ignorefile { get; set; }
        /// <summary>
        /// Write the built image’s ID to the file. When --platform is specified more than once, attempting to use this option triggers an error.
        /// </summary>
        [PodmanOption(Name = "iidfile")]
        public string? Iidfile { get; set; }
        /// <summary>
        /// Sets the configuration for IPC namespaces when handling RUN instructions. 
        /// The configured value can be “” (the empty string) or “container” to indicate that a new IPC namespace is created, or it can be “host” to indicate that the IPC namespace
        /// </summary>
        [PodmanOption(Name = "ipc")]
        public string? Ipc { get; set; }
        /// <summary>
        /// Controls what type of isolation is used for running processes as part of RUN instructions.
        /// </summary>
        [PodmanOption(Name = "isolation")]
        public string? Isolation { get; set; }
        /// <summary>
        /// Run up to N concurrent stages in parallel. 
        /// If the number of jobs is greater than 1, stdin is read from /dev/null. 
        /// If 0 is specified, then there is no limit in the number of jobs that run in parallel.
        /// </summary>
        [PodmanOption(Name = "jobs")]
        public Int64? Jobs { get; set; }
        /// <summary>
        /// Add an image label (e.g. label=value) to the image metadata. Can be used multiple times.
        /// </summary>
        [PodmanOption(Name = "label")]
        public string? Label { get; set; }
        /// <summary>
        /// Add an intermediate image label (e.g. label=value) to the intermediate image metadata. It can be used multiple times.
        /// </summary>
        [PodmanOption(Name = "layer-label", Format = FormatType.Multiple)]
        public string[]? LayerLabel { get; set; }
        /// <summary>
        /// Cache intermediate images during the build process (Default is true).
        /// </summary>
        [PodmanOption(Name = "layers")]
        public bool? Layers { get; set; }
        /// <summary>
        /// Log output which is sent to standard output and standard error to the specified file instead of to standard output and standard error. 
        /// This option is not supported on the remote client, including Mac and Windows (excluding WSL2) machines.
        /// </summary>
        [PodmanOption(Name = "logfile", Quoted = true)]
        public string? Logfile { get; set; }
        /// <summary>
        /// If --logfile and --platform are specified, the --logsplit option allows end-users to split the log file for each platform into different files in the following format: 
        /// ${logfile}_${platform-os}_${platform-arch}. 
        /// This option is not supported on the remote client, including Mac and Windows (excluding WSL2) machines.
        /// </summary>
        [PodmanOption(Name = "logsplit")]
        public bool? Logsplit { get; set; }
        /// <summary>
        /// Name of the manifest list to which the image is added. Creates the manifest list if it does not exist. 
        /// This option is useful for building multi architecture images.
        /// </summary>
        [PodmanOption(Name = "manifest")]
        public string? Manifest { get; set; }
        /// <summary>
        /// Memory limit. A unit can be b (bytes), k (kibibytes), m (mebibytes), or g (gibibytes).
        /// This option is not supported on cgroups V1 rootless systems.
        /// </summary>
        [PodmanOption(Name = "memory")]
        public string? Memory { get; set; }
        /// <summary>
        /// A limit value equal to memory plus swap. A unit can be b (bytes), k (kibibytes), m (mebibytes), or g (gibibytes).
        /// </summary>
        [PodmanOption(Name = "memory-swap")]
        public string? MemorySwap { get; set; }
        /// <summary>
        /// Sets the configuration for network namespaces when handling RUN instructions.
        /// </summary>
        [PodmanOption(Name = "netwokr")]
        public string? Network { get; set; }
        /// <summary>
        /// Do not use existing cached images for the container build. Build from the start with a new set of cached layers.
        /// </summary>
        [PodmanOption(Name = "no-cache")]
        public bool? NoCache { get; set; }
        /// <summary>
        /// Do not create the /etc/hostname file in the container for RUN instructions
        /// By default, Buildah manages the /etc/hostname file, adding the container’s own hostname. When the --no-hostname option is set, the image’s /etc/hostname will be preserved unmodified if it exists.
        /// </summary>
        [PodmanOption(Name = "no-hostname")]
        public string? NoHostname { get; set; }
        /// <summary>
        /// Do not create /etc/hosts for the container. By default, Podman manages /etc/hosts, adding the container’s own IP address and any hosts from --add-host. --no-hosts disables this, and the image’s /etc/hosts is preserved unmodified.
        /// </summary>
        [PodmanOption(Name = "no-hosts")]
        public bool? NoHosts { get; set; }
        /// <summary>
        /// This option is useful for the cases where end users explicitly want to set --omit-history to omit the optional History from built images or when working with images built using build tools that do not include History information in their images.
        /// </summary>
        [PodmanOption(Name = "omit-history")]
        public bool? OmitHistory { get; set; }
        /// <summary>
        /// Set the OS of the image to be built, and that of the base image to be pulled, if the build uses one, instead of using the current operating system of the build host. 
        /// Unless overridden, subsequent lookups of the same image in the local storage matches this OS, regardless of the host.
        /// </summary>
        [PodmanOption(Name = "os")]
        public string? Os { get; set; }
        /// <summary>
        /// Set the name of a required operating system feature for the image which is built. 
        /// By default, if the image is not based on scratch, the base image’s required OS feature list is kept, if the base image specified any. 
        /// This option is typically only meaningful when the image’s OS is Windows.
        /// </summary>
        [PodmanOption(Name = "os-feature")]
        public string? OsFeature { get; set; }
        /// <summary>
        /// Set the exact required operating system version for the image which is built. 
        /// By default, if the image is not based on scratch, the base image’s required OS version is kept, if the base image specified one. 
        /// This option is typically only meaningful when the image’s OS is Windows, and is typically set in Windows base images, so using this option is usually unnecessary.
        /// </summary>
        [PodmanOption(Name = "os-version")]
        public string? OsVersion { get; set; }
        /// <summary>
        /// Output destination (format: type=local,dest=path)
        /// The --output (or -o) option extends the default behavior of building a container image by allowing users to export the contents of the image as files on the local filesystem, which can be useful for generating local binaries, code generation, etc. 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "output")]
        public string? Output { get; set; }
        /// <summary>
        /// Sets the configuration for PID namespaces when handling RUN instructions. 
        /// The configured value can be “” (the empty string) or “container” to indicate that a new PID namespace is created, or it can be “host” to indicate that the PID namespace in which podman itself is being run is reused, or it can be the path to a PID namespace which is already in use by another process.
        /// </summary>
        [PodmanOption(Name = "pid")]
        public string? Pid { get; set; }
        /// <summary>
        /// Set the os/arch of the built image (and its base image, when using one) to the provided value instead of using the current operating system and architecture of the host (for example linux/arm). 
        /// Unless overridden, subsequent lookups of the same image in the local storage matches this platform, regardless of the host.
        /// The --platform option can be specified more than once, or given a comma-separated list of values as its argument. 
        /// When more than one platform is specified, the --manifest option is used instead of the --tag option.
        /// </summary>
        [PodmanOption(Name = "platform", Format = FormatType.Multiple)]
        public string[]? Platform { get; set; }
        /// <summary>
        /// Pull image policy. The default is missing.
        /// </summary>
        [PodmanOption(Name = "pull")]
        public string? Pull { get; set; }
        /// <summary>
        /// Suppress output messages which indicate which instruction is being processed, and of progress when pulling images from a registry, and when writing the output image.
        /// </summary>
        [PodmanOption(Name = "quiet")]
        public bool? Quiet { get; set; }
        /// <summary>
        /// Number of times to retry pulling or pushing images between the registry and local storage in case of failure. Default is 3.
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
        /// Remove intermediate containers after a successful build (default true).
        /// </summary>
        [PodmanOption(Name = "rm")]
        public bool? Rm { get; set; }
        /// <summary>
        /// The path to an alternate OCI-compatible runtime, which is used to run commands specified by the RUN instruction.
        /// </summary>
        [PodmanOption(Name = "runtime", Quoted = true)]
        public string? Runtime { get; set; }
        /// <summary>
        /// Adds global flags for the container runtime. 
        /// To list the supported flags, please consult the manpages of the selected container runtime.
        /// </summary>
        [PodmanOption(Name = "runtime-flag")]
        public string? RuntimeFlag { get; set; }
        /// <summary>
        /// Generate SBOMs (Software Bills Of Materials) for the output image by scanning the working container and build contexts using the named combination of scanner image, scanner commands, and merge strategy.
        /// </summary>
        [PodmanOption(Name = "sbom")]
        public string? Sbom { get; set; }
        /// <summary>
        /// When generating SBOMs, store the generated SBOM in the specified path in the output image. 
        /// There is no default.
        /// </summary>
        [PodmanOption(Name = "sbom-image-output", Quoted = true)]
        public string? SbomImageOutput { get; set; }
        /// <summary>
        /// When generating SBOMs, scan them for PURL (package URL) information, and save a list of found PURLs to the specified path in the output image. 
        /// There is no default.
        /// </summary>
        [PodmanOption(Name = "sbom-image-purl-output", Quoted = true)]
        public string? SbomImagePurlOutput { get; set; }
        /// <summary>
        /// If more than one --sbom-scanner-command value is being used, use the specified method to merge the output from later commands with output from earlier commands.
        /// </summary>
        [PodmanOption(Name = "sbom-merge-strategy")]
        public string? SbomMergeStrategy { get; set; }
        /// <summary>
        /// When generating SBOMs, store the generated SBOM in the named file on the local filesystem. 
        /// There is no default.
        /// </summary>
        [PodmanOption(Name = "sbom-output", Quoted = true)]
        public string? SbomOutput { get; set; }
        /// <summary>
        /// When generating SBOMs, scan them for PURL (package URL) information, and save a list of found PURLs to the named file in the local filesystem. 
        /// There is no default.
        /// </summary>
        [PodmanOption(Name = "sbom-purl-output", Quoted = true)]
        public string? SbomPurlOutput { get; set; }
        /// <summary>
        /// Generate SBOMs by running the specified command from the scanner image. 
        /// If multiple commands are specified, they are run in the order in which they are specified.
        /// </summary>
        [PodmanOption(Name = "sbom-scanner-command")]
        public string? SbomScannerCommand { get; set; }
        /// <summary>
        /// Generate SBOMs using the specified scanner image.
        /// </summary>
        [PodmanOption(Name = "sbom-scanner-image")]
        public string? SbomScannerImage { get; set; }
        /// <summary>
        /// Pass secret information used in the Containerfile for building images in a safe way that are not stored in the final image, or be seen in other stages. 
        /// The secret is mounted in the container at the default location of /run/secrets/id.
        /// </summary>
        [PodmanOption(Name = "secret", Format = FormatType.CommaSeparatedValue)]
        public string[]? Secret { get; set; }
        /// <summary>
        /// Security Options
        /// </summary>
        [PodmanOption(Name = "security-opt")]
        public string? SecurityOption { get; set; }
        /// <summary>
        /// Size of /dev/shm. A unit can be b (bytes), k (kibibytes), m (mebibytes), or g (gibibytes). 
        /// If the unit is omitted, the system uses bytes. 
        /// If the size is omitted, the default is 64m. 
        /// When size is 0, there is no limit on the amount of memory used for IPC by the container. 
        /// This option conflicts with --ipc=host.
        /// </summary>
        [PodmanOption(Name = "shm-size")]
        public string? ShmSize { get; set; }
        /// <summary>
        /// Sign the image using a GPG key with the specified FINGERPRINT. 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines,)
        /// </summary>
        [PodmanOption(Name = "sign-by")]
        public string? SignBy { get; set; }
        /// <summary>
        /// Skip stages in multi-stage builds which don’t affect the target stage. (Default: true).
        /// </summary>
        [PodmanOption(Name = "skip-unused-stages")]
        public bool? SkipUnusedStages { get; set; }
        /// <summary>
        /// Squash all of the image’s new layers into a single new layer; any preexisting layers are not squashed.
        /// </summary>
        [PodmanOption(Name = "squash")]
        public bool? Squash { get; set; }
        /// <summary>
        /// Squash all of the new image’s layers (including those inherited from a base image) into a single new layer
        /// </summary>
        [PodmanOption(Name = "squash-all")]
        public bool? SquashAll { get; set; }
        /// <summary>
        /// SSH agent socket or keys to expose to the build. 
        /// The socket path can be left empty to use the value of default=$SSH_AUTH_SOCK
        /// </summary>
        [PodmanOption(Name = "ssh", Format = FormatType.CommaSeparatedValue)]
        public string[]? Ssh { get; set; }
        /// <summary>
        /// Pass stdin into the RUN containers. Sometime commands being RUN within a Containerfile want to request information from the user. 
        /// For example apt asking for a confirmation for install. 
        /// Use --stdin to be able to interact from the terminal during the build.
        /// </summary>
        [PodmanOption(Name = "stdin")]
        public bool? Stdin { get; set; }
        /// <summary>
        /// Specifies the name which is assigned to the resulting image if the build process completes successfully. 
        /// If imageName does not include a registry name, the registry name localhost is prepended to the image name.
        /// </summary>
        [PodmanOption(Name = "tag", Format = FormatType.Multiple)]
        public string[]? Tag { get; set; }
        /// <summary>
        /// Set the target build stage to build. When building a Containerfile with multiple build stages, --target can be used to specify an intermediate build stage by name as the final stage for the resulting image. 
        /// Commands after the target stage is skipped.
        /// </summary>
        [PodmanOption(Name = "target")]
        public string? Target { get; set; }
        /// <summary>
        /// Set the create timestamp to seconds since epoch to allow for deterministic builds (defaults to current time). 
        /// By default, the created timestamp is changed and written into the image manifest with every commit, causing the image’s sha256 hash to be different even if the sources are exactly the same otherwise. 
        /// When --timestamp is set, the created timestamp is always set to the time specified and therefore not changed, allowing the image’s sha256 hash to remain the same. 
        /// All files committed to the layers of the image is created with the timestamp.
        /// </summary>
        [PodmanOption(Name = "timestamp")]
        public int? Timestamp { get; set; }
        /// <summary>
        /// Require HTTPS and verify certificates when contacting registries (default: true).
        /// If explicitly set to true, TLS verification is used. 
        /// If set to false, TLS verification is not used.
        /// </summary>
        [PodmanOption(Name = "tls-verify")]
        public bool? TlsVerify { get; set; }
        /// <summary>
        /// Specifies resource limits to apply to processes launched when processing RUN instructions.
        /// </summary>
        [PodmanOption(Name = "ulimit")]
        public string? Ulimit { get; set; }
        /// <summary>
        /// Unset environment variables from the final image.
        /// </summary>
        [PodmanOption(Name = "unsetenv")]
        public string? UnsetEnv { get; set; }
        /// <summary>
        /// Unset the image label, causing the label not to be inherited from the base image.
        /// </summary>
        [PodmanOption(Name = "unsetlabel")]
        public string? UnsetLabel { get; set; }
        /// <summary>
        /// Sets the configuration for user namespaces when handling RUN instructions. 
        /// The configured value can be “” (the empty string) or “container” to indicate that a new user namespace is created, it can be “host” to indicate that the user namespace in which podman itself is being run is reused, or it can be the path to a user namespace which is already in use by another process.
        /// </summary>
        [PodmanOption(Name = "userns")]
        public string? Userns { get; set; }
        /// <summary>
        /// Directly specifies a GID mapping to be used to set ownership, at the filesystem level, on the working container’s contents. 
        /// Commands run when handling RUN instructions defaults to being run in their own user namespaces, configured using the UID and GID maps.
        /// </summary>
        [PodmanOption(Name = "userns-gid-map")]
        public string? UsernsGidMap { get; set; }
        /// <summary>
        /// Specifies that a GID mapping to be used to set ownership, at the filesystem level, on the working container’s contents, can be found in entries in the /etc/subgid file which correspond to the specified group. 
        /// </summary>
        [PodmanOption(Name = "userns-gid-map-group")]
        public string? UsernsGidMapGroup { get; set; }
        /// <summary>
        /// Directly specifies a UID mapping to be used to set ownership, at the filesystem level, on the working container’s contents. 
        /// Commands run when handling RUN instructions default to being run in their own user namespaces, configured using the UID and GID maps.
        /// </summary>
        [PodmanOption(Name = "userns-uid-map")]
        public string? UsernsUidMap { get; set; }
        /// <summary>
        /// Specifies that a UID mapping to be used to set ownership, at the filesystem level, on the working container’s contents, can be found in entries in the /etc/subuid file which correspond to the specified user. 
        /// </summary>
        [PodmanOption(Name = "userns-uid-map-user")]
        public string? UsernsUidMapUser { get; set; }
        /// <summary>
        /// Sets the configuration for UTS namespaces when handling RUN instructions. 
        /// The configured value can be “” (the empty string) or “container” to indicate that a new UTS namespace to be created, or it can be “host” to indicate that the UTS namespace in which podman itself is being run is reused, or it can be the path to a UTS namespace which is already in use by another process.
        /// </summary>
        [PodmanOption(Name = "uts")]
        public string? Uts { get; set; }
        /// <summary>
        /// Set the architecture variant of the image to be built, and that of the base image to be pulled, if the build uses one, to the provided value instead of using the architecture variant of the build host.
        /// </summary>
        [PodmanOption(Name = "variant")]
        public string? Variant { get; set; }
        /// <summary>
        /// Mount a host directory into containers when executing RUN instructions during the build.
        /// </summary>
        [PodmanOption(Name = "volume", Format = FormatType.CommaSeparatedValue, Quoted = true)]
        public string[]? Volume { get; set; }
    }
}