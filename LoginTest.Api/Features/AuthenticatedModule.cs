using System;
using Carter;
using Microsoft.AspNetCore.Authorization;

namespace LoginTest.Api.Features;

public class AuthenticatedModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/authenticated", [Authorize] (HttpRequest req) =>
        {
            return Results.Ok("test");
        });
    }
}

