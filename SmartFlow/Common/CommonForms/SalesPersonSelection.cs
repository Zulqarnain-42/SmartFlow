using System;
using System.Windows.Forms;

namespace SmartFlow.Common.CommonForms
{
    public partial class SalesPersonSelection : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public SalesPersonSelection()
        {
            InitializeComponent();
        }
        private void SalesPersonSelection_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }
        private void SalesPersonSelection_Load(object sender, EventArgs e)
        {
            searchtxtbox.Focus();
            dgvsalesperson.ClearSelection();
            CommonFunction.GetSalesManInfo("", dgvsalesperson);
        }
        private void searchtxtbox_TextChanged(object sender, EventArgs e)
        {
            CommonFunction.GetSalesManInfo(searchtxtbox.Text,dgvsalesperson);
        }
        private void dgvsalesperson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvsalesperson != null)
                {
                    if (dgvsalesperson.Rows.Count > 0)
                    {
                        if(dgvsalesperson.SelectedRows.Count == 1)
                        {
                            GlobalVariables.salespersonidglobal = Convert.ToInt32(dgvsalesperson.CurrentRow.Cells["EmployeeID"].Value);
                            GlobalVariables.salespersonnameglobal = dgvsalesperson.CurrentRow.Cells["Fullname"].Value.ToString();
                            this.Close();
                        }
                    }
                }
            }catch(Exception ex) { throw ex; }
        }
        private void dgvsalesperson_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataGridViewRow selectedRow = dgvsalesperson.CurrentRow;
                    if (selectedRow != null)
                    {
                        GlobalVariables.salespersonidglobal = Convert.ToInt32(dgvsalesperson.CurrentRow.Cells["EmployeeID"].Value);
                        GlobalVariables.salespersonnameglobal = dgvsalesperson.CurrentRow.Cells["Fullname"].Value.ToString();
                        this.Close();
                    }
                }
            }catch(Exception ex) { throw ex; }
        }
        private void searchtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    DateTime currentTime = DateTime.Now;
                    TimeSpan timediff = currentTime - lastEnterPressTime;
                    if(timediff.TotalMilliseconds<= doubleEnterThreshold)
                    {
                        dgvsalesperson.Focus();
                        lastEnterPressTime = DateTime.MinValue;
                    }
                    else
                    {
                        lastEnterPressTime = currentTime;
                    }

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }catch(Exception ex) { throw ex; }
        }
    }
}
