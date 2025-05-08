var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
object value
    = builder.Services.AddSwaggerGen(); // ✅ Required

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();           // ✅ Required
    app.UseSwaggerUI();         // ✅ Required
}

app.UseAuthorization();
app.MapControllers();
app.Run();