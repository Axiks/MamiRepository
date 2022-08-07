namespace ManamiAnimeOfflineRepository.Models
{
    public class Root
    {
        public License license { get; set; }
        public string repository { get; set; }
        public string lastUpdate { get; set; }
        public List<ManamiAnime> data { get; set; }
    }
}
