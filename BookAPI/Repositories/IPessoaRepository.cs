using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PessoaAPI.Models;


namespace PessoaAPI.Repositories
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> Get();
        Task<Pessoa> Get(int id);

        Task<Pessoa> Get(string uf);
        
        Task<Pessoa> Create(Pessoa Pessoa);

        Task Update(Pessoa Pessoa);

        Task Delete(int id);

    }
}