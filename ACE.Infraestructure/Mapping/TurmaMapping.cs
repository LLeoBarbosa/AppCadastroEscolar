using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACE.Domain.Models;

namespace ACE.Infraestructure.Mapping
{
    public class TurmaMapping : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            
            builder.ToTable("TBTURMAS");

            builder.Property(t => t.Id).HasColumnName("ID");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
            .IsRequired() 
            .HasColumnType("varchar(50)").HasColumnName("NOME");

            builder.HasMany(t => t.Matriculas) // Uma Turma possui muitas Matriculas
             .WithOne(m => m.Turma) // Uma matricula esta atrelada a uma Turma
             .HasForeignKey(m => m.TurmaId) //Chave estrangeira na tabela Matricula
             .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
