using ACE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACE.Domain.Contracts
{
    public interface ITurmaRepository : IDisposable
    {
        Task AdicionarAsync(Turma turma);
        Task<List<Turma>> ListarAsync();
        Task<Turma> BuscarPorIdAsync(string nome);
        Task DeletarAsync(Turma turma);
        Task AtualizarAsync(Turma turma);

    }
}
