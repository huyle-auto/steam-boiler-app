namespace SteamBoilerApp.MVP.Views
{
    partial class ScheduleView
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
            tableSchedule = new DataGridView();
            panel1 = new Panel();
            label6 = new Label();
            panel2 = new Panel();
            label7 = new Label();
            label8 = new Label();
            lblRemainCuts = new Label();
            label10 = new Label();
            lblCurrentSpeed = new Label();
            label4 = new Label();
            label5 = new Label();
            lblRemainLineal = new Label();
            label2 = new Label();
            label3 = new Label();
            lblRemainTime = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)tableSchedule).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableSchedule
            // 
            tableSchedule.AllowUserToAddRows = false;
            tableSchedule.AllowUserToDeleteRows = false;
            tableSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tableSchedule.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            tableSchedule.BackgroundColor = Color.White;
            tableSchedule.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tableSchedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tableSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            tableSchedule.DefaultCellStyle = dataGridViewCellStyle2;
            tableSchedule.Location = new Point(0, 55);
            tableSchedule.Name = "tableSchedule";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            tableSchedule.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            tableSchedule.SelectionMode = DataGridViewSelectionMode.CellSelect;
            tableSchedule.Size = new Size(1054, 238);
            tableSchedule.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(tableSchedule);
            panel1.Location = new Point(24, 377);
            panel1.Name = "panel1";
            panel1.Size = new Size(1054, 293);
            panel1.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(0, 84, 166);
            label6.Location = new Point(14, 16);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(101, 21);
            label6.TabIndex = 9;
            label6.Text = "Order Setup";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(lblRemainCuts);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(lblCurrentSpeed);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(lblRemainLineal);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lblRemainTime);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(24, 23);
            panel2.Name = "panel2";
            panel2.Size = new Size(334, 333);
            panel2.TabIndex = 3;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(188, 279);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Size = new Size(123, 21);
            label7.TabIndex = 13;
            label7.Text = "Remain Cuts";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(0, 84, 166);
            label8.Location = new Point(18, 228);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(65, 23);
            label8.TabIndex = 12;
            label8.Text = "m/min";
            // 
            // lblRemainCuts
            // 
            lblRemainCuts.AutoSize = true;
            lblRemainCuts.BackColor = Color.Transparent;
            lblRemainCuts.FlatStyle = FlatStyle.Flat;
            lblRemainCuts.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRemainCuts.ForeColor = Color.FromArgb(0, 84, 166);
            lblRemainCuts.Location = new Point(14, 269);
            lblRemainCuts.Margin = new Padding(0);
            lblRemainCuts.Name = "lblRemainCuts";
            lblRemainCuts.Size = new Size(33, 37);
            lblRemainCuts.TabIndex = 11;
            lblRemainCuts.Text = "0";
            lblRemainCuts.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.BackColor = Color.Transparent;
            label10.FlatStyle = FlatStyle.Flat;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(188, 199);
            label10.Margin = new Padding(0);
            label10.Name = "label10";
            label10.Size = new Size(123, 21);
            label10.TabIndex = 10;
            label10.Text = "Current Speed";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCurrentSpeed
            // 
            lblCurrentSpeed.AutoSize = true;
            lblCurrentSpeed.BackColor = Color.Transparent;
            lblCurrentSpeed.FlatStyle = FlatStyle.Flat;
            lblCurrentSpeed.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCurrentSpeed.ForeColor = Color.FromArgb(0, 84, 166);
            lblCurrentSpeed.Location = new Point(14, 191);
            lblCurrentSpeed.Margin = new Padding(0);
            lblCurrentSpeed.Name = "lblCurrentSpeed";
            lblCurrentSpeed.Size = new Size(33, 37);
            lblCurrentSpeed.TabIndex = 9;
            lblCurrentSpeed.Text = "0";
            lblCurrentSpeed.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(188, 118);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(123, 21);
            label4.TabIndex = 8;
            label4.Text = "Remain Lineal";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(0, 84, 166);
            label5.Location = new Point(18, 145);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(26, 23);
            label5.TabIndex = 7;
            label5.Text = "m";
            // 
            // lblRemainLineal
            // 
            lblRemainLineal.AutoSize = true;
            lblRemainLineal.BackColor = Color.Transparent;
            lblRemainLineal.FlatStyle = FlatStyle.Flat;
            lblRemainLineal.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRemainLineal.ForeColor = Color.FromArgb(0, 84, 166);
            lblRemainLineal.Location = new Point(14, 108);
            lblRemainLineal.Margin = new Padding(0);
            lblRemainLineal.Name = "lblRemainLineal";
            lblRemainLineal.Size = new Size(33, 37);
            lblRemainLineal.TabIndex = 6;
            lblRemainLineal.Text = "0";
            lblRemainLineal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(188, 56);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(123, 21);
            label2.TabIndex = 5;
            label2.Text = "Remain Time";
            label2.TextAlign = ContentAlignment.MiddleRight;
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
            label3.Size = new Size(0, 21);
            label3.TabIndex = 3;
            // 
            // lblRemainTime
            // 
            lblRemainTime.AutoSize = true;
            lblRemainTime.BackColor = Color.Transparent;
            lblRemainTime.FlatStyle = FlatStyle.Flat;
            lblRemainTime.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRemainTime.ForeColor = Color.FromArgb(0, 84, 166);
            lblRemainTime.Location = new Point(14, 48);
            lblRemainTime.Margin = new Padding(0);
            lblRemainTime.Name = "lblRemainTime";
            lblRemainTime.Size = new Size(33, 37);
            lblRemainTime.TabIndex = 1;
            lblRemainTime.Text = "0";
            lblRemainTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 84, 166);
            label1.Location = new Point(14, 15);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 0;
            label1.Text = "Current Order";
            // 
            // ScheduleView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ScheduleView";
            Size = new Size(1101, 902);
            Load += ScheduleView_Load;
            ((System.ComponentModel.ISupportInitialize)tableSchedule).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tableSchedule;
        private Panel panel1;
        private Panel panel2;
        private Label label4;
        private Label label5;
        private Label lblRemainLineal;
        private Label label2;
        private Label label3;
        private Label lblRemainTime;
        private Label label1;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lblRemainCuts;
        private Label label10;
        private Label lblCurrentSpeed;
    }
}
