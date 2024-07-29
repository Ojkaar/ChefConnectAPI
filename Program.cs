using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.EntityFrameworkCore.Extensions;
using ChefConnectAPI; // Ajusta esto al espacio de nombres correcto

var builder = WebApplication.CreateBuilder(args);

// Configurar los servicios
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("No se pudo encontrar la cadena de conexión 'DefaultConnection'.");
    }
    options.UseMySQL(connectionString);
});

// Agregar servicios de controladores
builder.Services.AddControllers();

// Agregar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar la canalización de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
