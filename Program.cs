using api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => 
    {
        policy.WithOrigins("http://localhost:5022") // Origen de tu aplicación Blazor
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();



