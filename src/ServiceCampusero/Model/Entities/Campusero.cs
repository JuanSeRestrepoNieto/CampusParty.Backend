namespace Model.Entities;

public class Campusero
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string CiudadOrigen { get; set; } = default!;
    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
}