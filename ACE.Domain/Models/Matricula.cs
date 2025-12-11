using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACE.Domain.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        public DateTime DataMatricula { get; set; }
        public Guid AlunoId { get; set; }
        public Aluno? Aluno { get; set; }
        public Guid TurmaId { get; set; }
        public Turma? Turma { get; set; }

    }
}
