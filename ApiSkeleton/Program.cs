using Infrastructure.CORS;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.ApiSkeleton.Application;
using RifqiAmmarR.ApiSkeleton.Infrastructure;
using RifqiAmmarR.ApiSkeleton.Api.Middlewares;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Persistances.Extension;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var corsOptions = builder.Configuration
    .GetSection(nameof(CorsOptions))
    .Get<CorsOptions>()
    ?? throw new InvalidOperationException("CorsOptions not configured");


// Layer
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

await app.InitializeDatabaseAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/scalar");
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseCors(corsOptions.PolicyName);
app.UseHttpsRedirection();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
