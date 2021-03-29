using System;
using System.ComponentModel.DataAnnotations;

namespace MojePrzepisy.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [MaxLength(100)]
        public string Role { get; set; }

        public DateTime RegistrationTime { get; set; }
    }
}
