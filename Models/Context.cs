using Microsoft.EntityFrameworkCore;

namespace CadEscola.Models
{
    public class Context : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }

        public Context(DbContextOptions<Context> options) : base(options){}
    }
}
