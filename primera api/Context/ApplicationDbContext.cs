using Microsoft.EntityFrameworkCore;
using primera_api.models;

namespace primera_api.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Song> Song { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().HasKey(x => x.Id);
            modelBuilder.Entity<Artist>().HasKey(x => x.Id);
            modelBuilder.Entity<Song>().HasKey(x => x.Id);

            modelBuilder.Entity<Artist>().HasMany(A => A.Albums)
                .WithOne(x => x.Artist)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Album>().HasMany(A => A.Songs)
                .WithOne(x => x.Album)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
