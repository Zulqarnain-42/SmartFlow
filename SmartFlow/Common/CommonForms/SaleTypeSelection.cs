using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Common.CommonForms
{
    public partial class SaleTypeSelection : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public SaleTypeSelection()
        {
            InitializeComponent();
        }

        private void SaleTypeSelection_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }

        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            CommonFunction.GetSalesTypeInfo(searchtxtbox.Text, dgvsalestypeselection);
        }

        private void SaleTypeSelection_Load(object sender, EventArgs e)
        {
            searchtxtbox.Focus();
            dgvsalestypeselection.ClearSelection();
            CommonFunction.GetSalesTypeInfo("",dgvsalestypeselection);
        }

        private void dgvsalestypeselection_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvsalestypeselection != null)
                {
                    if (dgvsalestypeselection.Rows.Count > 0)
                    {
                        if(dgvsalestypeselection.SelectedRows.Count == 1)
                        {
                            GlobalVariables.saletypeidglobal = Convert.ToInt32(dgvsalestypeselection.CurrentRow.Cells["ID"].Value);
                            GlobalVariables.saletypenameglobal = dgvsalestypeselection.CurrentRow.Cells["Name"].Value.ToString();
                            GlobalVariables.saletypeistaxable = (bool)dgvsalestypeselection.CurrentRow.Cells["Taxable"].Value;
                            this.Close();
                        }
                    }
                }
            }catch (Exception ex) {throw ex;}
        }

        private void dgvsalestypeselection_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    DataGridViewRow selectedRow = dgvsalestypeselection.CurrentRow;
                    if (selectedRow != null)
                    {
                        GlobalVariables.saletypeidglobal = Convert.ToInt32(dgvsalestypeselection.CurrentRow.Cells["ID"].Value);
                        GlobalVariables.saletypenameglobal = dgvsalestypeselection.CurrentRow.Cells["Name"].Value.ToString();
                        GlobalVariables.saletypeistaxable = (bool)dgvsalestypeselection.CurrentRow.Cells["Taxable"].Value;
                        this.Close();
                    }
                }
            }catch (Exception ex) {throw ex;}
        }

        private void searchtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan timediff = currentTime - lastEnterPressTime;
                if(timediff.TotalMilliseconds <= doubleEnterThreshold)
                {
                    dgvsalestypeselection.Focus();
                    lastEnterPressTime = DateTime.MinValue;
                }
                else
                {
                    lastEnterPressTime = currentTime;
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
