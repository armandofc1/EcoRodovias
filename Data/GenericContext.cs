using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.SqlServer;
//using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.Extensions.Configuration;

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