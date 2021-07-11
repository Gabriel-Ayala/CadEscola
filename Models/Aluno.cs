using System;
using System.ComponentModel.DataAnnotations;


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

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        public String NumeroCertidaoNova { get; set; }

        [StringLength(11)]
        [RegularExpression(@"/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/", ErrorMessage = "O {0} está invalido" )]
        public String CPF { get; set; }
        
        public int responsavelId { get; set; }

        public virtual Responsavel responsavel { get; set; }
    }
}
