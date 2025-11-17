using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem.DamagesMaintenance
{
    public partial class frmDamageMainCard : Form
    {
        ucDamageMaintenanceCard ucDama = new ucDamageMaintenanceCard();
        public frmDamageMainCard()
        {
            InitializeComponent();
        }

        private void frmDamageMainCard_Load(object sender, EventArgs e)
        {
            ucDama.LoadData();
        }
    }
}
