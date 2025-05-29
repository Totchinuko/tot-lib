using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;
using System.Security.Principal;
using Microsoft.Win32;

namespace tot_lib.OsSpecific;

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

    public void RemoveSymbolicLink(string path)
    {
        if (Directory.Exists(path) && File.GetAttributes(path).HasFlag(FileAttributes.ReparsePoint))
            JunctionPoint.Delete(path);
        else if (Directory.Exists(path))
            Directory.Delete(path, true);
    }

    public void MakeSymbolicLink(string path, string targetPath)
    {
        if (Directory.Exists(path) && File.GetAttributes(path).HasFlag(FileAttributes.ReparsePoint))
            JunctionPoint.Delete(path);
        else if (Directory.Exists(path) || File.Exists(path))
            throw new Exception($"Can't setup Symbolic link at {path}");
        JunctionPoint.Create(path, targetPath, true);
    }

    public bool IsSymbolicLink(string path)
    {
        return JunctionPoint.Exists(path);
    }

    public string GetSymbolicLinkTarget(string path)
    {
        if (JunctionPoint.Exists(path))
            return JunctionPoint.GetTarget(path);
        return string.Empty;
    }
}