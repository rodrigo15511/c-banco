using System;
using Microsoft.EntityFrameworkCore;

namespace Exercicio
{
    public class AppDbContext : DbContext 
    {
        public DbSet<Usuario> Usuarios { get; set; } 
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<Software> Softwares { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=AulaProcedure;Username=postgres;Password=#Vasco2024");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Usuario>().ToTable("usuario");
            modelBuilder.Entity<Maquina>().ToTable("maquina"); 
            modelBuilder.Entity<Software>().ToTable("software"); 
        }
    }
}