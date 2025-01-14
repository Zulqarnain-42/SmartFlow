using DocumentFormat.OpenXml.VariantTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartFlow.Common.CommonFunction;

namespace SmartFlow.Common.CommonForms
{
    public partial class CurrencySelection : Form
    {
        public delegate void SendDataEventHandler(CurrencyData currency);
        public event SendDataEventHandler DataSent;
        public CurrencySelection()
        {
            InitializeComponent();
        }

        private void CurrencySelection_Load(object sender, EventArgs e)
        {
            CommonFunction.PopulateCurrencyComboBox(cmbcurrency);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                // Assuming the ComboBox (cmbcurrency) is populated with a list of currency objects
                if (cmbcurrency.SelectedItem != null)
                {
                    // Retrieve the selected currency (assuming it's a custom object)
                    CurrencyData selectedCurrency = cmbcurrency.SelectedItem as CurrencyData;

                    if (selectedCurrency != null)
                    {
                        // Trigger the event to send the data back to the parent form
                        DataSent?.Invoke(selectedCurrency);

                        // Optionally, close the child form
                        this.Close();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
