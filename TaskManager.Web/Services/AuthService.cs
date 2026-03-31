using System.Net.Http.Json;
using System.Text.Json;
using TaskManager.Web.Models;

namespace TaskManager.Web.Services;

public class AuthService
{
    private readonly HttpClient _http;
    private string? _token;
    private string? _userName;

    public AuthService(HttpClient http)
    {
        _http = http;
    }

    public bool IsAuthenticated => _token is not null;
    public string? UserName => _userName;

    public async Task<bool> LoginAsync(LoginRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/Auth/login", request);
        if (!response.IsSuccessStatusCode) return false;

        var result = await response.Content.ReadFromJsonAsync<JsonElement>();
        _token = result.GetProperty("token").GetString();
        _userName = result.GetProperty("name").GetString();
        _http.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
        return true;
    }

    public async Task<bool> RegisterAsync(RegisterRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/Auth/register", request);
        return response.IsSuccessStatusCode;
    }

    public void Logout()
    {
        _token = null;
        _userName = null;
        _http.DefaultRequestHeaders.Authorization = null;
    }
}