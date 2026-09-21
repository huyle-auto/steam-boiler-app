namespace SteamBoilerApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelSideMenu = new Panel();
            panelMainMenu = new FlowLayoutPanel();
            btnOverview = new Button();
            btnProductionData = new Button();
            panelProductionDataSubMenu = new FlowLayoutPanel();
            btnSchedule = new Button();
            btnPlantData = new Button();
            btnMachineSetting = new Button();
            btnChart = new Button();
            panelChartSubMenu = new FlowLayoutPanel();
            btnFuelUseChart = new Button();
            btnPressureControlChart = new Button();
            btnUser = new Button();
            panelUserSubMenu = new FlowLayoutPanel();
            btnSettings = new Button();
            btnLogout = new Button();
            panelLogo = new Panel();
            panelMainContent = new FlowLayoutPanel();
            panelSideMenu.SuspendLayout();
            panelMainMenu.SuspendLayout();
            panelProductionDataSubMenu.SuspendLayout();
            panelChartSubMenu.SuspendLayout();
            panelUserSubMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelSideMenu
            // 
            resources.ApplyResources(panelSideMenu, "panelSideMenu");
            panelSideMenu.BackColor = Color.White;
            panelSideMenu.Controls.Add(panelMainMenu);
            panelSideMenu.Controls.Add(panelLogo);
            panelSideMenu.Name = "panelSideMenu";
            // 
            // panelMainMenu
            // 
            resources.ApplyResources(panelMainMenu, "panelMainMenu");
            panelMainMenu.BackColor = Color.FromArgb(76, 110, 181);
            panelMainMenu.Controls.Add(btnOverview);
            panelMainMenu.Controls.Add(btnProductionData);
            panelMainMenu.Controls.Add(panelProductionDataSubMenu);
            panelMainMenu.Controls.Add(btnChart);
            panelMainMenu.Controls.Add(panelChartSubMenu);
            panelMainMenu.Controls.Add(btnUser);
            panelMainMenu.Controls.Add(panelUserSubMenu);
            panelMainMenu.Name = "panelMainMenu";
            // 
            // btnOverview
            // 
            resources.ApplyResources(btnOverview, "btnOverview");
            btnOverview.FlatAppearance.BorderSize = 0;
            btnOverview.FlatAppearance.MouseOverBackColor = Color.FromArgb(121, 146, 200);
            btnOverview.ForeColor = Color.White;
            btnOverview.Name = "btnOverview";
            btnOverview.UseVisualStyleBackColor = true;
            btnOverview.Click += btnOverview_Click;
            // 
            // btnProductionData
            // 
            btnProductionData.BackColor = Color.FromArgb(76, 110, 181);
            resources.ApplyResources(btnProductionData, "btnProductionData");
            btnProductionData.FlatAppearance.BorderSize = 0;
            btnProductionData.FlatAppearance.MouseOverBackColor = Color.FromArgb(121, 146, 200);
            btnProductionData.ForeColor = Color.White;
            btnProductionData.Name = "btnProductionData";
            btnProductionData.UseVisualStyleBackColor = false;
            btnProductionData.Click += btnProductionData_Click;
            // 
            // panelProductionDataSubMenu
            // 
            panelProductionDataSubMenu.Controls.Add(btnSchedule);
            panelProductionDataSubMenu.Controls.Add(btnPlantData);
            panelProductionDataSubMenu.Controls.Add(btnMachineSetting);
            resources.ApplyResources(panelProductionDataSubMenu, "panelProductionDataSubMenu");
            panelProductionDataSubMenu.Name = "panelProductionDataSubMenu";
            // 
            // btnSchedule
            // 
            btnSchedule.BackColor = Color.FromArgb(126, 162, 212);
            resources.ApplyResources(btnSchedule, "btnSchedule");
            btnSchedule.FlatAppearance.BorderSize = 0;
            btnSchedule.ForeColor = Color.White;
            btnSchedule.Name = "btnSchedule";
            btnSchedule.UseVisualStyleBackColor = false;
            btnSchedule.Click += btnSchedule_Click;
            // 
            // btnPlantData
            // 
            btnPlantData.BackColor = Color.FromArgb(126, 162, 212);
            resources.ApplyResources(btnPlantData, "btnPlantData");
            btnPlantData.FlatAppearance.BorderSize = 0;
            btnPlantData.ForeColor = Color.White;
            btnPlantData.Name = "btnPlantData";
            btnPlantData.UseVisualStyleBackColor = false;
            // 
            // btnMachineSetting
            // 
            btnMachineSetting.BackColor = Color.FromArgb(126, 162, 212);
            resources.ApplyResources(btnMachineSetting, "btnMachineSetting");
            btnMachineSetting.FlatAppearance.BorderSize = 0;
            btnMachineSetting.ForeColor = Color.White;
            btnMachineSetting.Name = "btnMachineSetting";
            btnMachineSetting.UseVisualStyleBackColor = false;
            btnMachineSetting.Click += btnMachineSetting_Click;
            // 
            // btnChart
            // 
            btnChart.BackColor = Color.FromArgb(76, 110, 181);
            btnChart.FlatAppearance.BorderSize = 0;
            btnChart.FlatAppearance.MouseOverBackColor = Color.FromArgb(121, 146, 200);
            resources.ApplyResources(btnChart, "btnChart");
            btnChart.ForeColor = Color.White;
            btnChart.Name = "btnChart";
            btnChart.UseVisualStyleBackColor = false;
            btnChart.Click += btnChart_Click;
            // 
            // panelChartSubMenu
            // 
            resources.ApplyResources(panelChartSubMenu, "panelChartSubMenu");
            panelChartSubMenu.Controls.Add(btnFuelUseChart);
            panelChartSubMenu.Controls.Add(btnPressureControlChart);
            panelChartSubMenu.Name = "panelChartSubMenu";
            // 
            // btnFuelUseChart
            // 
            btnFuelUseChart.BackColor = Color.FromArgb(126, 162, 212);
            resources.ApplyResources(btnFuelUseChart, "btnFuelUseChart");
            btnFuelUseChart.FlatAppearance.BorderSize = 0;
            btnFuelUseChart.ForeColor = Color.White;
            btnFuelUseChart.Name = "btnFuelUseChart";
            btnFuelUseChart.UseVisualStyleBackColor = false;
            btnFuelUseChart.Click += btnFuelUseChart_Click;
            // 
            // btnPressureControlChart
            // 
            btnPressureControlChart.BackColor = Color.FromArgb(126, 162, 212);
            resources.ApplyResources(btnPressureControlChart, "btnPressureControlChart");
            btnPressureControlChart.FlatAppearance.BorderSize = 0;
            btnPressureControlChart.ForeColor = Color.White;
            btnPressureControlChart.Name = "btnPressureControlChart";
            btnPressureControlChart.UseVisualStyleBackColor = false;
            btnPressureControlChart.Click += btnPressureControlChart_Click;
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.FromArgb(76, 110, 181);
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(121, 146, 200);
            resources.ApplyResources(btnUser, "btnUser");
            btnUser.ForeColor = Color.White;
            btnUser.Name = "btnUser";
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += btnUser_Click;
            // 
            // panelUserSubMenu
            // 
            panelUserSubMenu.Controls.Add(btnSettings);
            panelUserSubMenu.Controls.Add(btnLogout);
            resources.ApplyResources(panelUserSubMenu, "panelUserSubMenu");
            panelUserSubMenu.Name = "panelUserSubMenu";
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(126, 162, 212);
            resources.ApplyResources(btnSettings, "btnSettings");
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.ForeColor = Color.White;
            btnSettings.Name = "btnSettings";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(126, 162, 212);
            resources.ApplyResources(btnLogout, "btnLogout");
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.ForeColor = Color.White;
            btnLogout.Name = "btnLogout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panelLogo
            // 
            resources.ApplyResources(panelLogo, "panelLogo");
            panelLogo.Name = "panelLogo";
            // 
            // panelMainContent
            // 
            resources.ApplyResources(panelMainContent, "panelMainContent");
            panelMainContent.Name = "panelMainContent";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(229, 241, 247);
            Controls.Add(panelMainContent);
            Controls.Add(panelSideMenu);
            Name = "MainForm";
            Load += MainForm_Load;
            panelSideMenu.ResumeLayout(false);
            panelSideMenu.PerformLayout();
            panelMainMenu.ResumeLayout(false);
            panelMainMenu.PerformLayout();
            panelProductionDataSubMenu.ResumeLayout(false);
            panelChartSubMenu.ResumeLayout(false);
            panelUserSubMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSideMenu;
        private Button btnSchedule;
        private Button btnPlantData;
        private Button btnMachineSetting;
        private Button btnFuelUseChart;
        private Button btnPressureControlChart;
        private Button btnChart;
        private Panel panelLogo;
        private Button btnProductionData;
        private FlowLayoutPanel panelChartSubMenu;
        private Button btnOverview;
        private FlowLayoutPanel panelProductionDataSubMenu;
        private FlowLayoutPanel panelMainMenu;
        private Button btnUser;
        private FlowLayoutPanel panelUserSubMenu;
        private Button btnLogout;
        private FlowLayoutPanel panelMainContent;
        private Button btnSettings;
    }
}
