using System.Collections.Generic;

namespace primera_api.models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set;}
        public Artist Artist { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}