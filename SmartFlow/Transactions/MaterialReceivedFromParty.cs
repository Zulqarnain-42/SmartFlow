using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Sales;
using System;
using System.Data;
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
        private void saletypetxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(PurchaseTypeSelection));
            if (openForm == null) 
            {
                PurchaseTypeSelection purchaseTypeSelection = new PurchaseTypeSelection
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };
                CommonFunction.DisposeOnClose(purchaseTypeSelection);
                purchaseTypeSelection.Show();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void selectcustomertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(CustomerSelectionForm));
            if (openForm == null) 
            {
                CustomerSelectionForm customerSelectionForm = new CustomerSelectionForm
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };

                customerSelectionForm.FormClosed += delegate
                {
                    UpdateCustomerInfo();
                };
                CommonFunction.DisposeOnClose(customerSelectionForm);
                customerSelectionForm.Show();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void UpdateCustomerInfo()
        {
            if(GlobalVariables.customeridglobal > 0 && !string.IsNullOrEmpty(GlobalVariables.customercodeglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.customercodeglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.customermobileglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.customermobileglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.customernameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.customernameglobal))
            {
                accountcodetxtbox.Text = GlobalVariables.customercodeglobal;
                selectcustomertxtbox.Text = GlobalVariables.customernameglobal;
                reftxtbox.Text = GlobalVariables.customerrefrencegloba;
                mobiletxtbox.Text = GlobalVariables.customermobileglobal;
                customeridlbl.Text = GlobalVariables.customeridglobal.ToString();
            }
        }
        private void selectcustomertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(CustomerSelectionForm));
                if (openForm == null) 
                {
                    CustomerSelectionForm customerSelection = new CustomerSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    customerSelection.FormClosed += delegate
                    {
                        UpdateCustomerInfo();
                    };
                    CommonFunction.DisposeOnClose(customerSelection);
                    customerSelection.Show();

                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void selectcustomertxtbox_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(accountcodetxtbox.Text) && !string.IsNullOrWhiteSpace(accountcodetxtbox.Text) && 
                !string.IsNullOrEmpty(selectcustomertxtbox.Text) && !string.IsNullOrWhiteSpace(selectcustomertxtbox.Text) && 
                !string.IsNullOrEmpty(mobiletxtbox.Text) && !string.IsNullOrWhiteSpace(mobiletxtbox.Text) && 
                !string.IsNullOrEmpty(customeridlbl.Text) && !string.IsNullOrWhiteSpace(customeridlbl.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(CurrencySelection));
                if (openForm == null) 
                {
                    CurrencySelection currencySelection = new CurrencySelection
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    currencySelection.FormClosed += delegate
                    {
                        UpdateCurrencyInfo();
                    };
                    CommonFunction.DisposeOnClose(currencySelection);
                    currencySelection.Show();
                    
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void UpdateCurrencyInfo()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.currencynameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.currencynameglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.currencysymbolglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.currencysymbolglobal) && 
                GlobalVariables.currencyconversionrateglobal > 0 && GlobalVariables.currencyidglobal > 0)
            {
                currencyidlbl.Text = GlobalVariables.currencyidglobal.ToString();
                currencynamelbl.Text = GlobalVariables.currencynameglobal.ToString();
                currencysymbollbl.Text = GlobalVariables.currencysymbolglobal.ToString();
                currencyconversionratelbl.Text = GlobalVariables.currencyconversionrateglobal.ToString();
            }
        }
        private void salemantxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(SalesPersonSelection));
            if (openForm == null) 
            {
                SalesPersonSelection salesPerson = new SalesPersonSelection
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };
                salesPerson.FormClosed += delegate
                {
                    UpdateSalesPersonInfo();
                };
                CommonFunction.DisposeOnClose(salesPerson);
                salesPerson.Show();

            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void UpdateSalesPersonInfo()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.salespersonnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.salespersonnameglobal) && 
                GlobalVariables.salespersonidglobal > 0)
            {
                salemantxtbox.Text = GlobalVariables.salespersonnameglobal.ToString();
                salespersonidlbl.Text = GlobalVariables.salespersonidglobal.ToString();
            }
        }
        private void MaterialReceivedFromParty_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            shippingchargestxtbox.Text = intializer.ToString("N2");
            invoicenotxtbox.Text = GenerateNextInvoiceNumber();
        }
        private string GenerateNextInvoiceNumber()
        {
            try
            {
                string lastInvoiceNumber = GetLastInvoiceNumber();
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
        private string GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'DE-%' ORDER BY InvoiceNo DESC";
                DataTable invoiceData = DatabaseAccess.Retrive(query);
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
        private string CheckInvoiceBeforeInsert()
        {
            try
            {
                string lastInvoiceNumber = GetLastInvoiceNumber();
                string newInvoiceNumber = invoicenotxtbox.Text;

                if (String.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    return GenerateNextInvoiceNumber();
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
        private void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
            if (openForm == null)
            {
                ProductSelectionForm productSelection = new ProductSelectionForm
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };

                productSelection.FormClosed += delegate
                {
                    UpdateProductInfo();
                };
                CommonFunction.DisposeOnClose(productSelection);
                productSelection.Show();
            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
                if(openForm == null)
                {
                    ProductSelectionForm productSelectionForm = new ProductSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    productSelectionForm.FormClosed += delegate
                    {
                        UpdateProductInfo();
                    };
                    CommonFunction.DisposeOnClose(productSelectionForm);
                    productSelectionForm.Show();
                    
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void UpdateProductInfo()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.productmfrglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productmfrglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.productnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productnameglobal) && 
                GlobalVariables.productidglobal > 0)
            {
                productidlbl.Text = GlobalVariables.productidglobal.ToString();
                selectproducttxtbox.Text = GlobalVariables.productnameglobal.ToString();
                mfrtxtbox.Text = GlobalVariables.productmfrglobal.ToString();  
            }
        }
        private void selectproducttxtbox_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(mfrtxtbox.Text) && 
                !string.IsNullOrEmpty(productidlbl.Text) && !string.IsNullOrWhiteSpace(productidlbl.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(ProductQtyWarehouse));
                if (openForm == null)
                {
                    string productmfr = mfrtxtbox.Text;
                    int productid = Convert.ToInt32(productidlbl.Text);
                    ProductQtyWarehouse productQtyWarehouse = new ProductQtyWarehouse(productmfr, productid)
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    productQtyWarehouse.FormClosed += delegate
                    {
                        UpdateWarehouseInfo();
                    };
                    CommonFunction.DisposeOnClose(productQtyWarehouse);
                    productQtyWarehouse.Show();
                    
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void UpdateWarehouseInfo()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.warehousenameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.warehousenameglobal) && 
                GlobalVariables.warehouseidglobal > 0)
            {
                warehouseidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
                itemwisedescriptionlbl.Text = GlobalVariables.productitemwisedescriptiongloabl.ToString();
            }
        }
    }
}
