using UserManager.Data;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddData(builder.Configuration)
        .AddService();
}

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserManager}/{action=UserManager}/{id?}");

using (var scope = app.Services.CreateScope())
    try
    {
        var scopedContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        DbInitializer.Initializer(scopedContext);
    }
    catch
    {
        throw;
    }

app.Run();
