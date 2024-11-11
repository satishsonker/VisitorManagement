using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using VisitorManagement.Data;
using VisitorManagement.Validator;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssemblyContaining<VisitorValidator>();
});

// Add services to the container.
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigins",
        policy =>
        {
            policy.AllowAnyOrigin() // React frontend origin
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VisitorManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
