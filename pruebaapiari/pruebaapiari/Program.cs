using Microsoft.EntityFrameworkCore;
using pruebaapiari.Controllers;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

Main();

app.Run();

static void Main()
{
    string dbName = "AriTracker.db";
    if (File.Exists(dbName))
    {
        File.Delete(dbName);
    }
    using (var dbContext = new SQLiteContext())
    {
        dbContext.Database.EnsureCreated();
        if (!dbContext.WorkOrders.Any())
        {
            dbContext.WorkOrders.AddRange(new WorkOrder[]
            {
                new WorkOrder(1,"userTest","1234","12345","Johnny Arcia","123451","jarcia@gmail.com","Test Address","Test second Arddress","OT-001",DateTime.Now,"2032","17","001","01",
                "123",8000,1,"Agencia1","Brigada1","Clasificacion1","Corte","Asignado","",DateTime.Now,"BADGER","123","4","Pulgadas",false,1241223,233134)
            });
            dbContext.SaveChanges();
        }
    }
}