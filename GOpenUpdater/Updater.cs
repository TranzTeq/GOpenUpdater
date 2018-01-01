using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GOpenUpdater
{
    public class Updater
    {
        private static Lazy<HttpClient> _httpClientLazy = new Lazy<HttpClient>(() =>
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "GOpenUpdater");
            return client;
        });

        private static HttpClient HttpClientInstance => _httpClientLazy.Value;

        public UpdateConfiguration Configuration { get; set; }

        public Updater()
        {
            
        }

        public async Task<bool> CheckForUpdateAsync()
        {
            var localRelease = await GetLocalDefinitionAsync();
            var remoteRelease = await GetLatestReleaseDefinitionAsync();

            if (!Configuration.IncludePrelease || !remoteRelease.Prerelase) return false;
            if (Configuration.TargetCommitish != remoteRelease.TargetCommitish) return false;
            if (remoteRelease.PublishedAt == localRelease.PublishedAt) return false;

            return true;
        }

        public async Task<UpdateDefinition> GetLatestReleaseDefinitionAsync()
        {
            var uri = GithubUriBuilder.BuildLatestReleaseUri(Configuration.GithubUserame, Configuration.GithubRepositoryName);
            var response = await HttpClientInstance.GetAsync(uri);
            
        }

        public Task<UpdateDefinition> GetLocalDefinitionAsync()
        {
            
        }

        private async Task GetConfigurationAsync()
        {
            
        }

        public async Task SaveConfigurationAsync()
        {
            
        }
    }
}
