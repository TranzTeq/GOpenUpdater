using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOpenUpdater
{
    internal static class GithubUriBuilder
    {
        public const string ApiEndpoint = "https://api.github.com/repos/";
        public const string LatestReleasePath = "/releases/latest";

        public static string BuildLatestReleaseUri(string username, string repo)
        {
            return ApiEndpoint + username + "/" + repo + LatestReleasePath;
        }
    }
}
