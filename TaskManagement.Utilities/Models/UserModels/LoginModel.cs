using System.ComponentModel.DataAnnotations;
namespace TaskManagement.Utilities.Models;
   public class LoginModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters")]
        public string Username { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }
    }