using Application.Interfaces;
using Application.Mapping;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Web.Dal.Context;
using Web.Dal.Repositories;
using Web.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("MvcDatabase");
Console.WriteLine(connectionString);

builder.Services.AddDbContext<MvcDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(typeof(CourseMappingProfile));
builder.Services.AddAutoMapper(typeof(EducatorMappingProfile));
builder.Services.AddAutoMapper(typeof(StudentMappingProfile));
builder.Services.AddAutoMapper(typeof(StudentModelMappingProfile));
builder.Services.AddAutoMapper(typeof(EducatorModelMappingProfile));
builder.Services.AddAutoMapper(typeof(CourseModelMappingProfile));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IEducatorRepository, EducatorRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<EducatorService>();
builder.Services.AddScoped<CourseService>();

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