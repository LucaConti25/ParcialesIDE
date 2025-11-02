using Conti.Servicios;
using Conti.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Conti.ModeloDominio;
using Conti.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

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

app.MapGet("/multas/{id}", (int id) =>
{
    MultaServicios multaServicio = new MultaServicios();
    MultaDTO multaDTO = multaServicio.GetOne(id);
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


app.MapPost("/multas", (MultaDTO multaDTO) =>
{
    try
    {
        MultaServicios multaServicio = new MultaServicios();
        MultaDTO nuevaMulta = multaServicio.Add(multaDTO);
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

app.MapPut("/multas", (MultaDTO multaDTO) =>
{
    try
    {
        MultaServicios multaServicio = new MultaServicios();
        bool found = multaServicio.Update(multaDTO);
        
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

app.MapDelete("/multas/{id}", (int id) =>
{
    MultaServicios multaServicio = new MultaServicios();
    bool deleted = multaServicio.Delete(id);
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

app.MapGet("/multas", (HttpContext httpContex) =>
{
    try
    {
        MultaServicios multaServicio = new MultaServicios();    
        string? estado = httpContex.Request.Query["estado"];
        IEnumerable<MultaDTO> multas;
        if (string.IsNullOrEmpty(estado) || estado.Equals("Todas", StringComparison.OrdinalIgnoreCase))
        {
            multas = multaServicio.GetAll();
        }
        else // Si no, llama al nuevo método de filtrado
        {
            multas = multaServicio.GetByEstado(estado);
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

// ---- FIN RUTAS MULTAS ------
/*

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); 

 */

app.Run();

