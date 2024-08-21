using SmartFlow.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class PurchaseType : Form
    {
        public PurchaseType()
        {
            InitializeComponent();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (purchasetypetxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(purchasetypetxtbox, "Please Enter Sale Type.");
                    purchasetypetxtbox.Focus();
                    return;
                }

                string purchasetype = CommonFunction.CleanText(purchasetypetxtbox.Text);

                string query = string.Format("SELECT PurchaseTpeID,Name,Code,CreatedAt,CreatedDay,UpdatedAt,UpdatedDay,UserId,CompanyId,AddedBy,IsActive " +
                    "FROM PurchaseTypeTable WHERE Name LIKE '" + purchasetype + "'");
                DataTable datasaleType = DatabaseAccess.Retrive(query);

                if (datasaleType.Rows.Count == 0)
                {
                    string query2 = string.Empty;

                    if (checkBoxactive.Checked && checkBoxTax.Checked)
                    {
                        query2 = "INSERT INTO PurchaseTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + purchasetype + "','" + Guid.NewGuid() + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + true + "','" + true + "')";
                    }
                    else if (checkBoxactive.Checked && !checkBoxTax.Checked)
                    {
                        query2 = "INSERT INTO PurchaseTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + purchasetype + "','" + Guid.NewGuid() + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + true + "','" + false + "')";
                    }
                    else if (!checkBoxactive.Checked && checkBoxTax.Checked)
                    {
                        query2 = "INSERT INTO PurchaseTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + purchasetype + "','" + Guid.NewGuid() + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + false + "','" + true + "')";
                    }
                    else
                    {
                        query2 = "INSERT INTO PurchaseTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + purchasetype + "','" + Guid.NewGuid() + "'," +
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
            }
            catch (Exception ex) { throw ex; }
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (purchasetypetxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private void PurchaseType_KeyDown(object sender, KeyEventArgs e)
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
