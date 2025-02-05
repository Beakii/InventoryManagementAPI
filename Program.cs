using InventoryManagement.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
AppConfiguration.AddDataServices(builder.Services, builder.Configuration);
AppConfiguration.AddSwagger(builder.Services);
// End of container

var app = builder.Build();

// Configure the HTTP request pipeline.
AppConfiguration.EnableSwagger(app);

app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
