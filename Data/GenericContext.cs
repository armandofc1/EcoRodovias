using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.Extensions.Configuration;
using Models;

namespace Data
{
    public class GenericContext<T> : DbContext where T : Entidade
    {
        public DbSet<T> Entity { get; set; }

        public GenericContext()
        {
           // Database.EnsureCreated();//Cria o banco de dados, caso o mesmo não exista
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoUsuario>().HasMany(s => s.Usuarios).WithOne(s => s.TipoUsuario);
            modelBuilder.Entity<Usuario>().HasOne(s => s.TipoUsuario).WithMany(s => s.Usuarios);
            modelBuilder.Entity<Usuario>().HasMany(s => s.Chamados).WithOne(s => s.Usuario);
            modelBuilder.Entity<Usuario>().HasMany(s => s.Atendimentos).WithOne(s => s.Atendente);
            modelBuilder.Entity<Chamado>().HasOne(s => s.Usuario).WithMany(s => s.Chamados);
            modelBuilder.Entity<Chamado>().HasOne(s => s.Atendente).WithMany(s => s.Atendimentos);

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            optionsBuilder.UseOracle(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}