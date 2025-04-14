using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EyePocket.Models;
using Microsoft.AspNetCore.Identity;

namespace EyePocket.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
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
    public DbSet<EstadoCXP> EstadoCXP { get; set; }
    public DbSet<PagoCXP> pagocxp { get; set; }
    public DbSet<CXP> CXPs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(login => new { login.LoginProvider, login.ProviderKey });

        modelBuilder.Entity<PagoCXP>()
      .HasOne(p => p.MetodoPago)
      .WithMany()
      .HasForeignKey(p => p.MetodoPagoId)
      .OnDelete(DeleteBehavior.NoAction); // Cambio a NoAction

        modelBuilder.Entity<PagoCXP>()
            .HasOne(p => p.CuentaPorPagar)
            .WithMany()
            .HasForeignKey(p => p.CuentaPorPagarId)
            .OnDelete(DeleteBehavior.NoAction); // Cambio a NoAction



        modelBuilder.Entity<MetodosPago>().HasData(
            new MetodosPago { MetodoPagoId = 1, Descripcion = "Tarjeta" },
            new MetodosPago { MetodoPagoId = 2, Descripcion = "Efectivo" },
            new MetodosPago { MetodoPagoId = 3, Descripcion = "Cheque" }
        );

        modelBuilder.Entity<IdentityRole>().HasData(
           new IdentityRole { Id= "6ac343b0-00ef-4a1c-8f64-68daaca77b5b ", Name = "Ventas", NormalizedName = "VENTAS", ConcurrencyStamp= "6ac343b0-00ef-4a1c-8f64-68daaca77b5b" },
           new IdentityRole { Id= "6ac343b0-00ef-4a1c-8f64-68daaca77b4b", Name = "CuentasXCobrar", NormalizedName = "CUENTASXCOBRAR",ConcurrencyStamp= "6ac343b0-00ef-4a1c-8f64-68daaca77b4b" },
           new IdentityRole { Id= "6ac343b0-00ef-4a1c-8f64-68daaca77b2b", Name = "CuentasXPagar", NormalizedName = "CUENTASXPAGAR", ConcurrencyStamp = "6ac343b0-00ef-4a1c-8f64-68daaca77b2b" },
           new IdentityRole { Id= "6ac343b0-00ef-4a1c-8f64-68daaca77b1b",Name = "Inventario", NormalizedName = "INVENTARIO",ConcurrencyStamp="6ac343b0-00ef-4a1c-8f64-68daaca77b1b" },
           new IdentityRole { Id= "6ac343b0-00ef-4a1c-8f64-68daaca77b0b", Name = "ServicioAlCliente", NormalizedName = "SERVICIOALCLIENTE", ConcurrencyStamp= "6ac343b0-00ef-4a1c-8f64-68daaca77b0b" }
       );

        modelBuilder.Entity<Estados>().HasData(
            new Estados { EstadoId = 1, Nombre = "Pendiente" },
            new Estados { EstadoId = 2, Nombre = "Pagado" },
            new Estados { EstadoId = 3, Nombre = "Vencido" },
            new Estados { EstadoId = 4, Nombre = "Cancelado"},
            new Estados { EstadoId = 5, Nombre = "Aprobado" },
            new Estados { EstadoId = 6, Nombre = "Denegado" }

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


        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { CategoriaId = 1, Nombre = "Alimentos", Descripcion = "Productos comestibles y bebidas." },
            new Categoria { CategoriaId = 2, Nombre = "Electrónica", Descripcion = "Dispositivos electrónicos y accesorios." },
            new Categoria { CategoriaId = 3, Nombre = "Belleza", Descripcion = "Cosméticos y productos de cuidado personal." },
            new Categoria { CategoriaId = 4, Nombre = "Hogar", Descripcion = "Productos para el hogar y decoración." },
            new Categoria { CategoriaId = 5, Nombre = "Ferreteria", Descripcion = "Herramientas y suministros de construcción." },
            new Categoria { CategoriaId = 6, Nombre = "Papeleria", Descripcion = "Artículos de oficina y escolar." }
        );
    }

}