var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/build";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSpaStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");


// https://alexpotter.dev/net-6-with-vue-3/
app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    spa.Options.DefaultPageStaticFileOptions = new()
    {
        OnPrepareResponse = context =>
        {
            context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
            context.Context.Response.Headers.Add("Expires", "0");
        }
    };

    if (app.Environment.IsDevelopment())
    {
        SpaProxyingExtensions.UseProxyToSpaDevelopmentServer(spa, () =>
        {
            return Task.FromResult(new UriBuilder("http", "localhost", 3000).Uri);
        });
    }
    else
    {
        app.MapFallbackToFile("index.html"); 
    }
});

app.Run();
