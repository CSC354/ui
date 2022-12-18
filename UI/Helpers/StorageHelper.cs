using Blazored.LocalStorage;
using static System.String;

namespace UI.Helpers;

public static class StorageHelper
{
    private static string Token { get; set; } = null!;
    private static string Username { get; set; } = null!;

    public static string User(this ILocalStorageService s) => Username;
    public static string UserToken(this ILocalStorageService s) => Token;


    public static async Task CleanAsync(this ILocalStorageService s)
    {
        await s.ClearAsync();
        Token = Empty;
        Username = Empty;
    }

    public static async Task RegisterAsync(this ILocalStorageService storageService, string token, string username)
    {
        Token = token;
        await storageService.SetItemAsync("token", token);
        Username = username;
        await storageService.SetItemAsync("username", username);
    }
}