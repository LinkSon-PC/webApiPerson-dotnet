using Microsoft.EntityFrameworkCore;
using WebApiPerson.Context;
using WebApiPerson.Services;

var builder = WebApplication.CreateBuilder(args);

//JWT
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

// Add services to the container.
builder.Services.AddTransient<IServicePerson, ServicePerson>();

// crear variable para cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// registrar servicio para la conexión
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
