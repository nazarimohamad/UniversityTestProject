using PersistanceEF;
using Services.Course;
using Services.Semester;
using PersistanceEF.Course;
using PersistanceEF.Semsters;
using Services.SharedContracts;
using Services.Course.Contract;
using Services.Semester.Contract;
using Services.Teacher;
using PersistanceEF.Teacher;
using Services.TeacherCourse.Contract;
using Services.TeacherCourse;
using PersistanceEF.TeacherCourse;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//data context
builder.Services.AddDbContext<EFDataContext>();
//service
builder.Services.AddScoped<SemesterService, SemesterAppService>();
builder.Services.AddScoped<CourseService, CourseAppService>();
builder.Services.AddScoped<TeacherService, TeacherAppService>();
builder.Services.AddScoped<TeacherCourseService, TeacherCourseAppService>();
//repository
builder.Services.AddScoped<SemesterRepository, EFSemesterRepository>();
builder.Services.AddScoped<CourseRepository, EFCourseRepository>();
builder.Services.AddScoped<TeacherRepository, EFTeacherRepository>();
builder.Services.AddScoped<TeacherCourseRepository, EFTeacherCourseRepository>();
//unit of work
builder.Services.AddTransient<UnitOfWork, EFUnitOfWork>();

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

