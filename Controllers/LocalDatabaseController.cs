using ManamiAnimeOfflineRepository.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManamiAnimeOfflineRepository.Controllers
{
    internal class LocalDatabaseController
    {
        public string databasePath { get; }
        public LocalDatabaseController(string manamiOfflineDatabasePath)
        {
            databasePath = manamiOfflineDatabasePath;
            if (!ItExist())
            {
                CreateEmpty();
            }
        }
        public string GetAllData()
        {
            return File.ReadAllText(databasePath);
        }
        public void UpdateDatabase(string data)
        {
            File.WriteAllText(databasePath, data);
        }
        public void Delete()
        {
            if (ItExist())
            {
                File.Delete(databasePath);
            }
        }
        private bool ItExist()
        {
            return File.Exists(databasePath);
        }
        private void CreateEmpty()
        {
            File.Create(databasePath).Dispose();
        }
    }
}
