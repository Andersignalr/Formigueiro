using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAnyOrigin", builder =>
	{
		builder.AllowAnyOrigin()
			   .AllowAnyMethod()
			   .AllowAnyHeader();
	});
});


builder.Services.AddDbContextFactory<ChatContext>(opt =>
	opt.UseSqlite("Data source=chat.db"));

var app = builder.Build();

await using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
var context = scope.ServiceProvider.GetRequiredService<ChatContext>();
await context.Database.EnsureCreatedAsync();

if (!app.Environment.IsDevelopment())
{
	Console.WriteLine("AQUI É O PRODUÇÃO, PARÇA!");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
else
{
	Console.WriteLine("AQUI É O DESENVOLVIMENTO, PARÇA!");
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.MapHub<ChatHub>("/chathub");

app.Run();
