using Autofac.Extensions.DependencyInjection;
using Autofac;
using DataAccessLayer.Mappers.AutoMapper;
using BusinessLayer.DependencyResolvers.Autofac;
using CoreLayer.DependencyResolvers;
using CoreLayer.Utilities.IoC;
using CoreLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(DtoMapper));

builder.Services.AddDependencyResolvers(new ICoreModule[] // Burada IcoreModule edirik ki sabahsý gün baþqa module yarada bil?rik
{
    new CoreModule()
});

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
