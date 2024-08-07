using Autofac;
using Autofac.Extensions.DependencyInjection;
using ExaminationSystem;
using ExaminationSystem.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Autofac as the service provider factory.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
// Register services using Autofac.
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    containerBuilder.RegisterModule(new AutofacModule()));

builder.Services.AddAutoMapper(typeof(ExamProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
