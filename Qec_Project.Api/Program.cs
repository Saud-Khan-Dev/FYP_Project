using Microsoft.EntityFrameworkCore;
using Qec_Project.Api.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:4001").AllowAnyHeader().AllowAnyMethod();
    });
});




// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<AdminRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("MyAllowSpecificOrigin");
app.UseHttpsRedirection();
app.MapControllers();


app.Run();

