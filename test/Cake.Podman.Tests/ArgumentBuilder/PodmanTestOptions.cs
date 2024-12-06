using System;

namespace Cake.Podman.Tests.ArgumentBuilder;

public class PodmanTestOptions : PodmanOptions
{
    [PodmanOption(Name = "bool-option")]
    public bool? BoolProperty { get; set; }
    [PodmanOption(Name = "int-option")]
    public int? IntProperty { get; set; }
    [PodmanOption(Name = "string-option")]
    public string? StringProperty { get; set; }
    [PodmanOption(Name = "array-multi-option", Format = FormatType.Multiple)]
    public string[]? StringArrayMultipleProperty { get; set; }
    [PodmanOption(Name = "array-csv-option", Format = FormatType.CommaSeparatedValue)]
    public string[]? StringArrayCsvProperty { get; set; }
}
