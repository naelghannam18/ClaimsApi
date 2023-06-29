using ClaimsApi;
using ClaimsApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    // these options are for dev purposes only and they pose security threats
    // We should specify each of those options
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.UseMiddleware<GlobalExceptionHandler>();

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();
