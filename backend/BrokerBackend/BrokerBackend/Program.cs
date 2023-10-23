using BrokerBackend.Repositories;
using BrokerBackend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json")
.Build();

//Get connection string
var connectionString = builder.Configuration.GetConnectionString("connMyDB");

//Add dbContext
builder.Services.AddDbContext<BrokerContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// servicios 
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<PurchasesService>();
builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<StockService>();

//Agrego CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddRouting(routing => routing.LowercaseUrls = true); //ruta en minuscula

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

//Agrego CORS
app.UseCors(); 

app.Run();
