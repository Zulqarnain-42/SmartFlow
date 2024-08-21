using SmartFlow.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class SaleType : Form
    {
        public SaleType()
        {
            InitializeComponent();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(saletypetxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(saletypetxtbox,"Please Enter Sale Type.");
                    saletypetxtbox.Focus();
                    return;
                }

                string saletype = CommonFunction.CleanText(saletypetxtbox.Text);

                string query = string.Format("SELECT SaleTypeID,Name,Code,CreatedAt,CreatedDay,UpdatedAt,UpdatedDay,UserId,CompanyId,AddedBy,IsActive " +
                    "FROM SaleTypeTable WHERE Name LIKE '" + saletype + "'");
                DataTable datasaleType = DatabaseAccess.Retrive(query);

                if(datasaleType.Rows.Count == 0)
                {
                    string query2 = string.Empty;

                    if (checkBoxactive.Checked && checkBoxTax.Checked)
                    {
                        query2 = "INSERT INTO SaleTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + saletype + "','" + Guid.NewGuid() + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + true + "','" + true + "')";
                    }
                    else if(checkBoxactive.Checked && !checkBoxTax.Checked)
                    {
                        query2 = "INSERT INTO SaleTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + saletype + "','" + Guid.NewGuid() + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + true + "','" + false + "')";
                    }
                    else if(!checkBoxactive.Checked && checkBoxTax.Checked)
                    {
                        query2 = "INSERT INTO SaleTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + saletype + "','" + Guid.NewGuid() + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + false + "','" + true + "')";
                    }
                    else
                    {
                        query2 = "INSERT INTO SaleTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + saletype + "','" + Guid.NewGuid() + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + false + "','" + false + "')";
                    }
                    bool result = DatabaseAccess.Insert(query2);
                    if (result) 
                    {
                        MessageBox.Show("Inserted Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Something is wrong.");
                    }
                }
                else
                {
                    MessageBox.Show("Sale Type Already Exist.");
                }
            }catch(Exception ex) { throw ex; }
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (saletypetxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private void SaleType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (AreAnyTextBoxesFilled())
                {
                    DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                          "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                        e.Handled = true;
                    }
                }
                else
                {
                    this.Close();
                    e.Handled = true;
                }
            }
        }
    }
}
