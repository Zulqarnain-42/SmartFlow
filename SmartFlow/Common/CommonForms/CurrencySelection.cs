using System;
using System.Windows.Forms;

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

        private async void CurrencySelection_Load(object sender, EventArgs e)
        {
            await CommonFunction.PopulateCurrencyComboBoxAsync(cmbcurrency);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();

                if(conversionratetxtbox.Visible == true && conversionratetxtbox.Text.Length == 0)
                {
                    errorProvider.SetError(conversionratetxtbox,"Please Enter Conversion Rate.");
                    conversionratetxtbox.Focus();
                    return;
                }

                // Assuming the ComboBox (cmbcurrency) is populated with a list of currency objects
                if (cmbcurrency.SelectedItem != null)
                {
                    // Retrieve the selected currency (assuming it's a custom object)
                    CurrencyData selectedCurrency = cmbcurrency.SelectedItem as CurrencyData;

                    if (selectedCurrency != null)
                    {
                        if (decimal.TryParse(conversionratetxtbox.Text, out decimal conversionRate))
                        {
                            selectedCurrency.ConversionRate = conversionRate;
                        }
                        // Trigger the event to send the data back to the parent form
                        DataSent?.Invoke(selectedCurrency);

                        // Optionally, close the child form
                        this.Close();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void cmbcurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcurrency.SelectedItem != null)
            {
                // Assuming SelectedItem is an object with a property "Name"
                var selectedCurrency = (CurrencyData)cmbcurrency.SelectedItem;

                if (selectedCurrency.Name.Trim().Equals("Dirham", StringComparison.OrdinalIgnoreCase))
                {
                    conversionratetxtbox.Visible = false;
                    conversionratetxtbox.Text = "";  // Optionally clear the text
                    conversionratelbl.Visible = false;

                }
                else
                {
                    conversionratetxtbox.Visible = true;
                    conversionratelbl.Visible = true;
                }
            }
        }
    }
}
