global using ENSEK.Data;
global using Microsoft.EntityFrameworkCore;
using CsvHelper;
using ENSEK;
using ENSEK.Controllers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomOperationIds(apiDescription =>
    {
        return apiDescription.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DisplayOperationId();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//  For the Client

//var httpClient = new HttpClient();
//var client = new swaggerClient("https://localhost:7189/", httpClient);


//using (var streamReader = new StreamReader(@"C:\Meter_Reading.csv"))
//{
//    using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
//    {
//        var records = csvReader.GetRecords<dynamic>().ToList();
//    }
//}
