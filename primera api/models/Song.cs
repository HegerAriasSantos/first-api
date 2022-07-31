namespace primera_api.models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }


    }
}