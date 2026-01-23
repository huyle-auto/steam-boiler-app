namespace SteamBoilerApp.MachineSetting.Views
{
    partial class MachineSettingView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineSettingView));
            tableMachineSetting = new DataGridView();
            btnTableRefresh = new Button();
            btnTableSave = new Button();
            txtBoxStatus = new TextBox();
            lblInsertOrder = new Label();
            label1 = new Label();
            label2 = new Label();
            panelOrderInfo = new Panel();
            label27 = new Label();
            numMachineSpeed = new NumericUpDown();
            label24 = new Label();
            cboCustomerName = new ComboBox();
            dtpRunDate = new DateTimePicker();
            cboFluteType = new ComboBox();
            label19 = new Label();
            numPaperWidth = new NumericUpDown();
            label20 = new Label();
            label18 = new Label();
            numPaperLength = new NumericUpDown();
            label14 = new Label();
            label3 = new Label();
            label4 = new Label();
            panelSetPressure = new Panel();
            label23 = new Label();
            cboGsm5 = new ComboBox();
            cboGsm4 = new ComboBox();
            cboGsm3 = new ComboBox();
            cboGsm2 = new ComboBox();
            cboGsm1 = new ComboBox();
            cboLayer5 = new ComboBox();
            cboLayer4 = new ComboBox();
            cboLayer3 = new ComboBox();
            cboLayer2 = new ComboBox();
            cboLayer1 = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            panelLayer = new Panel();
            label21 = new Label();
            numBoilerPressure = new NumericUpDown();
            label22 = new Label();
            label16 = new Label();
            label17 = new Label();
            label15 = new Label();
            label9 = new Label();
            numFZone2Pressure = new NumericUpDown();
            label10 = new Label();
            numFZone1Pressure = new NumericUpDown();
            label11 = new Label();
            numBPressure = new NumericUpDown();
            label12 = new Label();
            numAPressure = new NumericUpDown();
            label13 = new Label();
            panel1 = new Panel();
            label26 = new Label();
            label25 = new Label();
            dtpTo = new DateTimePicker();
            dtpFrom = new DateTimePicker();
            btnDeleteOrder = new Button();
            btnFinishOrder = new Button();
            btnPauseOrder = new Button();
            btnRunOrder = new Button();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            btnBrowseFolder = new Button();
            label29 = new Label();
            label28 = new Label();
            ((System.ComponentModel.ISupportInitialize)tableMachineSetting).BeginInit();
            panelOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMachineSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPaperWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPaperLength).BeginInit();
            panelSetPressure.SuspendLayout();
            panelLayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBoilerPressure).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFZone2Pressure).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFZone1Pressure).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBPressure).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAPressure).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableMachineSetting
            // 
            tableMachineSetting.AllowUserToDeleteRows = false;
            tableMachineSetting.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tableMachineSetting.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            tableMachineSetting.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tableMachineSetting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tableMachineSetting.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            tableMachineSetting.DefaultCellStyle = dataGridViewCellStyle2;
            tableMachineSetting.Dock = DockStyle.Bottom;
            tableMachineSetting.Location = new Point(0, 61);
            tableMachineSetting.Name = "tableMachineSetting";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            tableMachineSetting.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            tableMachineSetting.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableMachineSetting.Size = new Size(1061, 245);
            tableMachineSetting.TabIndex = 0;
            // 
            // btnTableRefresh
            // 
            btnTableRefresh.Anchor = AnchorStyles.None;
            btnTableRefresh.AutoSize = true;
            btnTableRefresh.Font = new Font("Segoe UI", 12F);
            btnTableRefresh.Location = new Point(10, 12);
            btnTableRefresh.Name = "btnTableRefresh";
            btnTableRefresh.Size = new Size(87, 31);
            btnTableRefresh.TabIndex = 1;
            btnTableRefresh.Text = "Refresh";
            btnTableRefresh.UseVisualStyleBackColor = true;
            btnTableRefresh.Click += btnTableRefresh_Click;
            // 
            // btnTableSave
            // 
            btnTableSave.AutoSize = true;
            btnTableSave.Font = new Font("Segoe UI", 12F);
            btnTableSave.Location = new Point(988, 753);
            btnTableSave.Name = "btnTableSave";
            btnTableSave.Size = new Size(91, 34);
            btnTableSave.TabIndex = 2;
            btnTableSave.Text = "Save";
            btnTableSave.UseVisualStyleBackColor = true;
            btnTableSave.Click += btnTableSave_Click;
            // 
            // txtBoxStatus
            // 
            txtBoxStatus.Anchor = AnchorStyles.None;
            txtBoxStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxStatus.Location = new Point(757, 14);
            txtBoxStatus.Name = "txtBoxStatus";
            txtBoxStatus.ReadOnly = true;
            txtBoxStatus.Size = new Size(290, 29);
            txtBoxStatus.TabIndex = 3;
            // 
            // lblInsertOrder
            // 
            lblInsertOrder.AutoSize = true;
            lblInsertOrder.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInsertOrder.Location = new Point(9, 10);
            lblInsertOrder.Name = "lblInsertOrder";
            lblInsertOrder.Size = new Size(122, 21);
            lblInsertOrder.TabIndex = 4;
            lblInsertOrder.Text = "INSERT ORDER";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 45);
            label1.Name = "label1";
            label1.Size = new Size(124, 21);
            label1.TabIndex = 6;
            label1.Text = "Customer Name";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(19, 99);
            label2.Name = "label2";
            label2.Size = new Size(80, 21);
            label2.TabIndex = 8;
            label2.Text = "Flute Type";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelOrderInfo
            // 
            panelOrderInfo.BackColor = Color.White;
            panelOrderInfo.Controls.Add(label27);
            panelOrderInfo.Controls.Add(numMachineSpeed);
            panelOrderInfo.Controls.Add(label24);
            panelOrderInfo.Controls.Add(cboCustomerName);
            panelOrderInfo.Controls.Add(dtpRunDate);
            panelOrderInfo.Controls.Add(cboFluteType);
            panelOrderInfo.Controls.Add(label19);
            panelOrderInfo.Controls.Add(numPaperWidth);
            panelOrderInfo.Controls.Add(label20);
            panelOrderInfo.Controls.Add(label18);
            panelOrderInfo.Controls.Add(numPaperLength);
            panelOrderInfo.Controls.Add(label14);
            panelOrderInfo.Controls.Add(label3);
            panelOrderInfo.Controls.Add(lblInsertOrder);
            panelOrderInfo.Controls.Add(label1);
            panelOrderInfo.Controls.Add(label2);
            panelOrderInfo.Location = new Point(21, 398);
            panelOrderInfo.Name = "panelOrderInfo";
            panelOrderInfo.Size = new Size(385, 344);
            panelOrderInfo.TabIndex = 10;
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.None;
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label27.Location = new Point(267, 300);
            label27.Name = "label27";
            label27.Size = new Size(65, 21);
            label27.TabIndex = 36;
            label27.Text = "m / min";
            // 
            // numMachineSpeed
            // 
            numMachineSpeed.Anchor = AnchorStyles.None;
            numMachineSpeed.AutoSize = true;
            numMachineSpeed.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numMachineSpeed.Location = new Point(149, 298);
            numMachineSpeed.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numMachineSpeed.Name = "numMachineSpeed";
            numMachineSpeed.Size = new Size(80, 29);
            numMachineSpeed.TabIndex = 37;
            // 
            // label24
            // 
            label24.Anchor = AnchorStyles.None;
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label24.Location = new Point(19, 300);
            label24.Name = "label24";
            label24.Size = new Size(116, 21);
            label24.TabIndex = 35;
            label24.Text = "Machine Speed";
            label24.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboCustomerName
            // 
            cboCustomerName.Anchor = AnchorStyles.None;
            cboCustomerName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboCustomerName.FormattingEnabled = true;
            cboCustomerName.Location = new Point(149, 42);
            cboCustomerName.Name = "cboCustomerName";
            cboCustomerName.Size = new Size(213, 29);
            cboCustomerName.TabIndex = 34;
            // 
            // dtpRunDate
            // 
            dtpRunDate.Anchor = AnchorStyles.None;
            dtpRunDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpRunDate.Location = new Point(149, 150);
            dtpRunDate.Name = "dtpRunDate";
            dtpRunDate.Size = new Size(213, 29);
            dtpRunDate.TabIndex = 33;
            // 
            // cboFluteType
            // 
            cboFluteType.Anchor = AnchorStyles.None;
            cboFluteType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboFluteType.FormattingEnabled = true;
            cboFluteType.Location = new Point(149, 96);
            cboFluteType.Name = "cboFluteType";
            cboFluteType.Size = new Size(80, 29);
            cboFluteType.TabIndex = 32;
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.None;
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Location = new Point(267, 255);
            label19.Name = "label19";
            label19.Size = new Size(24, 21);
            label19.TabIndex = 29;
            label19.Text = "m";
            // 
            // numPaperWidth
            // 
            numPaperWidth.Anchor = AnchorStyles.None;
            numPaperWidth.AutoSize = true;
            numPaperWidth.DecimalPlaces = 2;
            numPaperWidth.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numPaperWidth.Location = new Point(149, 251);
            numPaperWidth.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPaperWidth.Name = "numPaperWidth";
            numPaperWidth.Size = new Size(101, 29);
            numPaperWidth.TabIndex = 30;
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.None;
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label20.Location = new Point(19, 253);
            label20.Name = "label20";
            label20.Size = new Size(95, 21);
            label20.TabIndex = 31;
            label20.Text = "Paper Width";
            label20.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.None;
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.Location = new Point(267, 205);
            label18.Name = "label18";
            label18.Size = new Size(24, 21);
            label18.TabIndex = 26;
            label18.Text = "m";
            // 
            // numPaperLength
            // 
            numPaperLength.Anchor = AnchorStyles.None;
            numPaperLength.AutoSize = true;
            numPaperLength.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numPaperLength.Location = new Point(149, 203);
            numPaperLength.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPaperLength.Name = "numPaperLength";
            numPaperLength.Size = new Size(80, 29);
            numPaperLength.TabIndex = 26;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.None;
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(19, 203);
            label14.Name = "label14";
            label14.Size = new Size(101, 21);
            label14.TabIndex = 28;
            label14.Text = "Paper Length";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(19, 150);
            label3.Name = "label3";
            label3.Size = new Size(74, 21);
            label3.TabIndex = 11;
            label3.Text = "Run Date";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 45);
            label4.Name = "label4";
            label4.Size = new Size(61, 21);
            label4.TabIndex = 12;
            label4.Text = "Layer 1";
            // 
            // panelSetPressure
            // 
            panelSetPressure.BackColor = Color.White;
            panelSetPressure.Controls.Add(label23);
            panelSetPressure.Controls.Add(cboGsm5);
            panelSetPressure.Controls.Add(cboGsm4);
            panelSetPressure.Controls.Add(cboGsm3);
            panelSetPressure.Controls.Add(cboGsm2);
            panelSetPressure.Controls.Add(cboGsm1);
            panelSetPressure.Controls.Add(cboLayer5);
            panelSetPressure.Controls.Add(cboLayer4);
            panelSetPressure.Controls.Add(cboLayer3);
            panelSetPressure.Controls.Add(cboLayer2);
            panelSetPressure.Controls.Add(cboLayer1);
            panelSetPressure.Controls.Add(label8);
            panelSetPressure.Controls.Add(label7);
            panelSetPressure.Controls.Add(label6);
            panelSetPressure.Controls.Add(label5);
            panelSetPressure.Controls.Add(label4);
            panelSetPressure.Location = new Point(425, 398);
            panelSetPressure.Name = "panelSetPressure";
            panelSetPressure.Size = new Size(320, 344);
            panelSetPressure.TabIndex = 14;
            // 
            // label23
            // 
            label23.Anchor = AnchorStyles.None;
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label23.Location = new Point(246, 10);
            label23.Name = "label23";
            label23.Size = new Size(44, 21);
            label23.TabIndex = 44;
            label23.Text = "GSM";
            // 
            // cboGsm5
            // 
            cboGsm5.Anchor = AnchorStyles.None;
            cboGsm5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboGsm5.FormattingEnabled = true;
            cboGsm5.Location = new Point(227, 251);
            cboGsm5.Name = "cboGsm5";
            cboGsm5.Size = new Size(79, 29);
            cboGsm5.TabIndex = 43;
            // 
            // cboGsm4
            // 
            cboGsm4.Anchor = AnchorStyles.None;
            cboGsm4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboGsm4.FormattingEnabled = true;
            cboGsm4.Location = new Point(227, 199);
            cboGsm4.Name = "cboGsm4";
            cboGsm4.Size = new Size(79, 29);
            cboGsm4.TabIndex = 42;
            // 
            // cboGsm3
            // 
            cboGsm3.Anchor = AnchorStyles.None;
            cboGsm3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboGsm3.FormattingEnabled = true;
            cboGsm3.Location = new Point(227, 147);
            cboGsm3.Name = "cboGsm3";
            cboGsm3.Size = new Size(79, 29);
            cboGsm3.TabIndex = 41;
            // 
            // cboGsm2
            // 
            cboGsm2.Anchor = AnchorStyles.None;
            cboGsm2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboGsm2.FormattingEnabled = true;
            cboGsm2.Location = new Point(227, 95);
            cboGsm2.Name = "cboGsm2";
            cboGsm2.Size = new Size(79, 29);
            cboGsm2.TabIndex = 40;
            // 
            // cboGsm1
            // 
            cboGsm1.Anchor = AnchorStyles.None;
            cboGsm1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboGsm1.FormattingEnabled = true;
            cboGsm1.Location = new Point(227, 42);
            cboGsm1.Name = "cboGsm1";
            cboGsm1.Size = new Size(79, 29);
            cboGsm1.TabIndex = 39;
            // 
            // cboLayer5
            // 
            cboLayer5.Anchor = AnchorStyles.None;
            cboLayer5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboLayer5.FormattingEnabled = true;
            cboLayer5.Location = new Point(96, 251);
            cboLayer5.Name = "cboLayer5";
            cboLayer5.Size = new Size(109, 29);
            cboLayer5.TabIndex = 38;
            // 
            // cboLayer4
            // 
            cboLayer4.Anchor = AnchorStyles.None;
            cboLayer4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboLayer4.FormattingEnabled = true;
            cboLayer4.Location = new Point(96, 199);
            cboLayer4.Name = "cboLayer4";
            cboLayer4.Size = new Size(109, 29);
            cboLayer4.TabIndex = 37;
            // 
            // cboLayer3
            // 
            cboLayer3.Anchor = AnchorStyles.None;
            cboLayer3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboLayer3.FormattingEnabled = true;
            cboLayer3.Location = new Point(96, 147);
            cboLayer3.Name = "cboLayer3";
            cboLayer3.Size = new Size(109, 29);
            cboLayer3.TabIndex = 36;
            // 
            // cboLayer2
            // 
            cboLayer2.Anchor = AnchorStyles.None;
            cboLayer2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboLayer2.FormattingEnabled = true;
            cboLayer2.Location = new Point(96, 95);
            cboLayer2.Name = "cboLayer2";
            cboLayer2.Size = new Size(109, 29);
            cboLayer2.TabIndex = 35;
            // 
            // cboLayer1
            // 
            cboLayer1.Anchor = AnchorStyles.None;
            cboLayer1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboLayer1.FormattingEnabled = true;
            cboLayer1.Location = new Point(96, 42);
            cboLayer1.Name = "cboLayer1";
            cboLayer1.Size = new Size(109, 29);
            cboLayer1.TabIndex = 34;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(20, 255);
            label8.Name = "label8";
            label8.Size = new Size(61, 21);
            label8.TabIndex = 24;
            label8.Text = "Layer 5";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(20, 203);
            label7.Name = "label7";
            label7.Size = new Size(61, 21);
            label7.TabIndex = 21;
            label7.Text = "Layer 4";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(20, 151);
            label6.Name = "label6";
            label6.Size = new Size(61, 21);
            label6.TabIndex = 18;
            label6.Text = "Layer 3";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 99);
            label5.Name = "label5";
            label5.Size = new Size(61, 21);
            label5.TabIndex = 15;
            label5.Text = "Layer 2";
            // 
            // panelLayer
            // 
            panelLayer.BackColor = Color.White;
            panelLayer.Controls.Add(label21);
            panelLayer.Controls.Add(numBoilerPressure);
            panelLayer.Controls.Add(label22);
            panelLayer.Controls.Add(label16);
            panelLayer.Controls.Add(label17);
            panelLayer.Controls.Add(label15);
            panelLayer.Controls.Add(label9);
            panelLayer.Controls.Add(numFZone2Pressure);
            panelLayer.Controls.Add(label10);
            panelLayer.Controls.Add(numFZone1Pressure);
            panelLayer.Controls.Add(label11);
            panelLayer.Controls.Add(numBPressure);
            panelLayer.Controls.Add(label12);
            panelLayer.Controls.Add(numAPressure);
            panelLayer.Controls.Add(label13);
            panelLayer.Location = new Point(766, 398);
            panelLayer.Name = "panelLayer";
            panelLayer.Size = new Size(313, 344);
            panelLayer.TabIndex = 26;
            // 
            // label21
            // 
            label21.Anchor = AnchorStyles.None;
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.Location = new Point(254, 45);
            label21.Name = "label21";
            label21.Size = new Size(33, 21);
            label21.TabIndex = 28;
            label21.Text = "bar";
            // 
            // numBoilerPressure
            // 
            numBoilerPressure.Anchor = AnchorStyles.None;
            numBoilerPressure.AutoSize = true;
            numBoilerPressure.DecimalPlaces = 2;
            numBoilerPressure.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numBoilerPressure.Location = new Point(167, 43);
            numBoilerPressure.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numBoilerPressure.Name = "numBoilerPressure";
            numBoilerPressure.Size = new Size(69, 29);
            numBoilerPressure.TabIndex = 26;
            // 
            // label22
            // 
            label22.Anchor = AnchorStyles.None;
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.Location = new Point(20, 46);
            label22.Name = "label22";
            label22.Size = new Size(50, 21);
            label22.TabIndex = 27;
            label22.Text = "Boiler";
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.None;
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(254, 260);
            label16.Name = "label16";
            label16.Size = new Size(33, 21);
            label16.TabIndex = 25;
            label16.Text = "bar";
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.None;
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.Location = new Point(254, 205);
            label17.Name = "label17";
            label17.Size = new Size(33, 21);
            label17.TabIndex = 24;
            label17.Text = "bar";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.None;
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(254, 153);
            label15.Name = "label15";
            label15.Size = new Size(33, 21);
            label15.TabIndex = 23;
            label15.Text = "bar";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(254, 98);
            label9.Name = "label9";
            label9.Size = new Size(33, 21);
            label9.TabIndex = 22;
            label9.Text = "bar";
            // 
            // numFZone2Pressure
            // 
            numFZone2Pressure.Anchor = AnchorStyles.None;
            numFZone2Pressure.AutoSize = true;
            numFZone2Pressure.DecimalPlaces = 2;
            numFZone2Pressure.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numFZone2Pressure.Location = new Point(167, 254);
            numFZone2Pressure.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numFZone2Pressure.Name = "numFZone2Pressure";
            numFZone2Pressure.Size = new Size(69, 29);
            numFZone2Pressure.TabIndex = 20;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(20, 257);
            label10.Name = "label10";
            label10.Size = new Size(133, 21);
            label10.TabIndex = 21;
            label10.Text = "Machine F Zone 2";
            // 
            // numFZone1Pressure
            // 
            numFZone1Pressure.Anchor = AnchorStyles.None;
            numFZone1Pressure.AutoSize = true;
            numFZone1Pressure.DecimalPlaces = 2;
            numFZone1Pressure.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numFZone1Pressure.Location = new Point(167, 202);
            numFZone1Pressure.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numFZone1Pressure.Name = "numFZone1Pressure";
            numFZone1Pressure.Size = new Size(69, 29);
            numFZone1Pressure.TabIndex = 17;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.None;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(20, 205);
            label11.Name = "label11";
            label11.Size = new Size(133, 21);
            label11.TabIndex = 18;
            label11.Text = "Machine F Zone 1";
            // 
            // numBPressure
            // 
            numBPressure.Anchor = AnchorStyles.None;
            numBPressure.AutoSize = true;
            numBPressure.DecimalPlaces = 2;
            numBPressure.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numBPressure.Location = new Point(167, 150);
            numBPressure.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numBPressure.Name = "numBPressure";
            numBPressure.Size = new Size(69, 29);
            numBPressure.TabIndex = 14;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.None;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(20, 153);
            label12.Name = "label12";
            label12.Size = new Size(82, 21);
            label12.TabIndex = 15;
            label12.Text = "Machine B";
            // 
            // numAPressure
            // 
            numAPressure.Anchor = AnchorStyles.None;
            numAPressure.AutoSize = true;
            numAPressure.DecimalPlaces = 2;
            numAPressure.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numAPressure.Location = new Point(167, 96);
            numAPressure.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numAPressure.Name = "numAPressure";
            numAPressure.Size = new Size(69, 29);
            numAPressure.TabIndex = 5;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.None;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(20, 99);
            label13.Name = "label13";
            label13.Size = new Size(83, 21);
            label13.TabIndex = 12;
            label13.Text = "Machine A";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.AutoSize = true;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label26);
            panel1.Controls.Add(label25);
            panel1.Controls.Add(dtpTo);
            panel1.Controls.Add(dtpFrom);
            panel1.Controls.Add(tableMachineSetting);
            panel1.Controls.Add(btnTableRefresh);
            panel1.Controls.Add(txtBoxStatus);
            panel1.Location = new Point(21, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(1061, 306);
            panel1.TabIndex = 27;
            // 
            // label26
            // 
            label26.Anchor = AnchorStyles.None;
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label26.Location = new Point(451, 17);
            label26.Name = "label26";
            label26.Size = new Size(24, 21);
            label26.TabIndex = 38;
            label26.Text = "to";
            // 
            // label25
            // 
            label25.Anchor = AnchorStyles.None;
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label25.Location = new Point(119, 17);
            label25.Name = "label25";
            label25.Size = new Size(47, 21);
            label25.TabIndex = 37;
            label25.Text = "From";
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.None;
            dtpTo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpTo.Location = new Point(495, 14);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(250, 29);
            dtpTo.TabIndex = 36;
            // 
            // dtpFrom
            // 
            dtpFrom.Anchor = AnchorStyles.None;
            dtpFrom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFrom.Location = new Point(182, 14);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(250, 29);
            dtpFrom.TabIndex = 35;
            // 
            // btnDeleteOrder
            // 
            btnDeleteOrder.BackColor = Color.Red;
            btnDeleteOrder.BackgroundImageLayout = ImageLayout.None;
            btnDeleteOrder.FlatAppearance.BorderSize = 0;
            btnDeleteOrder.FlatStyle = FlatStyle.Flat;
            btnDeleteOrder.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDeleteOrder.ForeColor = Color.Black;
            btnDeleteOrder.Location = new Point(21, 336);
            btnDeleteOrder.Name = "btnDeleteOrder";
            btnDeleteOrder.Size = new Size(117, 33);
            btnDeleteOrder.TabIndex = 42;
            btnDeleteOrder.Text = "Delete Order";
            btnDeleteOrder.UseVisualStyleBackColor = false;
            btnDeleteOrder.Click += btnDeleteOrder_Click;
            // 
            // btnFinishOrder
            // 
            btnFinishOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFinishOrder.AutoSize = true;
            btnFinishOrder.BackColor = Color.Tomato;
            btnFinishOrder.BackgroundImageLayout = ImageLayout.None;
            btnFinishOrder.FlatAppearance.BorderSize = 0;
            btnFinishOrder.FlatStyle = FlatStyle.Flat;
            btnFinishOrder.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnFinishOrder.ForeColor = Color.Black;
            btnFinishOrder.Location = new Point(988, 336);
            btnFinishOrder.Name = "btnFinishOrder";
            btnFinishOrder.Size = new Size(91, 33);
            btnFinishOrder.TabIndex = 41;
            btnFinishOrder.Text = "Finish";
            btnFinishOrder.UseVisualStyleBackColor = false;
            btnFinishOrder.Click += btnFinishOrder_Click;
            // 
            // btnPauseOrder
            // 
            btnPauseOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPauseOrder.AutoSize = true;
            btnPauseOrder.BackColor = Color.Yellow;
            btnPauseOrder.BackgroundImageLayout = ImageLayout.None;
            btnPauseOrder.FlatAppearance.BorderSize = 0;
            btnPauseOrder.FlatStyle = FlatStyle.Flat;
            btnPauseOrder.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPauseOrder.ForeColor = Color.Black;
            btnPauseOrder.Location = new Point(882, 336);
            btnPauseOrder.Name = "btnPauseOrder";
            btnPauseOrder.Size = new Size(91, 33);
            btnPauseOrder.TabIndex = 40;
            btnPauseOrder.Text = "Pause";
            btnPauseOrder.UseVisualStyleBackColor = false;
            btnPauseOrder.Click += btnPauseOrder_Click;
            // 
            // btnRunOrder
            // 
            btnRunOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRunOrder.AutoSize = true;
            btnRunOrder.BackColor = Color.Lime;
            btnRunOrder.BackgroundImageLayout = ImageLayout.None;
            btnRunOrder.FlatAppearance.BorderSize = 0;
            btnRunOrder.FlatStyle = FlatStyle.Flat;
            btnRunOrder.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRunOrder.ForeColor = Color.Black;
            btnRunOrder.Location = new Point(777, 336);
            btnRunOrder.Name = "btnRunOrder";
            btnRunOrder.Size = new Size(91, 33);
            btnRunOrder.TabIndex = 39;
            btnRunOrder.Text = "Run";
            btnRunOrder.UseVisualStyleBackColor = false;
            btnRunOrder.Click += btnRunOrder_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(btnBrowseFolder);
            panel2.Controls.Add(label29);
            panel2.Controls.Add(label28);
            panel2.Location = new Point(21, 788);
            panel2.Name = "panel2";
            panel2.Size = new Size(385, 95);
            panel2.TabIndex = 43;
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
            // MachineSettingView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(btnDeleteOrder);
            Controls.Add(panel1);
            Controls.Add(btnFinishOrder);
            Controls.Add(btnPauseOrder);
            Controls.Add(panelSetPressure);
            Controls.Add(btnRunOrder);
            Controls.Add(panelLayer);
            Controls.Add(panelOrderInfo);
            Controls.Add(btnTableSave);
            Name = "MachineSettingView";
            Size = new Size(1101, 902);
            Load += MachineSettingView_Load;
            ((System.ComponentModel.ISupportInitialize)tableMachineSetting).EndInit();
            panelOrderInfo.ResumeLayout(false);
            panelOrderInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMachineSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPaperWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPaperLength).EndInit();
            panelSetPressure.ResumeLayout(false);
            panelSetPressure.PerformLayout();
            panelLayer.ResumeLayout(false);
            panelLayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBoilerPressure).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFZone2Pressure).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFZone1Pressure).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBPressure).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAPressure).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView tableMachineSetting;
        private Button btnTableRefresh;
        private Button btnTableSave;
        private TextBox txtBoxStatus;
        private Label lblInsertOrder;
        private Label label1;
        private Label label2;
        private Panel panelOrderInfo;
        private Panel panelSetPressure;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private NumericUpDown numPaperLength;
        private Label label14;
        private Panel panelLayer;
        private NumericUpDown numFZone2Pressure;
        private Label label10;
        private NumericUpDown numFZone1Pressure;
        private Label label11;
        private NumericUpDown numBPressure;
        private Label label12;
        private NumericUpDown numAPressure;
        private Label label13;
        private Label label16;
        private Label label17;
        private Label label15;
        private Label label9;
        private Label label18;
        private Label label19;
        private NumericUpDown numPaperWidth;
        private Label label20;
        private Label label21;
        private NumericUpDown numBoilerPressure;
        private Label label22;
        private DateTimePicker dtpRunDate;
        private ComboBox cboFluteType;
        private ComboBox cboLayer5;
        private ComboBox cboLayer4;
        private ComboBox cboLayer3;
        private ComboBox cboLayer2;
        private ComboBox cboLayer1;
        private ComboBox cboGsm5;
        private ComboBox cboGsm4;
        private ComboBox cboGsm3;
        private ComboBox cboGsm2;
        private ComboBox cboGsm1;
        private Label label23;
        private ComboBox cboCustomerName;
        private Panel panel1;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private Label label25;
        private Button btnRunOrder;
        private Label label26;
        private Button btnFinishOrder;
        private Button btnPauseOrder;
        private Button btnDeleteOrder;
        private Label label27;
        private NumericUpDown numMachineSpeed;
        private Label label24;
        private Panel panel2;
        private Label label28;
        private Button btnBrowseFolder;
        private Label label29;
        private PictureBox pictureBox1;
    }
}
