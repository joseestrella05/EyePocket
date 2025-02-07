using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EyePocket.Models;

namespace EyePocket.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Clientes> Clientes { get; set; }

    public DbSet<Estados> Estados { get; set; }

    public void ConfigureGeneralModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estados>().HasData(
             new Estados { EstadoId = 1, Nombre = "Activo" },
             new Estados { EstadoId = 2, Nombre = "Inactivo" }
        );
    }


}