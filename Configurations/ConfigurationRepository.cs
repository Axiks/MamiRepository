using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManamiAnimeOfflineRepository.Configurations
{
    internal class ConfigurationRepository
    {
        private ConfigurationController controller;
        public ConfigurationRepository(string pathToConfigFile, ManamiConfig defaultManamiConfig)
        {
            controller = new ConfigurationController(pathToConfigFile);

            if (controller.IsEmptyConfig())
            {
                UpdateConfiguration(defaultManamiConfig);
            }
        }
        public ManamiConfig GetConfiguration()
        {
            string configurationData = controller.GetConfig();  
            return JsonConvert.DeserializeObject<ManamiConfig>(configurationData);
        }
        public void UpdateConfiguration(ManamiConfig manamiConfig)
        {
            string configurationData = JsonConvert.SerializeObject(manamiConfig);
            controller.UpdateConfig(configurationData);
        }
    }
}
