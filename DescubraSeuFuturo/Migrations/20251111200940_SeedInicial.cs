using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 

namespace DescubraSeuFuturo.Migrations
{
    public partial class SeedInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Competencias",
                columns: new[] { "Id", "Descricao", "NivelDemanda", "Nome", "SetorId" },
                values: new object[,]
                {
                    { 1, null, null, "Pensamento Crítico", null },
                    { 2, null, null, "Resolução de Problemas", null },
                    { 3, null, null, "Trabalho em Equipe", null },
                    { 4, null, null, "Aprendizado Contínuo", null }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "DuracaoHoras", "Link", "Nome", "Plataforma", "TrilhaAprendizadoId" },
                values: new object[,]
                {
                    { 1, null, null, "Análise de Dados", null, null },
                    { 2, null, null, "Desenvolvimento Web", null, null },
                    { 3, null, null, "Design de Experiência do Usuário", null, null }
                });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Descricao", "Nome", "Tipo" },
                values: new object[,]
                {
                    { 1, null, "Python", null },
                    { 2, null, "Comunicação", null },
                    { 3, null, "Gestão de Tempo", null }
                });

            migrationBuilder.InsertData(
                table: "Mentores",
                columns: new[] { "Id", "AreaAtuacao", "Contato", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia", null, null, "Ana Silva" },
                    { 2, "Design", null, null, "Carlos Almeida" },
                    { 3, "Empreendedorismo", null, null, "Beatriz Santos" }
                });

            migrationBuilder.InsertData(
                table: "Setores",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, null, "Tecnologia da Informação" },
                    { 2, null, "Design" },
                    { 3, null, "Educação" }
                });

            migrationBuilder.InsertData(
                table: "TrilhasAprendizado",
                columns: new[] { "Id", "CompetenciaId", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, null, "Fundamentos de lógica e algoritmos", "Introdução à Programação" },
                    { 2, null, "Noções básicas de design centrado no usuário", "UX Design para Iniciantes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Competencias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Competencias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Competencias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Competencias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Habilidades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Habilidades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Habilidades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Mentores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mentores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mentores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Setores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Setores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Setores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrilhasAprendizado",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrilhasAprendizado",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
