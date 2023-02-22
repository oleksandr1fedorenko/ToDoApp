using System.ComponentModel.DataAnnotations;

namespace TodoAppBe.Entities;

public class UserEntity
{
    [Required] public int Id { get; set; }
    [Required] public string Username { get; set; } = string.Empty;

    [Required] public byte[] PasswordHash { get; set; } = new byte[0];
    [Required] public byte[] PasswordSalt { get; set; } = new byte[0];
    public List<TaskEntity> Tasks { get; set; }
}