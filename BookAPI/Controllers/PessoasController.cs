using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PessoaAPI.Models;
using PessoaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PessoaAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaRepository _PessoaRepository;

        public PessoasController(IPessoaRepository PessoaRepository)
        {
            _PessoaRepository = PessoaRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Pessoa>> GetPessoas()
        {
            
            return await _PessoaRepository.Get();
        }

        
        [HttpGet("{id}")]
        
        public async Task<ActionResult<Pessoa>> GetPessoas(int id)
        {
            return await _PessoaRepository.Get(id);
        }

        [HttpGet("{uf}")]
        
        public async Task<ActionResult<Pessoa>> GetPessoas(string uf)
        {
            return await _PessoaRepository.Get(uf);
        }

        

        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoas([FromBody] Pessoa Pessoa)
        {

            var newPessoa = await _PessoaRepository.Create(Pessoa);
            return CreatedAtAction(nameof(GetPessoas), new { id = newPessoa.Id }, newPessoa);

        }

        [HttpPut]

        public async Task<ActionResult> PutPessoas(int id, [FromBody] Pessoa Pessoa)
        {
            if (id != Pessoa.Id)
            {
                return BadRequest();
            }

            await _PessoaRepository.Update(Pessoa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var PessoaToDelete = await _PessoaRepository.Get(id);

            if (PessoaToDelete == null)
            {
                return NotFound();

            }

            await _PessoaRepository.Delete(PessoaToDelete.Id);
            return NoContent();

        }
    }
}