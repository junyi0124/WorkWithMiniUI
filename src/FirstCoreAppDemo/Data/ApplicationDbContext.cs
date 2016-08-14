﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FirstCoreAppDemo.Models;

namespace FirstCoreAppDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MaterialEntity> Materials { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<MaterialEntity>()
                .HasIndex(m => m.FullCode)
                .IsUnique();
            builder.Entity<MaterialEntity>()
                .HasIndex(m => m.FullName);
            builder.Entity<MaterialEntity>()
                .HasIndex(m => m.Name);
            builder.Entity<MaterialEntity>()
                .HasIndex(m => m.PId);

        }


    }
}
