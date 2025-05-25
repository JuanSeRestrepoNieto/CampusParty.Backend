namespace Data.Repositories.Interfaces;

public interface IRepositoryCampusero
{
  Task<Campusero?> ObtenerCampusero(string email);
  Task<Campusero?> CrearCampusero(string email, string password);
  Task<Campusero?> ObtenerCampuseroPorId(int id);
  Task<bool> ActualizarCampusero(Campusero campusero);
  Task<bool> EliminarCampusero(int id);
  Task<bool> GuardarCambios();
}