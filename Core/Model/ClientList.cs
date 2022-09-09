using System.ComponentModel.DataAnnotations;

namespace CadastroDeCliente
{
    public class ClientList
    {
        [Required (ErrorMessage = "O nome é necessário para fazer o cadastro")]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(11, ErrorMessage = "O CPF não pode ter mais que 11 digitos")]
        [MinLength(11, ErrorMessage = "O CPF não pode ter menos que 11 digitos")]
        public string CPF { get; set; }
        
        [Required (ErrorMessage = "Por favor, adicione a sua data de nascimento")]
        public DateTime Birthday { get; set; }

        public int Age => DateTime.Now.Year - Birthday.Year;

        public long Id { get; set; }
    }
}