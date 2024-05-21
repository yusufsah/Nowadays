using Service.Contract;
using Service;
using Repositores.Constract;
using Repositores;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Ba�lant� dizgisini ekleyin (appsettings.json dosyas�ndan)
var connectionString = builder.Configuration.GetConnectionString("sqlConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new ArgumentNullException("sqlConnection", "Connection string 'sqlConnection' not found.");
}

builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(connectionString));

// Repository ve Service ba��ml�l�klar�n� kaydetme
builder.Services.AddScoped<IRepositoryManger, RepositoryManager>();
builder.Services.AddScoped<ICompanyRepositroyies, CompanyRepositroyies>();
builder.Services.AddScoped<IProjectRespository, ProjectRepository>();
builder.Services.AddScoped<IEmployeesRespository, EmployeesRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IEmployeeService, Employeeservice>();

// Swagger yap�land�rmas�
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper yap�land�rmas�
builder.Services.AddAutoMapper(typeof(Program));

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
