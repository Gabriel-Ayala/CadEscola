using CadEscola.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadEscola.Models
{
    public class Responsavel : IValidatableObject
    {
        [ForeignKey("aluno")]

        public int ResponsavelId { get; set; }

        [MinLength(3, ErrorMessage = "O {0} não pode conter menos que 3 caracteres.")]
        [MaxLength(180, ErrorMessage = "O {0} não pode conter mais que 200 caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [StringLength(11)]
        [RegularExpression(@"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/", ErrorMessage = "O {0} está invalido")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public String CPF { get; set; }

        public virtual Aluno Aluno { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> ResponsavelErrors = new List<ValidationResult>();

            if (Date.Age(DataNascimento) < 18)
            {
                ResponsavelErrors.Add(new ValidationResult("A idade do responsável tem que ser superior a 18 anos"));
            }
            return ResponsavelErrors;
        }

    }
}
