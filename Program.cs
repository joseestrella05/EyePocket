using Blazored.Toast;
using EyePocket.Components;
using EyePocket.Components.Account;
using EyePocket.Data;
using EyePocket.Models;
using EyePocket.Service;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var modelbuilder = WebApplication.CreateBuilder(args);

// Add services to the container.
modelbuilder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

modelbuilder.Services.AddCascadingAuthenticationState();
modelbuilder.Services.AddScoped<IdentityUserAccessor>();
modelbuilder.Services.AddScoped<IdentityRedirectManager>();
modelbuilder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

modelbuilder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = modelbuilder.Configuration.GetConnectionString("SqlConStr");
modelbuilder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
modelbuilder.Services.AddDatabaseDeveloperPageExceptionFilter();

modelbuilder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

modelbuilder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
modelbuilder.Services.AddBlazorBootstrap();

//inject services
modelbuilder.Services.AddScoped<ClienteServices>();
modelbuilder.Services.AddScoped<ProductosService>();
modelbuilder.Services.AddScoped<MermasService>();
modelbuilder.Services.AddScoped<TicketServices>();
modelbuilder.Services.AddScoped<T_PuntosServices>();
modelbuilder.Services.AddScoped<AgenteServices>();
modelbuilder.Services.AddScoped<CitasService>();
modelbuilder.Services.AddScoped<CuentasXCobrarService>();
modelbuilder.Services.AddScoped<OrdenVentaService>();
modelbuilder.Services.AddScoped<PagosCXCService>();
modelbuilder.Services.AddScoped<CuotasCXCService>();
modelbuilder.Services.AddScoped<InventarioService>();
modelbuilder.Services.AddScoped<ProvedoresServices>();
modelbuilder.Services.AddScoped<EstadoServices>();
modelbuilder.Services.AddScoped<CompraServices>();
modelbuilder.Services.AddScoped<OrdenVentasDetalleService>();
modelbuilder.Services.AddScoped<SolicitudesCreditoService>();




//notificacion
modelbuilder.Services.AddBlazoredToast();
var app = modelbuilder.Build();

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
