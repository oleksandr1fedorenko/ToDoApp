namespace TodoAppBe.DTO;

public class UserDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}