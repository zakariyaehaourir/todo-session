using State_Managment.Filters;
using State_Managment.Options;
using State_Managment.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<LoggerFilter>();
}
    
    );
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
//Mapper la section dans json a la class FileSettings bch mn2njktiwch  IConf dans les classes
var fileSettings = builder.Configuration.GetSection("FileSettings").Get<FileSettings>();
builder.Services.AddSingleton(fileSettings);
builder.Services.AddSingleton<IFileService, FileService>();
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
