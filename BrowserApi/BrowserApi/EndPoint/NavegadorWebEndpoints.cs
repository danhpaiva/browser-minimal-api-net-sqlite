using Microsoft.EntityFrameworkCore;
using BrowserApi.Data;
using BrowserApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace BrowserApi.EndPoint;

public static class NavegadorWebEndpoints
{
    public static void MapNavegadorWebEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/NavegadorWeb").WithTags(nameof(NavegadorWeb));

        group.MapGet("/", async (BrowserApiContext db) =>
        {
            return await db.NavegadorWeb.ToListAsync();
        })
        .WithName("GetAllNavegadorWebs")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<NavegadorWeb>, NotFound>> (long id, BrowserApiContext db) =>
        {
            return await db.NavegadorWeb.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is NavegadorWeb model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetNavegadorWebById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (long id, NavegadorWeb navegadorWeb, BrowserApiContext db) =>
        {
            var affected = await db.NavegadorWeb
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, navegadorWeb.Id)
                    .SetProperty(m => m.Nome, navegadorWeb.Nome)
                    .SetProperty(m => m.VersaoAtual, navegadorWeb.VersaoAtual)
                    .SetProperty(m => m.MotorRenderizacao, navegadorWeb.MotorRenderizacao)
                    .SetProperty(m => m.BaseCodigo, navegadorWeb.BaseCodigo)
                    .SetProperty(m => m.Fornecedor, navegadorWeb.Fornecedor)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateNavegadorWeb")
        .WithOpenApi();

        group.MapPost("/", async (NavegadorWeb navegadorWeb, BrowserApiContext db) =>
        {
            db.NavegadorWeb.Add(navegadorWeb);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/NavegadorWeb/{navegadorWeb.Id}",navegadorWeb);
        })
        .WithName("CreateNavegadorWeb")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (long id, BrowserApiContext db) =>
        {
            var affected = await db.NavegadorWeb
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteNavegadorWeb")
        .WithOpenApi();
    }
}
