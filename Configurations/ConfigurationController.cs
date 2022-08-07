using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManamiAnimeOfflineRepository.Configurations
{
    internal class ConfigurationController
    {
        private string pathToConfigFile;
        public ConfigurationController(string pathToConfigFile)
        {
            this.pathToConfigFile = pathToConfigFile;

            if (!IsExist())
            {
                CreateEmptyConfig();
            }
        }

        private void CreateEmptyConfig()
        {
            string currentDirectory = Path.GetDirectoryName(pathToConfigFile);
            if (!Directory.Exists(currentDirectory))
            {
                Directory.CreateDirectory(currentDirectory);
            }
            File.Create(pathToConfigFile).Dispose();
        }

        public bool IsEmptyConfig()
        {
            return new FileInfo(pathToConfigFile).Length == 0;
        }
        public string GetConfig()
        {
            string configurations = File.ReadAllText(pathToConfigFile);
            return configurations;
        }

        public void UpdateConfig(string data)
        {
            File.WriteAllText(pathToConfigFile, data);
        }
        private bool IsExist()
        {
            bool isExist = File.Exists(pathToConfigFile);
            return isExist;
        }
    }
}
