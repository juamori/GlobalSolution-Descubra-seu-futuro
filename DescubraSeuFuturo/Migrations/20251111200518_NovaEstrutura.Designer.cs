using DescubraSeuFuturo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DescubraSeuFuturo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20251111200518_NovaEstrutura")]
    partial class NovaEstrutura
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.10");

            modelBuilder.Entity("DescubraSeuFuturo.Models.Competencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("NivelDemanda")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SetorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SetorId");

                    b.ToTable("Competencias");
                });

            modelBuilder.Entity("DescubraSeuFuturo.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DuracaoHoras")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Plataforma")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TrilhaAprendizadoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TrilhaAprendizadoId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("DescubraSeuFuturo.Models.Empregabilidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Area")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fonte")
                        .HasColumnType("TEXT");

                    b.Property<double>("TaxaCrescimento")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Empregabilidades");
                });

            modelBuilder.Entity("DescubraSeuFuturo.Models.Habilidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Habilidades");
                });

            modelBuilder.Entity("DescubraSeuFuturo.Models.Mentor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AreaAtuacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Contato")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Mentores");
                });

            modelBuilder.Entity("DescubraSeuFuturo.Models.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("DescubraSeuFuturo.Models.TrilhaAprendizado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompetenciaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompetenciaId");

                    b.ToTable("TrilhasAprendizado");
                });

            modelBuilder.Entity("DescubraSeuFuturo.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("ObjetivoCarreira")
                        .HasColumnType("TEXT");

                    b.Property<string>("SenhaHash")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DescubraSeuFuturo.Models.Competencia", b =>
                {
                    b.HasOne("DescubraSeuFuturo.Models.Setor", "Setor")
                        .WithMany("Competencias")
                        .HasForeignKey("SetorId");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("DescubraSeuFuturo.Models.Curso", b =>
                {
                    b.HasOne("DescubraSeuFuturo.Models.TrilhaAprendizado", "TrilhaAprendizado")
                        .WithMany("Cursos")
                        .HasForeignKey("TrilhaAprendizadoId");

                    b.Navigation("TrilhaAprendizado");
                });

            modelBuilder.Entity("DescubraSeuFuturo.Models.TrilhaAprendizado", b =>
                {
                    b.HasOne("DescubraSeuFuturo.Models.Competencia", "Competencia")
                        .WithMany()
                        .HasForeignKey("CompetenciaId");

                    b.Navigation("Competencia");
                });

            modelBuilder.Entity("DescubraSeuFuturo.Models.Setor", b =>
                {
                    b.Navigation("Competencias");
                });

            modelBuilder.Entity("DescubraSeuFuturo.Models.TrilhaAprendizado", b =>
                {
                    b.Navigation("Cursos");
                });
#pragma warning restore 612, 618
        }
    }
}
