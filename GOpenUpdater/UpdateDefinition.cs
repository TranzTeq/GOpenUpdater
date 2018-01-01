using System;

namespace GOpenUpdater
{
    public class UpdateDefinition
    {
        public bool Prerelase { get; internal set; }
        public string ReleaseTag { get; internal set; }
        public string TargetCommitish { get; internal set; }
        public DateTime PublishedAt { get; internal set; }
        public string DownloadUrl { get; internal set; }
        public long Size { get; internal set; }
    }
}
