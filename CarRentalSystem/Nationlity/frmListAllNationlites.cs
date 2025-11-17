using System;
using System.Data;
using System.Windows.Forms;
using CarRentalBusiness;

namespace CarRentalSystem.Nationlity
{
    public partial class frmListAllNationlites : Form
    {
        public frmListAllNationlites()
        {
            InitializeComponent();
        }


        private void SearchData(string searchText)
        {
            if (dataGridView1.DataSource is DataTable dt)
            {
                DataView dv = dt.DefaultView;

                // Search both Arabic and English columns
                dv.RowFilter = string.Format(
                    "[English Name] LIKE '%{0}%' OR [Arabic Name] LIKE '%{0}%'",
                    searchText.Replace("'", "''")); // escape single quotes
            }
        }
        private void LoadNationalities()
        {
            DataTable dt = ClsNationlity.GetAllNationalities();

            if (dt == null)
            {
                lblCount.Text = "No data available.";
                dataGridView1.DataSource = null;
                return;
            }

            // Order the DataTable by id ascending
            DataView dv = dt.DefaultView;
            dv.Sort = "id ASC";
            DataTable sortedDt = dv.ToTable();

            // Select and rename columns as needed for display
            DataTable displayDt = new DataTable();
            displayDt.Columns.Add("ID", typeof(int));
            displayDt.Columns.Add("Arabic Name", typeof(string));
            displayDt.Columns.Add("English Name", typeof(string));

            foreach (DataRow row in sortedDt.Rows)
            {
                displayDt.Rows.Add(
                    row.Field<int>("id"),
                    row.Field<string>("nationality_name_ar"),
                    row.Field<string>("nationality_name_en")
                );
            }

            // Bind to DataGridView
            dataGridView1.DataSource = displayDt;

            // Show count in label
            lblCount.Text = $"Total Nationalities: {displayDt.Rows.Count}";

            // Optional: Autosize columns
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void frmListAllNationlites_Load_1(object sender, EventArgs e)
        {

            LoadNationalities();
            this.BeginInvoke(new Action(() =>
            {
                txtSearchByName.Focus();
                txtSearchByName.SelectAll(); // optional, highlights any existing text
            }));
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            SearchData(txtSearchByName.Text.Trim());
        }

        private void txtSearchByName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow Backspace
            if (e.KeyChar == (char)Keys.Back)
                return;

            // Allow English letters (A-Z, a-z)
            if (char.IsLetter(e.KeyChar))
                return;

            // Allow Arabic letters (Unicode range)
            if (e.KeyChar >= 0x0600 && e.KeyChar <= 0x06FF)
                return;

            // Otherwise block the key
            e.Handled = true;
        }
    }
}
