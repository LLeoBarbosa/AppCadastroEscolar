using ACE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACE.Domain.Contracts
{
    public interface IAlunoRepository : IDisposable
    {
        Task AdicionarAsync(Aluno aluno);
        Task<List<Aluno>> ListarAsync();
        Task<Aluno> BuscarPorCpfAsync(string cpf);
        Task DeletarAsync(Aluno aluno);
        Task AtualizarAsync(Aluno aluno);
    }

}
