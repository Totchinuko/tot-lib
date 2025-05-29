using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;

namespace tot_lib.OsSpecific;

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

    public void RemoveSymbolicLink(string path)
    {
    }

    public void MakeSymbolicLink(string path, string targetPath)
    {
    }

    public bool IsSymbolicLink(string path)
    {
        return false;
    }

    public string GetSymbolicLinkTarget(string path)
    {
        return string.Empty;
    }
}