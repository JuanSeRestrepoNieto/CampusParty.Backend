using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  }
}