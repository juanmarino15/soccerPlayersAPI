global using soccerPlayersApp.Models;
global using Microsoft.EntityFrameworkCore;
using soccerPlayersApp.Data.Interfaces;
using soccerPlayersApp.Data.Interfaces.Repositories;
using soccerPlayersApp.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//adding db context and sql server
builder.Services.AddDbContext<JuanDevContext>(options=>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>(); //scope reference to ourt repositories
builder.Services.AddScoped<ISPRepository, SPRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//handling cors
builder.Services.AddCors(opt=>
{
    opt.AddPolicy(name:"CorsPolicy",builder=>
    {
        builder.WithOrigins("http://localhost:4200") //replace with the production url when deploying
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
