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
    public class AlunoService : IAlunoService
    {

        private readonly IAlunoRepository _alunoRepository;
        

        public AlunoService(IAlunoRepository alunoRepository /*, IViaCepService cepService */ )
        {
            _alunoRepository = alunoRepository;
            // _cepService = cepService;
        }

        //********************************************************************************************
        //********************************************************************************************

        // --- CRUD Básico ---

        public async Task AdicionarAlunoAsync(Aluno aluno)
        {
            // 1. Regra de Negócio: Garante que o CPF não está em uso
            if (string.IsNullOrEmpty(aluno.CPF))
            {
                throw new ArgumentException("O CPF é obrigatório para cadastro.");
            }
            await ValidarCpfUnicoAsync(aluno.CPF);

          
            await _alunoRepository.AdicionarAsync(aluno);
        }

        //********************************************************************************************
        //********************************************************************************************

        public async Task AtualizarAlunoAsync(Aluno aluno)
        {
            if (aluno.Id == Guid.Empty)
            {
                throw new ArgumentException("ID do Aluno é obrigatório para atualização.");
            }

            // 1. Regra de Negócio: Garante que o CPF não está em uso por OUTRO aluno
            await ValidarCpfUnicoAsync(aluno.CPF, aluno.Id);

          
            await _alunoRepository.AtualizarAsync(aluno);
        }

        //********************************************************************************************
        //********************************************************************************************

        public async Task<Aluno> BuscarAlunoPorIdAsync(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                throw new ArgumentException("O CPF não pode ser vazio para a busca.");
            }
          
            return await _alunoRepository.BuscarPorCpfAsync(cpf);
        }

        //********************************************************************************************
        //********************************************************************************************

        public async Task DeletarAlunoAsync(Aluno aluno)
        {
            if (aluno == null || aluno.Id == Guid.Empty)
            {
                throw new ArgumentException("Aluno inválido para deleção.");
            }

            // Regra de Negócio: Poderia checar se o aluno tem matrículas ativas antes de deletar

            await _alunoRepository.DeletarAsync(aluno);
        }

        //********************************************************************************************
        //********************************************************************************************

        public async Task<List<Aluno>> ListarAlunosAsync()
        {
            return await _alunoRepository.ListarAsync();
        }

        //********************************************************************************************
        //********************************************************************************************
        // --- Regras de Negócio Específicas ---

        public async Task ValidarCpfUnicoAsync(string cpf, Guid? id = null)
        {
           
            var alunoExistente = await _alunoRepository.BuscarPorCpfAsync(cpf);
          
            if (alunoExistente != null)
            {             
                if (id == null || alunoExistente.Id != id.Value)
                {
                    throw new InvalidOperationException("CPF já cadastrado para outro aluno.");
                }
            }
            //else
            //{
            //    throw new ArgumentException("CPF Inexistente");
            //}
        }

        //********************************************************************************************
        //********************************************************************************************

        public async Task<Aluno> PreencherEnderecoPorCepAsync(string cep)
        {
            
            await Task.Delay(50);

            return new Aluno
            {
                CEP = cep,
                Logradouro = "Rua do Serviço",
                Bairro = "Bairro do Negócio",
                Cidade = "Cidade Central",
                UF = "CC"
              
            };
        
        }

        //********************************************************************************************
        //********************************************************************************************

        public void Dispose()
        {
            _alunoRepository?.Dispose();
        }

    }

}
