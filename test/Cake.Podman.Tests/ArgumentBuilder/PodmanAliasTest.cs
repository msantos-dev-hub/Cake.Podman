using System;
using Cake.Core;
using Cake.Podman.Extensions;
using Cake.Podman.Factory;

namespace Cake.Podman.Tests.ArgumentBuilder;

public static class PodmanAliasTest
{
    public static void PodmanTest(this ICakeContext context, PodmanTestOptions options, string argument)
    {
            new PodmanRunnerFactory().CreateRunner<PodmanTestOptions>(context)
                .Run("test", 
                     options ?? new(), 
                     new List<string>()
                        .Add<string>(argument));        
    }
}
