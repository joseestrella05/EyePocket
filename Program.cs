using Blazored.Toast;
using EyePocket.Components;
using EyePocket.Components.Account;
using EyePocket.Data;
using EyePocket.Models;
using EyePocket.Service;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("SqlConStr");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddBlazorBootstrap();

//inject services
builder.Services.AddScoped<ClienteServices>();
builder.Services.AddScoped<ProductosService>();
builder.Services.AddScoped<MermasService>();
builder.Services.AddScoped<TicketServices>();
builder.Services.AddScoped<T_PuntosServices>();
builder.Services.AddScoped<AgenteServices>();
builder.Services.AddScoped<CitasService>();
builder.Services.AddScoped<CuentasXCobrarService>();
builder.Services.AddScoped<OrdenVentaService>();
builder.Services.AddScoped<PagosCXCService>();
builder.Services.AddScoped<CuotasCXCService>();
builder.Services.AddScoped<InventarioService>();
builder.Services.AddScoped<ProvedoresServices>();
builder.Services.AddScoped<EstadoServices>();
builder.Services.AddScoped<CompraServices>();
builder.Services.AddScoped<OrdenVentasDetalleService>();
builder.Services.AddScoped<SolicitudesCreditoService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<DistribucionInventarioService>();
builder.Services.AddScoped<CXPService>();
builder.Services.AddScoped<PagoService>();
builder.Services.AddScoped<EstadoCXPService>();
builder.Services.AddScoped<MetodosPagoService>();



//notificacion
builder.Services.AddBlazoredToast();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
