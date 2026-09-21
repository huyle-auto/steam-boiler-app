namespace SteamBoilerApp.MVP.Views
{
    partial class AppSettingView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblHandshakeStatus = new Label();
            label4 = new Label();
            btnDisconnect = new Button();
            btnConnect = new Button();
            lblSlaveID = new Label();
            txtSlaveID = new TextBox();
            lblPort = new Label();
            txtPort = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtIPAddress = new TextBox();
            panel2 = new Panel();
            txtCtrlRoomPort = new TextBox();
            btnCtrlRoomDisconnect = new Button();
            btnCtrlRoomConnect = new Button();
            lblCtrlRoomStatus = new Label();
            label5 = new Label();
            button1 = new Button();
            button2 = new Button();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtCtrlRoomIPAddr = new TextBox();
            panel3 = new Panel();
            lblMqttStatus = new Label();
            btnMqttDisconnect = new Button();
            label12 = new Label();
            label3 = new Label();
            btnMqttConnect = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(lblHandshakeStatus);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnDisconnect);
            panel1.Controls.Add(btnConnect);
            panel1.Controls.Add(lblSlaveID);
            panel1.Controls.Add(txtSlaveID);
            panel1.Controls.Add(lblPort);
            panel1.Controls.Add(txtPort);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtIPAddress);
            panel1.Location = new Point(16, 15);
            panel1.Name = "panel1";
            panel1.Size = new Size(1068, 144);
            panel1.TabIndex = 0;
            // 
            // lblHandshakeStatus
            // 
            lblHandshakeStatus.Anchor = AnchorStyles.Top;
            lblHandshakeStatus.BackColor = Color.Red;
            lblHandshakeStatus.BorderStyle = BorderStyle.FixedSingle;
            lblHandshakeStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHandshakeStatus.Location = new Point(166, 105);
            lblHandshakeStatus.Name = "lblHandshakeStatus";
            lblHandshakeStatus.Size = new Size(36, 23);
            lblHandshakeStatus.TabIndex = 10;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(77, 105);
            label4.Name = "label4";
            label4.Size = new Size(52, 21);
            label4.TabIndex = 9;
            label4.Text = "Status";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Anchor = AnchorStyles.Top;
            btnDisconnect.AutoSize = true;
            btnDisconnect.Font = new Font("Segoe UI", 12F);
            btnDisconnect.Location = new Point(894, 45);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(104, 31);
            btnDisconnect.TabIndex = 8;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Top;
            btnConnect.AutoSize = true;
            btnConnect.Font = new Font("Segoe UI", 12F);
            btnConnect.Location = new Point(768, 45);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(104, 31);
            btnConnect.TabIndex = 7;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // lblSlaveID
            // 
            lblSlaveID.Anchor = AnchorStyles.Top;
            lblSlaveID.AutoSize = true;
            lblSlaveID.FlatStyle = FlatStyle.Flat;
            lblSlaveID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSlaveID.Location = new Point(552, 50);
            lblSlaveID.Name = "lblSlaveID";
            lblSlaveID.Size = new Size(64, 21);
            lblSlaveID.TabIndex = 6;
            lblSlaveID.Text = "Slave Id";
            lblSlaveID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSlaveID
            // 
            txtSlaveID.Anchor = AnchorStyles.Top;
            txtSlaveID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSlaveID.Location = new Point(624, 47);
            txtSlaveID.Name = "txtSlaveID";
            txtSlaveID.Size = new Size(74, 29);
            txtSlaveID.TabIndex = 5;
            txtSlaveID.Text = "1";
            txtSlaveID.TextAlign = HorizontalAlignment.Center;
            // 
            // lblPort
            // 
            lblPort.Anchor = AnchorStyles.Top;
            lblPort.AutoSize = true;
            lblPort.FlatStyle = FlatStyle.Flat;
            lblPort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPort.Location = new Point(372, 50);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(38, 21);
            lblPort.TabIndex = 4;
            lblPort.Text = "Port";
            lblPort.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPort
            // 
            txtPort.Anchor = AnchorStyles.Top;
            txtPort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPort.Location = new Point(416, 47);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(74, 29);
            txtPort.TabIndex = 3;
            txtPort.Text = "502";
            txtPort.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(77, 50);
            label2.Name = "label2";
            label2.Size = new Size(83, 21);
            label2.TabIndex = 2;
            label2.Text = "IP Address";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(103, 21);
            label1.TabIndex = 1;
            label1.Text = "Data Logger";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtIPAddress
            // 
            txtIPAddress.Anchor = AnchorStyles.Top;
            txtIPAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIPAddress.Location = new Point(166, 47);
            txtIPAddress.Name = "txtIPAddress";
            txtIPAddress.Size = new Size(158, 29);
            txtIPAddress.TabIndex = 0;
            txtIPAddress.Text = "10.0.166.210";
            txtIPAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.Controls.Add(txtCtrlRoomPort);
            panel2.Controls.Add(btnCtrlRoomDisconnect);
            panel2.Controls.Add(btnCtrlRoomConnect);
            panel2.Controls.Add(lblCtrlRoomStatus);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txtCtrlRoomIPAddr);
            panel2.Location = new Point(16, 379);
            panel2.Name = "panel2";
            panel2.Size = new Size(1068, 156);
            panel2.TabIndex = 11;
            panel2.Visible = false;
            // 
            // txtCtrlRoomPort
            // 
            txtCtrlRoomPort.Anchor = AnchorStyles.Top;
            txtCtrlRoomPort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCtrlRoomPort.Location = new Point(416, 56);
            txtCtrlRoomPort.Name = "txtCtrlRoomPort";
            txtCtrlRoomPort.Size = new Size(74, 29);
            txtCtrlRoomPort.TabIndex = 11;
            txtCtrlRoomPort.Text = "49321";
            txtCtrlRoomPort.TextAlign = HorizontalAlignment.Center;
            // 
            // btnCtrlRoomDisconnect
            // 
            btnCtrlRoomDisconnect.Anchor = AnchorStyles.Top;
            btnCtrlRoomDisconnect.AutoSize = true;
            btnCtrlRoomDisconnect.Font = new Font("Segoe UI", 12F);
            btnCtrlRoomDisconnect.Location = new Point(894, 54);
            btnCtrlRoomDisconnect.Name = "btnCtrlRoomDisconnect";
            btnCtrlRoomDisconnect.Size = new Size(104, 31);
            btnCtrlRoomDisconnect.TabIndex = 12;
            btnCtrlRoomDisconnect.Text = "Disconnect";
            btnCtrlRoomDisconnect.UseVisualStyleBackColor = true;
            btnCtrlRoomDisconnect.Click += btnCtrlRoomDisconnect_Click;
            // 
            // btnCtrlRoomConnect
            // 
            btnCtrlRoomConnect.Anchor = AnchorStyles.Top;
            btnCtrlRoomConnect.AutoSize = true;
            btnCtrlRoomConnect.Font = new Font("Segoe UI", 12F);
            btnCtrlRoomConnect.Location = new Point(768, 54);
            btnCtrlRoomConnect.Name = "btnCtrlRoomConnect";
            btnCtrlRoomConnect.Size = new Size(104, 31);
            btnCtrlRoomConnect.TabIndex = 11;
            btnCtrlRoomConnect.Text = "Connect";
            btnCtrlRoomConnect.UseVisualStyleBackColor = true;
            btnCtrlRoomConnect.Click += btnCtrlRoomConnect_Click;
            // 
            // lblCtrlRoomStatus
            // 
            lblCtrlRoomStatus.Anchor = AnchorStyles.Top;
            lblCtrlRoomStatus.BackColor = Color.Red;
            lblCtrlRoomStatus.BorderStyle = BorderStyle.FixedSingle;
            lblCtrlRoomStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCtrlRoomStatus.Location = new Point(166, 113);
            lblCtrlRoomStatus.Name = "lblCtrlRoomStatus";
            lblCtrlRoomStatus.Size = new Size(36, 23);
            lblCtrlRoomStatus.TabIndex = 10;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(77, 113);
            label5.Name = "label5";
            label5.Size = new Size(52, 21);
            label5.TabIndex = 9;
            label5.Text = "Status";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.AutoSize = true;
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(1328, 45);
            button1.Name = "button1";
            button1.Size = new Size(104, 31);
            button1.TabIndex = 8;
            button1.Text = "Disconnect";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.AutoSize = true;
            button2.Font = new Font("Segoe UI", 12F);
            button2.Location = new Point(1202, 45);
            button2.Name = "button2";
            button2.Size = new Size(104, 31);
            button2.TabIndex = 7;
            button2.Text = "Connect";
            button2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(372, 59);
            label7.Name = "label7";
            label7.Size = new Size(38, 21);
            label7.TabIndex = 4;
            label7.Text = "Port";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(77, 59);
            label8.Name = "label8";
            label8.Size = new Size(83, 21);
            label8.TabIndex = 2;
            label8.Text = "IP Address";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.FlatStyle = FlatStyle.Flat;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(9, 9);
            label9.Name = "label9";
            label9.Size = new Size(116, 21);
            label9.TabIndex = 1;
            label9.Text = "Control Room";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCtrlRoomIPAddr
            // 
            txtCtrlRoomIPAddr.Anchor = AnchorStyles.Top;
            txtCtrlRoomIPAddr.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCtrlRoomIPAddr.Location = new Point(166, 56);
            txtCtrlRoomIPAddr.Name = "txtCtrlRoomIPAddr";
            txtCtrlRoomIPAddr.Size = new Size(158, 29);
            txtCtrlRoomIPAddr.TabIndex = 0;
            txtCtrlRoomIPAddr.Text = "192.168.60.170";
            txtCtrlRoomIPAddr.TextAlign = HorizontalAlignment.Center;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblMqttStatus);
            panel3.Controls.Add(btnMqttDisconnect);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(btnMqttConnect);
            panel3.Location = new Point(16, 186);
            panel3.Name = "panel3";
            panel3.Size = new Size(1068, 172);
            panel3.TabIndex = 12;
            // 
            // lblMqttStatus
            // 
            lblMqttStatus.Anchor = AnchorStyles.Top;
            lblMqttStatus.BackColor = Color.Red;
            lblMqttStatus.BorderStyle = BorderStyle.FixedSingle;
            lblMqttStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMqttStatus.Location = new Point(166, 124);
            lblMqttStatus.Name = "lblMqttStatus";
            lblMqttStatus.Size = new Size(36, 23);
            lblMqttStatus.TabIndex = 12;
            // 
            // btnMqttDisconnect
            // 
            btnMqttDisconnect.Anchor = AnchorStyles.Top;
            btnMqttDisconnect.AutoSize = true;
            btnMqttDisconnect.Font = new Font("Segoe UI", 12F);
            btnMqttDisconnect.Location = new Point(894, 55);
            btnMqttDisconnect.Name = "btnMqttDisconnect";
            btnMqttDisconnect.Size = new Size(104, 31);
            btnMqttDisconnect.TabIndex = 16;
            btnMqttDisconnect.Text = "Stop";
            btnMqttDisconnect.UseVisualStyleBackColor = true;
            btnMqttDisconnect.Click += btnMqttDisconnect_Click;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top;
            label12.AutoSize = true;
            label12.FlatStyle = FlatStyle.Flat;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(77, 124);
            label12.Name = "label12";
            label12.Size = new Size(52, 21);
            label12.TabIndex = 11;
            label12.Text = "Status";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(9, 12);
            label3.Name = "label3";
            label3.Size = new Size(108, 21);
            label3.TabIndex = 11;
            label3.Text = "MQTT Broker";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnMqttConnect
            // 
            btnMqttConnect.Anchor = AnchorStyles.Top;
            btnMqttConnect.AutoSize = true;
            btnMqttConnect.Font = new Font("Segoe UI", 12F);
            btnMqttConnect.Location = new Point(768, 55);
            btnMqttConnect.Name = "btnMqttConnect";
            btnMqttConnect.Size = new Size(104, 31);
            btnMqttConnect.TabIndex = 15;
            btnMqttConnect.Text = "Start";
            btnMqttConnect.UseVisualStyleBackColor = true;
            btnMqttConnect.Click += btnMqttConnect_Click;
            // 
            // AppSettingView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "AppSettingView";
            Size = new Size(1101, 798);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtIPAddress;
        private Label lblSlaveID;
        private TextBox txtSlaveID;
        private Label lblPort;
        private TextBox txtPort;
        private Label label2;
        private Button btnDisconnect;
        private Button btnConnect;
        private Label lblHandshakeStatus;
        private Label label4;
        private Panel panel2;
        private Label lblCtrlRoomStatus;
        private Label label5;
        private Button button1;
        private Button button2;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtCtrlRoomIPAddr;
        private Button btnCtrlRoomDisconnect;
        private Button btnCtrlRoomConnect;
        private TextBox txtCtrlRoomPort;
        private Panel panel3;
        private Label label3;
        private Button btnMqttDisconnect;
        private Button btnMqttConnect;
        private Label lblMqttStatus;
        private Label label12;
    }
}
