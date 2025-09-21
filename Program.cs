using SignalRChat.Hubs;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins(
                              "https://agreeable-forest-053c68403.1.azurestaticapps.net",
                              "http://localhost:5173")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                      });
});


var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
app.MapHub<ChatHub>("/chatHub");
app.Run();
