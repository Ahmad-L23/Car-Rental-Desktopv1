using CarRentalBusiness;
using System;
using System.Windows.Forms;

namespace CarRentalSystem.mediator
{
    public partial class frmMediatorDetalis : Form
    {
        private int _mediatorId;

        // Constructor that receives mediator ID
        public frmMediatorDetalis(int mediatorId)
        {
            InitializeComponent();
            _mediatorId = mediatorId;
        }

        private void LoadMediatorDetails()
        {
            try
            {
                // Retrieve mediator details from business layer
                if (ClsMediator.GetMediatorInfoById(_mediatorId, out ClsMediator mediator))
                {
                    lblMediatorIdValue.Text = mediator.id?.ToString() ?? "???";
                    lblMediatorNameEnValue.Text = mediator.EnglishName ?? "???";
                    lblMediatorNameArValue.Text = mediator.ArabicName ?? "???";
                    lblEmailAddressValue.Text = string.IsNullOrEmpty(mediator.Email) ? "???" : mediator.Email;
                    lblPercentageValue.Text = mediator.Precentage.ToString("0.##") + " %";
                    lblPhoneNumberValue.Text = string.IsNullOrEmpty(mediator.PhoneNumber) ? "???" : mediator.PhoneNumber;

                    // 🟢 Update Active/Inactive label color and text
                    if (mediator.isActive)
                    {
                        lblActiveStatus.Text = "Active";
                        lblActiveStatus.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblActiveStatus.Text = "Inactive";
                        lblActiveStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    MessageBox.Show("Mediator not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading mediator details: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMediatorDetalis_Load_1(object sender, EventArgs e)
        {
            LoadMediatorDetails();
        }
    }
}
