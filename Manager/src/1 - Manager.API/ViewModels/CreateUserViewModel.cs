using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class CreateUserViewModel{

        [Required(ErrorMessage = "O Nome não pode ser nulo.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no minimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres")]
        public string  name { get; set; }
        
        [Required(ErrorMessage = "O Email não pode ser vazio.")]
        [MinLength(10, ErrorMessage = "O email deve ter no minimo 10 caracteres. ")]
        [MaxLength(180, ErrorMessage = "O email deve ter no máximo 180 caracteres")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string email { get; set; }

        [Required(ErrorMessage = "A senha não pode ser vazia. ")]
        [MinLength(10, ErrorMessage = "A senha deve ter no mínimo 6 caracteres. ")]
        [MaxLength(180, ErrorMessage = "A senha deve ter no máximo 80 caracteres. ")]
        public string password { get; set; }
    }
}