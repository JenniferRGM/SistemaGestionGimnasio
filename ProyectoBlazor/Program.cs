using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.DependencyInjection;
using ProyectoBlazor;
using ProyectoBlazor.Components;
using ProyectoBlazor.Repository;
using ProyectoBlazor.Service;
using SistemaGimnasio.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers(); // Registra los controladores

//builder.Services.AddSingleton<LocalStorageService>();
builder.Services.AddScoped<AuthenticationService>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<UsuarioRepository>(provider => new UsuarioRepository(connectionString));
builder.Services.AddScoped<MembresiaRepository>(provider => new MembresiaRepository(connectionString));
builder.Services.AddScoped<ClaseRepository>(provider => new ClaseRepository(connectionString));
builder.Services.AddScoped<EspacioRepository>(provider => new EspacioRepository(connectionString));
builder.Services.AddScoped<InventarioRepository>(provider => new InventarioRepository(connectionString));
builder.Services.AddScoped<ReporteRepository>(provider => new ReporteRepository(connectionString));
builder.Services.AddScoped<FacturaRepository>(provider => new FacturaRepository(connectionString));

builder.Services.AddScoped<ReservaRepository>(provider =>
    new ReservaRepository(
        connectionString,
        provider.GetRequiredService<EspacioService>()
    )
);

builder.Services.AddScoped<MembresiaService>();
builder.Services.AddScoped<ClaseService>();
builder.Services.AddScoped<EspacioService>();
builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<InventarioService>();
builder.Services.AddScoped<ReporteService>();
builder.Services.AddScoped<FacturacionService>();




builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddCircuitOptions(options => options.DetailedErrors = true);

builder.Services.AddSingleton<AppState>();
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("https://localhost:7154/api/"); // La URL base de tu API
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.MapControllers(); // Mapea los controladores en las rutas
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

