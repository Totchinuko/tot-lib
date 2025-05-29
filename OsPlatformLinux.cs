using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;

namespace tot_lib;

[SupportedOSPlatform("linux")]
public class OsPlatformLinux : IOsPlatformSpecific
{
    public bool TryGetLogonRun(string appName, [NotNullWhen(true)] out string? data)
    {
        data = null;
        return false;
    }

    public bool SetLogonRun(string appName, string data)
    {
        return false;
    }

    public bool RemoveLogonRun(string appName)
    {
        return false;
    }

    public bool IsProcessElevated()
    {
        return false;
    }
}