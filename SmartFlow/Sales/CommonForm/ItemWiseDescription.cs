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
    public partial class ItemWiseDescription : Form
    {
        private string _productmfr = null;
        private int _productid = 0;
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public ItemWiseDescription(int productid,string productmfr)
        {
            InitializeComponent();
            _productmfr = productmfr;
            _productid = productid;
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(itemwisedescriptiontxtbox.Text.Trim().Length > 0)
                {
                    GlobalVariables.productitemwisedescriptiongloabl = itemwisedescriptiontxtbox.Text;
                }
                this.Close();
            }
            catch(Exception ex) { throw ex; }
        }
        private void ItemWiseDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }
        private void ItemWiseDescription_Load(object sender, EventArgs e)
        {
            try
            {
                string query = string.Format("SELECT Description FROM ProductTable WHERE MFR = '" + _productmfr + "' AND ProductID = '" + _productid + "'");
                DataTable dtdescription = DatabaseAccess.Retrive(query);
                if(dtdescription!=null && dtdescription.Rows.Count > 0)
                {
                    itemwisedescriptiontxtbox.Text = dtdescription.Rows[0]["Description"].ToString();
                }
            }catch(Exception ex) { throw ex; }
        }
        private void itemwisedescriptiontxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan timeDiff = currentTime - lastEnterPressTime;

                if (timeDiff.TotalMilliseconds <= doubleEnterThreshold)
                {
                    // Double Enter detected
                    savebtn.Focus();
                    lastEnterPressTime = DateTime.MinValue; // Reset to prevent multiple triggers
                }
                else
                {
                    // First Enter press detected
                    lastEnterPressTime = currentTime;
                }

                e.Handled = true; // Prevent the beep sound on Enter key press
                e.SuppressKeyPress = true; // Prevent the beep sound on Enter key press
            }
        }
    }
}
