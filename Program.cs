using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using test_cargo_tracker_api.src.Data;
using test_cargo_tracker_api.src.Services;
using test_cargo_tracker_api.src.Services.Container;
using test_cargo_tracker_api.src.Services.Movements;
using test_cargo_tracker_api.src.Strategies.Movements;
using test_cargo_tracker_api.src.Utils;
using test_cargo_tracker_api.src.Utils.Container;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ICustomerInterface, CustomerService>();
builder.Services.AddScoped<CpfValidator>();

builder.Services.AddScoped<IContainerInterface, ContainerService>();
builder.Services.AddScoped<ContainerValidator>();

builder.Services.AddScoped<IContainerMovement, ContainerMovementService>();
builder.Services.AddScoped<ContainerMovementContext>();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

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
