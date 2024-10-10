using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore; // For DbContext and DbSet
using Microsoft.OpenApi.Models; // For OpenApiInfo
using TicketTrackingAPI.Data; // For TicketContext
using TicketTrackingAPI.Models; // For Ticket model
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<TicketContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<TicketReplyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Replace with the URL where your React app runs
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.AddControllers(); // Add this line to enable controller support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ticket Tracking API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket Tracking API v1"));
app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.UseAuthorization();

// Map your controller routes
app.MapControllers();

// Run the application
app.Run();
