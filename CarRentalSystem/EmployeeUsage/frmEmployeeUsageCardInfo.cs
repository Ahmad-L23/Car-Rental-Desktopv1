using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem.EmployeeUsage
{
    public partial class frmEmployeeUsageCardInfo : Form
    {
        ucEmployeeusageDetalis ucEployeeUsageDetalis = new ucEmployeeusageDetalis();
        public frmEmployeeUsageCardInfo()
        {
            InitializeComponent();
        }

        private void frmEmployeeUsageCardInfo_Load(object sender, EventArgs e)
        {
            ucEployeeUsageDetalis.LoadEmployeeUsageData();
        }
    }
}
