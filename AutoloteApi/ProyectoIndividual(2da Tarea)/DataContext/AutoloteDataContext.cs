using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProyectoIndividual_2da_Tarea_.DataContext;

namespace ProyectoIndividual_2da_Tarea_.Modelos
{
    public class AutoloteDataContext : DbContext
    {
        public DbSet<Carro> Carros { get; set; }
        public DbSet<DetalleCarro> DetalleCarros { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=KEVIN-PC;DataBase=AutoloteDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutoloteMap());
            base.OnModelCreating(modelBuilder);

        }
    }
}
