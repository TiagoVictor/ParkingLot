using Application.Car;
using Application.Car.Ports;
using Application.Ticket;
using Application.Ticket.Port;
using Data;
using Data.Car;
using Data.Ticket;
using Domain.Car.Port;
using Domain.Ticket.Port;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("Main");
builder.Services.AddDbContext<ParkingLotDbContext>(
    opt => opt.UseSqlite(connectionString)
    
);

builder.Services.AddControllers();
#region Ioc

builder.Services.AddScoped<ICarManager, CarManager>();
builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddScoped<ITicketManager, TicketManager>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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