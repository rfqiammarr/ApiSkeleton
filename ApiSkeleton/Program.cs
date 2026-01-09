using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.ApiSkeleton.Api.Middlewares;
using RifqiAmmarR.ApiSkeleton.Application;
using RifqiAmmarR.ApiSkeleton.Infrastructure;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Authentications;
using RifqiAmmarR.ApiSKeleton.Infrastructure.CORS;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Persistences.Extension;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var corsOptions = builder.Configuration
    .GetSection(nameof(CorsOptions))
    .Get<CorsOptions>()
    ?? throw new InvalidOperationException("CorsOptions not configured");

// BIND JwtOptions
builder.Services
    .AddOptions<JwtOptions>()
    .Bind(builder.Configuration.GetSection(nameof(JwtOptions)))
    .Validate(o => !string.IsNullOrWhiteSpace(o.Key), "Jwt Key is required")
    .ValidateOnStart();


// Layer
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

await app.InitializeDatabaseAsync();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/docs");
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseCors(corsOptions.PolicyName);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

