using ManamiAnimeOfflineRepository.Constans;
using ManamiAnimeOfflineRepository.Models.Costumes;

namespace ManamiAnimeOfflineRepository.Models
{
    public class ManamiAnime
    {
        public List<string> sources { get; set; }
        public string title { get; set; }
        public ManamiType type { get; set; }
        public int episodes { get; set; }
        public Status status { get; set; }
        public AnimeSeason animeSeason { get; set; }
        public string picture { get; set; }
        public string thumbnail { get; set; }
        public List<string> synonyms { get; set; }
        public List<string> relations { get; set; }
        public List<string> tags { get; set; }
        public List<SourceLink> sourceLinks { get; set; }
    }
}
