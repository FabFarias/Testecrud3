
using Testecrud3.Models;
using Microsoft.EntityFrameworkCore;

namespace Testecrud3.Data
{
    public class Contexto : DbContext
    {
        public Contexto (DbContextOptions<Contexto> options ) : base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Inscricao> Inscrições { get; set; }
        public DbSet<Socio> Socios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<Inscricao>().ToTable("Inscrição");
            modelBuilder.Entity<Socio>().ToTable("Socio");
        }
    }
}
