using AutoMapper;
using EmailNotification.BLL;
using EmailNotification.BLL.Interfaces;
using EmailNotification.DAL;
using EmailNotification.DAL.Interfaces;
using EmailNotification.Mappers;
using EmailNotification.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EmailDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NotificationDatabase")));

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddCors(p => p.AddPolicy("notificationApp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<INotificationBusiness, NotificationBusiness>();
builder.Services.AddTransient<INotificationDataAccess, NotificationDataAccess>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("notificationApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
