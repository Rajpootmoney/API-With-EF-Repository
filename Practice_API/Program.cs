using Microsoft.EntityFrameworkCore;
using Practice_API.Data;
using Practice_API.Interfaces.Manager;
using Practice_API.Manager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Connection String

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddTransient<IPostManager, PostManager>();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
    builder =>
    {
        builder.WithOrigins()
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

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

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
