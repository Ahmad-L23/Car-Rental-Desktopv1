using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem.Company
{
    public partial class CompanyCardUserControl1 : UserControl
    {
        public CompanyCardUserControl1()
        {
            InitializeComponent();
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        public int? CompanyId { get; set; }

        public string CompanyName
        {
            get => lblCompanyName.Text;
            set => lblCompanyName.Text = value;
        }

        public Image CompanyLogo
        {
            get => PictureBoxLogo.Image;
            set => PictureBoxLogo.Image = value;
        }

        // Declare events to notify parent form
        public event EventHandler<int> EditClicked;
        public event EventHandler<int> DeleteClicked;

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (CompanyId.HasValue)
                EditClicked?.Invoke(this, CompanyId.Value);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (CompanyId.HasValue)
                DeleteClicked?.Invoke(this, CompanyId.Value);
        }
    }
}
