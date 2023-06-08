﻿using Carter;
using LoginTest.Application;
using LoginTest.Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructures(builder.Configuration);
builder.Services.AddCarter();
builder.Services.AddMediatR(ApplicationAssembly.Instance);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCarter();
app.UseAuthentication();
app.UseAuthorization();
app.MapGet("/", () =>
{
    return "Hello world";
});

app.Run();

