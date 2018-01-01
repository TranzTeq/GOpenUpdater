using System.Collections.Generic;

namespace GOpenUpdater
{
    public class UpdateConfiguration
    {
        public bool IncludePrelease { get; set; }
        public string TargetCommitish { get; set; }
        public string GithubRepositoryName { get; set; }
        public string GithubUserame { get; set; }
        public List<IInstallAction> Actions { get; set; }
    }
}
