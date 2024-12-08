using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Contexts;
using TaskManagementSystem.Factories;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Service;
using TaskManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
}
);
builder.Services.AddScoped<ICategoryepository, Catigoryepository>();
builder.Services.AddScoped<IManagedTaskRepository, ManagedTaskRepository>();
builder.Services.AddScoped<IPriorityRepository, PriorityRepository>();
builder.Services.AddScoped<IManagedTaskFactory, ManagedTaskFactory>();
builder.Services.AddScoped<IManagedTaskService, ManagedTaskService>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); 
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

app.Run();
