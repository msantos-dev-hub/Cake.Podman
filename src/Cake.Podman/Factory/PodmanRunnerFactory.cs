using System;
using Cake.Core;
using Cake.Core.Tooling;

namespace Cake.Podman.Factory;

/// <summary>
/// Factory that create the podman Runner
/// </summary>
public class PodmanRunnerFactory : IRunnerFactory
{
    /// <summary>
    /// Create the runner
    /// </summary>
    /// <typeparam name="TOptions">The type of podman options</typeparam>
    /// <param name="context">The context</param>
    /// <returns>return the runner</returns>
    public IRunner<TOptions> CreateRunner<TOptions>(ICakeContext context) where TOptions : PodmanOptions, new()
    {
        return new PodmanRunner<TOptions>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
    }
}
