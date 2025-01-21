using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Transactions
{
    public partial class MaterialIssueToParty : Form
    {
        private decimal intializer = 0;
        private int invoiceCounter = 1;
        public MaterialIssueToParty()
        {
            InitializeComponent();
        }
        private void MaterialIssueToParty_KeyDown(object sender, KeyEventArgs e)
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
            if(e.KeyCode == Keys.Enter)
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(CustomerSelectionForm));
                if(openForm == null)
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
        
        private async void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
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
        private async void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ProductSelectionForm));
                if(openForm == null)
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
                    string productmfr = e.ProductMfr;
                    string productname = e.ProductName;
                    float productprice = e.ProductPrice;
                    string productupc = e.ProductUPC;
                    string productbarcode = e.ProductBarcode;

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
        private void pricetxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectproducttxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) &&
                    !string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text) &&
                    !string.IsNullOrEmpty(qtytxtbox.Text) && !string.IsNullOrWhiteSpace(qtytxtbox.Text) &&
                    !string.IsNullOrEmpty(pricetxtbox.Text) && !string.IsNullOrWhiteSpace(pricetxtbox.Text))
                {
                    int itemqty = Convert.ToInt32(qtytxtbox.Text);
                    float itemPrice = float.Parse(pricetxtbox.Text);
                    float totalamount = itemqty * itemPrice;
                    
                    /*VATForm vATForm = new VATForm(totalamount)
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };
                    CommonFunction.DisposeOnClose(vATForm);
                    vATForm.ShowDialog();*/

                    string mfr = mfrtxtbox.Text;
                    string warehouseid = warehouseidlbl.Text;
                    string productid = productidlbl.Text;
                    string productname = selectproducttxtbox.Text;
                    string qty = qtytxtbox.Text;
                    decimal price = decimal.Parse(pricetxtbox.Text);
                    /*int unitid = Convert.ToInt32(GlobalVariables.unitidglobal.ToString());
                    string unitname = GlobalVariables.unitnameglobal.ToString();
                    decimal vatAmount = GlobalVariables.productitemwisevatamount;

                    if (vatAmount > 0)
                    {
                        totalvattxtbox.Visible = true;
                        totalvatlbl.Visible = true;
                    }

                    decimal discount = GlobalVariables.productdiscountamountitemwise;
                    if (discount > 0)
                    {
                        totaldiscounttxtbox.Visible = true;
                        totaldiscountlbl.Visible = true;
                    }

                    decimal finalitemwise = GlobalVariables.productfinalamountwithvatanddiscountitemwise;*/
                    int quantity = Convert.ToInt32(qty);
                    bool productExists = false;
                    foreach(DataGridViewRow row in dgvsaleproducts.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (row.Cells["ProductID"].Value != null && row.Cells["ProductID"].Value.ToString() == productidlbl.Text.ToString())
                            {
                                int currentQuantity = Convert.ToInt32(row.Cells["qtycolumn"].Value);
                                row.Cells["qtycolumn"].Value = currentQuantity + Convert.ToInt32(qtytxtbox.Text);
                                productExists = true;
                                break;
                            }
                        }
                    }

                    /*if (!productExists)
                    {
                        dgvsaleproducts.Rows.Add(mfr, warehouseid, productid, productname, qty, unitid, unitname, price.ToString("N2"),
                            vatAmount.ToString("N2"), discount.ToString("N2"), finalitemwise.ToString("N2"));
                    }*/

                    mfrtxtbox.Text = string.Empty;
                    selectproducttxtbox.Text = string.Empty;
                    productidlbl.Text = string.Empty;
                    qtytxtbox.Text = string.Empty;
                    pricetxtbox.Text = string.Empty;
                    selectproducttxtbox.Focus();
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private async void MaterialIssueToParty_Load(object sender, EventArgs e)
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
        private void dgvsaleproducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                int productid = Convert.ToInt32(dgvsaleproducts.CurrentRow.Cells[0].Value);
                if (productid > 0) 
                {
                    foreach(DataGridViewRow row in dgvsaleproducts.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            dgvsaleproducts.Rows.Remove(row);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select One Row.");
                }
            }
        }
        private void dgvsaleproducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvsaleproducts!= null)
                {
                    if (dgvsaleproducts.Rows.Count > 0)
                    {
                        if(dgvsaleproducts.SelectedRows.Count == 1)
                        {
                            mfrtxtbox.Text = dgvsaleproducts.CurrentRow.Cells[0].Value.ToString();
                            selectproducttxtbox.Text = dgvsaleproducts.CurrentRow.Cells[0].Value.ToString();
                            qtytxtbox.Text = dgvsaleproducts.CurrentRow.Cells[0].Value.ToString();
                            pricetxtbox.Text = dgvsaleproducts.CurrentRow.Cells[0].Value.ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select One Row.");
                    }
                }
                else
                {
                    MessageBox.Show("No Record Available.");
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                string invoicespecialnotes = invoicespecialnotelbl.Text;
                float nettotal = float.Parse(nettotaltxtbox.Text);
                float totalvat = float.Parse(totalvattxtbox.Text);
                float totaldiscount = 0;

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
                    MaterialIssueToParty materialIssueToParty = new MaterialIssueToParty();
                    await CommonFunction.DisposeOnCloseAsync(materialIssueToParty);
                    materialIssueToParty.Show();
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
