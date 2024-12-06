using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Commands.Network.Create
{
    /// <summary>
    /// Options for Podman Network Create command
    /// </summary>
    public sealed class PodmanNetworkCreateOptions : PodmanOptions
    {
        /// <summary>
        /// Disables the DNS plugin for this network which if enabled, can perform container to container name resolution.
        /// </summary>
        [PodmanOption(Name = "disable-dns")]
        public bool? DisableDns { get; set; }
        /// <summary>
        /// Set network-scoped DNS resolver/nameserver for containers in this network. 
        /// If not set, the host servers from /etc/resolv.conf is used. 
        /// </summary>
        [PodmanOption(Name = "dns")]
        public string? Dns { get; set; }
        /// <summary>
        /// Driver to manage the network. Currently bridge, macvlan and ipvlan are supported. 
        /// Defaults to bridge. 
        /// As rootless the macvlan and ipvlan driver have no access to the host network interfaces because rootless networking requires a separate network namespace.
        /// </summary>
        [PodmanOption(Name = "driver")]
        public string? Driver { get; set; }
        /// <summary>
        /// Define a gateway for the subnet. To provide a gateway address, a subnet option is required. 
        /// Can be specified multiple times.
        /// </summary>
        //[PodmanOption(Name = "gateway", Format = FormatType.Multiple)]
        public string[]? Gateway { get; set; }
        /// <summary>
        /// Ignore the create request if a network with the same name already exists instead of failing. 
        /// Note, trying to create a network with an existing name and different parameters does not change the configuration of the existing one.
        /// </summary>
        [PodmanOption(Name = "ignore")]
        public bool? Ignore { get; set; }
        /// <summary>
        /// This option maps the network_interface option in the network config, see podman network inspect. 
        /// Depending on the driver, this can have different effects; for bridge, it uses the bridge interface name.
        /// </summary>
        [PodmanOption(Name = "interface-name")]
        public string? InterfaceName { get; set; }
        /// <summary>
        /// Restrict external access of this network when using a bridge network.
        /// </summary>
        [PodmanOption(Name = "internal")]
        public bool? Internal { get; set; }
        /// <summary>
        /// Allocate container IP from a range. 
        /// </summary>
        //[PodmanOption(Name = "ip-range", Format = FormatType.Multiple)]
        public string[]? IpRange { get; set; }
        /// <summary>
        /// Set the ipam driver (IP Address Management Driver) for the network. 
        /// When unset podman chooses an ipam driver automatically based on the network driver
        /// </summary>
        [PodmanOption(Name = "ipam-driver")]
        public string? IpamDriver { get; set; }
        /// <summary>
        /// Enable IPv6 (Dual Stack) networking. 
        /// If no subnets are given, it allocates an ipv4 and an ipv6 subnet.
        /// </summary>
        [PodmanOption(Name = "ipv6")]
        public string? Ipv6 { get; set; }
        /// <summary>
        /// Set metadata for a network (e.g., --label mykey=value).
        /// </summary>
        [PodmanOption(Name = "label")]
        public string? Label { get; set; }
        /// <summary>
        /// Set driver specific options.
        /// All drivers accept the mtu, metric, no_default_route and options
        /// </summary>
        [PodmanOption(Name = "opt")]
        public string? Opt { get; set; }
        /// <summary>
        /// This route will be added to every container in this network. Only available with the netavark backend. 
        /// It can be specified multiple times if more than one static route is desired.
        /// </summary>
        [PodmanOption(Name = "route", Format = FormatType.Multiple)]
        public string[]? Route { get; set; }
        /// <summary>
        /// The subnet in CIDR notation. 
        /// Can be specified multiple times to allocate more than one subnet for this network.
        /// </summary>
        //[PodmanOption(Name = "subnet", Format = FormatType.Multiple)]
        public string[]? Subnet { get; set; }
    }
}