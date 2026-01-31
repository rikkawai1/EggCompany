
using Application.Services;
using Infrastructure.DBContext;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IncubatorDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

/////SERVICES
builder.Services.AddScoped<ConfigService>();
builder.Services.AddScoped<IncubatorService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<SalesOrderService>();
builder.Services.AddScoped<AIService>();
builder.Services.AddScoped<IncubatorModelService>();
builder.Services.AddScoped<WarrantyService>();
builder.Services.AddScoped<CustomerService>();

/////REPOSITORIES
builder.Services.AddScoped<ConfigRepository>();
builder.Services.AddScoped<IncubatorRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<SalesOrderRepository>();
builder.Services.AddScoped<MaintenanceTicketRepository>();
builder.Services.AddScoped<WarrantyRepository>();
builder.Services.AddScoped<IncubatorModelRepository>();
builder.Services.AddScoped<CustomerRepository>();

///MAPPER
builder.Services.AddAutoMapper(typeof(Application.Mappings.MappingProfile).Assembly);


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
