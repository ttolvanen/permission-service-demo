var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var permissions = new[]
{
  "ReadPermission", "WritePermission"
};
var random = new Random();

app.MapGet("/permissions", () => permissions[random.Next(0, 1)])
  .WithName("GetPermission")
  .WithOpenApi();

app.Run();
