using System.ComponentModel.DataAnnotations;
using TodoAppBe.DTO;

namespace TodoAppBe.Entities.Domain
{
    public class UserDomain
    {
        [Key, Required, StringLength(50)]
        public string Username { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; } = new byte[0];
        [Required]
        public byte[] PasswordSalt { get; set; } = new byte[0];

        public UserDto ToDto()
        {
            return new UserDto
            {
                Username = Username,
                Password = Password,
                PasswordHash = PasswordHash,
                PasswordSalt = PasswordSalt
            };
        }
    }
}