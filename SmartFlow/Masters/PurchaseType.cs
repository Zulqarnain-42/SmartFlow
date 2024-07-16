using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                string query = string.Format("SELECT PurchaseTpeID,Name,Code,CreatedAt,CreatedDay,UpdatedAt,UpdatedDay,UserId,CompanyId,AddedBy,IsActive " +
                    "FROM PurchaseTypeTable WHERE Name LIKE '" + purchasetypetxtbox.Text + "'");
                DataTable datasaleType = DatabaseAccess.Retrive(query);

                if (datasaleType.Rows.Count == 0)
                {
                    string query2 = string.Empty;

                    if (checkBoxactive.Checked && checkBoxTax.Checked)
                    {
                        query2 = "INSERT INTO PurchaseTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + purchasetypetxtbox.Text + "','" + Guid.NewGuid() + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + true + "','" + true + "')";
                    }
                    else if (checkBoxactive.Checked && !checkBoxTax.Checked)
                    {
                        query2 = "INSERT INTO PurchaseTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + purchasetypetxtbox.Text + "','" + Guid.NewGuid() + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + true + "','" + false + "')";
                    }
                    else if (!checkBoxactive.Checked && checkBoxTax.Checked)
                    {
                        query2 = "INSERT INTO PurchaseTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + purchasetypetxtbox.Text + "','" + Guid.NewGuid() + "'," +
                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + false + "','" + true + "')";
                    }
                    else
                    {
                        query2 = "INSERT INTO PurchaseTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + purchasetypetxtbox.Text + "','" + Guid.NewGuid() + "'," +
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
    }
}
