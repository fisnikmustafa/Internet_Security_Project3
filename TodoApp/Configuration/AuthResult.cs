using System.Collections.Generic;

namespace TodoApp.Configuration
{
    public class AuthResult
    {
        public string Token { get; set; } = default!;

        public string RefreshToken { get; set; } = default!;

        public bool Success { get; set; } = default!;

        public List<string> Errors { get; set; } = default!;
    }
}