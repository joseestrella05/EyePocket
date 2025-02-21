using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EyePocket.Models;

namespace EyePocket.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Clientes> Clientes { get; set; }

    public DbSet<Estados> Estados { get; set; }


    public DbSet<Productos> Productos { get; set; }

    public DbSet<Tickets> Tickets { get; set; }

    public DbSet<Provedores> Provedores { get; set; }

    public DbSet<Compras> Compras { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estados>().HasData(
            new List<Estados>()
            {
                new()
                {
                    EstadoId = 1,
                    Nombre = "Pendientes"
                },
                new()
                {
                    EstadoId = 2,
                    Nombre = "Aprobrado"
                },
                new()
                {
                    EstadoId = 3,
                    Nombre = "Aceptada"
                }, 
                new()
                {
                    EstadoId = 4,
                    Nombre = "Cancelada"
                },
                new()
                {
                    EstadoId = 5,
                    Nombre = "Rechazada"
                }
            }
        );
        base.OnModelCreating(modelBuilder);
    }

}