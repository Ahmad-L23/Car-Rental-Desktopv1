using CarRentalBusiness;
using CarRentalSystem.PaymentMethod;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRentalSystem.PaymentMethods
{
    public partial class ucPaymentMethods : UserControl
    {
        private DataTable paymentMethodsTable;

        public ucPaymentMethods()
        {
            InitializeComponent();
        }

        private void ucPaymentMethods_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadPaymentMethods();
        }

        private void SetupDataGridView()
        {
            dgvPaymentMethods.AutoGenerateColumns = false;
            dgvPaymentMethods.Columns.Clear();

            dgvPaymentMethods.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",  // make sure your DataTable has "Id" column
                Visible = false
            });

            dgvPaymentMethods.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MethodName",
                HeaderText = "Name",
                DataPropertyName = "MethodName",  // your DataTable should have "Name"
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        public void LoadPaymentMethods()
        {
            try
            {
                paymentMethodsTable = ClsPaymentMethod.GetAllPaymentMethods();
                dgvPaymentMethods.DataSource = paymentMethodsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment methods:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddPaymentMethod_Click(object sender, EventArgs e)
        {
            var frmAdd = new frmAddUpdatePaymentMethod(null);
            frmAdd.ShowDialog();
            LoadPaymentMethods();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPaymentMethods.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvPaymentMethods.SelectedRows[0].Cells["id"].Value);

            using (var frm = new frmAddUpdatePaymentMethod(id))
            {
                frm.ShowDialog();
                LoadPaymentMethods();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPaymentMethods.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvPaymentMethods.SelectedRows[0].Cells["id"].Value);
            string name = dgvPaymentMethods.SelectedRows[0].Cells["Name"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Delete payment method '{name}'?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (ClsPaymentMethod.DeletePaymentMethod(id))
                {
                    MessageBox.Show("Payment method deleted successfully.");
                    LoadPaymentMethods();
                }
                else
                {
                    MessageBox.Show("Failed to delete payment method.");
                }
            }
        }

        private void dgvPaymentMethods_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvPaymentMethods.ClearSelection();
                dgvPaymentMethods.Rows[e.RowIndex].Selected = true;
                dgvPaymentMethods.CurrentCell = dgvPaymentMethods.Rows[e.RowIndex].Cells[1];
            }
        }
    }
}
