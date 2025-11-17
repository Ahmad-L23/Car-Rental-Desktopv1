using CarRentalBusiness;
using System;
using System.Data;
using System.Drawing;

using System.Windows.Forms;

namespace CarRentalSystem.Currency
{
    public partial class frmListCurrencies : Form
    {
        private DataTable _currenciesTable;

        public frmListCurrencies()
        {
            InitializeComponent();
        }

        private void frmListCurrencies_Load(object sender, EventArgs e)
        {
            LoadCurrencies();
            StyleGrid(dgvCurrencies);
        }

        private void LoadCurrencies()
        {
            _currenciesTable = ClsCurrency.GetCurrenciesDataTable();
            dgvCurrencies.DataSource = _currenciesTable;

            if (dgvCurrencies.Columns.Contains("Id"))
                dgvCurrencies.Columns["Id"].HeaderText = "ID";
            if (dgvCurrencies.Columns.Contains("NameEn"))
                dgvCurrencies.Columns["NameEn"].HeaderText = "Currency Name (English)";
            if (dgvCurrencies.Columns.Contains("NameAr"))
                dgvCurrencies.Columns["NameAr"].HeaderText = "اسم العملة (بالعربية)";

            if (dgvCurrencies.Columns.Contains("Id"))
                dgvCurrencies.Columns["Id"].Visible = false;
        }

        private void StyleGrid(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.LightGray;

            // Header Style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 35;

            // Row Style
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 76, 60);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Alternate rows
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Misc
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
        }

        private void dgvCurrencies_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgvCurrencies.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255);
        }

        private void dgvCurrencies_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgvCurrencies.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(245, 245, 245);
        }

        // 🧾 Context menu → Edit item
        

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCurrencies.CurrentRow == null)
                    return;

                int currencyId = Convert.ToInt32(dgvCurrencies.CurrentRow.Cells["Id"].Value);
                string currencyName = dgvCurrencies.CurrentRow.Cells["NameEn"].Value.ToString();

                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the currency \"{currencyName}\"?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    if (ClsCurrency.DeleteCurrency(currencyId))
                    {
                        MessageBox.Show("Currency deleted successfully.",
                                        "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCurrencies(); // Refresh grid
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete currency. Please try again.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the currency:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvCurrencies.CurrentRow == null)
                    return;

                int currencyId = Convert.ToInt32(dgvCurrencies.CurrentRow.Cells["Id"].Value);

                frmAddUpdateCurrency frm = new frmAddUpdateCurrency(currencyId);
                frm.ShowDialog();

                // Refresh data after editing
                LoadCurrencies();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while opening the edit form:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdateCurrency Add = new frmAddUpdateCurrency();
            Add.ShowDialog();
            LoadCurrencies();
        }
    }
}
