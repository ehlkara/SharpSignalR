using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SharpSignalR.API.Hubs;
using SharpSignalR.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("ConStr"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("https://localhost:7290").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});
builder.Services.AddControllers();
builder.Services.AddSignalR();
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
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

//http://localhost:4400/Myhub
app.MapHub<MyHub>("/MyHub");

app.Run();

