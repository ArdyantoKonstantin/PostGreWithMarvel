﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelEntity.Entity
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("user_pkey");
                entity.HasMany<Address>(e => e.Addresses)
                .WithOne(e => e.User).HasConstraintName("t__Adress_fkey").IsRequired();

                entity.HasGeneratedTsVectorColumn(
                    p => p.SearchVector,
                    "english",
                    p => new { p.Name }
                    ).HasIndex(p => p.SearchVector).HasMethod("GIN");
            });

        }
    }
}
