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

    public DbSet<Inventarios> Inventarios { get; set; }

}