using TareasApi.Data;
using TareasApi.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Configurar Kestrel para usar HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5223); // HTTP puerto
    options.ListenAnyIP(7097, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});

// Agregar servicios al contenedor.
builder.Services.Configure<Settings>(options =>
{
    options.ConnectionString = builder.Configuration.GetSection("ConnectionStrings:MongoDb").Value;
    options.Database = builder.Configuration.GetValue<string>("Database");
});

builder.Services.AddSingleton<TareasContext>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<Settings>>().Value;

    // Depuración
    Console.WriteLine($"ConnectionString: {settings.ConnectionString}");
    Console.WriteLine($"Database: {settings.Database}");

    return new TareasContext(settings.ConnectionString, settings.Database);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
