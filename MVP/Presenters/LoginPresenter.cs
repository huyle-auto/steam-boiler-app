using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.WindowManagement;

namespace SteamBoilerApp.MVP.Presenters
{
    public class LoginPresenter : IDisposable
    {
        private readonly ILoginView _view;
        private readonly IAuthService _auth;

        public event EventHandler<string>? LoginSucceeded;

        public LoginPresenter(ILoginView view, IAuthService auth)
        {
            this._view = view;
            this._auth = auth;
            this._view.LoginClicked += OnLoginClicked;
            this._view.CreateUserClicked += OnCreateUserClicked;
        }

        public void Dispose()
        {
            this._view.LoginClicked -= OnLoginClicked;
            this._view.CreateUserClicked -= OnCreateUserClicked;
        }

        private async void OnLoginClicked(object? sender, EventArgs e)
        {
            try
            {
                bool ok = await _auth.ValidateUserAsync(_view.Username, _view.Password);
                if (ok)
                {
                    this.LoginSucceeded?.Invoke(this, _view.Username);

                    _view.ClearInfo();  // Erase user info before closing
                    _view.Close();
                }
                else
                {
                    _view.ShowStatus("*Wrong username or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please connect to the correct Network." + "\n" + ex.InnerException?.Message ?? ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void OnCreateUserClicked(object? sender, EventArgs e)
        {
            try
            {
                if (_view.Username == string.Empty || _view.Password == string.Empty)
                {
                    _view.ShowStatus("*Missing username or password");
                    return;
                }

                bool ok = await _auth.CreateUserAsync(_view.Username, _view.Password);
                if (ok)
                {
                    _view.ClearInfo();  // Erase user info before closing
                }
                else
                {
                    _view.ShowStatus("*Wrong username or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
