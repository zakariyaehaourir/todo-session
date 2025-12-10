using State_Managment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService, UserService>(); //Chaque requette = instance
builder.Services.AddScoped<TodoService>();
builder.Services.AddScoped<ISessionManager , SessionManager>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(opt=>
    {
        opt.IdleTimeout = TimeSpan.FromHours(5);
        opt.Cookie.HttpOnly = true;
        opt.Cookie.Name = "SessionId";
    }
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
