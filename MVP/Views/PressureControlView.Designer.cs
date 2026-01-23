namespace SteamBoilerApp.MVP.Views
{
    partial class PressureControlView
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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PressureControlView));
            chartPressure = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panelChart = new Panel();
            lblStatus = new Label();
            btnLiveData = new Button();
            dtpToDate = new DateTimePicker();
            lblTo = new Label();
            dtpFromDate = new DateTimePicker();
            lblFrom = new Label();
            btnRefresh = new Button();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            btnBrowseFolder = new Button();
            label29 = new Label();
            label28 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            picBoxAutoTune = new PictureBox();
            txtConfigName = new TextBox();
            btnSavePidConfig = new Button();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            numDeadband = new NumericUpDown();
            label14 = new Label();
            label13 = new Label();
            cboTuneMode = new ComboBox();
            label12 = new Label();
            label11 = new Label();
            numOutputMax = new NumericUpDown();
            label9 = new Label();
            numOutputMin = new NumericUpDown();
            label10 = new Label();
            label8 = new Label();
            numSampleTime = new NumericUpDown();
            label7 = new Label();
            numKd = new NumericUpDown();
            label4 = new Label();
            numKi = new NumericUpDown();
            label6 = new Label();
            numKp = new NumericUpDown();
            label5 = new Label();
            label3 = new Label();
            numPressureSetpoint = new NumericUpDown();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            toolTipAutoTune = new ToolTip(components);
            panelAutoTuning = new Panel();
            panel3 = new Panel();
            btnAddFuelAutoTune = new Button();
            label19 = new Label();
            lblAutoKd = new Label();
            label27 = new Label();
            lblAutoKi = new Label();
            lblAutoKp = new Label();
            btnCancel = new Button();
            lblTimer = new Label();
            label21 = new Label();
            label23 = new Label();
            label20 = new Label();
            btnApply = new Button();
            label24 = new Label();
            label18 = new Label();
            panelPidOperation = new Panel();
            picBoxChangeOption = new PictureBox();
            lblOperationPrompt = new Label();
            btnAddFuelPid = new Button();
            lblOperationEvidence = new Label();
            lblOperationTitle = new Label();
            lblMajorCntdown = new Label();
            label34 = new Label();
            lblMinorCntdown = new Label();
            label26 = new Label();
            label22 = new Label();
            toolTipSwitchOption = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)chartPressure).BeginInit();
            panelChart.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxAutoTune).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDeadband).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numOutputMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numOutputMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSampleTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPressureSetpoint).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelAutoTuning.SuspendLayout();
            panel3.SuspendLayout();
            panelPidOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxChangeOption).BeginInit();
            SuspendLayout();
            // 
            // chartPressure
            // 
            chartPressure.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chartArea1.Name = "ChartArea1";
            chartPressure.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartPressure.Legends.Add(legend1);
            chartPressure.Location = new Point(0, 53);
            chartPressure.Name = "chartPressure";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartPressure.Series.Add(series1);
            chartPressure.Size = new Size(1049, 499);
            chartPressure.TabIndex = 0;
            chartPressure.Text = "chart1";
            // 
            // panelChart
            // 
            panelChart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelChart.Controls.Add(lblStatus);
            panelChart.Controls.Add(btnLiveData);
            panelChart.Controls.Add(dtpToDate);
            panelChart.Controls.Add(lblTo);
            panelChart.Controls.Add(dtpFromDate);
            panelChart.Controls.Add(lblFrom);
            panelChart.Controls.Add(btnRefresh);
            panelChart.Controls.Add(chartPressure);
            panelChart.Location = new Point(27, 25);
            panelChart.Name = "panelChart";
            panelChart.Size = new Size(1049, 552);
            panelChart.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.White;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.LimeGreen;
            lblStatus.Location = new Point(0, 53);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(3);
            lblStatus.Size = new Size(150, 27);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "* Refresh to update";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLiveData
            // 
            btnLiveData.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLiveData.BackColor = Color.Lime;
            btnLiveData.FlatStyle = FlatStyle.Flat;
            btnLiveData.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLiveData.Location = new Point(965, 0);
            btnLiveData.Name = "btnLiveData";
            btnLiveData.Size = new Size(84, 31);
            btnLiveData.TabIndex = 6;
            btnLiveData.Text = "Live Data";
            btnLiveData.UseVisualStyleBackColor = false;
            btnLiveData.Click += btnLiveData_Click;
            // 
            // dtpToDate
            // 
            dtpToDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpToDate.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpToDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.Location = new Point(595, 3);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(187, 29);
            dtpToDate.TabIndex = 5;
            // 
            // lblTo
            // 
            lblTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTo.Location = new Point(534, 5);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(24, 21);
            lblTo.TabIndex = 4;
            lblTo.Text = "to";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpFromDate.CustomFormat = "HH:mm:ss dd/MM/yyyy";
            dtpFromDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.Location = new Point(291, 3);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(187, 29);
            dtpFromDate.TabIndex = 3;
            // 
            // lblFrom
            // 
            lblFrom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFrom.Location = new Point(220, 5);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(44, 21);
            lblFrom.TabIndex = 2;
            lblFrom.Text = "from";
            // 
            // btnRefresh
            // 
            btnRefresh.AutoSize = true;
            btnRefresh.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(0, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 31);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(btnBrowseFolder);
            panel2.Controls.Add(label29);
            panel2.Controls.Add(label28);
            panel2.Location = new Point(27, 1304);
            panel2.Name = "panel2";
            panel2.Size = new Size(385, 95);
            panel2.TabIndex = 44;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(80, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(34, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 45;
            pictureBox1.TabStop = false;
            // 
            // btnBrowseFolder
            // 
            btnBrowseFolder.AutoSize = true;
            btnBrowseFolder.FlatAppearance.BorderSize = 0;
            btnBrowseFolder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBrowseFolder.Location = new Point(149, 47);
            btnBrowseFolder.Name = "btnBrowseFolder";
            btnBrowseFolder.Size = new Size(39, 31);
            btnBrowseFolder.TabIndex = 41;
            btnBrowseFolder.Text = "...";
            btnBrowseFolder.UseVisualStyleBackColor = true;
            btnBrowseFolder.Click += btnBrowseFolder_Click;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label29.Location = new Point(19, 52);
            label29.Name = "label29";
            label29.Size = new Size(110, 21);
            label29.TabIndex = 39;
            label29.Text = "Choose Folder";
            label29.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label28.Location = new Point(9, 12);
            label28.Name = "label28";
            label28.Size = new Size(70, 21);
            label28.TabIndex = 38;
            label28.Text = "EXPORT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 113);
            label1.Name = "label1";
            label1.Size = new Size(132, 21);
            label1.TabIndex = 46;
            label1.Text = "Pressure Setpoint";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(picBoxAutoTune);
            panel1.Controls.Add(txtConfigName);
            panel1.Controls.Add(btnSavePidConfig);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(numDeadband);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(cboTuneMode);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(numOutputMax);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(numOutputMin);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(numSampleTime);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(numKd);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(numKi);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(numKp);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(numPressureSetpoint);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(27, 896);
            panel1.Name = "panel1";
            panel1.Size = new Size(652, 387);
            panel1.TabIndex = 46;
            // 
            // picBoxAutoTune
            // 
            picBoxAutoTune.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picBoxAutoTune.Image = (Image)resources.GetObject("picBoxAutoTune.Image");
            picBoxAutoTune.Location = new Point(609, 6);
            picBoxAutoTune.Name = "picBoxAutoTune";
            picBoxAutoTune.Size = new Size(37, 37);
            picBoxAutoTune.SizeMode = PictureBoxSizeMode.Zoom;
            picBoxAutoTune.TabIndex = 46;
            picBoxAutoTune.TabStop = false;
            toolTipAutoTune.SetToolTip(picBoxAutoTune, "Auto-Tune");
            picBoxAutoTune.Click += picBoxAutoTune_Click;
            // 
            // txtConfigName
            // 
            txtConfigName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfigName.Location = new Point(529, 58);
            txtConfigName.Name = "txtConfigName";
            txtConfigName.ReadOnly = true;
            txtConfigName.Size = new Size(117, 29);
            txtConfigName.TabIndex = 71;
            // 
            // btnSavePidConfig
            // 
            btnSavePidConfig.AutoSize = true;
            btnSavePidConfig.BackColor = Color.Lime;
            btnSavePidConfig.FlatAppearance.BorderSize = 0;
            btnSavePidConfig.FlatStyle = FlatStyle.Popup;
            btnSavePidConfig.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSavePidConfig.Location = new Point(529, 347);
            btnSavePidConfig.Name = "btnSavePidConfig";
            btnSavePidConfig.Size = new Size(109, 31);
            btnSavePidConfig.TabIndex = 46;
            btnSavePidConfig.Text = "SAVE";
            btnSavePidConfig.UseVisualStyleBackColor = false;
            btnSavePidConfig.Click += btnSavePidConfig_Click;
            // 
            // label17
            // 
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.Location = new Point(366, 61);
            label17.Name = "label17";
            label17.Size = new Size(132, 21);
            label17.TabIndex = 70;
            label17.Text = "Config Name";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(490, 113);
            label16.Name = "label16";
            label16.Size = new Size(33, 21);
            label16.TabIndex = 69;
            label16.Text = "+-";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(613, 113);
            label15.Name = "label15";
            label15.Size = new Size(33, 21);
            label15.TabIndex = 68;
            label15.Text = "bar";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numDeadband
            // 
            numDeadband.DecimalPlaces = 1;
            numDeadband.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numDeadband.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numDeadband.Location = new Point(529, 111);
            numDeadband.Maximum = new decimal(new int[] { 10, 0, 0, 65536 });
            numDeadband.Name = "numDeadband";
            numDeadband.Size = new Size(64, 29);
            numDeadband.TabIndex = 67;
            numDeadband.TextAlign = HorizontalAlignment.Center;
            numDeadband.Value = new decimal(new int[] { 2, 0, 0, 65536 });
            // 
            // label14
            // 
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(366, 113);
            label14.Name = "label14";
            label14.Size = new Size(132, 21);
            label14.TabIndex = 66;
            label14.Text = "Deadband";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(19, 61);
            label13.Name = "label13";
            label13.Size = new Size(132, 21);
            label13.TabIndex = 65;
            label13.Text = "Tuning Mode";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboTuneMode
            // 
            cboTuneMode.Enabled = false;
            cboTuneMode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboTuneMode.FormattingEnabled = true;
            cboTuneMode.Location = new Point(181, 58);
            cboTuneMode.Name = "cboTuneMode";
            cboTuneMode.Size = new Size(130, 29);
            cboTuneMode.TabIndex = 64;
            cboTuneMode.SelectedIndexChanged += cboTuneMode_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(613, 286);
            label12.Name = "label12";
            label12.Size = new Size(33, 21);
            label12.TabIndex = 63;
            label12.Text = "%";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(613, 228);
            label11.Name = "label11";
            label11.Size = new Size(33, 21);
            label11.TabIndex = 62;
            label11.Text = "%";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numOutputMax
            // 
            numOutputMax.DecimalPlaces = 1;
            numOutputMax.Enabled = false;
            numOutputMax.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numOutputMax.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numOutputMax.InterceptArrowKeys = false;
            numOutputMax.Location = new Point(529, 286);
            numOutputMax.Name = "numOutputMax";
            numOutputMax.ReadOnly = true;
            numOutputMax.Size = new Size(64, 29);
            numOutputMax.TabIndex = 61;
            numOutputMax.TextAlign = HorizontalAlignment.Center;
            numOutputMax.Value = new decimal(new int[] { 1000, 0, 0, 65536 });
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(366, 288);
            label9.Name = "label9";
            label9.Size = new Size(132, 21);
            label9.TabIndex = 60;
            label9.Text = "Output Max";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numOutputMin
            // 
            numOutputMin.DecimalPlaces = 1;
            numOutputMin.Enabled = false;
            numOutputMin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numOutputMin.InterceptArrowKeys = false;
            numOutputMin.Location = new Point(529, 226);
            numOutputMin.Name = "numOutputMin";
            numOutputMin.ReadOnly = true;
            numOutputMin.Size = new Size(64, 29);
            numOutputMin.TabIndex = 59;
            numOutputMin.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(366, 228);
            label10.Name = "label10";
            label10.Size = new Size(132, 21);
            label10.TabIndex = 58;
            label10.Text = "Output Min";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(613, 171);
            label8.Name = "label8";
            label8.Size = new Size(33, 21);
            label8.TabIndex = 57;
            label8.Text = "s";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            label8.Visible = false;
            // 
            // numSampleTime
            // 
            numSampleTime.DecimalPlaces = 1;
            numSampleTime.Enabled = false;
            numSampleTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numSampleTime.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numSampleTime.InterceptArrowKeys = false;
            numSampleTime.Location = new Point(529, 169);
            numSampleTime.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            numSampleTime.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSampleTime.Name = "numSampleTime";
            numSampleTime.ReadOnly = true;
            numSampleTime.Size = new Size(64, 29);
            numSampleTime.TabIndex = 56;
            numSampleTime.TextAlign = HorizontalAlignment.Center;
            numSampleTime.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numSampleTime.Visible = false;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(366, 171);
            label7.Name = "label7";
            label7.Size = new Size(132, 21);
            label7.TabIndex = 55;
            label7.Text = "Sample Time";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            label7.Visible = false;
            // 
            // numKd
            // 
            numKd.DecimalPlaces = 2;
            numKd.Enabled = false;
            numKd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numKd.Increment = new decimal(new int[] { 2, 0, 0, 65536 });
            numKd.InterceptArrowKeys = false;
            numKd.Location = new Point(181, 284);
            numKd.Maximum = new decimal(new int[] { 30000, 0, 0, 0 });
            numKd.Name = "numKd";
            numKd.ReadOnly = true;
            numKd.Size = new Size(91, 29);
            numKd.TabIndex = 54;
            numKd.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(17, 286);
            label4.Name = "label4";
            label4.Size = new Size(132, 21);
            label4.TabIndex = 53;
            label4.Text = "Kd";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numKi
            // 
            numKi.DecimalPlaces = 2;
            numKi.Enabled = false;
            numKi.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numKi.Increment = new decimal(new int[] { 2, 0, 0, 65536 });
            numKi.InterceptArrowKeys = false;
            numKi.Location = new Point(181, 226);
            numKi.Maximum = new decimal(new int[] { 30000, 0, 0, 0 });
            numKi.Name = "numKi";
            numKi.ReadOnly = true;
            numKi.Size = new Size(91, 29);
            numKi.TabIndex = 52;
            numKi.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(18, 228);
            label6.Name = "label6";
            label6.Size = new Size(132, 21);
            label6.TabIndex = 51;
            label6.Text = "Ki";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numKp
            // 
            numKp.DecimalPlaces = 2;
            numKp.Enabled = false;
            numKp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numKp.Increment = new decimal(new int[] { 2, 0, 0, 65536 });
            numKp.InterceptArrowKeys = false;
            numKp.Location = new Point(181, 169);
            numKp.Maximum = new decimal(new int[] { 30000, 0, 0, 0 });
            numKp.Name = "numKp";
            numKp.ReadOnly = true;
            numKp.Size = new Size(91, 29);
            numKp.TabIndex = 50;
            numKp.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(18, 171);
            label5.Name = "label5";
            label5.Size = new Size(132, 21);
            label5.TabIndex = 49;
            label5.Text = "Kp";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(278, 113);
            label3.Name = "label3";
            label3.Size = new Size(33, 21);
            label3.TabIndex = 48;
            label3.Text = "bar";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numPressureSetpoint
            // 
            numPressureSetpoint.DecimalPlaces = 1;
            numPressureSetpoint.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numPressureSetpoint.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numPressureSetpoint.Location = new Point(182, 111);
            numPressureSetpoint.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numPressureSetpoint.Name = "numPressureSetpoint";
            numPressureSetpoint.Size = new Size(90, 29);
            numPressureSetpoint.TabIndex = 47;
            numPressureSetpoint.TextAlign = HorizontalAlignment.Center;
            numPressureSetpoint.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(127, 6);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(37, 37);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 46;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 84, 166);
            label2.Location = new Point(9, 14);
            label2.Name = "label2";
            label2.Size = new Size(115, 21);
            label2.TabIndex = 38;
            label2.Text = "PID CONTROL";
            // 
            // panelAutoTuning
            // 
            panelAutoTuning.BackColor = Color.White;
            panelAutoTuning.Controls.Add(panel3);
            panelAutoTuning.Controls.Add(lblAutoKd);
            panelAutoTuning.Controls.Add(label27);
            panelAutoTuning.Controls.Add(lblAutoKi);
            panelAutoTuning.Controls.Add(lblAutoKp);
            panelAutoTuning.Controls.Add(btnCancel);
            panelAutoTuning.Controls.Add(lblTimer);
            panelAutoTuning.Controls.Add(label21);
            panelAutoTuning.Controls.Add(label23);
            panelAutoTuning.Controls.Add(label20);
            panelAutoTuning.Controls.Add(btnApply);
            panelAutoTuning.Controls.Add(label24);
            panelAutoTuning.Controls.Add(label18);
            panelAutoTuning.Location = new Point(691, 896);
            panelAutoTuning.Name = "panelAutoTuning";
            panelAutoTuning.Size = new Size(385, 332);
            panelAutoTuning.TabIndex = 47;
            panelAutoTuning.Visible = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btnAddFuelAutoTune);
            panel3.Controls.Add(label19);
            panel3.Location = new Point(13, 58);
            panel3.Name = "panel3";
            panel3.Size = new Size(361, 46);
            panel3.TabIndex = 48;
            // 
            // btnAddFuelAutoTune
            // 
            btnAddFuelAutoTune.Anchor = AnchorStyles.Right;
            btnAddFuelAutoTune.AutoSize = true;
            btnAddFuelAutoTune.FlatAppearance.BorderSize = 0;
            btnAddFuelAutoTune.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddFuelAutoTune.Location = new Point(259, 5);
            btnAddFuelAutoTune.Name = "btnAddFuelAutoTune";
            btnAddFuelAutoTune.Size = new Size(94, 35);
            btnAddFuelAutoTune.TabIndex = 48;
            btnAddFuelAutoTune.Text = "Add Fuel";
            btnAddFuelAutoTune.UseVisualStyleBackColor = true;
            btnAddFuelAutoTune.Click += btnAddFuelAutoTune_Click;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.None;
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Location = new Point(-1, 11);
            label19.Name = "label19";
            label19.Size = new Size(206, 21);
            label19.TabIndex = 73;
            label19.Text = "Step 1: Feed fuel and record ";
            label19.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAutoKd
            // 
            lblAutoKd.AutoSize = true;
            lblAutoKd.BorderStyle = BorderStyle.FixedSingle;
            lblAutoKd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAutoKd.Location = new Point(323, 212);
            lblAutoKd.Name = "lblAutoKd";
            lblAutoKd.Size = new Size(42, 23);
            lblAutoKd.TabIndex = 81;
            lblAutoKd.Text = "0.00";
            lblAutoKd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label27.Location = new Point(285, 212);
            label27.Name = "label27";
            label27.Size = new Size(47, 21);
            label27.TabIndex = 80;
            label27.Text = "Kd = ";
            label27.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAutoKi
            // 
            lblAutoKi.AutoSize = true;
            lblAutoKi.BorderStyle = BorderStyle.FixedSingle;
            lblAutoKi.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAutoKi.Location = new Point(194, 212);
            lblAutoKi.Name = "lblAutoKi";
            lblAutoKi.Size = new Size(42, 23);
            lblAutoKi.TabIndex = 79;
            lblAutoKi.Text = "0.00";
            lblAutoKi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAutoKp
            // 
            lblAutoKp.AutoSize = true;
            lblAutoKp.BorderStyle = BorderStyle.FixedSingle;
            lblAutoKp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAutoKp.Location = new Point(62, 212);
            lblAutoKp.Name = "lblAutoKp";
            lblAutoKp.Size = new Size(42, 23);
            lblAutoKp.TabIndex = 78;
            lblAutoKp.Text = "0.00";
            lblAutoKp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(13, 283);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(81, 32);
            btnCancel.TabIndex = 77;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.BorderStyle = BorderStyle.FixedSingle;
            lblTimer.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimer.Location = new Point(316, 11);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(63, 27);
            lblTimer.TabIndex = 76;
            lblTimer.Text = "00:00";
            lblTimer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            label21.BorderStyle = BorderStyle.FixedSingle;
            label21.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.Location = new Point(13, 164);
            label21.Name = "label21";
            label21.Size = new Size(361, 40);
            label21.TabIndex = 75;
            label21.Text = "Step 3: Apply parameters";
            label21.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label23.Location = new Point(156, 212);
            label23.Name = "label23";
            label23.Size = new Size(42, 21);
            label23.TabIndex = 75;
            label23.Text = "Ki = ";
            label23.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            label20.BorderStyle = BorderStyle.FixedSingle;
            label20.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label20.Location = new Point(13, 113);
            label20.Name = "label20";
            label20.Size = new Size(361, 42);
            label20.TabIndex = 74;
            label20.Text = "Step 2: Wait for system to analyze";
            label20.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnApply
            // 
            btnApply.AutoSize = true;
            btnApply.BackColor = Color.Lime;
            btnApply.FlatAppearance.BorderSize = 0;
            btnApply.FlatStyle = FlatStyle.Popup;
            btnApply.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnApply.Location = new Point(293, 284);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(81, 32);
            btnApply.TabIndex = 48;
            btnApply.Text = "APPLY";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Visible = false;
            btnApply.Click += btnApply_Click;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label24.Location = new Point(20, 212);
            label24.Name = "label24";
            label24.Size = new Size(47, 21);
            label24.TabIndex = 73;
            label24.Text = "Kp = ";
            label24.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.FromArgb(0, 84, 166);
            label18.Location = new Point(13, 14);
            label18.Name = "label18";
            label18.Size = new Size(120, 21);
            label18.TabIndex = 73;
            label18.Text = "AUTO TUNING";
            // 
            // panelPidOperation
            // 
            panelPidOperation.BackColor = Color.White;
            panelPidOperation.Controls.Add(picBoxChangeOption);
            panelPidOperation.Controls.Add(lblOperationPrompt);
            panelPidOperation.Controls.Add(btnAddFuelPid);
            panelPidOperation.Controls.Add(lblOperationEvidence);
            panelPidOperation.Controls.Add(lblOperationTitle);
            panelPidOperation.Controls.Add(lblMajorCntdown);
            panelPidOperation.Controls.Add(label34);
            panelPidOperation.Controls.Add(lblMinorCntdown);
            panelPidOperation.Controls.Add(label26);
            panelPidOperation.Controls.Add(label22);
            panelPidOperation.Location = new Point(27, 602);
            panelPidOperation.Name = "panelPidOperation";
            panelPidOperation.Size = new Size(652, 272);
            panelPidOperation.TabIndex = 48;
            // 
            // picBoxChangeOption
            // 
            picBoxChangeOption.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picBoxChangeOption.Image = (Image)resources.GetObject("picBoxChangeOption.Image");
            picBoxChangeOption.Location = new Point(17, 123);
            picBoxChangeOption.Name = "picBoxChangeOption";
            picBoxChangeOption.Size = new Size(25, 25);
            picBoxChangeOption.SizeMode = PictureBoxSizeMode.Zoom;
            picBoxChangeOption.TabIndex = 72;
            picBoxChangeOption.TabStop = false;
            toolTipSwitchOption.SetToolTip(picBoxChangeOption, "Click to change option");
            picBoxChangeOption.Click += picBoxChangeOption_Click;
            // 
            // lblOperationPrompt
            // 
            lblOperationPrompt.AutoSize = true;
            lblOperationPrompt.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOperationPrompt.ForeColor = Color.FromArgb(64, 64, 64);
            lblOperationPrompt.Location = new Point(37, 132);
            lblOperationPrompt.Name = "lblOperationPrompt";
            lblOperationPrompt.Size = new Size(80, 25);
            lblOperationPrompt.TabIndex = 74;
            lblOperationPrompt.Text = "Prompt";
            // 
            // btnAddFuelPid
            // 
            btnAddFuelPid.Anchor = AnchorStyles.Right;
            btnAddFuelPid.AutoSize = true;
            btnAddFuelPid.FlatAppearance.BorderSize = 0;
            btnAddFuelPid.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddFuelPid.Location = new Point(544, 222);
            btnAddFuelPid.Name = "btnAddFuelPid";
            btnAddFuelPid.Size = new Size(94, 35);
            btnAddFuelPid.TabIndex = 76;
            btnAddFuelPid.Text = "Add Fuel";
            btnAddFuelPid.UseVisualStyleBackColor = true;
            btnAddFuelPid.Click += btnAddFuelPid_Click;
            // 
            // lblOperationEvidence
            // 
            lblOperationEvidence.AutoSize = true;
            lblOperationEvidence.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOperationEvidence.ForeColor = Color.DarkGray;
            lblOperationEvidence.Location = new Point(37, 174);
            lblOperationEvidence.Name = "lblOperationEvidence";
            lblOperationEvidence.Size = new Size(71, 21);
            lblOperationEvidence.TabIndex = 75;
            lblOperationEvidence.Text = "Evidence";
            // 
            // lblOperationTitle
            // 
            lblOperationTitle.AutoSize = true;
            lblOperationTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOperationTitle.ForeColor = Color.FromArgb(255, 128, 0);
            lblOperationTitle.Location = new Point(37, 88);
            lblOperationTitle.Name = "lblOperationTitle";
            lblOperationTitle.Size = new Size(75, 32);
            lblOperationTitle.TabIndex = 73;
            lblOperationTitle.Text = "TITLE";
            // 
            // lblMajorCntdown
            // 
            lblMajorCntdown.AutoSize = true;
            lblMajorCntdown.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMajorCntdown.Location = new Point(588, 43);
            lblMajorCntdown.Name = "lblMajorCntdown";
            lblMajorCntdown.Size = new Size(50, 21);
            lblMajorCntdown.TabIndex = 70;
            lblMajorCntdown.Text = "00:00";
            lblMajorCntdown.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label34.ForeColor = Color.FromArgb(0, 84, 166);
            label34.Location = new Point(443, 43);
            label34.Name = "label34";
            label34.Size = new Size(123, 21);
            label34.TabIndex = 71;
            label34.Text = "Next major in: ";
            // 
            // lblMinorCntdown
            // 
            lblMinorCntdown.AutoSize = true;
            lblMinorCntdown.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMinorCntdown.Location = new Point(588, 12);
            lblMinorCntdown.Name = "lblMinorCntdown";
            lblMinorCntdown.Size = new Size(50, 21);
            lblMinorCntdown.TabIndex = 68;
            lblMinorCntdown.Text = "00:00";
            lblMinorCntdown.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label26.ForeColor = Color.FromArgb(0, 84, 166);
            label26.Location = new Point(443, 12);
            label26.Name = "label26";
            label26.Size = new Size(124, 21);
            label26.TabIndex = 68;
            label26.Text = "Next minor in: ";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.FromArgb(0, 84, 166);
            label22.Location = new Point(9, 12);
            label22.Name = "label22";
            label22.Size = new Size(100, 21);
            label22.TabIndex = 39;
            label22.Text = "OPERATION";
            // 
            // PressureControlView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelPidOperation);
            Controls.Add(panelAutoTuning);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panelChart);
            Name = "PressureControlView";
            Size = new Size(1101, 1420);
            Load += PressureControlView_Load;
            ((System.ComponentModel.ISupportInitialize)chartPressure).EndInit();
            panelChart.ResumeLayout(false);
            panelChart.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxAutoTune).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDeadband).EndInit();
            ((System.ComponentModel.ISupportInitialize)numOutputMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numOutputMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSampleTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)numKd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numKi).EndInit();
            ((System.ComponentModel.ISupportInitialize)numKp).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPressureSetpoint).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelAutoTuning.ResumeLayout(false);
            panelAutoTuning.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panelPidOperation.ResumeLayout(false);
            panelPidOperation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxChangeOption).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPressure;
        private Panel panelChart;
        private Button btnRefresh;
        private DateTimePicker dtpFromDate;
        private Label lblFrom;
        private DateTimePicker dtpToDate;
        private Label lblTo;
        private Button btnLiveData;
        private Label lblStatus;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Button btnBrowseFolder;
        private Label label29;
        private Label label28;
        private Panel panel1;
        private Label label2;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label3;
        private NumericUpDown numPressureSetpoint;
        private NumericUpDown numSampleTime;
        private Label label7;
        private NumericUpDown numKd;
        private Label label4;
        private NumericUpDown numKi;
        private Label label6;
        private NumericUpDown numKp;
        private Label label5;
        private Label label8;
        private Label label12;
        private Label label11;
        private NumericUpDown numOutputMax;
        private Label label9;
        private NumericUpDown numOutputMin;
        private Label label10;
        private Label label13;
        private ComboBox cboTuneMode;
        private Label label15;
        private NumericUpDown numDeadband;
        private Label label14;
        private Label label16;
        private TextBox txtConfigName;
        private Label label17;
        private Button btnSavePidConfig;
        private PictureBox picBoxAutoTune;
        private ToolTip toolTipAutoTune;
        private Panel panelAutoTuning;
        private Label label18;
        private Label label19;
        private Label label21;
        private Label label20;
        private Button btnApply;
        private Label lblTimer;
        private Button btnCancel;
        private Label lblAutoKp;
        private Label label23;
        private Label label24;
        private Label lblAutoKd;
        private Label label27;
        private Label lblAutoKi;
        private Panel panel3;
        private Button btnAddFuelAutoTune;
        private Panel panelPidOperation;
        private Label label22;
        private Label lblMajorCntdown;
        private Label label34;
        private Label lblMinorCntdown;
        private Label label26;
        private Label lblOperationTitle;
        private Label lblOperationEvidence;
        private Label lblOperationPrompt;
        private Button btnAddFuelPid;
        private PictureBox picBoxChangeOption;
        private ToolTip toolTipSwitchOption;
    }
}
