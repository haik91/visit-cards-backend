using Microsoft.EntityFrameworkCore;
using VisitCardDemo.DbContexts;
using VisitCardDemo.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// added ef 
builder.Services.AddDbContext<VisitCardContext>(options =>
    options.UseSqlite("Data Source=visitcards.db"));

// add mapping 
builder.Services.AddAutoMapper(typeof(MapingProfile));

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


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

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
