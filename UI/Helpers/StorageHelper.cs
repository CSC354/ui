using Blazored.LocalStorage;

namespace UI.Helpers;

public static class StorageHelper
{
    private static string? Token { get; set; }
    private static string? Username { get; set; }

    public static string? User(this ILocalStorageService s) => Username;


    public static async Task CleanAsync(this ILocalStorageService s)
    {
        await s.ClearAsync();
        Token = null;
        Username = null;
    }

    public static async Task RegisterAsync(this ILocalStorageService storageService, string token, string username)
    {
        Token = token;
        await storageService.SetItemAsync("token", token);
        Username = username;
        await storageService.SetItemAsync("username", username);
    }
}