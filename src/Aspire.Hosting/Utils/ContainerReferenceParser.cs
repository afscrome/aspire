// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System.Text.RegularExpressions;

namespace Aspire.Hosting.Utils;

/// <summary>
/// Class to parse container references (e.g. "mcr.microsoft.com/dotnet/sdk:8.0")
/// </summary>
internal partial class ContainerReferenceParser
{
    public static ContainerReference Parse(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentOutOfRangeException(nameof(input), "repository name must have at least one component");
        }

        var match = ImageNameRegex().Match(input);

        if (!match.Success)
        {
            throw new ArgumentOutOfRangeException(nameof(input), input, "invalid reference format: could not parse container image name");
        }

        return new(
            GetGroupValueOrDefault(match.Groups["registry"]),
            match.Groups["image"].Value,
            GetGroupValueOrDefault(match.Groups["tag"]),
            GetGroupValueOrDefault(match.Groups["digest"])
            );

        static string? GetGroupValueOrDefault(Group group)
            => group.Success ? group.Value : default;
    }

    [GeneratedRegex("^((?<registry>((localhost|\\[(?:[a-fA-F0-9:]+)\\]|([\\w-]+(\\.[\\w-]+)+))(:\\d+)?)|([\\w-]+:\\d+))\\/)?(?<image>[\\w-./<>]+)(:(?<tag>[\\w-.<>]+))?(@(?<digest>.+))?$")]
    private static partial Regex ImageNameRegex();
}

internal record struct ContainerReference(string? Registry, string Image, string? Tag, string? Digest)
{
}
