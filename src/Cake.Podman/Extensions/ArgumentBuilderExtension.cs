#nullable enable
using Cake.Core.IO;
using Cake.Core;
using System.Reflection;
using System.Linq;

namespace Cake.Podman.Extensions;

/// <summary>
/// Extension for Argument builder
/// </summary>
public static class ArgumentBuilderExtension
{
    /// <summary>
    /// Appends all arguments from <paramref name="options"/>.
    /// </summary>
    /// <typeparam name="TOptions"></typeparam>
    /// <param name="builder"></param>
    /// <param name="options"></param>
    public static ProcessArgumentBuilder Append<TOptions>(this ProcessArgumentBuilder builder, TOptions options) where TOptions : PodmanOptions, new()
    {
        options ??= new TOptions();
        foreach (var property in typeof(TOptions).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            var optionAttribute = GetOptionAttribute(property);
            if (optionAttribute != null && property.GetValue(options) != null)
            {
                if (optionAttribute.Format == FormatType.Multiple)
                {
                    ((string[])property.GetValue(options)!).ToList().ForEach(o =>
                    {
                        if (optionAttribute.Quoted)
                        {
                            builder
                            .Append(GetOptionName(optionAttribute))
                            .AppendQuoted(GetArgument(o));
                        }
                        else
                        {
                            builder
                            .Append(GetOptionName(optionAttribute))
                            .Append(GetArgument(o));
                        }
                    });
                }
                else if (optionAttribute.Format == FormatType.CommaSeparatedValue)
                {
                    builder
                        .Append(GetOptionName(optionAttribute))
                        .Append(GetOptionArgument(property, options));

                }
                else if (optionAttribute.Quoted)
                {
                    builder
                        .Append(GetOptionName(optionAttribute))
                        .AppendQuoted(GetOptionArgument(property, options));
                }
                else if (optionAttribute.Secret)
                {
                    builder
                        .Append(GetOptionName(optionAttribute))
                        .AppendSecret(GetOptionArgument(property, options));
                }
                else
                {
                    builder
                        .Append(GetOptionName(optionAttribute))
                        .Append(GetOptionArgument(property, options));
                }

            }


        }
        return builder;
    }

    /// <summary>
    /// Appends all arguments from <paramref name="arguments"/>.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="arguments"></param>
    /// <returns></returns>
    public static ProcessArgumentBuilder Append(this ProcessArgumentBuilder builder, IEnumerable<string> arguments)
    {
        arguments.ToList().ForEach(arg => builder.Append(arg));
        return builder;
    }

    private static string? GetOptionArgument<TOptions>(PropertyInfo property, TOptions options) where TOptions : PodmanOptions, new()
    {
        if (property.PropertyType == typeof(bool))
        {
            return GetArgument((bool)property.GetValue(options)!);
        }
        else if (property.PropertyType == typeof(bool?))
        {
            return GetArgument((bool?)property.GetValue(options));
        }
        else if (property.PropertyType == typeof(int))
        {
            return GetArgument((int)property.GetValue(options)!);
        }
        else if (property.PropertyType == typeof(int?))
        {
            return GetArgument((int?)property.GetValue(options));
        }
        else if (property.PropertyType == typeof(Int64))
        {
            return GetArgument((Int64)property.GetValue(options)!);
        }
        else if (property.PropertyType == typeof(Int64?))
        {
            return GetArgument((Int64?)property.GetValue(options));
        }
        else if (property.PropertyType == typeof(string))
        {
            return GetArgument((string)property.GetValue(options)!);
        }
        else if (property.PropertyType == typeof(string[]))
        {
            return GetArgument(string.Join(",", (string[])property.GetValue(options)!));
        }
        else if (property.PropertyType == typeof(decimal))
        {
            return GetArgument((decimal)property.GetValue(options)!);
        }
        else if (property.PropertyType == typeof(decimal?))
        {
            return GetArgument((decimal?)property.GetValue(options));
        }        
        else
        {
            throw new NotImplementedException($"Property type not implemented: {property.Name}");
        }
    }

    private static PodmanOptionAttribute? GetOptionAttribute(PropertyInfo property) => property.GetCustomAttribute<PodmanOptionAttribute>();

    private static string GetOptionName(PodmanOptionAttribute optionAttribute) => $"--{optionAttribute.Name}";

    private static string? GetArgument(string? value) => !string.IsNullOrEmpty(value) ? value : null;
    private static string? GetArgument(bool? value) => null;
    private static string? GetArgument(int? value) => value.HasValue ? value.Value.ToString() : null;
    private static string? GetArgument(Int64? value) => value.HasValue ? value.Value.ToString() : null;
    private static string? GetArgument(decimal? value) => value.HasValue ? value.Value.ToString() : null;
}