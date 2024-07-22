
using InventoryManagement.API.Seed;
using InventoryManagement.BLL.Services.Implementations;
using InventoryManagement.BLL.Services.Interfaces;
using InventoryManagement.DAL.Data;
using InventoryManagement.DAL.Entities;
using InventoryManagement.DAL.Repositories.Implementations;
using InventoryManagement.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IDbInitializer,DbInitializer>();
builder.Services.AddScoped<IUnitOfWork ,UnitOfWork>();
builder.Services.AddScoped<IGenericServices, GenericServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
    var dbInitializer = services.GetRequiredService<IDbInitializer>();
    await dbInitializer.SeedRolesAndUsers();

}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
