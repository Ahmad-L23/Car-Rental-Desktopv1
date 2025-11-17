using System;
using System.Data;
using System.Windows.Forms;
using CarRentalBusiness;
using CarRentalSystem.Car; 

namespace CarRentalSystem.Vehicle
{
    public partial class frmListCar : Form
    {
        private DataTable _dt;

        public frmListCar()
        {
            InitializeComponent();
        }

        private void LoadCars()
        {
            try
            {
                _dt = ClsCar.GetAllCarsWithColorName();

                dgvCars.DataSource = _dt;

                // Hide image column
                if (dgvCars.Columns.Contains("CarImage"))
                    dgvCars.Columns["CarImage"].Visible = false;

                string[] idColumns = { "CarID", "CategoryId", "GroupId", "BranchId", "FuelTypeID" };
                foreach (var col in idColumns)
                {
                    if (dgvCars.Columns.Contains(col))
                        dgvCars.Columns[col].Visible = false;
                }

                if (!dgvCars.Columns.Contains("RowNumber"))
                {
                    DataGridViewTextBoxColumn rowNumberCol = new DataGridViewTextBoxColumn();
                    rowNumberCol.Name = "RowNumber";
                    rowNumberCol.HeaderText = "#";
                    rowNumberCol.ReadOnly = true;
                    rowNumberCol.Width = 40;
                    dgvCars.Columns.Insert(0, rowNumberCol);
                }
                foreach (DataGridViewRow row in dgvCars.Rows)
                {
                    row.Cells["RowNumber"].Value = (row.Index + 1).ToString();
                }

                if (dgvCars.Columns.Contains("CarNameEn"))
                    dgvCars.Columns["CarNameEn"].HeaderText = "Car Name (EN)";

                if (dgvCars.Columns.Contains("CarNameAr"))
                    dgvCars.Columns["CarNameAr"].HeaderText = "Car Name (AR)";

                if (dgvCars.Columns.Contains("Year"))
                    dgvCars.Columns["Year"].HeaderText = "Year";

                if (dgvCars.Columns.Contains("ColorName"))
                    dgvCars.Columns["ColorName"].HeaderText = "Color";

                if (dgvCars.Columns.Contains("InitialCounter"))
                    dgvCars.Columns["InitialCounter"].HeaderText = "Initial Counter";

                if (dgvCars.Columns.Contains("CurrentCounter"))
                    dgvCars.Columns["CurrentCounter"].HeaderText = "Current Counter";

                if (dgvCars.Columns.Contains("NumberOfSeats"))
                    dgvCars.Columns["NumberOfSeats"].HeaderText = "Seats";

                if (dgvCars.Columns.Contains("CarNumber"))
                    dgvCars.Columns["CarNumber"].HeaderText = "Car Number";

                if (dgvCars.Columns.Contains("EngineSize"))
                    dgvCars.Columns["EngineSize"].HeaderText = "Engine Size";

                if (dgvCars.Columns.Contains("LicenseDate"))
                    dgvCars.Columns["LicenseDate"].HeaderText = "License Date";

                if (dgvCars.Columns.Contains("ExpiryLicenseDate"))
                    dgvCars.Columns["ExpiryLicenseDate"].HeaderText = "License Expiry";

                if (dgvCars.Columns.Contains("IsAvailable"))
                {
                    dgvCars.Columns["IsAvailable"].HeaderText = "Available";
                    dgvCars.Columns["IsAvailable"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvCars.Columns.Contains("NumberOfRiders"))
                    dgvCars.Columns["NumberOfRiders"].HeaderText = "Riders";

                if (dgvCars.Columns.Contains("NumberOfLoads"))
                    dgvCars.Columns["NumberOfLoads"].HeaderText = "Loads";

                if (dgvCars.Columns.Contains("NumberOfRegistration"))
                    dgvCars.Columns["NumberOfRegistration"].HeaderText = "Registration Number";

                if (dgvCars.Columns.Contains("EngineNumber"))
                    dgvCars.Columns["EngineNumber"].HeaderText = "Engine Number";

                if (dgvCars.Columns.Contains("ChassisNumber"))
                    dgvCars.Columns["ChassisNumber"].HeaderText = "Chassis Number";

                if (dgvCars.Columns.Contains("NumberOfDoors"))
                    dgvCars.Columns["NumberOfDoors"].HeaderText = "Doors";

                if (dgvCars.Columns.Contains("GasolineType"))
                    dgvCars.Columns["GasolineType"].HeaderText = "Gasoline Type";

                if (dgvCars.Columns.Contains("CarPrice"))
                    dgvCars.Columns["CarPrice"].HeaderText = "Price";

                if (dgvCars.Columns.Contains("LicenseType"))
                    dgvCars.Columns["LicenseType"].HeaderText = "License Type";

                if (dgvCars.Columns.Contains("UsedFor"))
                    dgvCars.Columns["UsedFor"].HeaderText = "Used For";

                if (dgvCars.Columns.Contains("DamagesNumber"))
                    dgvCars.Columns["DamagesNumber"].HeaderText = "Damages";

                if (dgvCars.Columns.Contains("Description"))
                    dgvCars.Columns["Description"].HeaderText = "Description";

                

                // Clear selection to avoid auto-select first row
                if (dgvCars.Rows.Count > 0)
                    dgvCars.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load cars: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private int? GetSelectedCarId()
        {
            if (dgvCars.CurrentRow != null)
            {
                object val = dgvCars.CurrentRow.Cells["CarID"].Value;
                if (val != null && int.TryParse(val.ToString(), out int id))
                    return id;
            }
            return null;
        }

        private void frmListCar_Load_1(object sender, EventArgs e)
        {
            LoadCars();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int? carId = GetSelectedCarId();
            if (carId == null)
            {
                MessageBox.Show("Please select a car to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var frm = new frmAddUpdateVehicle(carId.Value))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadCars();
            }
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int? carId = GetSelectedCarId();
            if (carId == null)
            {
                MessageBox.Show("Please select a car to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this car?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                bool deleted = ClsCar.DeleteCar(carId.Value);
                if (deleted)
                    LoadCars();
                else
                    MessageBox.Show("Failed to delete the car.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdateVehicle frm = new frmAddUpdateVehicle();
            frm.ShowDialog();
            LoadCars();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox1.Text.Trim().Replace("'", "''"); // Escape quotes for safety

            if (string.IsNullOrEmpty(filterText))
            {
                // Clear filter, show all
                dgvCars.DataSource = _dt;
            }
            else
            {
                DataView dv = new DataView(_dt);
                // Filter by PlateNumber containing the text (case-insensitive)
                dv.RowFilter = $"Convert(PlateNumber, 'System.String') LIKE '%{filterText}%'";

                dgvCars.DataSource = dv;
            }

            // Re-add the row numbers since the DataSource changed
            AddRowNumbers();

        }

        private void AddRowNumbers()
        {
            if (!dgvCars.Columns.Contains("RowNumber"))
                return;

            for (int i = 0; i < dgvCars.Rows.Count; i++)
            {
                dgvCars.Rows[i].Cells["RowNumber"].Value = (i + 1).ToString();
            }
        }
    }
}
