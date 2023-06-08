﻿using System;
using Carter;
using LoginTest.Application.Authentication.Commands;
using LoginTest.Application.Authentication.Commons;
using LoginTest.Application.Authentication.Queries;
using LoginTest.Contracts.Authentication;
using Mapster;
using MediatR;

namespace LoginTest.Api.Features;

public class AuthenticationModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Login", async (LoginRequest request, ISender sender) =>
        {
            LoginQuery query = request.Adapt<LoginQuery>();
            var result = await sender.Send(query);
            if (result.IsFailure)
            {
                return Results.Problem(statusCode: StatusCodes.Status401Unauthorized, title: result.Error.Message);
            }
            var typeConfig = new TypeAdapterConfig();
            typeConfig.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(x => x.Id, src => src.User.Id)
            .Map(x => x.FirstName, src => src.User.FirstName)
            .Map(x => x.LastName, src => src.User.LastName)
            .Map(x => x.Email, src => src.User.Email);
            var data = result.Value.Adapt<AuthenticationResponse>(typeConfig);
            return Results.Ok(data);

        });

        app.MapPost("/Register", async (RegisterRequest request, ISender sender) =>
        {
            RegisterCommand command = request.Adapt<RegisterCommand>();
            var result = await sender.Send(command);
            if (result.IsFailure)
            {
                return Results.Problem(statusCode: StatusCodes.Status401Unauthorized, title: result.Error.Message);
            }
            var typeConfig = new TypeAdapterConfig();
            typeConfig.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(x => x.Id, src => src.User.Id)
            .Map(x => x.FirstName, src => src.User.FirstName)
            .Map(x => x.LastName, src => src.User.LastName)
            .Map(x => x.Email, src => src.User.Email);
            var data = result.Value.Adapt<AuthenticationResponse>(typeConfig);
            return Results.Ok(data);
        });
    }
}

