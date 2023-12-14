
using Microsoft.JSInterop;
using System.Text.Json;

public interface IUserService
{
    User? GetUser();

    void SetUser(User? user);

    Task GetUserFromLocalStorageAsync();

    Task SetUserFromLocalStorageAsync();

    Task ClearUser();
}
public class UserService : IUserService
{
    private User? _user;

    private readonly IJSRuntime _jsRuntime;

    public UserService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public User? GetUser() => _user;

    public void SetUser(User? user)
    {
        _user = user;
    }

    public async Task SetUserFromLocalStorageAsync()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "user", JsonSerializer.Serialize(_user));
    }


    public async Task GetUserFromLocalStorageAsync()
    {
        var storedUserJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "user");
        if (!string.IsNullOrEmpty(storedUserJson))
        {
            _user = JsonSerializer.Deserialize<User>(storedUserJson);
        }
    }

    public async Task ClearUser()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "user");
        _user = null;
    }
}
