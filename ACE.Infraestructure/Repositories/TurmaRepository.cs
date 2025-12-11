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
    public class TurmaRepository : ITurmaRepository
    {

        private readonly AppDbContext _context;

        public TurmaRepository(AppDbContext context)
        {
            _context = context;
        }

        //****************************************************************************
        //****************************************************************************

        public async Task AdicionarAsync(Turma turma)
        {
            await _context.Turmas.AddAsync(turma);
            await _context.SaveChangesAsync();
        }

        //****************************************************************************
        //****************************************************************************

        public async Task AtualizarAsync(Turma turma)
        {
        
            _context.Turmas.Attach(turma);
            _context.Entry(turma).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //****************************************************************************
        //****************************************************************************

        public async Task<Turma> BuscarPorIdAsync(string nome)
        {
           
            return await _context.Turmas.FindAsync(nome);
        }

        //****************************************************************************
        //****************************************************************************

        public async Task DeletarAsync(Turma turma)
        {
            _context.Turmas.Remove(turma);
                      
            await _context.SaveChangesAsync();
        }

        //****************************************************************************
        //****************************************************************************

        public async Task<List<Turma>> ListarAsync()
        {
            return await _context.Turmas
                .OrderBy(t => t.Nome)
                .ToListAsync();
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
