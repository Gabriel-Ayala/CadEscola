using CadEscola.Utils;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CadEscola.Models
{
    public class Responsavel
    {
        [ForeignKey("aluno")]

        int responsavelId { get; set; }
        
        [MinLength(3, ErrorMessage = "O {0} não pode conter menos que 3 caracteres.")]
        [MaxLength(180, ErrorMessage = "O {0} não pode conter mais que 200 caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        int nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        DateTime DataNascimento { get; set; }

        [StringLength(11)]
        [RegularExpression(@"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/", ErrorMessage = "O {0} está invalido")]
        String CPF { get; set; }

        public virtual Aluno aluno { get; set; }

    }
}
