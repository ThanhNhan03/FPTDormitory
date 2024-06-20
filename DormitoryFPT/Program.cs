using DormitoryFPT.Data;
using DormitoryFPT.Mapping;
using DormitoryFPT.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DormDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Add scoped
builder.Services.AddScoped<IRoomRepository, SQLRoomRepository>();
builder.Services.AddScoped<IHouseRepository, SQLHouseRepository>();
builder.Services.AddScoped<IFloorRepository, SQLFloorRepository>();
builder.Services.AddScoped<IDormRepository, SQLDormRepository>();

builder.Services.AddAutoMapper(typeof(AutoMappingProfile));
//builder.Services.AddControllers()
//           .AddJsonOptions(options =>
//           {
//               options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//               options.JsonSerializerOptions.WriteIndented = true;
//           });

//builder.Services.AddControllers()
//               .AddJsonOptions(options =>
//                   options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);


//Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
