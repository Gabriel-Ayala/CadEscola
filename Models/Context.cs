using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadEscola.Models
{
    public class Context : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        { 
            
        }
    }
}
