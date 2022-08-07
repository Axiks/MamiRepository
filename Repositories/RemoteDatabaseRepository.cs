using ManamiAnimeOfflineRepository.Controllers;
using ManamiAnimeOfflineRepository.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManamiAnimeOfflineRepository.Repositories
{
    internal class RemoteDatabaseRepository
    {
        private RemoteDatabaseController remoteDatabaseController;

        public RemoteDatabaseRepository(string manamiDatabaseLink, string manamiGetCommitsLink)
        {
            remoteDatabaseController = new RemoteDatabaseController(manamiDatabaseLink, manamiGetCommitsLink);
        }

        public string getLastVersionDatabase()
        {
            return remoteDatabaseController.GetLastVersion();
        }

        public Root getAllData()
        {
            string data = remoteDatabaseController.GetAllData();
            return JsonConvert.DeserializeObject<Root>(data);
        }
    }
}
