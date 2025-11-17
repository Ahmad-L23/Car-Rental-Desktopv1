using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CarRentalBusiness;
using CarRentalSystem.DamageMaintenance;

namespace CarRentalSystem.DamagesMaintenance
{
    public partial class ucDamageMaintenanceCard : UserControl
    {
        private DataTable _damageData;
        private int _currentIndex = -1;

        private Label lblRecordCounter;
 
        public ucDamageMaintenanceCard()
        {
            InitializeComponent();

 

            LoadData();
        }

        public void LoadData()
        {
            _damageData = ClsDamageMaintenance.GetDamagesWithEmpAndCarInfo();
            lblRecordCounte.Text = $"{_damageData.Rows.Count} Records";

            if (_damageData.Rows.Count > 0)
            {
                _currentIndex = 0;
                DisplayCurrentRecord();
            }
        }

        private void DisplayCurrentRecord()
        {
            if (_currentIndex < 0 || _currentIndex >= _damageData.Rows.Count)
                return;

            DataRow row = _damageData.Rows[_currentIndex];

            lblCarPlate.Text = row["PlateNumber"]?.ToString() ?? "N/A";
            lblDamageDat.Text = row["DamageDate"] != DBNull.Value
                ? Convert.ToDateTime(row["DamageDate"]).ToShortDateString()
                : "N/A";
            lblAmount.Text = row["TotalAmount"]?.ToString() ?? "N/A";

            // Convert status to meaningful text
            lblStat.Text = GetStatusText(row["Status"]);

            lblGasloineIn.Text = row["GasolineIn"]?.ToString() ?? "N/A";
            lblGasloineOut.Text = row["GasolineOut"]?.ToString() ?? "N/A";
            lblGrageName.Text = row["GarageName"]?.ToString() ?? "N/A";
            lblEmployeeName.Text = row["EmployeeName"]?.ToString() ?? "N/A";

            lblRepairStartDat.Text = row["RepairStartDate"] != DBNull.Value
                ? Convert.ToDateTime(row["RepairStartDate"]).ToShortDateString()
                : "N/A";

            v.Text = row["CompletionDate"] != DBNull.Value
                ? Convert.ToDateTime(row["CompletionDate"]).ToShortDateString()
                : "N/A";

            lblDesc.Text = row["Description"]?.ToString() ?? "N/A";

            lblStat.Text = GetStatusText(row["Status"]);

            // Change label color based on status
            switch (lblStat.Text)
            {
                case "Pending":
                    lblStat.ForeColor = Color.Orange;
                    break;

                case "In Progress":
                    lblStat.ForeColor = Color.Blue;
                    break;

                case "Completed":
                    lblStat.ForeColor = Color.Green;
                    break;

                default:
                    lblStat.ForeColor = Color.Gray;
                    break;
            }

        }

        private string GetStatusText(object statusObj)
        {
            if (statusObj == DBNull.Value || statusObj == null)
                return "N/A";

            if (!int.TryParse(statusObj.ToString(), out int status))
                return "Unknown";

            switch (status)
            {
                case 0: return "Pending";
                case 1: return "In Progress";
                case 2: return "Completed";
                default: return "Unknown";
            }
        }


        

        private void button3_Click(object sender, EventArgs e)
        {
            if (_damageData == null || _damageData.Rows.Count == 0)
                return;

            if (_currentIndex < _damageData.Rows.Count - 1)
            {
                _currentIndex++;
                DisplayCurrentRecord();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_damageData == null || _damageData.Rows.Count == 0)
                return;

            if (_currentIndex > 0)
            {
                _currentIndex--;
                DisplayCurrentRecord();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_damageData == null || _damageData.Rows.Count == 0)
                return;

            _currentIndex = _damageData.Rows.Count - 1;
            DisplayCurrentRecord();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_damageData == null || _damageData.Rows.Count == 0)
                return;

            _currentIndex = 0;
            DisplayCurrentRecord();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmAddEditDamageMaintenance frm = new frmAddEditDamageMaintenance();
            frm.ShowDialog();
            LoadData();
        }
    }
}
