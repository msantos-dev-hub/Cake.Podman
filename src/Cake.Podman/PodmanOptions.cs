using Cake.Core.Tooling;

namespace Cake.Podman;

/// <summary>
/// Base classe for podman command line options
/// </summary>
public abstract class PodmanOptions : ToolSettings
{
    /// <summary>
    /// Secret properties will not shown in output
    /// </summary>
    public readonly HashSet<string> SecretProperties;
    /// <summary>
    /// Initialize the options
    /// </summary>
    protected PodmanOptions() => SecretProperties = new HashSet<string>(CollectSecretProperties ?? Array.Empty<string>());
    /// <summary>
    /// Collect the secret properties
    /// </summary>
    /// <returns></returns>
    protected virtual string[]? CollectSecretProperties => null;

}
