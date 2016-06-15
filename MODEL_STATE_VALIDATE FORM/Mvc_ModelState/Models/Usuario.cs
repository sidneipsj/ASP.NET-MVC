using System.ComponentModel.DataAnnotations;

namespace Mvc_ModelState.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "Informe o nome do usuário.")]
        [StringLength(50, ErrorMessage = "O nome não deve exceder {1} caracteres.")]
        [Display(Name = "Nome do Usuario:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o sobrenome do usuário.")]
        [StringLength(50, ErrorMessage = "O sobrenome não deve exceder {1} caracteres.")]
        [Display(Name = "Sobrenome do Usuário:")]
        public string SobreNome { get; set; }

        [EmailAddress(ErrorMessage = "O endereço de email não é válido")]
        [Required(ErrorMessage = "Informe um endereço de email.")]
        [Display(Name = "Endereço de Email:")]
        public string Email { get; set; }
    }
}