using Conti.Servicios;
using Conti.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Conti.ModeloDominio;
using Conti.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<MultaRepository>();
builder.Services.AddScoped<MultaServicios>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(logging => { });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}


//------- INICIO RUTAS DE MULTAS -------//  

app.MapGet("/multas/{id}", async (int id, [FromServices] MultaServicios multaServicio) =>
{
    MultaDTO multaDTO = await multaServicio.GetOneAsync(id);
    if (multaDTO == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(multaDTO);

})
.WithName("GetMulta")
.Produces<MultaDTO>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();


app.MapPost("/multas", async (MultaDTO multaDTO, [FromServices] MultaServicios multaServicio) =>
{
    try
    {
        MultaDTO nuevaMulta = await multaServicio.AddAsync(multaDTO);
        return Results.Created($"/multas/{nuevaMulta.ID}", nuevaMulta);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { message = ex.Message });
    }   
})
.WithName("AddMulta")
.Produces<MultaDTO>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

app.MapPut("/multas", async (MultaDTO multaDTO, [FromServices] MultaServicios multaServicio) =>
{
    try
    {
        bool found = await multaServicio.UpdateAsync(multaDTO);
        
        if (!found)
        {
            return Results.NotFound();
        }

        return Results.NoContent();
    } 

    catch(ArgumentException ex)
    {
        return Results.BadRequest(new { message = ex.Message });
    }
})
.WithName("UpdateMulta")
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status400BadRequest)
.WithOpenApi();

app.MapDelete("/multas/{id}", async (int id, [FromServices] MultaServicios multaServicio) =>
{
    bool deleted = await multaServicio.DeleteAsync(id);
    if (!deleted)
    {
        return Results.NotFound();
    }
    return Results.NoContent();
})
.WithName("DeleteMulta")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.WithOpenApi();

app.MapGet("/multas", async (HttpContext context, [FromServices] MultaServicios multaServicio) =>
{
    try
    {
        string? estado = context.Request.Query["estado"];
        IEnumerable<MultaDTO> multas;
        if (string.IsNullOrEmpty(estado) || estado.ToLower().Equals("todas", StringComparison.OrdinalIgnoreCase))
        {
            multas = await multaServicio.GetAllAsync();
        }
        else 
        {
            multas = await multaServicio.GetByEstadoAsync(estado);
        }

        return Results.Ok(multas);

    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
}).WithName("GetMultas") 
.Produces<List<MultaDTO>>(StatusCodes.Status200OK)
.WithOpenApi();


app.MapPut("/multas/{id}/pagar", async (int id, [FromServices] MultaServicios servicio) =>
{
    try
    {
        var resultado = await servicio.PagarAsync(id);
        if (!resultado)
        {
            return Results.NotFound();
        }
        return Results.NoContent(); 
    }
    catch (KeyNotFoundException ex) 
    {
        return Results.NotFound(new { message = ex.Message });
    }
    catch (ArgumentException ex) 
    {
        return Results.Conflict(new { message = ex.Message });
    }
    catch (Exception ex) 
    {
        return Results.Problem(ex.Message);
    }
})
.WithName("PagarMulta")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status409Conflict)
.WithOpenApi();

// ---- FIN RUTAS MULTAS ------
/*

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); 

 */

app.Run();

