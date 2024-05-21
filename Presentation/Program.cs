using Microsoft.EntityFrameworkCore;
using Presentation.Mapper;
using Repositores;
using Repositores.Constract;

using Service;
using Service.Contract;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();
builder.Services.AddControllersWithViews();   // biz ekledik
builder.Services.AddRazorPages(); // biz ekledik


builder.Services.AddAutoMapper(typeof(Program));




builder.Services.AddDbContext<RepositoryContext>(Option => // /// BU KISIM VERÝ BAÐLANTISI BUNU BAÞKA YERE TAÞIDIK GERKELÝ UNUTMA
{
   Option.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")) ; 
     Option.EnableSensitiveDataLogging(true);
}
);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IRepositoryManger, RepositoryManager>();
builder.Services.AddScoped<ICompanyRepositroyies, CompanyRepositroyies>();
builder.Services.AddScoped<IProjectRespository,ProjectRepository>();
builder.Services.AddScoped<IEmployeesRespository,EmployeesRepository>();



builder.Services.AddScoped<IServiceManager,ServiceManager>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IEmployeeService, Employeeservice>();







var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
