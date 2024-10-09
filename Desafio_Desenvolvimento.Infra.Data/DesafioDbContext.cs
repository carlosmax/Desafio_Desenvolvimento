using Desafio_Desenvolvimento.Domain.Entities;
using Desafio_Desenvolvimento.Infra.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Desenvolvimento.Infra.Data
{
    public class DesafioDbContext : DbContext
    {
        public DbSet<Processo> Processos { get; set; }

        public DesafioDbContext() { }

        public DesafioDbContext(DbContextOptions<DesafioDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Processo>(builder =>
            {
                builder.ToTable("Processos");

                builder.HasKey(p => p.Id);

                builder.Property(p => p.Id)
                       .ValueGeneratedOnAdd();

                builder.Property(p => p.Nome)
                       .IsRequired()
                       .HasColumnType("nvarchar(255)")
                       .HasMaxLength(255);

                builder.Property(p => p.Npu)
                       .IsRequired()
                       .HasColumnType("varchar(25)")
                       .HasMaxLength(25);

                builder.Property(p => p.UF)
                       .IsRequired()
                       .HasColumnType("char(2)")
                       .HasMaxLength(2);

                builder.Property(p => p.Municipio)
                       .IsRequired()
                       .HasColumnType("nvarchar(255)")
                       .HasMaxLength(255);

                builder.Property(p => p.MunicipioCodigo)
                       .IsRequired();

                builder.Property(p => p.DataCadastro)
                       .IsRequired()
                       .HasDefaultValueSql("GETDATE()");

                builder.Property(p => p.DataVisualizacao)
                       .IsRequired(false);

                builder.HasIndex(p => p.Npu).IsUnique();
            });

            ProcessoSeed.Seed(modelBuilder);
        }
    }
}
