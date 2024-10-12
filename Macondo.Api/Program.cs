using Macondo.Data;
using Macondo.Repositories.Interfaces;
using Macondo.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    });
builder.Services.AddScoped<IRepository<Macondo.Model.List>, Repository<Macondo.Model.List>>();
builder.Services.AddScoped<ListService>();
builder.Services.AddScoped<IRepository<Macondo.Model.Item>, Repository<Macondo.Model.Item>>();
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<IRepository<Macondo.Model.Sample>, Repository<Macondo.Model.Sample>>();
builder.Services.AddScoped<SampleService>();

// Retrieve connection string from configuration
    var connectionString = Macondo.Helpers.ConfigurationHelper.GetConnectionString("MacondoDatabase");

    // Register the connection string as a singleton service
    builder.Services.AddSingleton(connectionString);

    // Register the DbContext with the same connection string
    builder.Services.AddDbContext<MacondoContext>(options =>options.UseSqlServer(connectionString));
    var app = builder.Build();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();



    app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // نمایش Swagger UI در URL اصلی
});


// Optional: شما می‌توانید مسیر پیش‌فرض را به صفحه Swagger هدایت کنید.
app.MapGet("/", context =>
{
    context.Response.Redirect("/index.html");

    return Task.CompletedTask;
});
app.UseRouting();


app.MapControllers(); // مپ کردن کنترلرها


app.Run();  // This is necessary to run the application