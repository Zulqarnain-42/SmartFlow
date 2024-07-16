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

namespace SmartFlow.Sales
{
    public partial class CurrencySelection : Form
    {
        public CurrencySelection()
        {
            InitializeComponent();
        }

        private void CurrencySelection_Load(object sender, EventArgs e)
        {
            CommonFunction.FillCurrencyData(currencyComboBox);
        }

        private void okbtn_Click(object sender, EventArgs e)
        {
            try
            {
                int currencyid = Convert.ToInt32(currencyComboBox.SelectedValue);

                string query = string.Format("SELECT CurrencyId,Symbol,Name FROM CurrencyTable WHERE CurrencyId = '" + currencyid + "'");
                DataTable dtcurr = DatabaseAccess.Retrive(query);

                if (dtcurr != null) 
                {
                    if (dtcurr.Rows.Count > 0)
                    {
                        DataRow currencyrow = dtcurr.Rows[0];

                        GlobalVariables.currencyidglobal = Convert.ToInt32(currencyrow["CurrencyId"].ToString());
                        GlobalVariables.currencynameglobal = currencyrow["Name"].ToString();
                        GlobalVariables.currencysymbolglobal = currencyrow["Symbol"].ToString();
                        GlobalVariables.currencyconversionrateglobal = float.Parse(currencyconversiontxtbox.Text.ToString());
                    }
                }

                this.Close();
            }catch (Exception ex) { throw ex; }
        }
    }
}
