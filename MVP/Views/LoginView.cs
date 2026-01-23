using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamBoilerApp.MVP.Views
{
    public partial class LoginView : Form, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public string Username => txtUsername.Text;

        public string Password => txtPassword.Text;

        public event EventHandler? LoginClicked;
        public event EventHandler? CreateUserClicked;

        public void ClearInfo()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        public void ShowStatus(string message)
        {
            lblStatus.Text = message;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginClicked?.Invoke(this, EventArgs.Empty);
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lblStatus;  // try not to focus any TextBox on load
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            CreateUserClicked?.Invoke(this, EventArgs.Empty);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            ShowStatus(string.Empty);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            ShowStatus(string.Empty);
        }

        private void OnFormResize(object sender, EventArgs e)
        {
            picBoxImage.Width = (int)(0.6 * this.Width);
            panelLoginInfo.Width = this.Width - picBoxImage.Width;
        }
    }
}
