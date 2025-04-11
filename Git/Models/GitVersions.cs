﻿namespace tot_lib.Git.Models
{
    public static class GitVersions
    {
        /// <summary>
        ///     The minimal version of Git that required by this app.
        /// </summary>
        public static readonly System.Version MINIMAL = new System.Version(2, 23, 0);

        /// <summary>
        ///     The minimal version of Git that supports the `add` command with the `--pathspec-from-file` option.
        /// </summary>
        public static readonly System.Version ADD_WITH_PATHSPECFILE = new System.Version(2, 25, 0);

        /// <summary>
        ///     The minimal version of Git that supports the `stash` command with the `--pathspec-from-file` option.
        /// </summary>
        public static readonly System.Version STASH_WITH_PATHSPECFILE = new System.Version(2, 26, 0);

        /// <summary>
        ///     The minimal version of Git that supports the `stash` command with the `--staged` option.
        /// </summary>
        public static readonly System.Version STASH_ONLY_STAGED = new System.Version(2, 35, 0);
    }
}