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
        [Required(ErrorMessage = " O campo {0} é obrigatório")]
        [MinLength(3, ErrorMessage = "O {0} não pode conter menos que 3 caracteres.")]
        [MaxLength(200, ErrorMessage = "O {0} não pode conter mais que 200 caracteres.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        public String Nome { get; set; }

        [Required(ErrorMessage = " O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        public int NumeroCertidaoNova { get; set; }

        [StringLength(11)]
        [RegularExpression(@"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/", ErrorMessage = "O {0} está invalido" )]
        public String CPF { get; set; }
        
        public int responsavelId { get; set; }

        private class ErrorMessageAttribute : Attribute
        {
        }
    }
}
