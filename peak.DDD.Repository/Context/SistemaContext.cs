using Microsoft.EntityFrameworkCore;
using peak.DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace peak.DDD.Repository.Context
{

 public class SistemaContext : DbContext
    {

        public SistemaContext(DbContextOptions<SistemaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Clientes>().ToTable("Cliente");
        }

        public DbSet<Clientes> Clientes { get; set; }
    }
}
