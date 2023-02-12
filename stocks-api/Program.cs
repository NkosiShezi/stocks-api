var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var myAllowedSpecificOrigins = "_myAllowedSpecificOrigins";

builder.Services.AddCors(options => {
    options.AddPolicy(name: myAllowedSpecificOrigins,
        policy => {
            policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        });
    });

builder.Services.AddControllers();
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
app.UseCors(myAllowedSpecificOrigins);

app.Run();

