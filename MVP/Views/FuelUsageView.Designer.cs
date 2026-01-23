namespace SteamBoilerApp.MVP.Views
{
    partial class FuelUsageView
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            lblThirdFuelName = new Label();
            label8 = new Label();
            lblThirdFuelUsed = new Label();
            lblSecondFuelName = new Label();
            label5 = new Label();
            lblSecondFuelUsed = new Label();
            lblFirstFuelName = new Label();
            dtpFuelUsageDay = new DateTimePicker();
            label3 = new Label();
            lblFirstFuelUsed = new Label();
            label1 = new Label();
            dtpFuelFeedLog = new DateTimePicker();
            btnAddFuelLog = new Button();
            tableFuelFeedLog = new DataGridView();
            panel2 = new Panel();
            lblFourthFuelName = new Label();
            label4 = new Label();
            lblFourthFuelUsed = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableFuelFeedLog).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblFourthFuelName);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lblFourthFuelUsed);
            panel1.Controls.Add(lblThirdFuelName);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(lblThirdFuelUsed);
            panel1.Controls.Add(lblSecondFuelName);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblSecondFuelUsed);
            panel1.Controls.Add(lblFirstFuelName);
            panel1.Controls.Add(dtpFuelUsageDay);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblFirstFuelUsed);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(17, 17);
            panel1.Name = "panel1";
            panel1.Size = new Size(309, 397);
            panel1.TabIndex = 0;
            // 
            // lblThirdFuelName
            // 
            lblThirdFuelName.AutoSize = true;
            lblThirdFuelName.BackColor = Color.Transparent;
            lblThirdFuelName.FlatStyle = FlatStyle.Flat;
            lblThirdFuelName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThirdFuelName.Location = new Point(106, 218);
            lblThirdFuelName.Margin = new Padding(0);
            lblThirdFuelName.Name = "lblThirdFuelName";
            lblThirdFuelName.Size = new Size(52, 21);
            lblThirdFuelName.TabIndex = 11;
            lblThirdFuelName.Text = "Fuel 3";
            lblThirdFuelName.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(0, 84, 166);
            label8.Location = new Point(18, 246);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(29, 21);
            label8.TabIndex = 10;
            label8.Text = "kg";
            // 
            // lblThirdFuelUsed
            // 
            lblThirdFuelUsed.AutoSize = true;
            lblThirdFuelUsed.BackColor = Color.Transparent;
            lblThirdFuelUsed.FlatStyle = FlatStyle.Flat;
            lblThirdFuelUsed.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblThirdFuelUsed.ForeColor = Color.FromArgb(0, 84, 166);
            lblThirdFuelUsed.Location = new Point(14, 209);
            lblThirdFuelUsed.Margin = new Padding(0);
            lblThirdFuelUsed.Name = "lblThirdFuelUsed";
            lblThirdFuelUsed.Size = new Size(56, 37);
            lblThirdFuelUsed.TabIndex = 9;
            lblThirdFuelUsed.Text = "0.0";
            lblThirdFuelUsed.Visible = false;
            // 
            // lblSecondFuelName
            // 
            lblSecondFuelName.AutoSize = true;
            lblSecondFuelName.BackColor = Color.Transparent;
            lblSecondFuelName.FlatStyle = FlatStyle.Flat;
            lblSecondFuelName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSecondFuelName.Location = new Point(106, 137);
            lblSecondFuelName.Margin = new Padding(0);
            lblSecondFuelName.Name = "lblSecondFuelName";
            lblSecondFuelName.Size = new Size(52, 21);
            lblSecondFuelName.TabIndex = 8;
            lblSecondFuelName.Text = "Fuel 2";
            lblSecondFuelName.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(0, 84, 166);
            label5.Location = new Point(18, 165);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(29, 21);
            label5.TabIndex = 7;
            label5.Text = "kg";
            // 
            // lblSecondFuelUsed
            // 
            lblSecondFuelUsed.AutoSize = true;
            lblSecondFuelUsed.BackColor = Color.Transparent;
            lblSecondFuelUsed.FlatStyle = FlatStyle.Flat;
            lblSecondFuelUsed.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSecondFuelUsed.ForeColor = Color.FromArgb(0, 84, 166);
            lblSecondFuelUsed.Location = new Point(14, 128);
            lblSecondFuelUsed.Margin = new Padding(0);
            lblSecondFuelUsed.Name = "lblSecondFuelUsed";
            lblSecondFuelUsed.Size = new Size(56, 37);
            lblSecondFuelUsed.TabIndex = 6;
            lblSecondFuelUsed.Text = "0.0";
            lblSecondFuelUsed.Visible = false;
            // 
            // lblFirstFuelName
            // 
            lblFirstFuelName.AutoSize = true;
            lblFirstFuelName.BackColor = Color.Transparent;
            lblFirstFuelName.FlatStyle = FlatStyle.Flat;
            lblFirstFuelName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFirstFuelName.Location = new Point(106, 57);
            lblFirstFuelName.Margin = new Padding(0);
            lblFirstFuelName.Name = "lblFirstFuelName";
            lblFirstFuelName.Size = new Size(52, 21);
            lblFirstFuelName.TabIndex = 5;
            lblFirstFuelName.Text = "Fuel 1";
            lblFirstFuelName.Visible = false;
            // 
            // dtpFuelUsageDay
            // 
            dtpFuelUsageDay.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFuelUsageDay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFuelUsageDay.Format = DateTimePickerFormat.Short;
            dtpFuelUsageDay.Location = new Point(181, 12);
            dtpFuelUsageDay.Name = "dtpFuelUsageDay";
            dtpFuelUsageDay.Size = new Size(109, 29);
            dtpFuelUsageDay.TabIndex = 4;
            dtpFuelUsageDay.ValueChanged += dtpFuelUsage_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 84, 166);
            label3.Location = new Point(18, 85);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(29, 21);
            label3.TabIndex = 3;
            label3.Text = "kg";
            // 
            // lblFirstFuelUsed
            // 
            lblFirstFuelUsed.AutoSize = true;
            lblFirstFuelUsed.BackColor = Color.Transparent;
            lblFirstFuelUsed.FlatStyle = FlatStyle.Flat;
            lblFirstFuelUsed.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFirstFuelUsed.ForeColor = Color.FromArgb(0, 84, 166);
            lblFirstFuelUsed.Location = new Point(14, 48);
            lblFirstFuelUsed.Margin = new Padding(0);
            lblFirstFuelUsed.Name = "lblFirstFuelUsed";
            lblFirstFuelUsed.Size = new Size(56, 37);
            lblFirstFuelUsed.TabIndex = 1;
            lblFirstFuelUsed.Text = "0.0";
            lblFirstFuelUsed.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 15);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(135, 21);
            label1.TabIndex = 0;
            label1.Text = "Total Fuel Usage";
            // 
            // dtpFuelFeedLog
            // 
            dtpFuelFeedLog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFuelFeedLog.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFuelFeedLog.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFuelFeedLog.Format = DateTimePickerFormat.Short;
            dtpFuelFeedLog.Location = new Point(14, 12);
            dtpFuelFeedLog.Name = "dtpFuelFeedLog";
            dtpFuelFeedLog.Size = new Size(109, 29);
            dtpFuelFeedLog.TabIndex = 12;
            dtpFuelFeedLog.ValueChanged += dtpFuelFeedLog_ValueChanged;
            // 
            // btnAddFuelLog
            // 
            btnAddFuelLog.AutoSize = true;
            btnAddFuelLog.BackColor = Color.Transparent;
            btnAddFuelLog.FlatStyle = FlatStyle.System;
            btnAddFuelLog.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddFuelLog.Location = new Point(129, 9);
            btnAddFuelLog.Name = "btnAddFuelLog";
            btnAddFuelLog.Size = new Size(101, 33);
            btnAddFuelLog.TabIndex = 13;
            btnAddFuelLog.Text = "Add New";
            btnAddFuelLog.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddFuelLog.UseVisualStyleBackColor = false;
            btnAddFuelLog.Visible = false;
            btnAddFuelLog.Click += btnAddFuelLog_Click;
            // 
            // tableFuelFeedLog
            // 
            tableFuelFeedLog.AllowUserToDeleteRows = false;
            tableFuelFeedLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tableFuelFeedLog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            tableFuelFeedLog.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tableFuelFeedLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tableFuelFeedLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            tableFuelFeedLog.DefaultCellStyle = dataGridViewCellStyle2;
            tableFuelFeedLog.Location = new Point(0, 57);
            tableFuelFeedLog.Name = "tableFuelFeedLog";
            tableFuelFeedLog.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            tableFuelFeedLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            tableFuelFeedLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableFuelFeedLog.Size = new Size(733, 269);
            tableFuelFeedLog.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dtpFuelFeedLog);
            panel2.Controls.Add(tableFuelFeedLog);
            panel2.Controls.Add(btnAddFuelLog);
            panel2.Location = new Point(350, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(733, 326);
            panel2.TabIndex = 15;
            // 
            // lblFourthFuelName
            // 
            lblFourthFuelName.AutoSize = true;
            lblFourthFuelName.BackColor = Color.Transparent;
            lblFourthFuelName.FlatStyle = FlatStyle.Flat;
            lblFourthFuelName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFourthFuelName.Location = new Point(106, 308);
            lblFourthFuelName.Margin = new Padding(0);
            lblFourthFuelName.Name = "lblFourthFuelName";
            lblFourthFuelName.Size = new Size(52, 21);
            lblFourthFuelName.TabIndex = 14;
            lblFourthFuelName.Text = "Fuel 4";
            lblFourthFuelName.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(0, 84, 166);
            label4.Location = new Point(18, 336);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(29, 21);
            label4.TabIndex = 13;
            label4.Text = "kg";
            // 
            // lblFourthFuelUsed
            // 
            lblFourthFuelUsed.AutoSize = true;
            lblFourthFuelUsed.BackColor = Color.Transparent;
            lblFourthFuelUsed.FlatStyle = FlatStyle.Flat;
            lblFourthFuelUsed.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFourthFuelUsed.ForeColor = Color.FromArgb(0, 84, 166);
            lblFourthFuelUsed.Location = new Point(14, 299);
            lblFourthFuelUsed.Margin = new Padding(0);
            lblFourthFuelUsed.Name = "lblFourthFuelUsed";
            lblFourthFuelUsed.Size = new Size(56, 37);
            lblFourthFuelUsed.TabIndex = 12;
            lblFourthFuelUsed.Text = "0.0";
            lblFourthFuelUsed.Visible = false;
            // 
            // FuelUsageView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FuelUsageView";
            Size = new Size(1101, 709);
            Load += FuelUsageView_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tableFuelFeedLog).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label lblFirstFuelUsed;
        private Label label3;
        private DateTimePicker dtpFuelUsageDay;
        private Label lblThirdFuelName;
        private Label label8;
        private Label lblThirdFuelUsed;
        private Label lblSecondFuelName;
        private Label label5;
        private Label lblSecondFuelUsed;
        private Label lblFirstFuelName;
        private DateTimePicker dtpFuelFeedLog;
        private Button btnAddFuelLog;
        private DataGridView tableFuelFeedLog;
        private Panel panel2;
        private Label lblFourthFuelName;
        private Label label4;
        private Label lblFourthFuelUsed;
    }
}
