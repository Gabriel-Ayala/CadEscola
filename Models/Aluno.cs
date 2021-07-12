using CadEscola.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CadEscola.Models
{
    public class Aluno : IValidatableObject

    {
        [Key]
        public int AlunoId { get; set; }

        [Required(ErrorMessage = " O campo {0} é obrigatório")]
        [MinLength(3, ErrorMessage = "O {0} não pode conter menos que 3 caracteres.")]
        [MaxLength(200, ErrorMessage = "O {0} não pode conter mais que 200 caracteres.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Certidão de Nascimento")]
        public String NumeroCertidaoNova { get; set; }

        [StringLength(11)]
        [RegularExpression(@"[0-9]{11}", ErrorMessage = "O {0} está invalido")]
        public String CPF { get; set; }

        public int ResponsavelId { get; set; }
        public virtual Responsavel Responsavel { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> AlunoErrors = new List<ValidationResult>();

            if (CPF == null && NumeroCertidaoNova == null)
            {
                AlunoErrors.Add(new ValidationResult("é necessário o campo CPF ou Certidão de Nascimento"));
            }
            if (Date.Age(DataNascimento) < 18 && Responsavel == null)
            {
                AlunoErrors.Add(new ValidationResult("é obrigatório para alunos menores de idade cadastro de responsável"));
            }
            if (Date.Age(DataNascimento) < 6)
            {
                AlunoErrors.Add(new ValidationResult("a aluno deve ter 6 anos ou mais"));
            }
            return AlunoErrors;
        }
    }
}
