using CheapBuyAPI;
using CheapBuyAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CheapBuyDbContext>(
       options => options.UseSqlServer(builder.Configuration["ConnectionString"]));


builder.Services.AddScoped<ICheapBuyDbContext, CheapBuyDbContext>();
builder.Services.AddScoped(typeof(ICheapBuyRepository<>), typeof(CheapBuyRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//TODO: Removed to run Nextjs locally
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
