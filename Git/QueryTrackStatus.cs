﻿using System.CommandLine;
using tot_lib.Git.Models;

namespace tot_lib.Git;

public class QueryTrackStatus : GitCommand
{
    public QueryTrackStatus(string repo, string local, string upstream)
    {
        WorkingDirectory = repo;
        Context = repo;
        Args = $"rev-list --left-right {local}...{upstream}";
    }

    public BranchTrackStatus Result()
    {
        var status = new BranchTrackStatus();

        var rs = ReadToEnd();
        if (!rs.IsSuccess)
            return status;

        var lines = rs.StdOut.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            if (line[0] == '>')
                status.Behind.Add(line.Substring(1));
            else
                status.Ahead.Add(line.Substring(1));
        }

        return status;
    }
}