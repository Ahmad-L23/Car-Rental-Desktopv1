using CarRentalBusiness;
using CarRentalSystem.EmployeeUsageForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalSystem.EmployeeUsage
{
    public partial class ucEmployeeusageDetalis : UserControl
    {
        private DataTable usageData;
        private int currentIndex = -1;

        public ucEmployeeusageDetalis()
        {
            InitializeComponent();
            // Hook up button click events
            btnFirst.Click += BtnFirst_Click;
            btnPrev.Click += BtnPrev_Click;
            btnNext.Click += BtnNext_Click;
            btnLast.Click += BtnLast_Click;

            LoadEmployeeUsageData();
        }

        public void LoadEmployeeUsageData()
        {
            try
            {
                usageData = ClsEmployeeUsage.getFullEmployeeData();

                if (usageData != null && usageData.Rows.Count > 0)
                {
                    currentIndex = 0;
                    DisplayLabelsData();
                }
                else
                {
                    currentIndex = -1;
                    ClearLabels();
                    MessageBox.Show("No usage data available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load employee usage data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayLabelsData()
        {
            if (usageData == null || currentIndex < 0 || currentIndex >= usageData.Rows.Count)
                return;

            DataRow row = usageData.Rows[currentIndex];

            lblEmployeeNameValue.Text = row["EmployeeName"]?.ToString() ?? "???";
            lblCarPlateValue.Text = row["PlateNumber"]?.ToString() ?? "???";
            lblCarGroupValue.Text = row["CarCategory"]?.ToString() ?? "???";
            txtReason.Text = row["UsageReason"]?.ToString() ?? "???";

            lblExitDateValue.Text = row["ExitDate"] != DBNull.Value
               ? Convert.ToDateTime(row["ExitDate"]).ToString("dd/MM/yyyy")
               : "N/A";


            lblExitBranchValue.Text = row["ExitBranch"]?.ToString() ?? "???";
            lblStatusValue.Text = GetStatusText(row["Status"]);

            lblExitCounterValue.Text = row["ExitCounter"]?.ToString() ?? "???";
            lblExitFuelValue.Text = row["ExitFuel"]?.ToString() ?? "???";

            lblEntryBranchValue.Text = row["EntryBranch"]?.ToString() ?? "???";

            lblEntryDateValue.Text = row["EntryDate"] != DBNull.Value
                ? Convert.ToDateTime(row["EntryDate"]).ToString("dd/MM/yyyy")
                : "N/A";

            lblEntryCounterValue.Text = row["EntryCounter"]?.ToString() ?? "???";
            lblEntryFuelValue.Text = row["EntryFuel"]?.ToString() ?? "???";

            UpdateNavigationButtons();
        }

        private void ClearLabels()
        {
            lblEmployeeNameValue.Text = "???";
            lblCarPlateValue.Text = "???";
            lblCarGroupValue.Text = "???";
            txtReason.Text = "???";
            lblExitDateValue.Text = "???";
            lblExitBranchValue.Text = "???";
            lblStatusValue.Text = "???";
            lblExitCounterValue.Text = "???";
            lblExitFuelValue.Text = "???";
            lblEntryBranchValue.Text = "???";
            lblEntryDateValue.Text = "???";
            lblEntryCounterValue.Text = "???";
            lblEntryFuelValue.Text = "???";
        }

        private string GetStatusText(object statusObj)
        {
            if (statusObj == DBNull.Value || statusObj == null)
                return "N/A";

            if (!int.TryParse(statusObj.ToString(), out int status))
                return "Unknown";

            switch (status)
            {
                case 0:
                    return "Pending";
                case 1:
                    return "Delvired";
                case 2:
                    return "Completed";
                default:
                    return "Unknown";
            }
        }


        private void UpdateNavigationButtons()
        {
            bool hasData = usageData != null && usageData.Rows.Count > 0;
            btnFirst.Enabled = hasData && currentIndex > 0;
            btnPrev.Enabled = hasData && currentIndex > 0;
            btnNext.Enabled = hasData && currentIndex < usageData.Rows.Count - 1;
            btnLast.Enabled = hasData && currentIndex < usageData.Rows.Count - 1;
        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            if (usageData == null || usageData.Rows.Count == 0)
                return;

            currentIndex = 0;
            DisplayLabelsData();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (usageData == null || usageData.Rows.Count == 0)
                return;

            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayLabelsData();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (usageData == null || usageData.Rows.Count == 0)
                return;

            if (currentIndex < usageData.Rows.Count - 1)
            {
                currentIndex++;
                DisplayLabelsData();
            }
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            if (usageData == null || usageData.Rows.Count == 0)
                return;

            currentIndex = usageData.Rows.Count - 1;
            DisplayLabelsData();
        }

        private void lblCarGroupLabel_Click(object sender, EventArgs e)
        {

        }

        private void lblCarGroupValue_Click(object sender, EventArgs e)
        {

        }

        private void ucEmployeeusageDetalis_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditEmployeeUsage frm = new frmAddEditEmployeeUsage();
            frm.ShowDialog();
            LoadEmployeeUsageData();
            BtnLast_Click(sender, null);
        }
    }
}
