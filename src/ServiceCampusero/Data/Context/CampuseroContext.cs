using Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class CampuseroContext : DbContext
{
    public DbSet<Campusero> Campuseros => Set<Campusero>();

    public CampuseroContext(DbContextOptions<CampuseroContext> options) : base(options) { }
}
