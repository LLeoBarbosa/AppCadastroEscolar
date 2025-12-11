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
    public class MatriculaMapping : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {

            builder.ToTable("TBMATRICULAS");

            builder.Property(m => m.Id).HasColumnName("ID");
            builder.HasKey(x => x.Id).HasName("ID");

            builder.Property(m => m.DataMatricula)
           .IsRequired()
           .HasColumnType("varchar(50)").HasColumnName("DATAMATRICULA");

            builder.Property(m => m.AlunoId).HasColumnName("ALUNO_ID");
            builder.Property(m => m.TurmaId).HasColumnName("TURMA_ID");

            
            builder.HasOne(m => m.Aluno) // Uma matricula pertence a um Aluno
                .WithMany(a => a.Matriculas) //Um aluno possui muitas Matriculas
                .HasForeignKey(m => m.AlunoId);

           
            builder.HasOne(m => m.Turma) // Uma matricula pertence a uma turma
                .WithMany(t => t.Matriculas) // Uma turma possui muitas matriculas
                .HasForeignKey(m => m.TurmaId);

        }
    }
}
