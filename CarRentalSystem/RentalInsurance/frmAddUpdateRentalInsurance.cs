using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem.RentalInsurance
{
    public partial class frmAddUpdateRentalInsurance : Form
    {
        clsRentalInsurance _rentalInsuracne;
        int? _RentalInsuranceId = null;
        public frmAddUpdateRentalInsurance()
        {
            InitializeComponent();
            loadPaymentMethods();
        }

        public frmAddUpdateRentalInsurance(int rentalInsuranceID)
        {
            //load Function and make the name of the form to be update
            _RentalInsuranceId = rentalInsuranceID;
            
            LoadRentalData((int)_RentalInsuranceId);
        }
        private void frmAddUpdateRentalInsurance_Load(object sender, EventArgs e)
        {
            loadPaymentMethods();
        }

        void loadPaymentMethods()
        {
            var dt = ClsPaymentMethod.GetAllPaymentMethods();
            cbpaymentmethod.DataSource = dt;
            cbpaymentmethod.DisplayMember = "MethodName";
            cbpaymentmethod.ValueMember = "MethodName";
            cbpaymentmethod.SelectedIndex = -1;
        }
        void LoadRentalData(int rentalInsuId)
        {
            _rentalInsuracne = clsRentalInsurance.FindRentalInsuranceById(rentalInsuId);

            txtName.Text = _rentalInsuracne.Name;
            cbpaymentmethod.SelectedValue = _rentalInsuracne.PaymentMethodId;
            txtPrice.Text = _rentalInsuracne.Price.ToString();
            txtStatus.Text = _rentalInsuracne.status.ToString();
            cbActive.Checked = _rentalInsuracne.isActive;
            cbIncludeTax.Checked = _rentalInsuracne.includeTax;
            txtNotes.Text = _rentalInsuracne.Notes;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_RentalInsuranceId.HasValue) 
                _rentalInsuracne = new clsRentalInsurance();

            _rentalInsuracne.Name = txtName.Text;
            _rentalInsuracne.PaymentMethodId = (int)cbpaymentmethod.SelectedValue;
            _rentalInsuracne.Price = Convert.ToDouble(txtPrice.Text);
            _rentalInsuracne.status =txtStatus.Text;
            _rentalInsuracne.isActive = cbActive.Checked;
            _rentalInsuracne.includeTax = cbIncludeTax.Checked;
            _rentalInsuracne.Notes = txtNotes.Text;



            if (_rentalInsuracne.Save())
            
                MessageBox.Show("Saved Successfully");
            
            else
                MessageBox.Show("Something Went Wrong While Saving");




        }

        
    }
}
