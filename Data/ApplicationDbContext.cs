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
    public DbSet<OrdenCompra> ordenCompra { get; set; }
    public DbSet<OrdenCompraDetalle> ordenCompraDetalles { get; set; }
    public DbSet<EstadoOrdenCompra> estadoOdCompra { get; set; }

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

        modelBuilder.Entity<EstadoOrdenCompra>().HasData(
    new List<EstadoOrdenCompra>()
    {
        new EstadoOrdenCompra() { EstadoOdId = 1, descripcionEstado = "Realizada" },
        new EstadoOrdenCompra() { EstadoOdId = 2, descripcionEstado = "Aprobada" },
        new EstadoOrdenCompra() { EstadoOdId = 3, descripcionEstado = "Enviada" },
        new EstadoOrdenCompra() { EstadoOdId = 4, descripcionEstado = "Facturada" },
        new EstadoOrdenCompra() { EstadoOdId = 5, descripcionEstado = "Rechazada" },
        new EstadoOrdenCompra() { EstadoOdId = 6, descripcionEstado = "Recibida" },
        new EstadoOrdenCompra() { EstadoOdId = 7, descripcionEstado = "Cerrada" }
    }
);



       modelBuilder.Entity<Productos>().HasData(
           new List<Productos>()
           {
               new Productos(){ ProductoId=1, Codigo="5334", Nombre="Galletas Princesa", Precio=123, Costo=344, Categoria="Comestibles", Proveedor="Club Crackers", Descripcion="Galletas",Descuento=200},
               new Productos(){ ProductoId=2, Codigo="8254", Nombre="Jugo Santal", Precio=234, Costo=345, Categoria="Bebibas", Proveedor="Santal", Descripcion="Jugo",Descuento=654},
               new Productos(){ ProductoId=3, Codigo="7259", Nombre="Salami Mortadela", Precio=156, Costo=643, Categoria="Comestibles", Proveedor="Induveca", Descripcion="salami",Descuento=523},
               new Productos(){ ProductoId=4, Codigo="3842", Nombre="Toallitas Nosotras", Precio=564, Costo=764, Categoria="Toallas humedas", Proveedor="Nosotras", Descripcion="Toallas",Descuento=402},
           }
       );

        base.OnModelCreating(modelBuilder);
    }



}