using API.Extensions;
using Presentation.Filters;


var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register the the DI and database registration.
builder.Services.AddDataAccess(builder.Configuration);

// register the api filters and reference the presntation layer to use the controllers.
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
// call to use the custom Global Exception Handler Middleware
app.UseGlobalExceptionHandler();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
