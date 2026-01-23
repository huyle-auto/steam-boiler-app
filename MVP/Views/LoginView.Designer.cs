namespace SteamBoilerApp.MVP.Views
{
    partial class LoginView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            picBoxImage = new PictureBox();
            panelLoginInfo = new Panel();
            btnCreateUser = new Button();
            lblStatus = new Label();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)picBoxImage).BeginInit();
            panelLoginInfo.SuspendLayout();
            SuspendLayout();
            // 
            // picBoxImage
            // 
            picBoxImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picBoxImage.BackColor = Color.White;
            picBoxImage.Image = Properties.Resources.scgp_png;
            picBoxImage.Location = new Point(0, 0);
            picBoxImage.Margin = new Padding(4);
            picBoxImage.Name = "picBoxImage";
            picBoxImage.Size = new Size(570, 577);
            picBoxImage.SizeMode = PictureBoxSizeMode.CenterImage;
            picBoxImage.TabIndex = 0;
            picBoxImage.TabStop = false;
            // 
            // panelLoginInfo
            // 
            panelLoginInfo.BackColor = Color.White;
            panelLoginInfo.Controls.Add(btnCreateUser);
            panelLoginInfo.Controls.Add(lblStatus);
            panelLoginInfo.Controls.Add(btnLogin);
            panelLoginInfo.Controls.Add(txtPassword);
            panelLoginInfo.Controls.Add(txtUsername);
            panelLoginInfo.Controls.Add(label1);
            panelLoginInfo.Dock = DockStyle.Right;
            panelLoginInfo.Location = new Point(568, 0);
            panelLoginInfo.Name = "panelLoginInfo";
            panelLoginInfo.Size = new Size(380, 577);
            panelLoginInfo.TabIndex = 1;
            // 
            // btnCreateUser
            // 
            btnCreateUser.Anchor = AnchorStyles.None;
            btnCreateUser.BackColor = Color.FromArgb(56, 115, 185);
            btnCreateUser.FlatAppearance.BorderSize = 0;
            btnCreateUser.FlatStyle = FlatStyle.Flat;
            btnCreateUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateUser.ForeColor = Color.White;
            btnCreateUser.Location = new Point(41, 464);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(307, 35);
            btnCreateUser.TabIndex = 5;
            btnCreateUser.Text = "CREATE USER";
            btnCreateUser.UseVisualStyleBackColor = false;
            btnCreateUser.Visible = false;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.None;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(41, 320);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(307, 28);
            lblStatus.TabIndex = 4;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.BackColor = Color.FromArgb(56, 115, 185);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(41, 356);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(307, 35);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Location = new Point(41, 295);
            txtPassword.MaxLength = 20;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(307, 22);
            txtPassword.TabIndex = 2;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.None;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Location = new Point(41, 247);
            txtUsername.MaxLength = 20;
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(307, 22);
            txtUsername.TabIndex = 1;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(41, 182);
            label1.Name = "label1";
            label1.Size = new Size(307, 39);
            label1.TabIndex = 0;
            label1.Text = "SIGN IN TO YOUR ACCOUNT";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginView
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 577);
            Controls.Add(panelLoginInfo);
            Controls.Add(picBoxImage);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MinimumSize = new Size(964, 616);
            Name = "LoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Welcome";
            Load += LoginView_Load;
            Resize += OnFormResize;
            ((System.ComponentModel.ISupportInitialize)picBoxImage).EndInit();
            panelLoginInfo.ResumeLayout(false);
            panelLoginInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picBoxImage;
        private Panel panelLoginInfo;
        private Label label1;
        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label lblStatus;
        private Button btnCreateUser;
    }
}