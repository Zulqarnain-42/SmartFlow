using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Sales.CommonForm
{
    public partial class AvailabilityForm : Form
    {
        public AvailabilityForm()
        {
            InitializeComponent();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(availtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(availtxtbox,"Please Enter Availability Time");
                    availtxtbox.Focus();
                    return;
                }

                GlobalVariables.availabilitystatus = availtxtbox.Text;
                this.Close();
            }catch(Exception ex) { throw ex; }
        }
    }
}
