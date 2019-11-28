using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;

namespace Data
{
    public class EcoRodoviasContext : DbContext
    {
        public DbSet<TipoUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Chamado> Chamados { get; set; }

        public EcoRodoviasContext()
        {
           // Database.EnsureCreated();//Cria o banco de dados, caso o mesmo não exista
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TipoUsuario>()
            //.HasMany(e => e.Usuarios)
            //.WithOne()
            //.HasForeignKey(e => e.TipoUsuarioCodigo);

            //modelBuilder.Entity<Usuario>()
            //.HasOne(e => e.TipoUsuario)
            //.WithMany()
            //.HasForeignKey(e => e.TipoUsuarioCodigo);

            //modelBuilder.Entity<Usuario>()
            //.HasMany(e => e.Chamados)
            //.WithOne()
            //.HasForeignKey(e => e.UsuarioCodigo);

            //modelBuilder.Entity<Usuario>()
            //.HasMany(e => e.Atendimentos)
            //.WithOne()
            //.HasForeignKey(e => e.AtendenteCodigo);

            //modelBuilder.Entity<Chamado>()
            //.HasOne(e => e.Usuario)
            //.WithMany()
            //.HasForeignKey(e => e.UsuarioCodigo);

            //modelBuilder.Entity<Chamado>()
            //.HasOne(e => e.Atendente)
            //.WithMany()
            //.HasForeignKey(e => e.AtendenteCodigo);

            modelBuilder.Entity<TipoUsuario>().HasMany(s => s.Usuarios).WithOne(s => s.TipoUsuario);
            modelBuilder.Entity<Usuario>().HasOne(s => s.TipoUsuario).WithMany(s => s.Usuarios); //.HasForeignKey(d => d.TipoUsuarioCodigo);
            modelBuilder.Entity<Usuario>().HasMany(s => s.Chamados).WithOne(s => s.Usuario);//.HasForeignKey(d => d.UsuarioCodigo);
            modelBuilder.Entity<Usuario>().HasMany(s => s.Atendimentos).WithOne(s => s.Atendente);//;.HasForeignKey(d => d.AtendenteCodigo);
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
            optionsBuilder.UseOracle(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}