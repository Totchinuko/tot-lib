﻿using System.CommandLine;

namespace tot_lib.Git;

public class QueryGitDir : GitCommand
{
    public QueryGitDir(string workDir)
    {
        WorkingDirectory = workDir;
        Args = "rev-parse --git-dir";
        RaiseError = false;
    }

    public string? Result()
    {
        var rs = ReadToEnd().StdOut;
        if (string.IsNullOrEmpty(rs))
            return null;

        rs = rs.Trim();
        if (Path.IsPathRooted(rs))
            return rs;
        return Path.GetFullPath(Path.Combine(WorkingDirectory, rs));
    }
}