using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Transactions
{
    public partial class ModifyCreditNote : Form
    {
        public ModifyCreditNote()
        {
            InitializeComponent();
        }

        private void invoicenotxtbox_TextChanged(object sender, EventArgs e)
        {
            string prefix = "PIS-";
            if (!invoicenotxtbox.Text.StartsWith(prefix))
            {
                invoicenotxtbox.Text = prefix;
                invoicenotxtbox.SelectionStart = invoicenotxtbox.Text.Length; // Place the cursor at the end
            }
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {

        }

        private void ModifyCreditNote_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private async void invoicenotxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                string userinput = invoicenotxtbox.Text;
                if (userinput.Length > 0)
                {
                    // Using parameterized query to avoid SQL injection
                    string query = "SELECT invoicedate FROM InvoiceTable WHERE InvoiceNo = @InvoiceNo";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@InvoiceNo", userinput }
                    };

                    DataTable invoiceData = await DatabaseAccess.RetriveAsync(query, parameters);

                    if (invoiceData.Rows.Count > 0)
                    {
                        DataRow row = invoiceData.Rows[0];
                        invoicedatetxtbox.Text = Convert.ToDateTime(row["invoicedate"]).ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
