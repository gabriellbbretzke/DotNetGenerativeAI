using DotnetGenerativeAI.Components;
using DotnetGenerativeAI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddOllamaChatCompletion(
    modelId: "phi3:mini",
    endpoint: new Uri("http://localhost:11434")
);

builder.Services.AddTransient((sp) => new Kernel(sp));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=DATA/app.db;Cache=Shared")); // This sets the database file name

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
