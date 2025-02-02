using Persistence;

Console.WriteLine("Web API is starting...");
var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("IsDevelopment : " + builder.Environment.IsDevelopment());
Console.WriteLine("IsProduction : " + builder.Environment.IsProduction());
Console.WriteLine("Web Root Path" + builder.Environment.WebRootPath);
Console.WriteLine("Content Root Path" + builder.Environment.ContentRootPath);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddPersistenceServices(builder.Configuration.GetConnectionString("MiniECommerceConnectionString"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();