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



       
    }

}

