//using BL;

//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddSingleton<BLManager>();
//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
using BL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<BLManager>();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:4200", "development site")
    .AllowAnyHeader().AllowAnyMethod());
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAngular", builder =>
//    {
//        builder.WithOrigins("http://localhost:4200")
//               .AllowAnyHeader()
//               .AllowAnyMethod();
//    });
//});
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAngular");
app.Run();




