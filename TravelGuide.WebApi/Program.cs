using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TravelGuide.Domain.Repository;
using TravelGuide.Persistence.EFCore;
using TravelGuide.Persistence.EFCore.Repository;
using FluentValidation.AspNetCore;
using FluentValidation;
using TravelGuide.Domain.Services;
using TravelGuide.Application.Services;
using TravelGuide.Application.Helpers.Validators;
using TravelGuide.Domain.Models;
using TravelGuide.Application.Helpers.Auth;
using TravelGuide.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(fv =>
        fv.RegisterValidatorsFromAssemblyContaining<Program>())
    .AddJsonOptions(o =>
        o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(build => 
    build.AllowAnyOrigin()));

builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(
    builder.Configuration.GetConnectionString("EntityFrameworkCore")));

builder.Services.AddScoped<IPointRepository, PointRepository>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddTransient<IValidator<RouteRequest>, RouteValidator>();
builder.Services.AddTransient<IValidator<PointRequest>, PointValidator>();
builder.Services.AddTransient<IValidator<AuthenticateRequest>, AuthRequestValidator>();
builder.Services.AddTransient<IValidator<RegistrationRequest>, RegistrationRequestValidator>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.UseCors(builder => {
    builder.AllowAnyOrigin();
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
});

app.Run();
