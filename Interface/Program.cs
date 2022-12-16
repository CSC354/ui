using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Grpc.Net.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();



builder.Services.AddBlazoredLocalStorage();

builder.Services.AddSingleton(sev =>
{
    const string url = "172.21.0.5:8000";
    var builder = new UriBuilder(url);
    var channel = GrpcChannel.ForAddress(builder.Uri);
    return new Sijl.Sijl.SijlClient(channel);
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