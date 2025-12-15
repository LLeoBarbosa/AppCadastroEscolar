using ACE.Domain.Contracts;
using ACE.Domain.Models;
using ACE.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACE.Infraestructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {

        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        //****************************************************************************
        //****************************************************************************

        public async Task AdicionarAsync(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
          
            await _context.SaveChangesAsync();
        }

        //****************************************************************************
        //****************************************************************************

        public async Task<List<Aluno>> ListarAsync()
        {
          
            return await _context.Alunos
                .OrderBy(a => a.Nome)
                .ToListAsync();
        }

        //****************************************************************************
        //****************************************************************************

        public async Task<Aluno> BuscarPorCpfAsync(string cpf)
        {
            //return await _context.Alunos.FindAsync(cpf);
            return await _context.Alunos.SingleOrDefaultAsync(a => a.CPF == cpf);
        }

        //****************************************************************************
        //****************************************************************************

        public async Task DeletarAsync(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }

        //****************************************************************************
        //****************************************************************************

        public async Task AtualizarAsync(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
           
            await _context.SaveChangesAsync();
        }

        //****************************************************************************
        //****************************************************************************

        public void Dispose()
        {
           _context?.Dispose();
        }

        //****************************************************************************
        //****************************************************************************

    }
}
