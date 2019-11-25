using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Proxies;

namespace Data
{
    public class GenericContext<T> : DbContext where T : Entidade
    {
        public DbSet<T> Entity { get; set; }

        public GenericContext()
        {
            Database.EnsureCreated();//Cria o banco de dados, caso o mesmo não exista
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /* 
            var conexao = new SqlConnectionStringBuilder()
            {
                DataSource = @"DSK-0203\SQLEXPRESS",
                InitialCatalog = "Repositorio",
                IntegratedSecurity = true,
                Database = "Repositorio"
            };
            optionsBuilder.UseSqlServer(conexao.ConnectionString);*/
            optionsBuilder.UseSqlServer(@"server=DSK-0203;database=Repositorio;trusted_connection=true;");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}