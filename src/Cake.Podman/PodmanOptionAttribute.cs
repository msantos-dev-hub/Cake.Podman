namespace Cake.Podman;

/// <summary>
/// Attribute used for PodmanOptions properties
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class PodmanOptionAttribute: Attribute
{
    /// <summary>
    /// Podman option name
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Podman option format
    /// </summary>
    public FormatType Format { get; set; } = FormatType.None;

    /// <summary>
    /// Podman option quoted
    /// </summary>
    public bool Quoted { get; set; } = false;

    /// <summary>
    /// Podman option secret
    /// </summary>
    public bool Secret { get; set; } = false;
}

/// <summary>
/// Format enum for multiple parameters
/// </summary>
public enum FormatType
{
    /// <summary>
    /// Used as default value
    /// </summary>    
    None,
    /// <summary>
    /// Used when the parameter can be setted multiple times
    /// </summary>
    Multiple,
    /// <summary>
    /// Used when the parameter can be separated by comma
    /// </summary>
    CommaSeparatedValue
}
