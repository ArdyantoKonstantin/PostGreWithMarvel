using MarvelContract.RequestModel;
using MarvelEntity.Entity;
using MarvelServices.RequestService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetConnectionString("UserDB");

builder.Services.AddDbContext<UserDbContext>(dbcontextBuilder =>
{
    dbcontextBuilder.UseNpgsql(connString).UseSnakeCaseNamingConvention();
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserHandler).Assembly));
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
