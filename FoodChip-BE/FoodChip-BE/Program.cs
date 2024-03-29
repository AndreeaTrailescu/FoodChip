using Application;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Interfaces;
using Infrastructure.Repositories;
using FoodChip_BE.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DB Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)
    );

//MediatR
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(AssemblyMarker).Assembly));

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Repositories
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICookingMethodRepository, CookingMethodRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

//Apply Migrations
builder.Services.AddHostedService<DatabaseMigrationsService>();

//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

//Exception Middleware
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();
