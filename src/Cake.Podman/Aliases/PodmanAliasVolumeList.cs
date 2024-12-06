using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Podman.Factory;

namespace Cake.Podman.Aliases
{
    /// <summary>
    /// Alias for working with volume list command
    /// </summary>
    partial class PodmanAlias
    {
        /// <summary>
        /// Run volume list command
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static IEnumerable<string> PodmanVolumeList(this ICakeContext context, Commands.Volume.Ls.PodmanVolumeLsOptions options)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            return new PodmanRunnerFactory().CreateRunner<Commands.Volume.Ls.PodmanVolumeLsOptions>(context)
                .RunWithResult("volume ls",
                                options ?? new(),
                                proc => proc.ToArray(),
                                null);
        }
    }
}