using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PessoaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PessoaAPI.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {

       
        private readonly PessoaContext _context;

        public PessoaRepository(PessoaContext context)
        {
            _context = context;
        }
        public async Task<Pessoa> Create(Pessoa Pessoa)
        {
            _context.Pessoas.Add(Pessoa);
            await _context.SaveChangesAsync();
            return Pessoa;
        }

        public async Task Delete(int id)
        {
            var PessoaToDelete = await _context.Pessoas.FindAsync(id);
            _context.Pessoas.Remove(PessoaToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pessoa>> Get()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> Get(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task<Pessoa> Get(string uf)
        {
            return await _context.Pessoas.FindAsync(uf);
        }

        public async Task Update(Pessoa Pessoa)
        {
            _context.Entry(Pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}