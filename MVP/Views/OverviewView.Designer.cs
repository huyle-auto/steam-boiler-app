namespace SteamBoilerApp.MachineSetting.Views
{
    partial class OverviewView
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
            CodeArtEng.Gauge.Themes.ThemeColors themeColors1 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors2 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors3 = new CodeArtEng.Gauge.Themes.ThemeColors();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            gaugeSteamPressure = new CodeArtEng.Gauge.CircularGauge();
            gaugeLimitRange1 = new CodeArtEng.Gauge.GaugeLimitRange();
            gaugeLimitRange2 = new CodeArtEng.Gauge.GaugeLimitRange();
            gaugeLimitRange3 = new CodeArtEng.Gauge.GaugeLimitRange();
            chartFuelDist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            cboFuelDist = new ComboBox();
            panelFuelDist = new Panel();
            panelSteamPressure = new Panel();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)chartFuelDist).BeginInit();
            panelFuelDist.SuspendLayout();
            panelSteamPressure.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // gaugeSteamPressure
            // 
            gaugeSteamPressure.ErrorLimit = 10D;
            gaugeSteamPressure.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gaugeSteamPressure.FontTitle = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gaugeSteamPressure.FontUnitLabel = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gaugeSteamPressure.InfoMode = CodeArtEng.Gauge.GaugeInfoMode.NONE;
            gaugeSteamPressure.Limits.Add(gaugeLimitRange1);
            gaugeSteamPressure.Limits.Add(gaugeLimitRange2);
            gaugeSteamPressure.Limits.Add(gaugeLimitRange3);
            gaugeSteamPressure.Location = new Point(0, 0);
            gaugeSteamPressure.Name = "gaugeSteamPressure";
            gaugeSteamPressure.ResetValue = 0D;
            gaugeSteamPressure.ScaleFactor = 1D;
            gaugeSteamPressure.Size = new Size(127, 129);
            gaugeSteamPressure.TabIndex = 0;
            gaugeSteamPressure.TabStop = false;
            gaugeSteamPressure.Title = "";
            gaugeSteamPressure.Unit = "bar";
            themeColors1.KnobInnerBorderColor = Color.FromArgb(200, 200, 200);
            themeColors1.KnobTone = Color.FromArgb(200, 200, 200);
            gaugeSteamPressure.UserDefinedColors.Base = themeColors1;
            themeColors2.KnobInnerBorderColor = Color.FromArgb(200, 200, 200);
            themeColors2.KnobTone = Color.FromArgb(200, 200, 200);
            gaugeSteamPressure.UserDefinedColors.Error = themeColors2;
            themeColors3.KnobInnerBorderColor = Color.FromArgb(200, 200, 200);
            themeColors3.KnobTone = Color.FromArgb(200, 200, 200);
            gaugeSteamPressure.UserDefinedColors.Warning = themeColors3;
            gaugeSteamPressure.Value = 0D;
            gaugeSteamPressure.WarningLimit = 9.3D;
            // 
            // gaugeLimitRange1
            // 
            gaugeLimitRange1.Color = Color.Red;
            gaugeLimitRange1.Name = "gaugeLimitRange1";
            gaugeLimitRange1.RangeType = CodeArtEng.Gauge.GaugeLimitRangeType.LesserOrEqualThan;
            gaugeLimitRange1.Value = 7D;
            // 
            // gaugeLimitRange2
            // 
            gaugeLimitRange2.Color = Color.Yellow;
            gaugeLimitRange2.Name = "gaugeLimitRange2";
            gaugeLimitRange2.Type = CodeArtEng.Gauge.GaugeLimitType.Warning;
            gaugeLimitRange2.Value = 10D;
            // 
            // gaugeLimitRange3
            // 
            gaugeLimitRange3.Color = Color.Red;
            gaugeLimitRange3.Name = "gaugeLimitRange3";
            gaugeLimitRange3.Value = 13D;
            // 
            // chartFuelDist
            // 
            chartArea1.Name = "ChartArea1";
            chartFuelDist.ChartAreas.Add(chartArea1);
            chartFuelDist.Dock = DockStyle.Fill;
            legend1.Alignment = StringAlignment.Center;
            legend1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.TitleFont = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chartFuelDist.Legends.Add(legend1);
            chartFuelDist.Location = new Point(0, 0);
            chartFuelDist.Name = "chartFuelDist";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.CustomProperties = "PieStartAngle=270";
            series1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = Color.White;
            series1.LabelFormat = "#,##0.0'%'";
            series1.Legend = "Legend1";
            series1.Name = "PieSeries";
            chartFuelDist.Series.Add(series1);
            chartFuelDist.Size = new Size(423, 260);
            chartFuelDist.TabIndex = 2;
            chartFuelDist.Text = "chart1";
            title1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title1.Name = "chartTitleFuelDistribution";
            title1.Text = "Fuel Types Usage Distribution";
            chartFuelDist.Titles.Add(title1);
            // 
            // cboFuelDist
            // 
            cboFuelDist.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboFuelDist.FormattingEnabled = true;
            cboFuelDist.Location = new Point(281, 36);
            cboFuelDist.Name = "cboFuelDist";
            cboFuelDist.Size = new Size(126, 29);
            cboFuelDist.TabIndex = 3;
            cboFuelDist.SelectedIndexChanged += cboFuelDistribution_SelectedIndexChanged;
            // 
            // panelFuelDist
            // 
            panelFuelDist.Controls.Add(cboFuelDist);
            panelFuelDist.Controls.Add(chartFuelDist);
            panelFuelDist.Location = new Point(662, 415);
            panelFuelDist.Name = "panelFuelDist";
            panelFuelDist.Size = new Size(423, 260);
            panelFuelDist.TabIndex = 4;
            // 
            // panelSteamPressure
            // 
            panelSteamPressure.BackColor = Color.White;
            panelSteamPressure.Controls.Add(gaugeSteamPressure);
            panelSteamPressure.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelSteamPressure.Location = new Point(21, 18);
            panelSteamPressure.Name = "panelSteamPressure";
            panelSteamPressure.Size = new Size(127, 129);
            panelSteamPressure.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(922, 18);
            panel1.Name = "panel1";
            panel1.Size = new Size(163, 91);
            panel1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(241, 90, 34);
            label2.Location = new Point(11, 40);
            label2.Name = "label2";
            label2.Size = new Size(72, 37);
            label2.TabIndex = 1;
            label2.Text = "60%";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 14);
            label1.Name = "label1";
            label1.Size = new Size(134, 21);
            label1.TabIndex = 0;
            label1.Text = "Boiler Efficiency";
            // 
            // OverviewView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panelSteamPressure);
            Controls.Add(panelFuelDist);
            Name = "OverviewView";
            Size = new Size(1101, 689);
            ((System.ComponentModel.ISupportInitialize)chartFuelDist).EndInit();
            panelFuelDist.ResumeLayout(false);
            panelSteamPressure.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CodeArtEng.Gauge.CircularGauge gaugeSteamPressure;
        private CodeArtEng.Gauge.GaugeLimitRange gaugeLimitRange1;
        private CodeArtEng.Gauge.GaugeLimitRange gaugeLimitRange2;
        private CodeArtEng.Gauge.GaugeLimitRange gaugeLimitRange3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFuelDist;
        private ComboBox cboFuelDist;
        private Panel panelFuelDist;
        private Panel panelSteamPressure;
        private Panel panel1;
        private Label label1;
        private Label label2;
    }
}
