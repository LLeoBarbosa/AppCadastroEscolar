using ACE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACE.Domain.Contracts.Services
{
    public interface ITurmaService
    {
        // CRUD Básico
        Task AdicionarAsync(Turma turma);
        Task AtualizarAsync(Turma turma);
        Task DeletarAsync(Guid turmaId); 

        // Consultas
        Task<List<Turma>> ListarAsync();
        Task<Turma?> BuscarPorIdAsync(Guid turmaId);
        Task<bool> NomeTurmaJaExisteAsync(string nome, Guid? idIgnorar = null);
    }

}
