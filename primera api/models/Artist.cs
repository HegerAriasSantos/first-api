using System;
using System.Collections.Generic;
namespace primera_api.models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Album> Albums { get;set; }
    }
}
