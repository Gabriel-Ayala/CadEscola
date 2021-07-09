using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadEscola.Models
{
    public class Aluno
    {
        [Key]
        public int AlunoId { get; set; }

        [MinLength(3, ErrorMessage = "O {0} não pode conter menos que 3 caracteres.")]
        [MaxLength(200, ErrorMessage = "O {0} não pode conter mais que 200 caracteres.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public int NumeroCertidaoNova { get; set; }

        [Index(IsUnique = true)]
        public String CPF { get; set; }
        public int responsavelId { get; set; }

        private class ErrorMessageAttribute : Attribute
        {
        }
    }
}
