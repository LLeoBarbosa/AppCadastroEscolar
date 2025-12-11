using ACE.Domain.Contracts;
using ACE.Domain.Contracts.Services;
using ACE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACE.Infraestructure.Repositories.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        // ****************************************************************************
        // OPERAÇÕES CRUD COM REGRAS DE NEGÓCIO
        // ****************************************************************************

        public async Task AdicionarAsync(Turma turma)
        {
            // 1. Regra de Negócio: Nome da Turma deve ser único
            if (await NomeTurmaJaExisteAsync(turma.Nome!))
            {
                throw new InvalidOperationException($"A turma com o nome '{turma.Nome}' já existe.");
            }

            // 2. Garante que o ID da turma seja gerado
            if (turma.Id == Guid.Empty)
            {
                turma.Id = Guid.NewGuid();
            }

            await _turmaRepository.AdicionarAsync(turma);
        }

        public async Task AtualizarAsync(Turma turma)
        {
            // 1. Regra de Negócio: Nome da Turma deve ser único (Ignorando o ID atual da turma)
            if (await NomeTurmaJaExisteAsync(turma.Nome!, turma.Id))
            {
                throw new InvalidOperationException($"A turma com o nome '{turma.Nome}' já existe.");
            }

          
            var turmaExistente = await BuscarPorIdAsync(turma.Id);

            if (turmaExistente == null)
            {
                throw new KeyNotFoundException($"Turma com ID '{turma.Id}' não encontrada para atualização.");
            }

            await _turmaRepository.AtualizarAsync(turma);
        }

        public async Task DeletarAsync(Guid turmaId)
        {
            // 1. Buscar a turma para deletar
            var turma = await BuscarPorIdAsync(turmaId);

            if (turma == null)
            {
                // Se não encontrou, consideramos a operação como 'feita' ou lançamos uma exceção
                throw new KeyNotFoundException($"Turma com ID '{turmaId}' não encontrada para exclusão.");
            }                     

            await _turmaRepository.DeletarAsync(turma);
        }

        // ****************************************************************************
        // OPERAÇÕES DE CONSULTA
        // ****************************************************************************

        public async Task<List<Turma>> ListarAsync()
        {
            return await _turmaRepository.ListarAsync();
        }

        public async Task<Turma?> BuscarPorIdAsync(Guid turmaId)
        {
        
            var todasTurmas = await _turmaRepository.ListarAsync();
            return todasTurmas.FirstOrDefault(t => t.Id == turmaId);
        }

        public async Task<bool> NomeTurmaJaExisteAsync(string nome, Guid? idIgnorar = null)
        {
           
            var turmas = await _turmaRepository.ListarAsync();

           
            return turmas.Any(t => t.Nome!.Equals(nome, StringComparison.OrdinalIgnoreCase) &&
                                   (idIgnorar == null || t.Id != idIgnorar.Value));
        }
    }
}
