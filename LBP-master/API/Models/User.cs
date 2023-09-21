using System;
using System.Collections.Generic;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApplication2.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EMail { get; set; }

    public string? DateOfBirth { get; set; }

    public string? PasportDetails { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? Appointment { get; set; }

    public virtual Group? AppointmentNavigation { get; set; }
}


public static class UserEndpoints
{
	public static void MapUserEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/User").WithTags(nameof(User));

        group.MapGet("/", async (CompanyV2Context db) =>
        {
            return await db.Users.ToListAsync();
        })
        .WithName("GetAllUsers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<User>, NotFound>> (int id, CompanyV2Context db) =>
        {
            return await db.Users.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is User model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetUserById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, User user, CompanyV2Context db) =>
        {
            var affected = await db.Users
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, user.Id)
                  .SetProperty(m => m.Fio, user.Fio)
                  .SetProperty(m => m.PhoneNumber, user.PhoneNumber)
                  .SetProperty(m => m.EMail, user.EMail)
                  .SetProperty(m => m.DateOfBirth, user.DateOfBirth)
                  .SetProperty(m => m.PasportDetails, user.PasportDetails)
                  .SetProperty(m => m.Login, user.Login)
                  .SetProperty(m => m.Password, user.Password)
                  .SetProperty(m => m.Appointment, user.Appointment)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateUser")
        .WithOpenApi();

        group.MapPost("/", async (User user, CompanyV2Context db) =>
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/User/{user.Id}",user);
        })
        .WithName("CreateUser")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, CompanyV2Context db) =>
        {
            var affected = await db.Users
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteUser")
        .WithOpenApi();
    }
}