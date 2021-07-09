using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadEscola.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public DateTime DataNascimento { get; set; }

        public int NumeroCertidaoNova { get; set; }

        public String CPF { get; set; }

        public int responsavelId { get; set; }
    }
}
