using Model.Entities;

namespace Data.Repositories;

public class RepositoryCampusero : IRepositoryCampusero
{
  private readonly CampuseroContext _context;

  public RepositoryCampusero(CampuseroContext context)
  {
    _context = context;
  }

  public async Task<Campusero?> ObtenerCampusero(string email)
  {
    return await _context.Campuseros.FirstOrDefaultAsync(c => c.Email == email);
  }
  public async Task<Campusero?> CrearCampusero(string email, string password)
  {
    Campusero campusero = new Campusero
    {
      Email = email,
      PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
      FechaRegistro = DateTime.UtcNow
    };

    await _context.Campuseros.AddAsync(campusero);
    await _context.SaveChangesAsync();

    return campusero;
  }
  public async Task<Campusero?> ObtenerCampuseroPorId(int id)
  {
    return await _context.Campuseros.FindAsync(id);
  }
  public async Task<bool> ActualizarCampusero(Campusero campusero)
  {
    _context.Campuseros.Update(campusero);
    return await _context.SaveChangesAsync() > 0;
  }
  public async Task<bool> EliminarCampusero(int id)
  {
    Campusero campusero = await ObtenerCampuseroPorId(id);
    if (campusero == null) return false;

    _context.Campuseros.Remove(campusero);
    return await _context.SaveChangesAsync() > 0;
  }
  public async Task<bool> GuardarCambios()
  {
    return await _context.SaveChangesAsync() > 0;
  }
}