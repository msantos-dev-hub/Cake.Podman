#nullable enable
using System;
using Cake.Core;
using Cake.Podman.Commands.Image.Push;
using Cake.Podman.Factory;
using Cake.Podman.Extensions;

namespace Cake.Podman.Aliases;

/// <summary>
/// Alias for working with push command
/// </summary>
partial class PodmanAlias
{
    /// <summary>
    /// Run push command to container registry
    /// </summary>
    /// <param name="context"></param>
    /// <param name="destination"></param>
    public static void PodmanImagePush(this ICakeContext context, string destination)
    {
        PodmanImagePush(context, new(), null, destination);
    }

    /// <summary>
    /// Run push command to container registry with another tag
    /// </summary>
    /// <param name="context"></param>
    /// <param name="image"></param>
    /// <param name="destination"></param>
    public static void PodmanImagePush(this ICakeContext context, string image, string destination)
    {
        PodmanImagePush(context, new(), image, destination);
    }

    /// <summary>
    /// Run push command using custom options
    /// </summary>
    /// <param name="context"></param>
    /// <param name="options"></param>
    /// <param name="image"></param>
    /// <param name="destination"></param>
    public static void PodmanImagePush(this ICakeContext context, PodmanImagePushOptions options, string? image, string destination)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentException.ThrowIfNullOrEmpty(destination, nameof(destination));

        new PodmanRunnerFactory().CreateRunner<Commands.Image.Push.PodmanImagePushOptions>(context)
            .Run("image push",
                 options ?? new(),
                 new List<string>()
                    .AddIf(_ => !string.IsNullOrEmpty(image), image!)
                    .Add<string>(destination));
    }
}
