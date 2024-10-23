using Application.AutoMapper;
using Application.Reviews.DTOs.Validators;
using Application.Reviews.DTOs;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Application.Reviews.Queries.List;
using Application.Reviews.Queries.Get;
using Application.Reviews.Commands.Create;
using Application.Reviews.Commands.Update;
using Application.Reviews.Commands.Delete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();


builder.Services.AddDbContext<ReviewDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllReviewsHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetReviewByIdHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateReviewHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateReviewHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteReviewHandler).Assembly));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddTransient<IValidator<ReviewDto>, ReviewDTOValidator>();

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

app.MapControllers();

app.Run();

