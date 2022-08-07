using ManamiAnimeOfflineRepository.Constans.Costumes;
using ManamiAnimeOfflineRepository.Controllers;
using ManamiAnimeOfflineRepository.Models;
using ManamiAnimeOfflineRepository.Models.Costumes;
using Newtonsoft.Json;

namespace ManamiAnimeOfflineRepository.Repositories
{
    internal class LocalDatabaseRepository
    {
        public string manamiOfflineDatabasePath { get; }
        private LocalDatabaseController localDatabaseController;
        public LocalDatabaseRepository(string manamiOfflineDatabasePath)
        {
            this.manamiOfflineDatabasePath = manamiOfflineDatabasePath;
            localDatabaseController = new LocalDatabaseController(manamiOfflineDatabasePath);
        }
        public Root GetAll()
        {
            string data = localDatabaseController.GetAllData();
            Root manamiList = JsonConvert.DeserializeObject<Root>(data);

            if (manamiList is not null)
            {
                List<ManamiAnime> manamiAnimes = ConvertLinks(manamiList.data);
                manamiList.data = manamiAnimes;
            }

            return manamiList;
        }
        public void UpdateDatabase(Root rootDatabaseObj)
        {
            string jsonData = JsonConvert.SerializeObject(rootDatabaseObj);
            localDatabaseController.UpdateDatabase(jsonData);
        }
        private List<ManamiAnime> ConvertLinks(List<ManamiAnime> manamiAnimes)
        {
            /*for (int i = 0; i < manamiAnimes.Count(); i++)
            {
                List<SourceLink> sourceLinks = ConvertLinkToObject(manamiDatabaseObj.data[i].sources);
                manamiAnimes.data[i].sourceLinks = sourceLinks;
            }*/

            foreach (ManamiAnime anime in manamiAnimes)
            {
                List<SourceLink> sourceLinks = ConvertLinkToObject(anime.sources);
                anime.sourceLinks = sourceLinks;
            }

            return manamiAnimes;
        }
        private List<SourceLink> ConvertLinkToObject(List<string> linksSource)
        {
            List<SourceLink> sourceLinks = new List<SourceLink>();
            foreach (string manamiSorce in linksSource ?? Enumerable.Empty<string>())
            {
                Uri uri = new Uri(manamiSorce);
                string domainName = uri.Host;

                SourceLink sourceLink = new SourceLink();
                sourceLink.Url = manamiSorce;
                sourceLink.Id = GetUrlId(manamiSorce);

                switch (domainName)
                {
                    case "anidb.net":
                        sourceLink.resource = Resource.AnidbNet;
                        break;
                    case "anilist.co":
                        sourceLink.resource = Resource.AnilistCo;
                        break;
                    case "anime-planet.com":
                        sourceLink.resource = Resource.AnimeplanetCom;
                        break;
                    case "anisearch.com":
                        sourceLink.resource = Resource.AnisearchCom;
                        break;
                    case "kitsu.io":
                        sourceLink.resource = Resource.KitsuIo;
                        break;
                    case "livechart.me":
                        sourceLink.resource = Resource.LivechartMe;
                        break;
                    case "myanimelist.net":
                        sourceLink.resource = Resource.MyanimelistNet;
                        break;
                    case "notify.moe":
                        sourceLink.resource = Resource.NotityMoe;
                        break;
                }
                sourceLinks.Add(sourceLink);
            }
            return sourceLinks;
        }
        private string GetUrlId(string path)
        {
            Uri uri = new Uri(path);
            string segments = uri.Segments.Last();
            return segments;
        }
        /*private void UpdateDatabase(string remoteDatabaseLink)
        {
            if (!File.Exists(manamiOfflineDatabasePath))
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(remoteDatabaseLink, manamiOfflineDatabasePath);
                }
            }

            string shaLastCommit = GetLastVersionDatabase(ManamiGetCommitsLink);
            string shaLocalLastCommit = GetLastVersionDatabase(ConfigurationManager.AppSettings["ShaOfDownloadedDataBase"]);

            if (shaLastCommit != shaLocalLastCommit)
            {
                DownloadManamiDatabase(ManamiDatabaseLink, ManamiOfflineDatabasePath);
                ConfigurationManager.AppSettings["ShaOfDownloadedDataBase"] = shaLastCommit;
            }
        }*/
    }
}
