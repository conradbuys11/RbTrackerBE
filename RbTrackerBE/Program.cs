using Microsoft.EntityFrameworkCore;
using RbTrackerBE.DatabaseContext;
using RbTrackerBE.Services;

var corsPolicyName = "_myCorsPolicy";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
builder.Services.AddDbContext<AppDbContext>(options =>
    options
    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    //.UseSeeding((context, _) =>
    //{

    //})
    //.UseAsyncSeeding(async (context, _, cancellationToken) =>
    //{

    //})
    );

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicyName);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
