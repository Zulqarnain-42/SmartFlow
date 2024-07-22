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
    public partial class ProductConditionForm : Form
    {
        public ProductConditionForm()
        {
            InitializeComponent();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (conditiontxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(conditiontxtbox,"Please Enter Condition");
                    conditiontxtbox.Focus();
                    return;
                }

                GlobalVariables.productconditionglobal = conditiontxtbox.Text;
                this.Close();
            }catch(Exception ex) { throw ex; }
        }
    }
}
