using System.ComponentModel.DataAnnotations;
using TodoAppBe.Entities.Domain;

namespace TodoAppBe.Entities;

public class UserEntity
{
        [Key, Required, StringLength(50)]
        public string Username { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        [StringLength(500)]
        public byte[] PasswordHash { get; set; }

        [StringLength(500)]
        public byte[] PasswordSalt { get; set; }

        public UserDomain ToDomain()
        {
            return new UserDomain
            {
                Username = Username,
                Password = Password,
                PasswordHash = PasswordHash,
                PasswordSalt = PasswordSalt
            };
        }
}