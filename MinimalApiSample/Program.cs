
using ManagerModel.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using MinimalApiSample.DataDb;
using MinimalApiSample.DbMysql;
using MinimalApiSample.IIterfaces;
using MinimalApiSample.ServiceCustom;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddCors();



builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<MinimalApiSample.DataDb.TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));


builder.Services.AddDbContext<MovieMVCrud>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieMVCrud")
        // x => x.MigrationsAssembly("MinimalApiSample.Migrationds")
        );
 });

builder.Services.AddTransient<IDataService, DataService>();


builder.Services.AddTransient<IDataServiceMsql, DataServiceMysql>();



var connectionString = builder.Configuration.GetConnectionString("DbMysql");

builder.Services.AddDbContext<DataBaseMsql>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});




builder.Services.AddScoped<TokenService, TokenService>();

builder.Services.AddDbContext<DataBaseWithIdentity>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthIdentity")
        );
});

builder.Services
    .AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 3;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<DataBaseWithIdentity>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
        {
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = new TimeSpan(0, 1, 0);
        });

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "apiWithAuthBackend",
            ValidAudience = "apiWithAuthBackend",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("!SomethingSecret!")
            ),
        };
    });






//builder.Services.TryAddTransient<ILog,MyConsultApi>();


//var oneService = new ServiceDescriptor(typeof(ILog), typeof(MyConsultApi), ServiceLifetime.Scoped);
//builder.Services.Add(oneService);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

 // app.UseSession();

app.MapControllers();
app.MapDefaultControllerRoute();
app.UseHttpsRedirection();

// Creando Apis 
//app.MapGet("/todoitems", async (MovieMVCrud db) =>
//    await db.Movie.ToListAsync())
//        .WithName("ShowAllItems");

//app.MapGet("/todoitemsIs", async (MovieMVCrud db) =>
//{
//    await db.Movie
//    // .Where(x => x. == true)
//    .ToListAsync();
//});
//app.MapPost("TodoPost", async (MovieModel todo, MovieMVCrud db) =>
//{
//    todo.Id =  Guid.NewGuid();
//    db.Movie.Add(todo);
//    await db.SaveChangesAsync();
//    return Results.Created($"/todoitems{todo.Id}", todo);
//});

//app.MapGet("JustId/{id}", async (int id, MovieMVCrud db) =>
//    await db.Movie.FindAsync(id)
//    is MovieModel todo
//    ? Results.Ok(todo)
//    : Results.NotFound());

//app.MapDelete("DeleteItem/{id}", async (int id, MovieMVCrud db) =>
//{
//    if (await db.Movie.FindAsync(id) is MovieModel item)
//    {
//        db.Movie.Remove(item);
//        await db.SaveChangesAsync();
//        return Results.Ok(item);
//    }
//    return Results.NotFound();
//});

//app.MapPut("ChangeData/{id}", async (Guid id, MovieModel imputTodo, MovieMVCrud db) =>
//{
//   // var item = await db.Movie.FindAsync(id);
//    var _item = await  db.Movie.Where( x=> x.Id.Equals(id)).FirstAsync();
//    if (_item is null) return Results.NotFound();

//    // item.IsComplete = imputTodo.IsComplete;
//    _item.Title = imputTodo.Title;
//    await db.SaveChangesAsync();
//    return Results.NoContent();
//});
//app.MapGet("/ComeHere", () => "Hello Apis");
// Test Apis

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";




app.UseCors("AllowOrigin");

app.Run();
