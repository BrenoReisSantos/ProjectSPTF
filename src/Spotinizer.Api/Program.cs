using Microsoft.EntityFrameworkCore;
using Spotinizer.Repository;
using Spotinizer.Services.Services;
using Sptf.Data;
using Sptf.Domain.Repository;
using Sptf.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<SpotinizerContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Spotinizer");
    options.UseNpgsql(connectionString, config => config.MigrationsAssembly("Spotinizer.Data"));
});

builder.Services.AddTransient<IOrganizerRepository, OrganizerRepository>();
builder.Services.AddTransient<IOrganizerService, OrganizerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();