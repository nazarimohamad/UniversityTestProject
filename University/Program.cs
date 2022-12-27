using PersistanceEF;
using PersistanceEF.Semsters;
using Services.Semester;
using Services.Semester.Contract;
using Services.SharedContracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//data context
builder.Services.AddDbContext<EFDataContext>();
//service
builder.Services.AddScoped<SemesterService, SemesterAppService>();
//repository
builder.Services.AddScoped<SemesterRepository, EFSemesterRepository>();
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

