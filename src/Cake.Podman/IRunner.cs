#nullable enable
using System;
using Cake.Core.Tooling;

namespace Cake.Podman;

/// <summary>
/// Interface to implement the runner
/// </summary>
public interface IRunner<TOptions> where TOptions : ToolSettings
{
    /// <summary>
    /// Run the command
    /// </summary>
    /// <param name="command">The command</param>
    /// <param name="options">The custom options</param>
    /// <param name="arguments">The additional parameter</param>
    void Run(string command, TOptions options, IEnumerable<string>? arguments);

    /// <summary>
    /// Runs a command and returns a result
    /// </summary>
    /// <typeparam name="T">The type of the command</typeparam>
    /// <param name="command">The command</param>
    /// <param name="options">The settings</param>
    /// <param name="processOutput">The process output</param>
    /// <param name="arguments">The arguments</param>
    /// <returns></returns>
    T[] RunWithResult<T>(string command, TOptions options, Func<IEnumerable<string>, T[]> processOutput, IEnumerable<string>? arguments);
}
