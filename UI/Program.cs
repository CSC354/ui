using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Grpc.Net.Client;
using Sijl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();


builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();

builder.Services.AddSingleton(_ =>
{
    const string url = "172.21.0.5:8000";
    var uriBuilder = new UriBuilder(url);
    var channel = GrpcChannel.ForAddress(uriBuilder.Uri);
    return new Sijl.Sijl.SijlClient(channel);
});


builder.Services.AddSingleton(_ =>
{
    const string url = "172.21.0.5:8000";
    var uriBuilder = new UriBuilder(url);
    var channel = GrpcChannel.ForAddress(uriBuilder.Uri);
    return new Profile.ProfileClient(channel);
});


var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();