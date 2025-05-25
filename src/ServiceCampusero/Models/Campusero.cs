using System.ComponentModel.DataAnnotations;

namespace CampuserosService.Models
{
  public class Campusero
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    public int CiudadId { get; set; }
    public Ciudad Ciudad { get; set; }

    public int? CarpaId { get; set; }
    public Carpa? Carpa { get; set; }

    public int? PabellonId { get; set; }
    public Pabellon? Pabellon { get; set; }

    public ICollection<CampuseroEquipo> Equipos { get; set; }
    public ICollection<Hardware> Hardware { get; set; }
  }

  public class Ciudad
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    public int Habitantes { get; set; }
    public int Universidades { get; set; }
  }

  public class Pabellon
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    public decimal Area { get; set; }
    public string Ubicacion { get; set; }
  }

  public class Carpa
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public int Numero { get; set; }

    public int PabellonId { get; set; }
    public Pabellon Pabellon { get; set; }
  }
}