using Taze.Business.Abstract;
using Taze.Business.Concrete;
using Taze.Data;
using Taze.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection ayarlarý
builder.Services.AddSingleton<TazeContext>();
builder.Services.AddScoped<IGenericRepository, GenericRepository>();
builder.Services.AddScoped<IContentService, ContentManager>();

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
