using ACE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACE.Domain.Contracts
{
    public interface IMatriculaRepository : IDisposable
    {

        Task AdicionarAsync(Matricula matricula);
        
        Task<List<Matricula>> ListarAsync();
        
        Task<Matricula> BuscarPorIdAsync(int id);
        
        Task DeletarAsync(Matricula matricula);
        
        Task AtualizarAsync(Matricula matricula);

        // Método específico para buscar matrículas por aluno ou turma
        Task<List<Matricula>> BuscarPorAlunoIdAsync(int alunoId);

    }
}
