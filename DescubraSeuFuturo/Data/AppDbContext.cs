using Microsoft.EntityFrameworkCore;
using DescubraSeuFuturo.Models;

namespace DescubraSeuFuturo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Empregabilidade> Empregabilidades { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Mentor> Mentores { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<TrilhaAprendizado> TrilhasAprendizado { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Competências
            modelBuilder.Entity<Competencia>().HasData(
                new Competencia { Id = 1, Nome = "Pensamento Crítico" },
                new Competencia { Id = 2, Nome = "Resolução de Problemas" },
                new Competencia { Id = 3, Nome = "Trabalho em Equipe" },
                new Competencia { Id = 4, Nome = "Aprendizado Contínuo" }
            );

            // Cursos
            modelBuilder.Entity<Curso>().HasData(
                new Curso { Id = 1, Nome = "Análise de Dados" },
                new Curso { Id = 2, Nome = "Desenvolvimento Web" },
                new Curso { Id = 3, Nome = "Design de Experiência do Usuário" }
            );

            // Habilidades
            modelBuilder.Entity<Habilidade>().HasData(
                new Habilidade { Id = 1, Nome = "Python" },
                new Habilidade { Id = 2, Nome = "Comunicação" },
                new Habilidade { Id = 3, Nome = "Gestão de Tempo" }
            );

            // Setores
            modelBuilder.Entity<Setor>().HasData(
                new Setor { Id = 1, Nome = "Tecnologia da Informação" },
                new Setor { Id = 2, Nome = "Design" },
                new Setor { Id = 3, Nome = "Educação" }
            );

            // Trilhas de Aprendizado
            modelBuilder.Entity<TrilhaAprendizado>().HasData(
                new TrilhaAprendizado { Id = 1, Nome = "Introdução à Programação", Descricao = "Fundamentos de lógica e algoritmos" },
                new TrilhaAprendizado { Id = 2, Nome = "UX Design para Iniciantes", Descricao = "Noções básicas de design centrado no usuário" }
            );

            //  Mentores
            modelBuilder.Entity<Mentor>().HasData(
                new Mentor { Id = 1, Nome = "Ana Silva", AreaAtuacao = "Tecnologia" },
                new Mentor { Id = 2, Nome = "Carlos Almeida", AreaAtuacao = "Design" },
                new Mentor { Id = 3, Nome = "Beatriz Santos", AreaAtuacao = "Empreendedorismo" }
            );
        }
    }
}