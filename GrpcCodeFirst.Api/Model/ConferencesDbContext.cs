﻿using Microsoft.EntityFrameworkCore;

namespace GrpcCodeFirst.Api.Model
{
    public class ConferencesDbContext : DbContext
    {
        public ConferencesDbContext(DbContextOptions<ConferencesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Conference> Conferences { get; set; }
    }
}
