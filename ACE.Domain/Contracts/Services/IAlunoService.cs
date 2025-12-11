using ACE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACE.Domain.Contracts.Services
{
    public interface IAlunoService : IDisposable
    {

        // CRUD Básico
        Task AdicionarAlunoAsync(Aluno aluno);
        Task AtualizarAlunoAsync(Aluno aluno);
        Task<Aluno> BuscarAlunoPorIdAsync(string cpf);
        Task DeletarAlunoAsync(Aluno aluno);
        Task<List<Aluno>> ListarAlunosAsync();

        // Regras de Negócio Específicas
        Task ValidarCpfUnicoAsync(string cpf, Guid? id);

        // Assinatura para o serviço de busca de endereço pelo CEP
        Task<Aluno> PreencherEnderecoPorCepAsync(string cep);

    }
}
