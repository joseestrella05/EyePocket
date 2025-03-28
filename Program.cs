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
