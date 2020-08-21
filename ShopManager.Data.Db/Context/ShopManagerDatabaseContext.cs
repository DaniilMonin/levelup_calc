using Microsoft.EntityFrameworkCore;

namespace ShopManager.Data.Db.Context
{
    public sealed class ShopManagerDatabaseContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            optionsBuilder.UseSqlite("Data Source=E:/LevelUp/Database/blogging.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Ignore(x => x.DisplayName);
            modelBuilder.Entity<User>().Ignore(x => x.SystemName);
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasIndex(x => x.Id).IsUnique();


            modelBuilder.Entity<Item>().Ignore(x => x.SystemName);
            modelBuilder.Entity<Item>().Ignore(x => x.DisplayName);
            modelBuilder.Entity<Item>().HasKey(x => x.Id);
            modelBuilder.Entity<Item>().HasIndex(x => x.Id).IsUnique();
        }
    }
}