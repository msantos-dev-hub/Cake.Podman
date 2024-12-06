using System;
using Cake.Core;
using Cake.Core.Tooling;

namespace Cake.Podman.Factory;

/// <summary>
/// Interface to abstract the runner factory
/// </summary>
public interface IRunnerFactory
{
    /// <summary>
    /// Create the runner
    /// </summary>
    /// <typeparam name="TOptions">The type of the Podman Options</typeparam>
    /// <param name="context">The context</param>
    /// <returns>The runner</returns>
    IRunner<TOptions> CreateRunner<TOptions>(ICakeContext context) where TOptions : PodmanOptions, new();
}
