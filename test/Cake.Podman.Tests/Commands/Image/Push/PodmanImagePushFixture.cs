using System;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Podman.Aliases;
using Cake.Podman.Commands.Image.Push;
using Cake.Testing.Fixtures;

namespace Cake.Podman.Tests.Commands.Image.Push;

public class PodmanImagePushFixture : ToolFixture<PodmanImagePushOptions>, ICakeContext
{
    public enum PodmanPushEnum
    {
        ALL_ARGUMENTS,
        ALL_ARGUMENTS_WITH_OPTION,
        ONLY_DESTINATION_ARGUMENT,
        DESTINATION_WITH_OPTION
    }

    private readonly PodmanPushEnum _podmanPushEnum;

    public PodmanImagePushFixture(PodmanPushEnum fixture) : base("podman")
    {
        _podmanPushEnum = fixture;
    }

    public string? Image { get; set; }
    public string? Destination { get; set; }

    public ICakeLog Log => Log;

    public ICakeArguments Arguments => throw new NotImplementedException();

    public IRegistry Registry => Registry;

    public ICakeDataResolver Data => throw new NotImplementedException();

    IFileSystem ICakeContext.FileSystem => FileSystem;

    ICakeEnvironment ICakeContext.Environment => Environment;

    IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;

    ICakeConfiguration ICakeContext.Configuration => throw new NotImplementedException();

    protected override void RunTool()
    {
        switch (_podmanPushEnum)
        {
            case PodmanPushEnum.ALL_ARGUMENTS:
                this.PodmanImagePush(Image!, Destination!);
                break;
            case PodmanPushEnum.ALL_ARGUMENTS_WITH_OPTION:
                this.PodmanImagePush(Settings, Image, Destination!);
                break;
            case PodmanPushEnum.ONLY_DESTINATION_ARGUMENT:
                this.PodmanImagePush(Destination!);
                break;
            case PodmanPushEnum.DESTINATION_WITH_OPTION:
                this.PodmanImagePush(Settings, null, Destination!);
                break;                
            default:
                throw new NotImplementedException();
        }
    }
}
