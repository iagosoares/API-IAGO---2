using Microsoft.EntityFrameworkCore;

namespace PessoaAPI.Models
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) :base(options){
            Database.EnsureCreated();
        }
        public DbSet<Pessoa> Pessoas {get; init;}
    }
   
}