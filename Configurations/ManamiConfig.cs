using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManamiAnimeOfflineRepository.Configurations
{
    internal class ManamiConfig
    {
        public string manamiFolderPath { get; }
        public string offlineDatabaseFileName { get; }
        public string manamiGetCommitsLink { get; }
        public string manamiRemoteRepositoryLink { get; }
        public string shaOfDownloadedDataBase { get; set; }

        public ManamiConfig(string manamiFolderPath, string offlineDatabaseFileName, string manamiGetCommitsLink, string manamiRemoteRepositoryLink)
        {
            this.manamiFolderPath = manamiFolderPath;
            this.offlineDatabaseFileName = offlineDatabaseFileName;
            this.manamiGetCommitsLink = manamiGetCommitsLink;
            this.manamiRemoteRepositoryLink = manamiRemoteRepositoryLink;
        }
        public string GetPathToOfflineDatabase()
        {
            string path = @"";
            path += manamiFolderPath + offlineDatabaseFileName;
            return path;
        }
    }
}
