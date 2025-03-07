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
    public DbSet<CXP> CXP { get; set; }
    public DbSet<MetodoPago> MetodoPagos { get; set; }

    public DbSet<EstadoCXP> EstadoCXP { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estados>().HasData(
            new List<Estados>()
            {
                new Estados()
                {
                    EstadoId = 1,
                    Nombre = "Pendientes"
                },
                new Estados()
                {
                    EstadoId = 2,
                    Nombre = "Aprobado"
                },
                new Estados()
                {
                    EstadoId = 3,
                    Nombre = "Aceptada"
                },
                new Estados()
                {
                    EstadoId = 4,
                    Nombre = "Cancelada"
                },
                new Estados()
                {
                    EstadoId = 5,
                    Nombre = "Rechazada"
                }
            }
        );

        modelBuilder.Entity<MetodoPago>().HasData(
            new List<MetodoPago>()
            {
                new MetodoPago()
                {
                    MetodoPagoId = 1,
                    Descripcion = "Pago por Cuota"
                },
                new MetodoPago()
                {
                    MetodoPagoId = 2,
                    Descripcion = "Efectivo"
                },
                new MetodoPago()
                {
                    MetodoPagoId = 3,
                    Descripcion = "Transferencia Bancaria"
                },
                new MetodoPago()
                {
                    MetodoPagoId = 4,
                    Descripcion = "Tarjeta de crédito"
                },
                new MetodoPago()
                {
                    MetodoPagoId = 5,
                    Descripcion = "Cheque"
                }
            }
        );

        modelBuilder.Entity<EstadoCXP>().HasData(
    new List<EstadoCXP>()
    {
        new EstadoCXP()
        {
            EstadoCXPId = 1,
            descripcion = "Pagada"
        },
        new EstadoCXP()
        {
            EstadoCXPId = 2,
            descripcion = "Pendiente"
        },
        new EstadoCXP()
        {
            EstadoCXPId = 3,
            descripcion = "Retrasada"
        },
        new EstadoCXP()
        {
            EstadoCXPId = 4,
            descripcion = "Aceptada"
        },
        new EstadoCXP()
        {
            EstadoCXPId = 5,
            descripcion = "Rechazada"
        }
    }
       );

        base.OnModelCreating(modelBuilder);
    }

}