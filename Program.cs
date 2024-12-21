using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VSureB2b_Reports.Control;
using VSureB2b_Reports.ImportExport;
using VSureB2b_Reports.BO;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<WebAPIManager>();
builder.Services.AddHttpClient<WebAPIManager>();

// Read allowed origins from appsettings.json
//var allowedCorsOrigins = builder.Configuration.GetSection("appSettings:AllowedCorsOrigins").Get<string[]>();

// Add CORS policies
//builder.Services.AddCors(options =>
//{
//    //options.AddPolicy("AllowSpecificPorts", builder =>
//    //    builder.WithOrigins(allowedCorsOrigins)
//    //           .AllowAnyHeader()
//    //           .AllowAnyMethod());
//    options.AddPolicy("AllowSpecificPorts1",
//        builder => builder.WithOrigins(
//                              "https://vieva.in:9002",
//                              "http://vieva.in:8000",
//                              "http://localhost:4300",
//                              "http://localhost:4200")
//                          .AllowAnyHeader()
//                          .AllowAnyMethod());

//    options.AddPolicy("AllowAllOrigins", builder =>
//        builder.AllowAnyOrigin()
//               .AllowAnyHeader()
//               .AllowAnyMethod());
//});


var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins(allowedOrigins)
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .SetIsOriginAllowed(origin => true)
                          .AllowCredentials());
});


var app = builder.Build();

Utility1.Configure(builder.Configuration);
//NTFW.Configure(builder.Configuration);

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin"); // Enable CORS
app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        if (!context.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
        {
            Console.WriteLine($"CORS header missing for request: {context.Request.Path}");
        }
        return Task.CompletedTask;
    });
    await next();
});

// Apply the "AllowAllOrigins" CORS policy globally
//app.UseCors("AllowAllOrigins");
// Apply the "AllowSpecificPorts" CORS policy to specific endpoints or globally as needed
//app.UseCors("AllowSpecificPorts");
//app.UseCors("AllowSpecificPorts1");

app.UseAuthorization();

app.MapControllers();

app.Run();
