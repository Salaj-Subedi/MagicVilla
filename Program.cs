using MagicVilla.Data;
using MagicVilla.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using Serilog;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.


//using Sirilog for logger instead of default logger 
//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
//    .WriteTo.File("log/villalogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();

//builder.Host.UseSerilog();
try {
    builder.Services.AddDbContext<ApplicationDbContext>(Option =>
    {
        Option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
    });
}
catch (Exception e) 
{
    Console.WriteLine(e);
}

builder.Services.AddControllers(option =>
{
    //option.ReturnHttpNotAcceptable = true; for allowing plain text
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters(); // for supporting xmlformatters
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILogging, Logging>(); // adding scope so that u can use it as dependency injection custom logger 
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

app.Run();
