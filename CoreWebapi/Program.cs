using CoreWebapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IDataAccessService, DataAccessService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins(new string[]
                    {
                      "https://localhost:7373",
                       "https://localhost:3000",
                      "http://localhost:3000",


                    })
                .WithMethods("POST", "GET", "PUT", "DELETE")
         .AllowAnyHeader()
         .AllowCredentials();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowOrigin");

app.Run();
