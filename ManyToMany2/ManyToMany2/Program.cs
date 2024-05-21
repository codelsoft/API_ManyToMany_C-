using ManyToMany2.Data;
using ManyToMany2.Helper;
using ManyToMany2.Interface;
using ManyToMany2.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PCContext>(opt => 
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("PCConn"));
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}) ;
builder.Services.AddScoped<IConsultant, ConsultantRepos>();
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfiles());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);



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
