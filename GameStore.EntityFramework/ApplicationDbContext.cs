using GameStore.Entities;
using System;
using System.Data.Entity;


namespace GameStore.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Game> Games{ get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PublisherImage> PublisherImages { get; set; }
        public DbSet<GameImage> GameImages { get; set; }
        public DbSet<UserImage> UserImages { get; set; }

        static ApplicationDbContext()
        {
            //Database.SetInitializer(new DbInitializer());
        }

        public ApplicationDbContext(String connectionStringName)
            : base(connectionStringName)
        {
        }

    }
}
