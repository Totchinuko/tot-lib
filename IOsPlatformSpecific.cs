using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace tot_lib;

public interface IOsPlatformSpecific
{
    bool TryGetLogonRun(string appName, [NotNullWhen(true)] out string? data);
    bool SetLogonRun(string appName, string data);
    bool RemoveLogonRun(string appName);
    bool IsProcessElevated();
}

public static class OsPlatformSpecificExtensions
{
    public static bool HasLogonRun(this IOsPlatformSpecific os, string appName)
    {
        return os.TryGetLogonRun(appName, out _);
    }

    public static IOsPlatformSpecific GetOsPlatformSpecific()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return new OsPlatformWindows();
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return new OsPlatformLinux();
        throw new NotSupportedException("OS not supported");
    }
}