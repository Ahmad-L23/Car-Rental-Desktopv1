using CarRentalBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem.CashReceipt
{
    public partial class frmAddUpdateCashReceipt : Form
    {
        clsCashReceipt _CashReceitp;
        int? CashReceitpID = null;
        public frmAddUpdateCashReceipt()
        {
            InitializeComponent();
            LoadPaymentMethods();
            LoadBox();
            LoadCurrencies();
        }

        public frmAddUpdateCashReceipt(int id)
        {
            CashReceitpID = id;
            InitializeComponent();
            LoadPaymentMethods();
            LoadBox();
            LoadCurrencies();

            this.Text = "Update Cash Receipt";

        }


        private void LoadCashReceipt(int id)
        {
            _CashReceitp = clsCashReceipt.findCashReceipt(id);

            if(_CashReceitp == null)
            {
                MessageBox.Show($"no cash receipt found with {id} id");
                return;
            }


            txtCashReceiptNumber.Text = _CashReceitp.CashREceiptNumber.ToString();
            dpCashereceipt.Value = _CashReceitp.CashReceiptDate;
            cbPaymentMethod.SelectedValue = _CashReceitp.paymentMethodid;
            cbBox.SelectedValue = _CashReceitp.boxid;
            cbCurrency.SelectedValue = _CashReceitp.Currencyid;
            txtExchangePrice.Text = _CashReceitp.ExchangePrice.ToString();
        }

        private void frmAddUpdateCashReceipt_Load(object sender, EventArgs e)
        {

        }

        private void LoadPaymentMethods()
        {
            DataTable dt = ClsPaymentMethod.GetAllPaymentMethods();
            cbPaymentMethod.DataSource = dt;
            cbPaymentMethod.DisplayMember = "MethodName";
            cbPaymentMethod.ValueMember = "Id";
            cbPaymentMethod.SelectedIndex = -1;
        }

        private void LoadBox()
        {
            DataTable dt = ClsBox.GetBoxesDataTable();
            cbBox.DataSource = dt;
            cbBox.DisplayMember = "Name";
            cbBox.ValueMember = "BoxID";
            cbBox.SelectedIndex = -1;
        }


        private void LoadCurrencies()
        {
            DataTable dt = ClsCurrency.GetCurrenciesDataTable();
            cbCurrency.DataSource = dt;
            cbCurrency.DisplayMember = "nameEn";
            cbCurrency.ValueMember = "Id";
            cbCurrency.SelectedIndex = -1;
        }


        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!CashReceitpID.HasValue)
            {
                _CashReceitp = new clsCashReceipt();
            }

            int CashReceitpNumber = clsCashReceipt.GetLastNumber() + 1;

            _CashReceitp.CashREceiptNumber = CashReceitpNumber;
            _CashReceitp.CashReceiptDate = dpCashereceipt.Value;
            _CashReceitp.paymentMethodid = (int)cbPaymentMethod.SelectedValue;
            _CashReceitp.boxid = (int)cbBox.SelectedValue;
            _CashReceitp.Currencyid = (int)cbCurrency.SelectedValue;
            _CashReceitp.ExchangePrice = Convert.ToDouble(txtExchangePrice.Text);


            if(_CashReceitp.Save())
            {
                MessageBox.Show($"The Cash Receipt with {_CashReceitp.CashREceiptNumber} saved successfully");
            }
            else
            {
                MessageBox.Show("Something went wrong while saving");
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
