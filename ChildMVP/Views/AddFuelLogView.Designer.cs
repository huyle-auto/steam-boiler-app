namespace SteamBoilerApp.ChildMVP.Views
{
    partial class AddFuelLogView
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
            dtpAddFuelTime = new DateTimePicker();
            label1 = new Label();
            cboFuelType = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            numFuelMass = new NumericUpDown();
            panel1 = new Panel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFuelMass).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dtpAddFuelTime
            // 
            dtpAddFuelTime.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpAddFuelTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpAddFuelTime.Format = DateTimePickerFormat.Custom;
            dtpAddFuelTime.Location = new Point(120, 16);
            dtpAddFuelTime.Name = "dtpAddFuelTime";
            dtpAddFuelTime.Size = new Size(200, 29);
            dtpAddFuelTime.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 19);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 1;
            label1.Text = "Time:";
            // 
            // cboFuelType
            // 
            cboFuelType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboFuelType.FormattingEnabled = true;
            cboFuelType.Location = new Point(120, 20);
            cboFuelType.Name = "cboFuelType";
            cboFuelType.Size = new Size(200, 29);
            cboFuelType.TabIndex = 2;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 74);
            label5.Name = "label5";
            label5.Size = new Size(105, 21);
            label5.TabIndex = 8;
            label5.Text = "Weight (kg):";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(8, 23);
            label4.Name = "label4";
            label4.Size = new Size(86, 21);
            label4.TabIndex = 7;
            label4.Text = "Fuel Type:";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(cboFuelType);
            panel2.Controls.Add(numFuelMass);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 52);
            panel2.Name = "panel2";
            panel2.Size = new Size(336, 201);
            panel2.TabIndex = 14;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(155, 154);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 33);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.BackColor = Color.Lime;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(245, 154);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 33);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // numFuelMass
            // 
            numFuelMass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numFuelMass.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numFuelMass.Location = new Point(121, 72);
            numFuelMass.Maximum = new decimal(new int[] { 25000, 0, 0, 0 });
            numFuelMass.Name = "numFuelMass";
            numFuelMass.Size = new Size(109, 29);
            numFuelMass.TabIndex = 5;
            numFuelMass.TextAlign = HorizontalAlignment.Center;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtpAddFuelTime);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(336, 53);
            panel1.TabIndex = 15;
            // 
            // AddFuelLogView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 253);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFuelLogView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Fuel";
            Load += AddFuelLogView_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numFuelMass).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpAddFuelTime;
        private Label label1;
        private ComboBox cboFuelType;
        private NumericUpDown numFuelMass;
        private Label label5;
        private Label label4;
        private Panel panel2;
        private Panel panel1;
        private Button btnCancel;
        private Button btnSave;
    }
}