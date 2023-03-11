using System.Text.Json.Serialization;
using LMS.Web.API.Configurations;
using LMS.Web.API.Data;
using LMS.Web.API.Data.Contracts;
using LMS.Web.API.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LMSDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("LMSDbConnStr")));

builder.Services.AddControllers();

builder.Services.AddCors(q => q.AddPolicy("AllowAll", policy => policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<DbContext, LMSDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
