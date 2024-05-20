using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WAD.CW1._00013292.Models;

namespace WAD.CW1._00013292.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<KeyItem> KeyItems { get; set; }
        public DbSet<KeyType> KeyTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KeyType>()
                .HasMany(k => k.KeyItems)
                .WithOne(i => i.KeyType)
                .HasForeignKey(i => i.KeyTypeId);

            modelBuilder.Entity<KeyType>().HasData(
                new KeyType { KeyTypeId = 1, Name = "API Key", Description = "Keys for API access" },
                new KeyType { KeyTypeId = 2, Name = "License Key", Description = "Keys for software licensing" }
            );
        }
    }
}
