namespace BackgroundService.EntityFrameworkCore.Models;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime LastUpdatePwd { get; set; }
}
