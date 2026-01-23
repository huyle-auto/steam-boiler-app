using Microsoft.WindowsAPICodePack.Dialogs;
using SteamBoilerApp.MachineSetting.Contracts;
using SteamBoilerApp.Models;
using SteamBoilerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamBoilerApp.MachineSetting.Views
{
    public partial class MachineSettingView : UserControl, IMachineSettingView
    {
        public MachineSettingView()
        {
            InitializeComponent();
            InitLayerControls();
        }

        private List<ComboBox> _cboLayers;
        private List<ComboBox> _cboPaperGrammages;

        public DateTime FromDate => dtpFrom.Value.Date;
        public DateTime ToDate => dtpTo.Value.Date;
        public int SelectedOrderId => (int)(tableMachineSetting.CurrentRow?.Cells["OrderId"].Value ?? 0);

        public string ExportFullPath { get; set; }
        public bool Append { get; set; }

        public event EventHandler RefreshClicked;
        public event EventHandler SaveClicked;
        public event EventHandler DeleteClicked;

        public event EventHandler RunOrderClicked;
        public event EventHandler PauseOrderClicked;
        public event EventHandler FinishOrderClicked;
        public event EventHandler OnViewLoad;
        public event EventHandler ExportClicked;

        public void InvokeUI(Action action)
        {
            if (IsDisposed) return;

            if (InvokeRequired)
            {
                BeginInvoke(action);
            }
            else
            {
                action();
            }
        }
        private void InitLayerControls()
        {
            _cboLayers = [
                cboLayer1,
                cboLayer2,
                cboLayer3,
                cboLayer4,
                cboLayer5
            ];
            _cboPaperGrammages = [cboGsm1, cboGsm2, cboGsm3, cboGsm4, cboGsm5];
        }
        public Order GetNewOrderData()
        {
            var order = new Order
            {
                CustomerId = (int)cboCustomerName.SelectedValue,
                FluteTypeId = (int)cboFluteType.SelectedValue,
                RunDate = dtpRunDate.Value.Date
            };

            // Paper Types & Grammages
            for (int i = 0; i < _cboLayers.Count; i++)
            {
                // Validation 
                if (_cboLayers[i].SelectedIndex == 0 || _cboPaperGrammages[i].SelectedIndex == 0)
                {
                    throw new Exception($"Please select Paper Type & Grammage for Layer {i + 1}, or leave both empty");
                }

                order.Layers.Add(new Layer
                {
                    LayerPosition = (i + 1),
                    PaperTypeId = (int)_cboLayers[i].SelectedValue,
                    PaperGrammageId = (int)_cboPaperGrammages[i].SelectedValue
                });
            }

            // Measurements (currently ignore Machine Pressure)
            order.Measurements.Add(new Measurement
            {
                MachineId = null,
                MeasurementTypeId = 3,
                MeasuredValue = numPaperLength.Value,   // Paper Length
                UnitId = 3
            });

            order.Measurements.Add(new Measurement
            {
                MachineId = null,
                MeasurementTypeId = 4,
                MeasuredValue = numPaperWidth.Value,    // Paper Width
                UnitId = 3
            });

            order.Measurements.Add(new Measurement
            {
                MachineId = 1,
                MeasurementTypeId = 1,
                MeasuredValue = numAPressure.Value,          // A Pressure
                UnitId = 1
            });

            order.Measurements.Add(new Measurement
            {
                MachineId = 2,
                MeasurementTypeId = 1,
                MeasuredValue = numBPressure.Value,          // B Pressure
                UnitId = 1
            });

            order.Measurements.Add(new Measurement
            {
                MachineId = 3,
                MeasurementTypeId = 1,
                MeasuredValue = numFZone1Pressure.Value,          // F Zone 1 Pressure
                UnitId = 1
            });

            order.Measurements.Add(new Measurement
            {
                MachineId = 4,
                MeasurementTypeId = 1,
                MeasuredValue = numFZone2Pressure.Value,          // F Zone 2 Pressure
                UnitId = 1
            });

            order.Measurements.Add(new Measurement
            {
                MachineId = null,
                MeasurementTypeId = 2,
                MeasuredValue = numMachineSpeed.Value,           // Manufacture Speed
                UnitId = 2
            });

            return order;
        }

        public void SetCustomers(List<Customer> customers)
        {
            cboCustomerName.DataSource = null;
            cboCustomerName.DataSource = customers;
            cboCustomerName.DisplayMember = "CustomerName";
            cboCustomerName.ValueMember = "CustomerId";
            cboCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCustomerName.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void SetFluteTypes(List<FluteType> fluteTypes)
        {
            cboFluteType.DataSource = null;
            cboFluteType.DataSource = fluteTypes;
            cboFluteType.DisplayMember = "FluteCode";
            cboFluteType.ValueMember = "FluteTypeId";
            cboFluteType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboFluteType.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        public void SetPaperGrammages(List<PaperGrammage> paperGrammages)
        {
            paperGrammages.Insert(0, new PaperGrammage { PaperGrammageId = 0, GrammageValue = 0 });
            foreach (var cbo in _cboPaperGrammages)
            {
                cbo.DataSource = null;
                cbo.DataSource = new List<PaperGrammage>(paperGrammages);
                cbo.DisplayMember = "GrammageValue";
                cbo.ValueMember = "PaperGrammageId";
                cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
        public void SetPaperTypes(List<PaperType> paperTypes)
        {
            paperTypes.Insert(0, new PaperType { PaperTypeId = 0, PaperCode = "", Description = "No Paper" });
            foreach (var cbo in _cboLayers)
            {
                cbo.DataSource = null;
                cbo.DataSource = new List<PaperType>(paperTypes);
                cbo.DisplayMember = "PaperCode";
                cbo.ValueMember = "PaperTypeId";
                cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        public void ShowOrder(List<OrderSummary> table)
        {
            // Refresh tablemachineSetting here
            tableMachineSetting.DataSource = table;
            tableMachineSetting.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ColorRowsByStatus();
        }
        public void ShowStatus(string status)
        {
            txtBoxStatus.Text = status;
        }

        private void ColorRowsByStatus()
        {
            foreach (DataGridViewRow row in tableMachineSetting.Rows)
            {
                if (row.Cells["Status"].Value == null)
                    continue;

                string status = row.Cells["Status"].Value.ToString() ?? string.Empty;

                switch (status)
                {
                    case "RUN":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(0, 255, 0);
                        break;

                    case "PAUSE":
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        break;

                    case "FINISH":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 99, 71);
                        break;

                    default:
                        row.DefaultCellStyle.BackColor = Color.White;
                        break;
                }
            }
        }
        private void btnTableRefresh_Click(object sender, EventArgs e)
        {
            RefreshClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnTableSave_Click(object sender, EventArgs e)
        {
            SaveClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnRunOrder_Click(object sender, EventArgs e)
        {
            RunOrderClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnPauseOrder_Click(object sender, EventArgs e)
        {
            PauseOrderClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnFinishOrder_Click(object sender, EventArgs e)
        {
            FinishOrderClicked?.Invoke(this, EventArgs.Empty);

        }

        private void MachineSettingView_Load(object sender, EventArgs e)
        {
            OnViewLoad?.Invoke(this, EventArgs.Empty);
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog();
            dialog.Filter = "Excel Workbook|*.xlsx";
            dialog.Title = "Select File Location and File Name";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.FileName = DateTime.Now.ToString("order_dd-MM-yy") + ".xlsx"; // Optional: provide a default file name

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ExportFullPath = dialog.FileName;
                ExportClicked?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}
