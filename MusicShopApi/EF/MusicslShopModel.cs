using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;

namespace MusicShopApi
{

    public class MusicalShopModel : DbContext
    {

        public MusicalShopModel(DbContextOptions<MusicalShopModel> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Publisher>(e => e.HasIndex(e => e.Name).IsUnique());
            modelBuilder.Entity<Group>(e => e.HasIndex(e => e.Name).IsUnique());
            modelBuilder.Entity<Genre>(e => e.HasIndex(e => e.Name).IsUnique());
            modelBuilder.Entity<User>(e => e.HasIndex(e => e.Login).IsUnique());
        }

        public virtual DbSet<Disc> Discs { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }

    }

}