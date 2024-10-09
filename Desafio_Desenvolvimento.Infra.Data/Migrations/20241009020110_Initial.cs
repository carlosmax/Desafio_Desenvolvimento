using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Desafio_Desenvolvimento.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Npu = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    UF = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MunicipioCodigo = table.Column<int>(type: "INTEGER", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETDATE()"),
                    DataVisualizacao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Processos",
                columns: new[] { "Id", "DataCadastro", "DataVisualizacao", "Municipio", "MunicipioCodigo", "Nome", "Npu", "UF" },
                values: new object[,]
                {
                    { new Guid("036b37a4-cc0b-4db3-89d5-8a9a55f5a191"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2705), null, "Fortaleza", 2304400, "Ação de Alimentos", "000015-23.2023.8.06.0001", "CE" },
                    { new Guid("143252d2-4a3a-429d-9626-487065c12687"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2694), null, "Rio de Janeiro", 3304557, "Ação de Execução Fiscal", "000005-12.2023.8.19.0001", "RJ" },
                    { new Guid("24d9d30f-707f-44f2-8694-3fec03ac2a7d"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2698), null, "Curitiba", 4106902, "Ação de Usucapião", "000009-90.2023.8.16.0001", "PR" },
                    { new Guid("69931674-41a3-4abc-a9fd-af82a652cb19"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2699), null, "Cuiabá", 5103403, "Ação de Alvará Judicial", "000010-12.2023.8.11.0002", "MT" },
                    { new Guid("82276992-1b8a-40ef-960b-8444eb008433"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2684), null, "São Paulo", 3550308, "Ação de Rescisão Contratual", "000003-67.2023.8.26.0100", "SP" },
                    { new Guid("8ba3812f-f5a0-4665-b967-50b7edb11f26"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2673), null, "São Paulo", 3550308, "Ação de Indenização por Danos Morais", "000001-23.2023.8.26.0100", "SP" },
                    { new Guid("9e64182a-9ec3-42a9-acd7-5e51896c84fb"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2703), null, "Belo Horizonte", 3106200, "Ação Trabalhista por Verbas Rescisórias", "000012-56.2023.5.03.0001", "MG" },
                    { new Guid("aaa8fa0d-1ddd-4a8e-834b-c268d2abdea8"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2693), null, "Rio de Janeiro", 3304557, "Divórcio Consensual", "000004-89.2023.8.19.0001", "RJ" },
                    { new Guid("b5798b2c-3f15-438a-a885-4b923ffabd14"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2704), null, "Belo Horizonte", 3106200, "Ação de Divórcio Litigioso", "000014-90.2023.8.13.0001", "MG" },
                    { new Guid("c9d1d385-0b0f-4063-8194-dac2103e766b"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2696), null, "Curitiba", 4106902, "Ação de Cobrança de Condomínio", "000007-56.2023.8.16.0001", "PR" },
                    { new Guid("d5b7baab-c719-4f6e-9811-10d8fa4825e0"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2695), null, "Rio de Janeiro", 3304557, "Ação de Inventário e Partilha", "000006-34.2023.8.19.0001", "RJ" },
                    { new Guid("da2a6800-edb4-4545-adf6-780b7579998b"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2697), null, "Curitiba", 4106902, "Mandado de Segurança", "000008-78.2023.8.16.0001", "PR" },
                    { new Guid("e0febb8d-ae63-4661-871e-d57dee75f84a"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2683), null, "São Paulo", 3550308, "Ação de Cobrança de Aluguéis Atrasados", "000002-45.2023.8.26.0100", "SP" },
                    { new Guid("ef66202b-a916-4953-b22b-38e480ed6642"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2703), null, "Belo Horizonte", 3106200, "Ação de Reintegração de Posse", "000013-78.2023.8.13.0001", "MG" },
                    { new Guid("f4f6413c-f1f8-4c10-9384-b1154395759f"), new DateTime(2024, 10, 8, 23, 1, 9, 694, DateTimeKind.Local).AddTicks(2700), null, "Cuiabá", 5103403, "Ação de Interdição", "000011-34.2023.8.11.0002", "MT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Processos_Npu",
                table: "Processos",
                column: "Npu",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Processos");
        }
    }
}
