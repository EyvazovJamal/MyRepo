using System.Reflection;
using FluentValidation;
using App.Middlewares;
using App.Options;
using App.Repositories;
using App.Repositories.Base;
using App.Repositories.BookRepository;
using App.Repositories.BookRepository.Base;
using App.Services;
using App.Services.Base;
using App.Services.BookServices;
using App.Services.BookServices.Base;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddValidatorsFromAssemblies(new Assembly[]{
    Assembly.GetExecutingAssembly()
});

builder.Services.AddScoped<IHttpLogRepository,HttpLogRepository>();
builder.Services.AddScoped<IHttpLogger,HttpLogger>();
builder.Services.AddScoped<IBookRepository,BookRepository>();
builder.Services.AddScoped<IBookService,BookService>();

builder.Services.Configure<DataBaseOptions>(options=>{
    var connectionString=builder.Configuration.GetConnectionString("BookReviewDb");
    options.ConnectionString=connectionString!;
});

builder.Services.AddScoped<ITestService,TestService>();



var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();


app.Run();

