using ACE.Domain.Abstract;
using ACE.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACE.Infraestructure.Mapping
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("TBALUNOS");

            builder.Property(a => a.Id).HasColumnName("ID");
            builder.HasKey(x => x.Id);

            builder.Property(a => a.Nome)
            .IsRequired()
            .HasColumnType("varchar(50)").HasColumnName("NOME");

            builder.Property(a => a.CPF).HasColumnName("CPF");
            builder.HasIndex(a => a.CPF).IsUnique();

            builder.Property(a => a.CEP)
            .HasColumnName("CEP")
            .HasMaxLength(9)        
            .IsRequired(false);     

            builder.Property(a => a.Logradouro)
                .HasColumnName("LOGRADOURO")
                .HasMaxLength(100)
            .IsRequired(false);

            builder.Property(a => a.Bairro)
                .HasColumnName("BAIRRO")
                .HasMaxLength(50)
            .IsRequired(false);

            builder.Property(a => a.Cidade)
                .HasColumnName("CIDADE")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(a => a.UF)
                .HasColumnName("UF")
                .HasMaxLength(2)        
                .IsRequired(false);

            builder.Property(a => a.Numero)
                .HasColumnName("NUMERO")
                .HasMaxLength(10)
                .IsRequired(false);

            builder.HasMany(a => a.Matriculas) 
                .WithOne(m => m.Aluno) 
                .HasForeignKey(m => m.AlunoId) 
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
