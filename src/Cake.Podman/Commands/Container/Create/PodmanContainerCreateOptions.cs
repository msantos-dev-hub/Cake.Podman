using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Container.Create
{
    /// <summary>
    /// Options for Podman Container Create command
    /// </summary>    
    public sealed class PodmanContainerCreateOptions : PodmanOptions
    {
        /// <summary>
        /// Add a custom host-to-IP mapping (host:ip)
        /// </summary>
        [PodmanOption(Name = "add-host")]
        public string? AddHost { get; set; }
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
        /// Attach to STDIN, STDOUT or STDERR.
        /// </summary>
        [PodmanOption(Name = "attach")]
        public string? Attach { get; set; }
        /// <summary>
        /// Path of the authentication file. Default is ${XDG_RUNTIME_DIR}/containers/auth.json on Linux, and $HOME/.config/containers/auth.json on Windows/macOS. 
        /// The file is created by podman login.
        /// </summary>
        [PodmanOption(Name = "authfile", Quoted = true)]
        public string? Authfile { get; set; }
        /// <summary>
        /// Block IO relative weight. The weight is a value between 10 and 1000.
        /// This option is not supported on cgroups V1 rootless systems.
        /// </summary>
        [PodmanOption(Name = "blkio-weight")]
        public int? BlkioWeight { get; set; }
        /// <summary>
        /// Block IO relative device weight.
        /// </summary>
        [PodmanOption(Name = "blkio-weight-device")]
        public int? BlkioWieghtDevice { get; set; }
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
        /// When running on cgroup v2, specify the cgroup file to write to and its value. 
        /// For example --cgroup-conf=memory.high=1073741824 sets the memory.high limit to 1GB.
        /// </summary>
        [PodmanOption(Name = "cgroup-conf")]
        public string? CgroupConf { get; set; }
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
        /// Determines whether the container creates CGroups.
        /// </summary>
        [PodmanOption(Name = "cgroups")]
        public bool? Cgroups { get; set; }
        /// <summary>
        /// Path to a directory inside the container that is treated as a chroot directory. 
        /// Any Podman managed file (e.g., /etc/resolv.conf, /etc/hosts, etc/hostname) that is mounted into the root directory is mounted into that location as well. 
        /// Multiple directories are separated with a comma.
        /// </summary>
        [PodmanOption(Name = "chrootdirs", Format = FormatType.CommaSeparatedValue, Quoted = true)]
        public string[]? ChRootDirs { get; set; }
        /// <summary>
        /// Write the container ID to file. 
        /// The file is removed along with the container, except when used with podman --remote run on detached containers.
        /// </summary>
        [PodmanOption(Name = "cidfile", Quoted = true)]
        public string? CidFile { get; set; }
        /// <summary>
        /// Write the pid of the conmon process to a file. 
        /// As conmon runs in a separate process than Podman, this is necessary when using systemd to restart Podman containers. 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "conmon-pidfile", Quoted = true)]
        public string? ConmonPidFile { get; set; }
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
        public Int64? CpQuota { get; set; }
        /// <summary>
        /// Limit the CPU real-time period in microseconds.
        /// Limit the container’s Real Time CPU usage. 
        /// This option tells the kernel to restrict the container’s Real Time CPU usage to the period specified.
        /// This option is only supported on cgroups V1 rootful systems.
        /// </summary>
        [PodmanOption(Name = "cpu-rt-period")]
        public Int64? CpuRtPeriod { get; set; }
        /// <summary>
        /// Limit the CPU real-time runtime in microseconds.
        /// Limit the containers Real Time CPU usage. 
        /// This option tells the kernel to limit the amount of time in a given CPU period Real Time tasks may consume. 
        /// Ex: Period of 1,000,000us and Runtime of 950,000us means that this container can consume 95% of available CPU and leave the remaining 5% to normal priority tasks.
        /// </summary>
        [PodmanOption(Name = "cpu-rt-runtime")]
        public Int64? CpuRtRuntime { get; set; }
        /// <summary>
        /// By default, all containers get the same proportion of CPU cycles. 
        /// This proportion can be modified by changing the container’s CPU share weighting relative to the combined weight of all the running containers. 
        /// Default weight is 1024.
        /// The proportion only applies when CPU-intensive processes are running. 
        /// When tasks in one container are idle, other containers can use the left-over CPU time. 
        /// The actual amount of CPU time varies depending on the number of containers running on the system.
        /// </summary>
        [PodmanOption(Name = "cpu-shares")]
        public Int64? CpuShares { get; set; }        
        /// <summary>
        /// Number of CPUs. 
        /// The default is 0.0 which means no limit. 
        /// This is shorthand for --cpu-period and --cpu-quota, therefore the option cannot be specified with --cpu-period or --cpu-quota.
        /// </summary>
        [PodmanOption(Name = "cpus")]
        public decimal? Cpus { get; set; }
        /// <summary>
        /// CPUs in which to allow execution. 
        /// Can be specified as a comma-separated list (e.g. 0,1), as a range (e.g. 0-3), or any combination thereof (e.g. 0-3,7,11-15)
        /// This option is not supported on cgroups V1 rootless systems.
        /// </summary>
        [PodmanOption(Name = "cpuset-cpus", Format = FormatType.CommaSeparatedValue)]
        public string[]? CpusetCpus { get; set; }
        /// <summary>
        /// Memory nodes (MEMs) in which to allow execution (0-3, 0,1). 
        /// Only effective on NUMA systems.
        /// If there are four memory nodes on the system (0-3), use --cpuset-mems=0,1 then processes in the container only uses memory from the first two memory nodes.
        /// This option is not supported on cgroups V1 rootless systems.
        /// </summary>
        [PodmanOption(Name = "cpuset-mems", Format = FormatType.CommaSeparatedValue)]
        public string[]? CpusetMems { get; set; }        
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
        /// Add a rule to the cgroup allowed devices list. 
        /// </summary>
        [PodmanOption(Name = "device-cgroup-rule")]
        public string? DeviceCgroupRule { get; set; }
        /// <summary>
        /// Limit read rate (in bytes per second) from a device (e.g. --device-read-bps=/dev/sda:1mb).
        /// </summary>
        [PodmanOption(Name = "device-read-bps")]
        public string? DeviceReadBps { get; set; }
        /// <summary>
        /// Limit read rate (in IO operations per second) from a device (e.g. --device-read-iops=/dev/sda:1000).
        /// </summary>
        [PodmanOption(Name = "device-read-iops")]
        public string? DeviceReadIops { get; set; }
        /// <summary>
        /// Limit write rate (in bytes per second) to a device (e.g. --device-write-bps=/dev/sda:1mb).
        /// </summary>
        [PodmanOption(Name = "device-write-bps")]
        public string? DeviceWriteBps { get; set; }
        /// <summary>
        /// Limit write rate (in IO operations per second) to a device (e.g. --device-write-iops=/dev/sda:1000).
        /// </summary>
        [PodmanOption(Name = "device-write-iops")]
        public string? DeviceWriteIops { get; set; }
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
        /// Override the default ENTRYPOINT from the image.
        /// </summary>
        [PodmanOption(Name = "entrypoint")]
        public string? Entrypoint { get; set; }
        /// <summary>
        /// Set environment variables.
        /// </summary>
        [PodmanOption(Name = "env", Format = FormatType.Multiple)]
        public string[]? Env { get; set; }
        /// <summary>
        /// Read in a line-delimited file of environment variables.
        /// </summary>
        [PodmanOption(Name = "env-file", Quoted = true)]
        public string? EnvFile { get; set; }
        /// <summary>
        /// Use host environment inside of the container. See Environment note below for precedence. 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "env-host")]
        public bool? EnvHost { get; set; }
        /// <summary>
        /// Preprocess default environment variables for the containers. 
        /// For example if image contains environment variable hello=world user can preprocess it using --env-merge hello=${hello}-some so new value is hello=world-some.
        /// </summary>
        [PodmanOption(Name = "env-merge", Format = FormatType.Multiple)]
        public string[]? EnvMerge { get; set; }
        /// <summary>
        /// Expose a port or a range of ports (e.g. --expose=3300-3310). 
        /// The protocol can be tcp, udp or sctp and if not given tcp is assumed. 
        /// This option matches the EXPOSE instruction for image builds and has no effect on the actual networking rules unless -P/--publish-all is used to forward to all exposed ports from random host ports. 
        /// To forward specific ports from the host into the container use the -p/--publish option instead.
        /// </summary>
        [PodmanOption(Name = "expose", Format = FormatType.Multiple)]
        public string[]? Expose { get; set; }
        /// <summary>
        /// Run the container in a new user namespace using the supplied GID mapping. 
        /// This option conflicts with the --userns and --subgidname options. 
        /// This option provides a way to map host GIDs to container GIDs in the same way as --uidmap maps host UIDs to container UIDs. For details see --uidmap.
        /// </summary>
        [PodmanOption(Name = "gidmap")]
        public string? Gidmap { get; set; }
        /// <summary>
        /// GPU devices to add to the container (‘all’ to pass all GPUs) Currently only Nvidia devices are supported.
        /// </summary>
        [PodmanOption(Name = "gpus")]
        public string? Gpus { get; set; }
        /// <summary>
        /// Assign additional groups to the primary user running within the container process.
        /// </summary>
        [PodmanOption(Name = "group-add", Format = FormatType.Multiple)]
        public string[]? GroupAdd { get; set; }        
        /// <summary>
        /// Customize the entry that is written to the /etc/group file within the container when --user is used.
        /// </summary>
        [PodmanOption(Name = "group-entry")]
        public string? GroupEntry { get; set; }
        /// <summary>
        /// Set or alter a healthcheck command for a container. 
        /// The command is a command to be executed inside the container that determines the container health. 
        /// The command is required for other healthcheck options to be applied. 
        /// A value of none disables existing healthchecks.
        /// </summary>
        [PodmanOption(Name = "heath-cmd")]
        public string? HealthCmd { get; set; }
        /// <summary>
        /// Set an interval for the healthchecks. An interval of disable results in no automatic timer setup. 
        /// The default is 30s.
        /// </summary>
        [PodmanOption(Name = "heath-interval")]
        public int? HealthInterval { get; set; }
        /// <summary>
        /// Action to take once the container transitions to an unhealthy state. 
        /// The default is none.
        /// </summary>
        [PodmanOption(Name = "health-on-failure")]
        public string? HealthOnFailure { get; set; }
        /// <summary>
        /// The number of retries allowed before a healthcheck is considered to be unhealthy. 
        /// The default value is 3.
        /// </summary>
        [PodmanOption(Name = "health-retries")]
        public int? HealthRetries { get; set; }
        /// <summary>
        /// The initialization time needed for a container to bootstrap. 
        /// The value can be expressed in time format like 2m3s. The default value is 0s.
        /// </summary>
        [PodmanOption(Name = "health-start-period")]
        public string? HealthStartPeriod { get; set; }
        /// <summary>
        /// Set a startup healthcheck command for a container. 
        /// This command is executed inside the container and is used to gate the regular healthcheck. 
        /// When the startup command succeeds, the regular healthcheck begins and the startup healthcheck ceases.
        /// </summary>
        [PodmanOption(Name = "health-startup-cmd")]
        public string? HealthStartupCmd { get; set; }
        /// <summary>
        /// Set an interval for the startup healthcheck. An interval of disable results in no automatic timer setup. 
        /// The default is 30s.
        /// </summary>
        [PodmanOption(Name = "health-startup-interval")]
        public int? HealthStartupInterval { get; set; }
        /// <summary>
        /// The number of attempts allowed before the startup healthcheck restarts the container. 
        /// If set to 0, the container is never restarted. 
        /// The default is 0.
        /// </summary>
        [PodmanOption(Name = "health-startup-retries")]
        public int? HealthStartupRetries { get; set; }
        /// <summary>
        /// The number of successful runs required before the startup healthcheck succeeds and the regular healthcheck begins. 
        /// A value of 0 means that any success begins the regular healthcheck. 
        /// The default is 0.
        /// </summary>
        [PodmanOption(Name = "health-startup-success")]
        public int? HealthStartupSuccess { get; set; }
        /// <summary>
        /// The maximum time a startup healthcheck command has to complete before it is marked as failed. 
        /// The value can be expressed in a time format like 2m3s. 
        /// The default value is 30s.
        /// </summary>
        [PodmanOption(Name = "health-startup-timeout")]
        public string? HealthStartupTimeout { get; set; }
        /// <summary>
        /// The maximum time allowed to complete the healthcheck before an interval is considered failed. 
        /// Like start-period, the value can be expressed in a time format such as 1m22s. 
        /// The default value is 30s.
        /// </summary>
        [PodmanOption(Name = "health-timeout")]
        public string? HealthTimeout { get; set; }
        /// <summary>
        /// Container host name
        /// </summary>
        [PodmanOption(Name = "hostname")]
        public string? Hostname { get; set; }
        /// <summary>
        /// Add a user account to /etc/passwd from the host to the container. 
        /// The Username or UID must exist on the host system.
        /// </summary>
        [PodmanOption(Name = "hostuser")]
        public string? Hostuser { get; set; }
        /// <summary>
        /// By default proxy environment variables are passed into the container if set for the Podman process.
        /// </summary>
        [PodmanOption(Name = "http-proxy")]
        public bool? HttpProxy { get; set; }
        /// <summary>
        /// Tells Podman how to handle the builtin image volumes. Default is bind.
        /// </summary>
        [PodmanOption(Name = "image-volume")]
        public string? ImageVolume { get; set; }
        /// <summary>
        /// Run an init inside the container that forwards signals and reaps processes. 
        /// The container-init binary is mounted at /run/podman-init. 
        /// Mounting over /run breaks container execution.
        /// </summary>
        [PodmanOption(Name = "init")]
        public bool? Init { get; set; }
        /// <summary>
        /// (Pods only). 
        /// When using pods, create an init style container, which is run after the infra container is started but before regular pod containers are started. 
        /// Init containers are useful for running setup operations for the pod’s applications.
        /// </summary>
        [PodmanOption(Name = "init-ctr")]
        public string? InitCtr { get; set; }
        /// <summary>
        /// Path to the container-init binary.
        /// </summary>
        [PodmanOption(Name = "init-path", Quoted = true)]
        public string? InitPath { get; set; }
        /// <summary>
        /// Specify a static IPv4 address for the container, for example 10.88.64.128. 
        /// This option can only be used if the container is joined to only a single network - i.e., --network=network-name is used at most once - and if the container is not joining another container’s network namespace via --network=container:id. The address must be within the network’s IP address pool (default 10.88.0.0/16).
        /// To specify multiple static IP addresses per container, set multiple networks using the --network option with a static IP address specified for each using the ip mode for that option.
        /// </summary>
        [PodmanOption(Name = "ip", Format = FormatType.Multiple)]
        public string[]? Ip { get; set; }
        /// <summary>
        /// Specify a static IPv6 address for the container, for example fd46:db93:aa76:ac37::10. 
        /// This option can only be used if the container is joined to only a single network - i.e., --network=network-name is used at most once - and if the container is not joining another container’s network namespace via --network=container:id. 
        /// The address must be within the network’s IPv6 address pool.
        /// </summary>
        [PodmanOption(Name = "ip6", Format = FormatType.Multiple)]
        public string[]? Ip6 { get; set; }
        /// <summary>
        /// Sets the configuration for IPC namespaces when handling RUN instructions. 
        /// The configured value can be “” (the empty string) or “container” to indicate that a new IPC namespace is created, or it can be “host” to indicate that the IPC namespace
        /// </summary>
        [PodmanOption(Name = "ipc")]
        public string? Ipc { get; set; }      
        /// <summary>
        /// Add metadata to a container.
        /// </summary>
        [PodmanOption(Name = "label")]
        public string? Label { get; set; }          
        /// <summary>
        /// Read in a line-delimited file of labels.
        /// </summary>
        [PodmanOption(Name = "label-file", Quoted = true)]
        public string? LabelFile { get; set; }
        /// <summary>
        /// Logging driver for the container. 
        /// Currently available options are k8s-file, journald, none, passthrough and passthrough-tty, with json-file aliased to k8s-file for scripting compatibility. 
        /// (Default journald).
        /// </summary>
        [PodmanOption(Name = "log-driver")]
        public string? LogDriver { get; set; }
        /// <summary>
        /// Logging driver specific options.
        /// This option is currently supported only by the journald log driver.
        /// </summary>
        [PodmanOption(Name = "log-opt")]
        public string? LogOpt { get; set; }
        /// <summary>
        /// Container network interface MAC address (e.g. 92:d0:c6:0a:29:33) 
        /// This option can only be used if the container is joined to only a single network - i.e., --network=network-name is used at most once - and if the container is not joining another container’s network namespace via --network=container:id.
        /// </summary>
        [PodmanOption(Name = "mac-address")]
        public string? MacAddress { get; set; }
        /// <summary>
        /// Memory limit. A unit can be b (bytes), k (kibibytes), m (mebibytes), or g (gibibytes).
        /// This option is not supported on cgroups V1 rootless systems.
        /// </summary>
        [PodmanOption(Name = "memory")]
        public string? Memory { get; set; }
        /// <summary>
        /// Memory soft limit. A unit can be b (bytes), k (kibibytes), m (mebibytes), or g (gibibytes).
        /// After setting memory reservation, when the system detects memory contention or low memory, containers are forced to restrict their consumption to their reservation. 
        /// So always set the value below --memory, otherwise the hard limit takes precedence. By default, memory reservation is the same as memory limit.
        /// </summary>
        [PodmanOption(Name = "memory-reservation")]
        public string? MemoryReservation { get; set; }
        /// <summary>
        /// A limit value equal to memory plus swap. A unit can be b (bytes), k (kibibytes), m (mebibytes), or g (gibibytes).
        /// </summary>
        [PodmanOption(Name = "memory-swap")]
        public string? MemorySwap { get; set; }
        /// <summary>
        /// Tune a container’s memory swappiness behavior. Accepts an integer between 0 and 100.
        /// This flag is only supported on cgroups V1 rootful systems.
        /// </summary>
        [PodmanOption(Name = "memory-swappiness")]
        public short? MemorySwapiness { get; set; }
        /// <summary>
        /// Attach a filesystem mount to the container
        /// Current supported mount TYPEs are bind, devpts, glob, image, ramfs, tmpfs and volume.
        /// </summary>
        [PodmanOption(Name = "mount")]
        public string? Mount { get; set; }
        /// <summary>
        /// Assign a name to the container.
        /// </summary>
        [PodmanOption(Name = "name")]
        public string? Name { get; set; }
        /// <summary>
        /// Sets the configuration for network namespaces when handling RUN instructions.
        /// </summary>
        [PodmanOption(Name = "network")]
        public string? Network { get; set; }
        /// <summary>
        /// Add a network-scoped alias for the container, setting the alias for all networks that the container joins. 
        /// </summary>
        [PodmanOption(Name = "network-alias")]
        public string? NetworkAlias { get; set; }
        /// <summary>
        /// Disable any defined healthchecks for container.
        /// </summary>
        [PodmanOption(Name = "no-healthcheck")]
        public bool? NoHealthcheck { get; set; }
        /// <summary>
        /// Do not create /etc/hosts for the container. 
        /// By default, Podman manages /etc/hosts, adding the container’s own IP address and any hosts from --add-host. --no-hosts disables this, and the image’s /etc/hosts is preserved unmodified.
        /// </summary>
        [PodmanOption(Name = "no-hosts")]
        public bool? NoHosts { get; set; }
        /// <summary>
        /// Whether to disable OOM Killer for the container or not.
        /// This flag is not supported on cgroups V2 systems.
        /// </summary>
        [PodmanOption(Name = "oom-kill-disable")]
        public bool? OomKillDisable { get; set; }
        /// <summary>
        /// Tune the host’s OOM preferences for containers (accepts values from -1000 to 1000).
        /// </summary>
        [PodmanOption(Name = "oom-score-adj")]
        public int? OomScoreAdj { get; set; }
        /// <summary>
        /// Override the OS, defaults to hosts, of the image to be pulled. 
        /// For example, windows. Unless overridden, subsequent lookups of the same image in the local storage matches this OS, regardless of the host.
        /// </summary>
        [PodmanOption(Name = "os")]
        public string? Os { get; set; }
        /// <summary>
        /// Customize the entry that is written to the /etc/passwd file within the container when --passwd is used.
        /// </summary>
        [PodmanOption(Name = "passwd-entry")]
        public string? PasswdEntry { get; set; }
        /// <summary>
        /// Personality sets the execution domain via Linux personality(2).
        /// </summary>
        [PodmanOption(Name = "personality")]
        public string? Personality { get; set; }
        /// <summary>
        /// Set the PID namespace mode for the container. 
        /// The default is to create a private PID namespace for the container.
        /// </summary>
        [PodmanOption(Name = "pid")]
        public string? Pid { get; set; }
        /// <summary>
        /// When the pidfile location is specified, the container process’ PID is written to the pidfile. 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines) 
        /// If the pidfile option is not specified, the container process’ PID is written to /run/containers/storage/${storage-driver}-containers/$CID/userdata/pidfile.
        /// </summary>
        [PodmanOption(Name = "pidfile", Quoted = true)]
        public string? Pidfile { get; set; }
        /// <summary>
        /// Tune the container’s pids limit. 
        /// Set to -1 to have unlimited pids for the container. 
        /// The default is 2048 on systems that support “pids” cgroup controller.
        /// </summary>
        [PodmanOption(Name = "pids-limit")]
        public int? PidsLimit { get; set; }
        /// <summary>
        /// Specify the platform for selecting the image. (Conflicts with --arch and --os) 
        /// The --platform option can be used to override the current architecture and operating system. Unless overridden, subsequent lookups of the same image in the local storage matches this platform, regardless of the host.
        /// </summary>
        [PodmanOption(Name = "platform")]
        public string? Platform { get; set; }
        /// <summary>
        /// Run container in an existing pod. Podman makes the pod automatically if the pod name is prefixed with new:. 
        /// To make a pod with more granular options, use the podman pod create command before creating a container. 
        /// When a container is run with a pod with an infra-container, the infra-container is started first.
        /// </summary>
        [PodmanOption(Name = "pod")]
        public string? Pod { get; set; }
        /// <summary>
        /// Run container in an existing pod and read the pod’s ID from the specified file. 
        /// When a container is run within a pod which has an infra-container, the infra-container starts first.
        /// </summary>
        [PodmanOption(Name = "pod-id-file", Quoted = true)]
        public string? PodIdFile { get; set; }
        /// <summary>
        /// Give extended privileges to this container. The default is false.
        /// By default, Podman containers are unprivileged (=false) and cannot, for example, modify parts of the operating system. 
        /// This is because by default a container is only allowed limited access to devices. 
        /// A “privileged” container is given the same access to devices as the user launching the container, with the exception of virtual consoles (/dev/tty\d+) when running in systemd mode (--systemd=always).
        /// </summary>
        [PodmanOption(Name = "privileged")]
        public bool? Privileged { get; set; }
        /// <summary>
        /// Publish a container’s port, or range of ports, to the host.
        /// Both hostPort and containerPort can be specified as a range of ports. 
        /// When specifying ranges for both, the number of container ports in the range must match the number of host ports in the range.
        /// </summary>
        [PodmanOption(Name = "publish", Format = FormatType.Multiple)]
        public string[]? Publish { get; set; }
        /// <summary>
        /// Publish all exposed ports to random ports on the host interfaces. The default is false.
        /// When set to true, publish all exposed ports to the host interfaces. 
        /// If the operator uses -P (or -p) then Podman makes the exposed port accessible on the host and the ports are available to any client that can reach the host.
        /// </summary>
        [PodmanOption(Name = "publish-all")]
        public bool? PublishAll { get; set; }
        /// <summary>
        /// Pull image policy. The default is missing.
        /// </summary>
        [PodmanOption(Name = "pull")]
        public string? Pull { get; set; }
        /// <summary>
        /// Rdt-class sets the class of service (CLOS or COS) for the container to run in.
        /// </summary>
        [PodmanOption(Name = "rdt-class")]
        public string? RdtClass { get; set; }
        /// <summary>
        /// Mount the container’s root filesystem as read-only.
        /// By default, container root filesystems are writable, allowing processes to write files anywhere. 
        /// By specifying the --read-only flag, the containers root filesystem are mounted read-only prohibiting any writes.
        /// </summary>
        [PodmanOption(Name = "read-only")]
        public bool? ReadOnly { get; set; }
        /// <summary>
        /// When running --read-only containers, mount a read-write tmpfs on /dev, /dev/shm, /run, /tmp, and /var/tmp. 
        /// The default is true.
        /// </summary>
        [PodmanOption(Name = "read-only-tmpfs")]
        public bool? ReadOnlyTmpfs { get; set; }
        /// <summary>
        /// If another container with the same name already exists, replace and remove it. 
        /// The default is false.
        /// </summary>
        [PodmanOption(Name = "replace")]
        public bool? Replace { get; set; }
        /// <summary>
        /// Specify one or more requirements. A requirement is a dependency container that is started before this container. 
        /// Containers can be specified by name or ID, with multiple containers being separated by commas.
        /// </summary>
        [PodmanOption(Name = "requires")]
        public string? Requires { get; set; }
        /// <summary>
        /// Restart policy to follow when containers exit. 
        /// Restart policy does not take effect if a container is stopped via the podman kill or podman stop commands.
        /// </summary>
        [PodmanOption(Name = "restart")]
        public string? Restart { get; set; }
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
        /// Automatically remove the container and any anonymous unnamed volume associated with the container when it exits. 
        /// The default is false.
        /// </summary>
        [PodmanOption(Name = "rm")]
        public bool? Rm { get; set; }
        /// <summary>
        /// If specified, the first argument refers to an exploded container on the file system.
        /// This is useful to run a container without requiring any image management, the rootfs of the container is assumed to be managed externally.
        /// </summary>
        [PodmanOption(Name = "rootfs")]
        public string? Rootfs { get; set; }
        /// <summary>
        /// Determines how to use the NOTIFY_SOCKET, as passed with systemd and Type=notify.
        /// </summary>
        [PodmanOption(Name = "sdnotify")]
        public string? Sdnotify { get; set; }
        /// <summary>
        /// Give the container access to a secret. Can be specified multiple times.
        /// </summary>
        [PodmanOption(Name = "secret", Format = FormatType.CommaSeparatedValue)]
        public string[]? Secret { get; set; }
        /// <summary>
        /// Security Options
        /// </summary>
        [PodmanOption(Name = "security-opt")]
        public string? SecurityOpt { get; set; }
        /// <summary>
        /// Size of /dev/shm. A unit can be b (bytes), k (kibibytes), m (mebibytes), or g (gibibytes). If the unit is omitted, the system uses bytes. 
        /// If the size is omitted, the default is 64m. When size is 0, there is no limit on the amount of memory used for IPC by the container. 
        /// This option conflicts with --ipc=host.
        /// </summary>
        [PodmanOption(Name = "shm-size")]
        public string? ShmSize { get; set; }
        /// <summary>
        /// Size of systemd-specific tmpfs mounts such as /run, /run/lock, /var/log/journal and /tmp. 
        /// A unit can be b (bytes), k (kibibytes), m (mebibytes), or g (gibibytes). 
        /// If the unit is omitted, the system uses bytes. 
        /// If the size is omitted, the default is 64m. When size is 0, the usage is limited to 50% of the host’s available memory.
        /// </summary>
        [PodmanOption(Name = "shm-size-systemd")]
        public string? ShmSizeSystemd { get; set; }
        /// <summary>
        /// Signal to stop a container. Default is SIGTERM.
        /// </summary>
        [PodmanOption(Name = "stop-signal")]
        public string? StopSignal { get; set; }
        /// <summary>
        /// Timeout to stop a container. Default is 10. 
        /// Remote connections use local containers.conf for defaults.
        /// </summary>
        [PodmanOption(Name = "stop-timeout")]
        public int? StopTimeout { get; set; }
        /// <summary>
        /// Run the container in a new user namespace using the map with name in the /etc/subgid file. 
        /// If running rootless, the user needs to have the right to use the mapping. 
        /// See subgid(5). This flag conflicts with --userns and --gidmap.
        /// </summary>
        [PodmanOption(Name = "subgidname")]
        public string? Subgidname { get; set; }
        /// <summary>
        /// Run the container in a new user namespace using the map with name in the /etc/subuid file. 
        /// If running rootless, the user needs to have the right to use the mapping. See subuid(5). 
        /// This flag conflicts with --userns and --uidmap.
        /// </summary>
        [PodmanOption(Name = "subuidname")]
        public string? Subuidname { get; set; }
        /// <summary>
        /// Configure namespaced kernel parameters at runtime.
        /// </summary>
        [PodmanOption(Name = "sysctl")]
        public string? SysCtl { get; set; }
        /// <summary>
        /// Run container in systemd mode. 
        /// The default is true.
        /// </summary>
        [PodmanOption(Name = "systemd")]
        public bool? Systemd { get; set; }
        /// <summary>
        /// Maximum time a container is allowed to run before conmon sends it the kill signal. 
        /// By default containers run until they exit or are stopped by podman stop.
        /// </summary>
        [PodmanOption(Name = "timeout")]
        public int? Timeout { get; set; }
        /// <summary>
        /// Require HTTPS and verify certificates when contacting registries (default: true). 
        /// If explicitly set to true, TLS verification is used. If set to false, TLS verification is not used. 
        /// If not specified, TLS verification is used unless the target registry is listed as an insecure registry in containers-registries.conf(5)
        /// </summary>
        [PodmanOption(Name = "tls-verify")]
        public bool? TlsVerify { get; set; }
        /// <summary>
        /// Create a tmpfs mount.
        /// </summary>
        [PodmanOption(Name = "tmpfs")]
        public string? Tmpfs { get; set; }
        /// <summary>
        /// Allocate a pseudo-TTY. 
        /// The default is false
        /// </summary>
        [PodmanOption(Name = "tty")]
        public bool? Tty { get; set; }
        /// <summary>
        /// Set timezone in container. This flag takes area-based timezones, GMT time, as well as local, which sets the timezone in the container to match the host machine. 
        /// See /usr/share/zoneinfo/ for valid timezones. 
        /// Remote connections use local containers.conf for defaults
        /// </summary>
        [PodmanOption(Name = "tz")]
        public string? Tz { get; set; }
        /// <summary>
        /// Run the container in a new user namespace using the supplied UID mapping. 
        /// This option conflicts with the --userns and --subuidname options. 
        /// This option provides a way to map host UIDs to container UIDs. 
        /// It can be passed several times to map different ranges.
        /// </summary>
        [PodmanOption(Name = "uidmap")]
        public string? Uidmap { get; set; }
        /// <summary>
        /// Ulimit options. 
        /// Sets the ulimits values inside of the container.
        /// </summary>
        [PodmanOption(Name = "ulimit")]
        public string? Ulimit { get; set; }
        /// <summary>
        /// Set the umask inside the container. 
        /// Defaults to 0022. 
        /// Remote connections use local containers.conf for defaults
        /// </summary>
        [PodmanOption(Name = "umask")]
        public string? Umask { get; set; }
        /// <summary>
        /// Unset default environment variables for the container. 
        /// Default environment variables include variables provided natively by Podman, environment variables configured by the image, and environment variables from containers.conf.
        /// </summary>
        [PodmanOption(Name = "unsetenv")]
        public string? Unsetenv { get; set; }
        /// <summary>
        /// Unset all default environment variables for the container. 
        /// Default environment variables include variables provided natively by Podman, environment variables configured by the image, and environment variables from containers.conf.
        /// </summary>
        [PodmanOption(Name = "unsetenv-all")]
        public bool? UnsetenvAll { get; set; }
        /// <summary>
        /// Sets the username or UID used and, optionally, the groupname or GID for the specified command. 
        /// Both user and group may be symbolic or numeric.
        /// </summary>
        [PodmanOption(Name = "user")]
        public string? User { get; set; }
        /// <summary>
        /// Set the user namespace mode for the container.
        /// </summary>
        [PodmanOption(Name = "userns")]
        public string? Userns { get; set; }
        /// <summary>
        /// Set the UTS namespace mode for the container. 
        /// The following values are supported:
        /// </summary>
        [PodmanOption(Name = "uts")]
        public string? Uts { get; set; }
        /// <summary>
        /// Use VARIANT instead of the default architecture variant of the container image. 
        /// Some images can use multiple variants of the arm architectures, such as arm/v5 and arm/v7.
        /// </summary>
        [PodmanOption(Name = "variant")]
        public string? Variant { get; set; }
        /// <summary>
        /// Create a bind mount. 
        /// If -v /HOST-DIR:/CONTAINER-DIR is specified, Podman bind mounts /HOST-DIR from the host into /CONTAINER-DIR in the Podman container.
        /// </summary>
        [PodmanOption(Name = "volume")]
        public string? Volume { get; set; }
        /// <summary>
        /// Mount volumes from the specified container(s). 
        /// Used to share volumes between containers. 
        /// The options is a comma-separated list with the following available elements:
        /// </summary>
        [PodmanOption(Name = "volumes-from")]
        public string? VolumesFrom { get; set; }
        /// <summary>
        /// Working directory inside the container.
        /// </summary>
        [PodmanOption(Name = "workdir")]
        public string? Workdir { get; set; }
    }
}