namespace Model.DTO;

public class RegisterRequest
{
    public string NombreCompleto { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string CiudadOrigen { get; set; } = default!;
}