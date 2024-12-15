using ProyectoBlazor.Service;
using System.Text.Json;
using ProyectoBlazor.Modelos;

namespace ProyectoBlazor
{
    public class AppState
    {

        private Usuario? _currentUser;

        public AppState() { }

        public Usuario? CurrentUser
        {
            get => _currentUser;
            private set
            {
                if (_currentUser != value)
                {
                    _currentUser = value;
                }
            }
        }

        // Setter
        public void SetCurrentUser(Usuario? user)
        {
            CurrentUser = user;
        }



        //    private readonly LocalStorageService _localStorageService;
        //    private Usuario? _currentUser;
        //    private bool _initialized = false;

        //    public AppState(LocalStorageService localStorageService)
        //    {
        //        _localStorageService = localStorageService;
        //    }

        //    public Usuario? CurrentUser
        //    {
        //        get => _currentUser;
        //        private set
        //        {
        //            if (_currentUser != value)
        //            {
        //                _currentUser = value;
        //                SaveUserToLocalStorage(_currentUser);
        //                OnChange?.Invoke();
        //            }
        //        }

        //    }

        //    public void Login(Usuario user)
        //    {
        //        _currentUser = user;
        //        this.SaveUserToLocalStorage(user);
        //    }

        //    public void Logout()
        //    {
        //        _currentUser = null;
        //    }

        //    async public Task<bool> IsAuthenticated()
        //    {
        //        await this.LoadUserFromLocalStorage();
        //        return _currentUser != null;
        //    }

        //    private async Task LoadUserFromLocalStorage()
        //    {
        //        var userJson = await _localStorageService.GetItemAsync("currentUser");
        //        if (!string.IsNullOrEmpty(userJson))
        //        {
        //            _currentUser = JsonSerializer.Deserialize<Usuario>(userJson);
        //        }
        //    }

        //    private async Task SaveUserToLocalStorage(Usuario? user)
        //    {
        //        if (user != null)
        //        {
        //            var userJson = JsonSerializer.Serialize(user);
        //            await _localStorageService.SetItemAsync("currentUser", userJson);
        //        }
        //        else
        //        {
        //            await _localStorageService.RemoveItemAsync("currentUser");
        //        }
        //    }

        //    public event Action? OnChange;

        //    public async Task InitializeAsync()
        //    {
        //        if (!_initialized)
        //        {
        //            await LoadUserFromLocalStorage();
        //            _initialized = true;
        //        }
        //    }
        //}


    }

}

