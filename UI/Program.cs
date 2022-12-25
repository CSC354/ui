using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Grpc.Net.Client;
using Syncfusion.Blazor;
using Sijl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddSyncfusionBlazor();
// const string sijl = "http://sijl:8000";
// const string discuss = "http://discuss:8000";


const string sijl = "172.21.0.5:8000";
const string discuss = "172.21.0.6:8000";

builder.Services.AddSingleton(_ =>
{
    var uriBuilder = new UriBuilder(sijl);
    var channel = GrpcChannel.ForAddress(uriBuilder.Uri);
    return new Sijl.Sijl.SijlClient(channel);
});


builder.Services.AddSingleton(_ =>
{
    var uriBuilder = new UriBuilder(sijl);
    var channel = GrpcChannel.ForAddress(uriBuilder.Uri);
    return new Profile.ProfileClient(channel);
});

builder.Services.AddSingleton(_ =>
    {
        var uriBuilder = new UriBuilder(discuss);
        var channel = GrpcChannel.ForAddress(uriBuilder.Uri);
        return new Discuss.Discuss.DiscussClient(channel);
    }
);


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