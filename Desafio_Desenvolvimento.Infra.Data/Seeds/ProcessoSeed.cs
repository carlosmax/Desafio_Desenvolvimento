using Desafio_Desenvolvimento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Desenvolvimento.Infra.Data.Seeds
{
    public static class ProcessoSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Processo>().HasData(
                new Processo("Ação de Indenização por Danos Morais", "000001-23.2023.8.26.0100", "SP", "São Paulo", 3550308),
                new Processo("Ação de Cobrança de Aluguéis Atrasados", "000002-45.2023.8.26.0100", "SP", "São Paulo", 3550308),
                new Processo("Ação de Rescisão Contratual", "000003-67.2023.8.26.0100", "SP", "São Paulo", 3550308),
                new Processo("Divórcio Consensual", "000004-89.2023.8.19.0001", "RJ", "Rio de Janeiro", 3304557),
                new Processo("Ação de Execução Fiscal", "000005-12.2023.8.19.0001", "RJ", "Rio de Janeiro", 3304557),
                new Processo("Ação de Inventário e Partilha", "000006-34.2023.8.19.0001", "RJ", "Rio de Janeiro", 3304557),
                new Processo("Ação de Cobrança de Condomínio", "000007-56.2023.8.16.0001", "PR", "Curitiba", 4106902),
                new Processo("Mandado de Segurança", "000008-78.2023.8.16.0001", "PR", "Curitiba", 4106902),
                new Processo("Ação de Usucapião", "000009-90.2023.8.16.0001", "PR", "Curitiba", 4106902),
                new Processo("Ação de Alvará Judicial", "000010-12.2023.8.11.0002", "MT", "Cuiabá", 5103403),
                new Processo("Ação de Interdição", "000011-34.2023.8.11.0002", "MT", "Cuiabá", 5103403),
                new Processo("Ação Trabalhista por Verbas Rescisórias", "000012-56.2023.5.03.0001", "MG", "Belo Horizonte", 3106200),
                new Processo("Ação de Reintegração de Posse", "000013-78.2023.8.13.0001", "MG", "Belo Horizonte", 3106200),
                new Processo("Ação de Divórcio Litigioso", "000014-90.2023.8.13.0001", "MG", "Belo Horizonte", 3106200),
                new Processo("Ação de Alimentos", "000015-23.2023.8.06.0001", "CE", "Fortaleza", 2304400)
            );
        }
    }
}
