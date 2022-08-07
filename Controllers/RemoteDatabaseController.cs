using Newtonsoft.Json.Linq;
using System.Net;

namespace ManamiAnimeOfflineRepository.Controllers
{
    internal class RemoteDatabaseController
    {
        private string manamiGetCommitsLink;
        private string manamiDatabaseLink;
        public RemoteDatabaseController(string manamiDatabaseLink, string manamiGetCommitsLink)
        {
            this.manamiDatabaseLink = manamiDatabaseLink;
            this.manamiGetCommitsLink = manamiGetCommitsLink;
        }

        public string GetAllData()
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(manamiDatabaseLink);
            }
            return json;
        }
        public string GetLastVersion()
        {
            string sha;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent",
                    "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");

                using (var response = client.GetAsync(manamiGetCommitsLink).Result)
                {
                    var json = response.Content.ReadAsStringAsync().Result;

                    dynamic commits = JArray.Parse(json);
                    sha = commits[0].sha;
                }
            }
            return sha;
        }
    }
}
