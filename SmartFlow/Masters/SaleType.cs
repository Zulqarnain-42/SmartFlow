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
        public SaleType(int saletypeid)
        {
            InitializeComponent();
            this.saletypeidlbl.Text = saletypeid.ToString();
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
                
                if(savebtn.Text == "UPDATE")
                {
                    string updatesaletype = string.Empty;
                    if(checkBoxactive.Checked && checkBoxTax.Checked)
                    {
                        updatesaletype = "UPDATE SaleTypeTable SET Name = '" + saletypetxtbox.Text + "'," +
                            "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                            "UpdatedDay = '" + DateTime.Now.DayOfWeek + "',IsActive = '" + true + "',IsTaxable = '" + true + "' WHERE SaleTypeID = '" + saletypeidlbl.Text + "'";
                    }
                    else if(checkBoxactive.Checked && !checkBoxTax.Checked)
                    {
                        updatesaletype = "UPDATE SaleTypeTable SET Name = '" + saletypetxtbox.Text + "'," +
                           "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                           "UpdatedDay = '" + DateTime.Now.DayOfWeek + "',IsActive = '" + true + "',IsTaxable = '" + false + "' WHERE SaleTypeID = '" + saletypeidlbl.Text + "'";
                    }
                    else if(!checkBoxactive.Checked && checkBoxTax.Checked)
                    {
                        updatesaletype = "UPDATE SaleTypeTable SET Name = '" + saletypetxtbox.Text + "'," +
                           "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                           "UpdatedDay = '" + DateTime.Now.DayOfWeek + "',IsActive = '" + false + "',IsTaxable = '" + true + "' WHERE SaleTypeID = '" + saletypeidlbl.Text + "'";
                    }
                    else
                    {
                        updatesaletype = "UPDATE SaleTypeTable SET Name = '" + saletypetxtbox.Text + "'," +
                           "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                           "UpdatedDay = '" + DateTime.Now.DayOfWeek + "',IsActive = '" + false + "',IsTaxable = '" + false + "' WHERE SaleTypeID = '" + saletypeidlbl.Text + "'";
                    }

                    
                }
                else
                {
                    string query2 = string.Empty;
                    if (checkBoxactive.Checked && checkBoxTax.Checked)
                    {
                        query2 = "INSERT INTO SaleTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + saletypetxtbox.Text + "','" + Guid.NewGuid() + "'," +
                            "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + true + "','" + true + "')";
                    }
                    else if (checkBoxactive.Checked && !checkBoxTax.Checked)
                    {
                        query2 = "INSERT INTO SaleTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + saletypetxtbox.Text + "','" + Guid.NewGuid() + "'," +
                            "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + true + "','" + false + "')";
                    }
                    else if (!checkBoxactive.Checked && checkBoxTax.Checked)
                    {
                        query2 = "INSERT INTO SaleTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + saletypetxtbox.Text + "','" + Guid.NewGuid() + "'," +
                            "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + false + "','" + true + "')";
                    }
                    else
                    {
                        query2 = "INSERT INTO SaleTypeTable (Name,Code,CreatedAt,CreatedDay,IsActive,IsTaxable) VALUES ('" + saletypetxtbox.Text + "','" + Guid.NewGuid() + "'," +
                            "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + false + "','" + false + "')";
                    }

                    
                }
                
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

        private void SaleType_Load(object sender, EventArgs e)
        {
            string labeldata = saletypeidlbl.Text;
            bool isInteger = int.TryParse(labeldata, out int result);
            if (isInteger)
            {
                FindRecord(result);
            }
        }

        private void FindRecord(int saletypeid)
        {
            try
            {
                string query = "SELECT SaleTypeID,Name,Code,UpdatedAt,UpdatedDay,IsActive,IsTaxable FROM SaleTypeTable WHERE SaleTypeID = '" + saletypeid + "'";
                DataTable dtsaletype = DatabaseAccess.Retrive(query);

                if (dtsaletype != null && dtsaletype.Rows.Count > 0) 
                {
                    saletypeidlbl.Text = dtsaletype.Rows[0]["SaleTypeID"].ToString();
                    saletypetxtbox.Text = dtsaletype.Rows[0]["Name"].ToString();
                    saletypecodelbl.Text = dtsaletype.Rows[0]["Code"].ToString();
                    checkBoxactive.Checked = Convert.ToBoolean(dtsaletype.Rows[0]["IsActive"].ToString());
                    checkBoxTax.Checked = Convert.ToBoolean(dtsaletype.Rows[0]["IsTaxable"].ToString());
                }

                savebtn.Text = "UPDATE";
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
