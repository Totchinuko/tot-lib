using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;
using System.Security.Principal;
using Microsoft.Win32;

namespace tot_lib;

[SupportedOSPlatform("windows")]
public class OsPlatformWindows : IOsPlatformSpecific
{
    public bool TryGetLogonRun(string appName, [NotNullWhen(true)] out string? data)
    {
        data = null;
        try
        {
            var rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rk is null) return false;

            data = rk.GetValue(appName) as string;
            return data != null;
        }
        catch
        {
            return false;
        }
    }
    
    public bool SetLogonRun(string appName, string data)
    {
        try
        {
            var rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rk is null) return false;
            rk.SetValue(appName, data);
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public bool RemoveLogonRun(string appName)
    {
        try
        {
            var rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rk is null) return false;
            rk.DeleteValue(appName, throwOnMissingValue: false);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool IsProcessElevated()
    {
        return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
    }
}