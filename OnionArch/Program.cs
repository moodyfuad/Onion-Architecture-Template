using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Persistant;
using Persistant.Repositories;
using Service.Abstraction;
using Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddDbContext<RepositoryDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Local"))
);

builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemplyReference).Assembly);
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
