using ACE.Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace ACE.Domain.Models
{
    public class Aluno : Entity
    {

        public string Nome { get; set; } = "";
        public string CPF { get; set; } = "";
        public string CEP { get; set; } = "";
        public string Logradouro { get; set; } = "";
        public string Bairro { get; set; } = "";
        public string Cidade { get; set; } = "";
        public string UF { get; set; } = ""; // Estado (Ex: SP, RJ)
        public int? Numero { get; set; }
        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

    }

}
