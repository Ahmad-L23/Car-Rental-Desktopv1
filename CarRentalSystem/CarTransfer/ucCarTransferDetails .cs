using CarRentalBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.CarTransfer
{
    public partial class ucCarTransferDetails : UserControl
    {
        private DataTable transferData;
        private int currentIndex = -1;

        public ucCarTransferDetails()
        {
            InitializeComponent();

            // Hook up navigation buttons
            btnFirst.Click += BtnFirst_Click;
            btnPrev.Click += BtnPrev_Click;
            btnNext.Click += BtnNext_Click;
            btnLast.Click += BtnLast_Click;

            // Hook up Add button
            btnAdd.Click += BtnAdd_Click;

            LoadCarTransferData();
        }

        public void LoadCarTransferData()
        {
            try
            {
                transferData = ClsCarTransfer.GetAllCarTransferSummary();

                if (transferData != null && transferData.Rows.Count > 0)
                {
                    currentIndex = 0;
                    DisplayTransferData();
                }
                else
                {
                    currentIndex = -1;
                    ClearLabels();
                    MessageBox.Show("No car transfer data available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load car transfer data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayTransferData()
        {
            if (transferData == null || currentIndex < 0 || currentIndex >= transferData.Rows.Count)
                return;

            DataRow row = transferData.Rows[currentIndex];

            lblTransferReasonValue.Text = row["TransferReason"]?.ToString() ?? "???";
            lblPlateNumberValue.Text = row["PlateNumber"]?.ToString() ?? "???";
            lblEmployeeNameValue.Text = row["EmployeeName"]?.ToString() ?? "???";
            lblExitDateValue.Text = row["ExitDate"] != DBNull.Value
                ? Convert.ToDateTime(row["ExitDate"]).ToString("dd/MM/yyyy")
                : "N/A";

            lblExitBranchValue.Text = row["ExitBranchName"]?.ToString() ?? "???";
            lblTransferToBranchValue.Text = row["TransferToBranchName"]?.ToString() ?? "???";
            lblStatusValue.Text = GetStatusText(row["Status"]);

            UpdateNavigationButtons();
        }

        private void ClearLabels()
        {
            lblTransferReasonValue.Text = "???";
            lblPlateNumberValue.Text = "???";
            lblEmployeeNameValue.Text = "???";
            lblExitDateValue.Text = "???";
            lblExitBranchValue.Text = "???";
            lblTransferToBranchValue.Text = "???";
            lblStatusValue.Text = "???";
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
                    return "Delivered";
                case 2:
                    return "InProgress";
                default:
                    return "Unknown";
            }

        }

        private void UpdateNavigationButtons()
        {
            bool hasData = transferData != null && transferData.Rows.Count > 0;
            btnFirst.Enabled = hasData && currentIndex > 0;
            btnPrev.Enabled = hasData && currentIndex > 0;
            btnNext.Enabled = hasData && currentIndex < transferData.Rows.Count - 1;
            btnLast.Enabled = hasData && currentIndex < transferData.Rows.Count - 1;
        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            if (transferData == null || transferData.Rows.Count == 0) return;
            currentIndex = 0;
            DisplayTransferData();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (transferData == null || transferData.Rows.Count == 0) return;
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayTransferData();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (transferData == null || transferData.Rows.Count == 0) return;
            if (currentIndex < transferData.Rows.Count - 1)
            {
                currentIndex++;
                DisplayTransferData();
            }
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            if (transferData == null || transferData.Rows.Count == 0) return;
            currentIndex = transferData.Rows.Count - 1;
            DisplayTransferData();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmAddUpdateCarTransfer();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadCarTransferData();
                BtnLast_Click(sender, e);
            }
        }
    }
}
