using examenSeleccionBansi.Models;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using WebService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BdiExamenContext>();
builder.Services.AddTransient<WebService.WebService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/agregar", (WebService.WebService ws, HttpContext context) =>
{
    int id = Convert.ToInt32(context.Request.Query["id"]);
    string nombre = context.Request.Query["nombre"];
    string descripcion = context.Request.Query["descripcion"];
    bool resultado;
    string resDescripcion;

    ws.AgregarExamen(id, nombre, descripcion, out resultado, out resDescripcion);

    return resDescripcion;
});

app.MapGet("/actualizar", (WebService.WebService ws, HttpContext context) =>
{
    int id = Convert.ToInt32(context.Request.Query["id"]);
    string nombre = context.Request.Query["nombre"];
    string descripcion = context.Request.Query["descripcion"];
    bool resultado;
    string resDescripcion;

    ws.ActualizarExamen(id, nombre, descripcion, out resultado, out resDescripcion);

    return resDescripcion;
});

app.MapGet("/eliminar", (WebService.WebService ws, HttpContext context) =>
{
    int id = Convert.ToInt32(context.Request.Query["id"]);
    bool resultado;
    string resDescripcion;

    ws.EliminarExamen(id, out resultado, out resDescripcion);

    return resDescripcion;
});

app.MapGet("/consultar", (WebService.WebService ws, HttpContext context) =>
{
    int id = Convert.ToInt32(context.Request.Query["id"]);
    string nombre = context.Request.Query["nombre"];
    string descripcion = context.Request.Query["descripcion"];

    return ws.ConsultarExamen(id, nombre, descripcion);
});

app.Run();
