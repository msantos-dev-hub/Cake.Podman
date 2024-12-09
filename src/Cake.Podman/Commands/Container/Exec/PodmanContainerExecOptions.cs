#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Container.Exec
{
    /// <summary>
    /// Options for Podman Container Execute command
    /// </summary>    
    public sealed class PodmanContainerExecOptions : PodmanOptions
    {
        /// <summary>
        /// Start the exec session, but do not attach to it. 
        /// The command runs in the background, and the exec session is automatically removed when it completes. 
        /// The podman exec command prints the ID of the exec session and exits immediately after it starts.
        /// </summary>
        [PodmanOption(Name = "detach")]
        public bool? Detach { get; set; }
        /// <summary>
        /// Specify the key sequence for detaching a container. 
        /// Format is a single character or one or more ctrl-(value) characters where (value) is one of: a-z, @, ^, [, , or _. 
        /// Specifying “” disables this feature. 
        /// The default is ctrl-p,ctrl-q.
        /// </summary>
        [PodmanOption(Name = "detach-keys")]
        public string? DetachKeys { get; set; }
        /// <summary>
        /// This option allows arbitrary environment variables that are available for the process to be launched inside of the container. 
        /// If an environment variable is specified without a value, Podman checks the host environment for a value and set the variable only if it is set on the host. 
        /// As a special case, if an environment variable ending in * is specified without a value, Podman searches the host environment for variables starting with the prefix and adds those variables to the container.
        /// </summary>
        [PodmanOption(Name = "env", Format = FormatType.Multiple)]
        public string[]? Env { get; set; }
        /// <summary>
        /// Read in a line-delimited file of environment variables.
        /// </summary>
        [PodmanOption(Name = "env-file", Quoted = true)]
        public string? EnvFile { get; set; }
        /// <summary>
        /// Instead of providing the container name or ID, use the last created container. 
        /// Note: the last started container can be from other users of Podman on the host machine. 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "latest")]
        public bool? Latest { get; set; }
        /// <summary>
        /// Pass down to the process the additional file descriptors specified in the comma separated list. 
        /// It can be specified multiple times. 
        /// This option is only supported with the crun OCI runtime. 
        /// It might be a security risk to use this option with other OCI runtimes.
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "preserve-fd")]
        public string? PreserveFd { get; set; }
        /// <summary>
        /// Pass down to the process N additional file descriptors (in addition to 0, 1, 2). 
        /// The total FDs are 3+N. 
        /// (This option is not available with the remote Podman client, including Mac and Windows (excluding WSL2) machines)
        /// </summary>
        [PodmanOption(Name = "preserve-fds")]
        public string? PreserveFds { get; set; }
        /// <summary>
        /// Give extended privileges to this container. The default is false.
        /// </summary>
        [PodmanOption(Name = "privileged")]
        public bool? Privileged { get; set; }
        /// <summary>
        /// Allocate a pseudo-TTY. 
        /// The default is false.
        /// When set to true, Podman allocates a pseudo-tty and attach to the standard input of the container. 
        /// This can be used, for example, to run a throwaway interactive shell.
        /// </summary>
        [PodmanOption(Name = "tty")]
        public bool? Tty { get; set; }
        /// <summary>
        /// Sets the username or UID used and, optionally, the groupname or GID for the specified command. 
        /// Both user and group may be symbolic or numeric.
        /// </summary>
        [PodmanOption(Name = "user")]
        public string? User { get; set; }
        /// <summary>
        /// Working directory inside the container.
        /// The default working directory for running binaries within a container is the root directory (/). 
        /// The image developer can set a different default with the WORKDIR instruction. 
        /// The operator can override the working directory by using the -w option.
        /// </summary>
        [PodmanOption(Name = "workdir")]
        public string? Workdir { get; set; }
    }
}