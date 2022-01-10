using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models.DTOs.Requests
{
    public class TokenRequest
    {
        [Required]
        public string Token { get; set; } = default!;

         [Required]
        public string RefreshToken { get; set; } = default!;
    }
}