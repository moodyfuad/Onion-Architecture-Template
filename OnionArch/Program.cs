using API.Extensions;
using API.Filters;
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
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddControllers(
    options => { options.Filters.Add<ValidateModelAttribute>(); }
    ).AddApplicationPart(typeof(Presentation.AssemplyReference).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("X-Pagination"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseDeveloperExceptionPage();
}
app.UseGlobalExceptionHandler();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
