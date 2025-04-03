using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EyePocket.Models;
using Microsoft.AspNetCore.Identity;

namespace EyePocket.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Ciudades> Ciudades { get; set; }
    public DbSet<Devoluciones> Devoluciones { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Estados> Estados { get; set; }
    public DbSet<Citas> Citas { get; set; }
    public DbSet<Agentes> Agentes { get; set; }
    public DbSet<TarjetaPuntos> TarjetaPuntos { get; set; }
    public DbSet<Mermas> Mermas { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<OrdenVentaDetalle> OrdenVentasDetalle { get; set; }
    public DbSet<CuentasXCobrar> CuentasXCobrar { get; set; }
    public DbSet<Provedores> Provedores { get; set; }
    public DbSet<OrdenVenta> OrdenVenta { get; set; }
    public DbSet<Tickets> Tickets { get; set; }
    public DbSet<MetodosPago> MetodosPago { get; set; }
    public DbSet<PagosCXC> PagosCXC { get; set; }
    public DbSet<CuotasCXC> CuotasCXC { get; set; }
    public DbSet<Inventarios> Inventarios { get; set; }
    public DbSet<Compras> Compras { get; set; }
    public DbSet<ComprasDetalles> ComprasDetalles { get; set; }
    public DbSet<SolicitudesCredito> SolicitudesCredito { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<DistribucionInventario> DistribucionInventario { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(login => new { login.LoginProvider, login.ProviderKey });

        modelBuilder.Entity<MetodosPago>().HasData(
            new MetodosPago { MetodoPagoId = 1, Descripcion = "Tarjeta" },
            new MetodosPago { MetodoPagoId = 2, Descripcion = "Efectivo" },
            new MetodosPago { MetodoPagoId = 3, Descripcion = "Cheque" }
        );

        modelBuilder.Entity<Estados>().HasData(
            new Estados { EstadoId = 1, Nombre = "Pendiente" },
            new Estados { EstadoId = 2, Nombre = "Pagado" },
            new Estados { EstadoId = 3, Nombre = "Vencido" }
        );

        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { CategoriaId = 1, Nombre = "Alimentos", Descripcion = "Productos comestibles y bebidas." },
            new Categoria { CategoriaId = 2, Nombre = "Electr�nica", Descripcion = "Dispositivos electr�nicos y accesorios." },
            new Categoria { CategoriaId = 3, Nombre = "Belleza", Descripcion = "Cosm�ticos y productos de cuidado personal." },
            new Categoria { CategoriaId = 4, Nombre = "Hogar", Descripcion = "Productos para el hogar y decoraci�n." },
            new Categoria { CategoriaId = 5, Nombre = "Ferreteria", Descripcion = "Herramientas y suministros de construcci�n." },
            new Categoria { CategoriaId = 6, Nombre = "Papeleria", Descripcion = "Art�culos de oficina y escolar." }
        );
    }

}