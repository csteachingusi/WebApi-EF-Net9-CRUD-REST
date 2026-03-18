using Microsoft.EntityFrameworkCore;
using W9WebAPI_CRUD_Example.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();// step 1. Adds Swagger services to the container, which generates API documentation and provides a UI for testing the API endpoints.

//step 2. Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//step 3.1 Configure CORS to allow requests from any origin (you can customize this as needed)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//step 3.2 Use the defined CORS policy in the middleware pipeline
app.UseCors("AllowAll");//allows any origin, header, and method. You can customize this policy to restrict access as needed.

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
