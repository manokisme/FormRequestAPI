using Microsoft.EntityFrameworkCore;
using FormRequestAPI.Data;
using FormRequestAPI.Hubs; 

var builder = WebApplication.CreateBuilder(args);



// Configure the DbContext to use SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add SignalR to the service container
builder.Services.AddSignalR(); 

builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();

// Map controllers to routes
app.MapControllers();

// Map the SignalR Hub route (this is where the client will connect to)
app.MapHub<RequestHub>("/requestHub"); // Define the SignalR Hub endpoint

// Run the application
app.Run();
