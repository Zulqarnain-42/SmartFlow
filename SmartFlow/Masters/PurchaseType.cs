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
        public PurchaseType(int purchaseid)
        {
            InitializeComponent();
            this.purchasetypeidlbl.Text = purchaseid.ToString();
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
                
                if(savebtn.Text == "UPDATE")
                {
                    string updatepurchasetype = string.Empty;
                    
                    if (checkBoxactive.Checked && checkBoxTax.Checked)
                    {
                        updatepurchasetype = string.Format("UPDATE PurchaseTypeTable SET Name = '" + purchasetypetxtbox.Text + "'," +
                            "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                            "UpdatedDay = '" + DateTime.Now.DayOfWeek + "',IsActive = '" + true + "'," +
                            "IsTaxable = '" + true + "' WHERE PurchaseTpeID = '" + purchasetypeidlbl.Text + "'");
                    }
                    else if(checkBoxactive.Checked && !checkBoxTax.Checked)
                    {
                        updatepurchasetype = string.Format("UPDATE PurchaseTypeTable SET Name = '" + purchasetypetxtbox.Text + "'," +
                            "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                            "UpdatedDay = '" + DateTime.Now.DayOfWeek + "',IsActive = '" + true + "'," +
                            "IsTaxable = '" + false + "' WHERE PurchaseTpeID = '" + purchasetypeidlbl.Text + "'");
                    }
                    else if(!checkBoxactive.Checked && checkBoxTax.Checked)
                    {
                        updatepurchasetype = string.Format("UPDATE PurchaseTypeTable SET Name = '" + purchasetypetxtbox.Text + "'," +
                            "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                            "UpdatedDay = '" + DateTime.Now.DayOfWeek + "',IsActive = '" + false + "'," +
                            "IsTaxable = '" + true + "' WHERE PurchaseTpeID = '" + purchasetypeidlbl.Text + "'");
                    }
                    else
                    {
                        updatepurchasetype = string.Format("UPDATE PurchaseTypeTable SET Name = '" + purchasetypetxtbox.Text + "'," +
                            "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                            "UpdatedDay = '" + DateTime.Now.DayOfWeek + "',IsActive = '" + false + "'," +
                            "IsTaxable = '" + false + "' WHERE PurchaseTpeID = '" + purchasetypeidlbl.Text + "'");
                    }
                    
                    
                }
                else
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
                    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

        private void PurchaseType_Load(object sender, EventArgs e)
        {
            string labeldata = purchasetypeidlbl.Text;
            bool isInteger = int.TryParse(labeldata, out int result);
            if (isInteger)
            {
                FindRecord(result);
            }
        }

        private void FindRecord(int purchasetypeid)
        {
            try
            {
                string query = string.Format("SELECT PurchaseTpeID,Name,Code,IsActive,IsTaxable FROM PurchaseTypeTable WHERE PurchaseTpeID = '" + purchasetypeid + "'");
                DataTable dtpurchasetype = DatabaseAccess.Retrive(query);

                if (dtpurchasetype != null && dtpurchasetype.Rows.Count > 0)
                {
                    purchasetypeidlbl.Text = dtpurchasetype.Rows[0]["PurchaseTpeID"].ToString();
                    purchasetypetxtbox.Text = dtpurchasetype.Rows[0]["Name"].ToString();
                    purchasetypecodelbl.Text = dtpurchasetype.Rows[0]["Code"].ToString();
                    checkBoxactive.Checked = Convert.ToBoolean(dtpurchasetype.Rows[0]["IsActive"].ToString());
                    checkBoxTax.Checked = Convert.ToBoolean(dtpurchasetype.Rows[0]["IsTaxable"].ToString());
                }

                savebtn.Text = "UPDATE";
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
