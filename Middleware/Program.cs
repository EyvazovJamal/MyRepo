using Middleware.Middlewares;
using Middleware.Options;
using Middleware.Repositories;
using Middleware.Repositories.Base;
using Middleware.Services;
using Middleware.Services.Base;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IHttpLogRepository,HttpLogRepository>();
builder.Services.AddScoped<IHttpLogger,HttpLogger>();

builder.Services.Configure<DataBaseOptions>(options=>{
    var connectionString=builder.Configuration.GetConnectionString("BookReviewDb");
    options.ConnectionString=connectionString!;
});

builder.Services.AddScoped<ITestService,TestService>();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();


app.Run();

