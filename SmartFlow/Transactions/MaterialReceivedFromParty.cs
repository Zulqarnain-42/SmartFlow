using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Transactions
{
    public partial class MaterialReceivedFromParty : Form
    {
        private decimal intializer = 0;
        private int invoiceCounter = 1;
        public MaterialReceivedFromParty()
        {
            InitializeComponent();
        }
        private void MaterialReceivedFromParty_KeyDown(object sender, KeyEventArgs e)
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
        private bool AreAnyTextBoxesFilled()
        {
            if (selectcustomertxtbox.Text.Trim().Length > 0) { return true; }
            if (salemantxtbox.Text.Trim().Length > 0) { return true; }
            if (selectproducttxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvsaleproducts.Rows.Count > 0) { return true; }
            return false; // No TextBox is filled
        }
        private async void selectcustomertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(CustomerSelectionForm));
            if (openForm == null) 
            {
                CustomerSelectionForm customerSelectionForm = new CustomerSelectionForm
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };

                customerSelectionForm.CustomerDataSelected += UpdateCustomerInfo;

                await CommonFunction.DisposeOnCloseAsync(customerSelectionForm);
                customerSelectionForm.Show();
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private async void UpdateCustomerInfo(object sender, CustomerData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int customerid = e.CustomerId;
                    string customerName = e.CustomerName;
                    string customercode = e.CustomerCode;
                    string customermobile = e.CustomerMobile;
                    string customercompany = e.CustomerCompanyName;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        /*supplieridlbl.Text = supplierId.ToString();
                        selectsuppliertxtbox.Text = supplierName;
                        codetxtbox.Text = supplierCode;
                        companytxtbox.Text = companyName;*/
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private async void selectcustomertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(CustomerSelectionForm));
                if (openForm == null) 
                {
                    CustomerSelectionForm customerSelection = new CustomerSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    customerSelection.CustomerDataSelected += UpdateCustomerInfo;

                    await CommonFunction.DisposeOnCloseAsync(customerSelection);
                    customerSelection.Show();

                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        
        private async void MaterialReceivedFromParty_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            shippingchargestxtbox.Text = intializer.ToString("N2");
            invoicenotxtbox.Text = await GenerateNextInvoiceNumber();
        }
        private async Task<string> GenerateNextInvoiceNumber()
        {
            try
            {
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber;

                if (lastInvoiceNumber == null)
                {

                    // Generate the invoice number using the current date and a sequential number
                    string sequentialPart = invoiceCounter.ToString("D5"); // Assuming a 5-digit sequential number

                    // Increment the invoice counter for the next invoice
                    invoiceCounter++;

                    // Concatenate the date part and sequential part to form the invoice number
                    newInvoiceNumber = $"{sequentialPart}";

                    return newInvoiceNumber;
                    // If no previous invoice number, start with the first one
                }
                else
                {
                    // Extract the sequential part from the last invoice number
                    string sequentialPart = lastInvoiceNumber.Substring(lastInvoiceNumber.LastIndexOf('-') + 1);
                    int lastSequentialNumber = int.Parse(sequentialPart);
                    // Increment the sequential number
                    int nextSequentialNumber = lastSequentialNumber + 1;

                    // Generate the new invoice number
                    newInvoiceNumber = $"{nextSequentialNumber:D5}";
                }

                return newInvoiceNumber;
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private async Task<string> GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'DE-%' ORDER BY InvoiceNo DESC";
                DataTable invoiceData = await DatabaseAccess.RetriveAsync(query);
                if (invoiceData.Rows.Count > 0)
                {
                    lastInvoiceNumber = invoiceData.Rows[0]["InvoiceNo"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lastInvoiceNumber;
        }
        private async Task<string> CheckInvoiceBeforeInsert()
        {
            try
            {
                string lastInvoiceNumber = await GetLastInvoiceNumber();
                string newInvoiceNumber = invoicenotxtbox.Text;

                if (String.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    return await GenerateNextInvoiceNumber();
                }
                else
                {
                    return invoicenotxtbox.Text;
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private async void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
            if (openForm == null)
            {
                ProductSelectionForm productSelection = new ProductSelectionForm
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };

                productSelection.ProductDataSelected += UpdateProductInfo;

                await CommonFunction.DisposeOnCloseAsync(productSelection);
                productSelection.Show();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private async void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                if(openForm == null)
                {
                    ProductSelectionForm productSelectionForm = new ProductSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    productSelectionForm.ProductDataSelected += UpdateProductInfo;

                    await CommonFunction.DisposeOnCloseAsync(productSelectionForm);
                    productSelectionForm.Show();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private async void UpdateWarehouseInfo(object sender, WarehouseData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int warehouseid = e.WarehouseId;
                    string warehousename = e.WarehouseName;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        /*supplieridlbl.Text = supplierId.ToString();
                        selectsuppliertxtbox.Text = supplierName;
                        codetxtbox.Text = supplierCode;
                        companytxtbox.Text = companyName;*/
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UpdateProductInfo(object sender, ProductData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int productid = e.ProductId;
                    string productName = e.ProductName;
                    string productmfr = e.ProductMfr;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        /*supplieridlbl.Text = supplierId.ToString();
                        selectsuppliertxtbox.Text = supplierName;
                        codetxtbox.Text = supplierCode;
                        companytxtbox.Text = companyName;*/
                    }));
                });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and show them to the user
                MessageBox.Show($"An error occurred while updating supplier information: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void savebtn_Click(object sender, EventArgs e)
        {
            bool detailadded = false;
            try
            {
                string invoiceNo = await CheckInvoiceBeforeInsert();
                DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                int customerid = Convert.ToInt32(customeridlbl.Text);
                string customercode = accountcodetxtbox.Text;
                string customername = selectcustomertxtbox.Text;
                string customerrefrence = reftxtbox.Text;
                string mobile = mobiletxtbox.Text;
                string salespersonname = salemantxtbox.Text;
                float nettotal = float.Parse(nettotaltxtbox.Text);
                float totalvat = float.Parse(totalvattxtbox.Text);
                float totaldiscount = 0;

                /*if (!string.IsNullOrEmpty(totaldiscounttxtbox.Text) && !string.IsNullOrWhiteSpace(totaldiscounttxtbox.Text))
                {
                    totaldiscount = float.Parse(totaldiscounttxtbox.Text);
                }
                else
                {
                    totaldiscount = float.Parse(discounttxtbox.Text);
                }*/

                float shippingcharges = float.Parse(shippingchargestxtbox.Text.ToString());

                string invoicecode = Guid.NewGuid().ToString();

                string tableName = "InvoiceTable";
                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo },
                    { "invoicedate", invoiceDate },
                    { "ClientID", customerid },
                    { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                    { "CreatedDay", DateTime.Now.DayOfWeek },
                    { "InvoiceCode", invoicecode },
                    { "NetTotal", nettotal },
                    { "ClientName", customername },
                    { "TotalVat", totalvat },
                    { "TotalDiscount", totaldiscount },
                    { "FreightShippingCharges", shippingcharges }
                };

                bool result = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);

                if (result)
                {
                    foreach (DataGridViewRow row in dgvsaleproducts.Rows)
                    {
                        if (row.IsNewRow) { continue; }

                        int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                        int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                        float unitprice = float.Parse(row.Cells["pricecolumn"].Value.ToString());
                        string productname = row.Cells["productnamecolumn"].Value.ToString();
                        string mfr = row.Cells["codecolumn"].Value.ToString();
                        float discount = float.Parse(row.Cells["discountcolumn"].Value.ToString());
                        float vat = float.Parse(row.Cells["vatcolumn"].Value.ToString());
                        string itemdescription = row.Cells["itemdescriptioncolumn"].Value.ToString();
                        int warehouseid = Convert.ToInt32(row.Cells["warehouseidcolumn"].Value.ToString());
                        float total = float.Parse(row.Cells["totalcolumn"].Value.ToString());
                        int unitid = Convert.ToInt32(row.Cells["unitidcolumn"].Value.ToString());

                        string subtable = "InvoiceDetailsTable";
                        var subColumnData = new Dictionary<string, object>
                        {
                            { "InvoiceNo", invoiceNo },
                            { "Invoicecode", invoicecode },
                            { "Productid", productid },
                            { "Quantity", -quantity },
                            { "UnitSalePrice", unitprice },
                            { "ItemSerialNoid", null },
                            { "ProductName", productname },
                            { "MFR", mfr },
                            { "ItemWiseDiscount", discount },
                            { "ItemWiseVAT", vat },
                            { "ItemDescription", itemdescription },
                            { "Warehouseid", warehouseid },
                            { "ItemTotal", total },
                            { "Unitid", unitid },
                            { "AddInventory", false }
                        };

                        detailadded = await DatabaseAccess.ExecuteQueryAsync(subtable, "INSERT", subColumnData);
                    }
                }

                if (detailadded)
                {
                    MaterialReceivedFromParty materialReceivedFromParty = new MaterialReceivedFromParty();
                    await CommonFunction.DisposeOnCloseAsync(materialReceivedFromParty);
                    materialReceivedFromParty.Show();
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
