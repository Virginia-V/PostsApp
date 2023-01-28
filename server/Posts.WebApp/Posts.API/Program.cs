using Microsoft.EntityFrameworkCore;
using Posts.Bll;
using Posts.Bll.Interfaces;
using Posts.Bll.Services;
using Posts.Dal;
using Posts.Dal.Interfaces;
using Posts.Dal.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(BllAssemblyMarker));

builder.Services.AddDbContext<PostsDbContext>(optionBuilder =>
{
    optionBuilder.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("x-total-count");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
