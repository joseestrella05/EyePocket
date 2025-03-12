using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EyePocket.Models;
using Microsoft.AspNetCore.Identity;

namespace EyePocket.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
	public DbSet<Clientes> Clientes { get; set; }

	public DbSet<Estados> Estados { get; set; }

    public DbSet<Mermas> Mermas { get; set; }
    public DbSet<Productos> Productos { get; set; }
	public DbSet<CuentasXCobrar> CuentasXCobrar { get; set; }

	public DbSet<Productos> Productos { get; set; }


	public DbSet<OrdenVenta> OrdenVenta { get; set; }
	public DbSet<Tickets> Tickets { get; set; }

	public DbSet<MetodosPago> MetodosPago { get; set; }
	public DbSet<PagosCXC> PagosCXC { get; set; }
	public DbSet<CuotasCXC> CuotasCXC { get; set; }
  public DbSet<Inventarios> Inventarios { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder); // Asegura que Identity est� bien configurado

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
	}





}