using System.ComponentModel.DataAnnotations;

namespace InstafoodApp.Web.Client.DTO
{
    public class UserDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email in not valid")]
        [EmailAddress(ErrorMessage = "Email in not valid")]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? AdminCode { get; set; } = string.Empty;
    }
}
