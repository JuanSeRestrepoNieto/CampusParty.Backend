using Model.DTOs;
using Model.Entities;

namespace Core.Interfaces;

public interface IServicioCampusero
{
    Task<Campusero> RegistrarAsync(RegisterRequest request);
    Task<Campusero?> IniciarSesionAsync(LoginRequest request);
}
