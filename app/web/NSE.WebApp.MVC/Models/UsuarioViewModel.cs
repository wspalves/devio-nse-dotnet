using System.ComponentModel.DataAnnotations;

namespace NSE.WebApp.MVC.Models
{
    public abstract class UsuarioAuth
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está com formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Senha { get; set; }
    }

    public class UsuarioRegistro : UsuarioAuth
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string SenhaConfirmacao { get; set; }
    }

    public class UsuarioLogin : UsuarioAuth
    {

    }

    public class UsuarioRespostaLogin
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioToken UsuarioToken { get; set; }
    }

    public class UsuarioToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UsuarioClaim> Claims { get; set; }
    }

    public class UsuarioClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
