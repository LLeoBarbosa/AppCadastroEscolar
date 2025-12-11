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
    public class MatriculaRepository : IMatriculaRepository
    {

        private readonly AppDbContext _context;

        public MatriculaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Matricula matricula)
        {
            await _context.Matriculas.AddAsync(matricula);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Matricula matricula)
        {
            _context.Matriculas.Update(matricula);
            await _context.SaveChangesAsync();
        }

        public async Task<Matricula> BuscarPorIdAsync(int id)
        {
          
            return await _context.Matriculas.AsNoTracking()
                .Include(m => m.Aluno) // Inclui o objeto Aluno
                .Include(m => m.Turma) // Inclui o objeto Turma
                .FirstOrDefaultAsync(m => m.Id == id);
        }

      
        public async Task<List<Matricula>> BuscarPorAlunoIdAsync(Guid alunoId)
        {
            return await _context.Matriculas
               .Where(m => m.AlunoId == alunoId)
               .Include(m => m.Aluno)
               .Include(m => m.Turma)
               .OrderByDescending(m => m.DataMatricula)
               .ToListAsync();
        }

        public async Task DeletarAsync(Matricula matricula)
        {
            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Matricula>> ListarAsync()
        {
          
            return await _context.Matriculas
                .Include(m => m.Aluno)
                .Include(m => m.Turma)
                .OrderByDescending(m => m.DataMatricula)
                .ToListAsync();
        }

        public Task<List<Matricula>> BuscarPorAlunoIdAsync(int alunoId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
