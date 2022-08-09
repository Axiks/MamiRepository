using ManamiAnimeOfflineRepository.Configurations;
using ManamiAnimeOfflineRepository.Models;
using ManamiAnimeOfflineRepository.Repositories;

namespace ManamiAnimeOfflineRepository
{
    public class MamiDatabase
    {
        private ConfigurationRepository configurationRepository;
        private RemoteDatabaseRepository remoteDatabaseRepository;
        private LocalDatabaseRepository localDatabaseRepository;
        private List<ManamiAnime> manamiAnimes;

        public MamiDatabase(string pathToManamiFolder, bool autoUpdateLocalDatabase = false)
        {
            ManamiConfig defaultConfigFile = new ManamiConfig(pathToManamiFolder, "database.json", "https://api.github.com/repos/manami-project/anime-offline-database/commits", "https://raw.githubusercontent.com/manami-project/anime-offline-database/master/anime-offline-database.json");
            configurationRepository = new ConfigurationRepository(pathToManamiFolder + "\\setting.json", defaultConfigFile);

            ManamiConfig config = configurationRepository.GetConfiguration();

            remoteDatabaseRepository = new RemoteDatabaseRepository(config.manamiRemoteRepositoryLink, config.manamiGetCommitsLink);
            localDatabaseRepository = new LocalDatabaseRepository(config.GetPathToOfflineDatabase());

            manamiAnimes = new List<ManamiAnime>();


            if (autoUpdateLocalDatabase)
            {
                UpdateDatabaseFromRemoteDatabase();
            }
            
            Root manamiDatabaseObj = localDatabaseRepository.GetAll();
            if (manamiDatabaseObj != null)
            {
                manamiAnimes = manamiDatabaseObj.data;
            }
        }

        public void UpdateDatabaseFromRemoteDatabase()
        {
            if (AvaibleNewVersion())
            {
                Root remoteData = remoteDatabaseRepository.getAllData();
                localDatabaseRepository.UpdateDatabase(remoteData);
                ManamiConfig manamiConfig = configurationRepository.GetConfiguration();
                manamiConfig.shaOfDownloadedDataBase = remoteDatabaseRepository.getLastVersionDatabase();
                configurationRepository.UpdateConfiguration(manamiConfig);
            }
        }

        private bool AvaibleNewVersion()
        {
            string remoteRepositoryLastVerion = remoteDatabaseRepository.getLastVersionDatabase();
            ManamiConfig manamiConfig = configurationRepository.GetConfiguration();
            return remoteRepositoryLastVerion != manamiConfig.shaOfDownloadedDataBase;
        }

        public List<ManamiAnime> GetAllAnime()
        {
            return manamiAnimes;
        }

        public List<ManamiAnime> GetAnimeById(string id)
        {
            var query = from manamiAnime in manamiAnimes
                        from sourceLink in manamiAnime.sourceLinks
                        where sourceLink.Id == id
                        select manamiAnime;
            return query.ToList();
        }

        public List<ManamiAnime> GetAnimeSearch(string q)
        {
            var query = from manamiAnime in manamiAnimes
                        from titleSynonyms in manamiAnime.synonyms
                        where manamiAnime.title == q || manamiAnime.title == titleSynonyms
                        select manamiAnime;
            return query.ToList();
        }
    }
}