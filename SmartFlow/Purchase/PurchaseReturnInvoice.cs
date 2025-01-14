using DocumentFormat.OpenXml.Office2013.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using SmartFlow.Purchase.ReportViewer;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static SmartFlow.DatabaseAccess;

namespace SmartFlow
{
    public partial class PurchaseReturnInvoice : Form
    {
        private int invoiceCounter = 1;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        public PurchaseReturnInvoice()
        {
            InitializeComponent();
        }
        public PurchaseReturnInvoice(DataTable dtinvoice,DataTable dtinvoicedetails)
        {
            InitializeComponent();
            this._dtinvoice = dtinvoice;
            this._dtinvoicedetails = dtinvoicedetails;
        }
        private void PurchaseReturnInvoice_Load(object sender, EventArgs e)
        {
            if(_dtinvoice!=null && _dtinvoice.Rows.Count>0 && _dtinvoicedetails!=null && _dtinvoicedetails.Rows.Count > 0)
            {
                DataRow row = _dtinvoice.Rows[0];
                invoicenotxtbox.Text = row["InvoiceNo"].ToString();
                suppliercodetxtbox.Text = row["CodeAccount"].ToString();
                invoicedatetxtbox.Text = Convert.ToDateTime(row["invoicedate"]).ToString("dd/MM/yyyy");
                selectsuppliertxtbox.Text = row["ClientName"].ToString();
                supplieridlbl.Text = row["ClientID"].ToString();
                invoicecodelbl.Text = row["InvoiceCode"].ToString();
                invoicereftxtbox.Text = row["InvoiceRefrence"].ToString();
                companytxtbox.Text = row["CompanyName"].ToString();
                shippingchargestxtbox.Text = row["FreightShippingCharges"].ToString();

                foreach (DataRow invoiceDetailsRow in _dtinvoicedetails.Rows)
                {
                    int detailsRowIndex = dgvpurchaseproducts.Rows.Add();
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["mfrcolumn"].Value = invoiceDetailsRow["MFR"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["productid"].Value = invoiceDetailsRow["Productid"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["productnamecolumn"].Value = invoiceDetailsRow["ProductName"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["qtycolumn"].Value = invoiceDetailsRow["Quantity"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["unitidcolumn"].Value = invoiceDetailsRow["Unitid"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["unitnamecolumn"].Value = invoiceDetailsRow["UnitName"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["pricecolumn"].Value = invoiceDetailsRow["UnitSalePrice"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["discountcolumn"].Value = invoiceDetailsRow["ItemWiseDiscount"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["vatcolumn"].Value = invoiceDetailsRow["ItemWiseVAT"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["totalcolumn"].Value = invoiceDetailsRow["ItemTotal"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["warehouseidcolumn"].Value = invoiceDetailsRow["Warehouseid"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["itemdescriptioncolumn"].Value = invoiceDetailsRow["ItemDescription"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["lengthinmetercolumn"].Value = invoiceDetailsRow["LengthInMeter"];
                    dgvpurchaseproducts.Rows[detailsRowIndex].Cells["pricepermetercolumn"].Value = invoiceDetailsRow["PricePerMeter"];
                }

                savebtn.Text = "UPDATE";
            }
            else
            {
                invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                invoicenotxtbox.Text = GenerateNextInvoiceNumber();
            }
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
                    string invoicepart = "PR";
                    string datePart = DateTime.Today.ToString("yyMMdd");
                    string sequentialPart = invoiceCounter.ToString("D5"); // Assuming a 5-digit sequential number

                    // Increment the invoice counter for the next invoice
                    invoiceCounter++;

                    // Concatenate the date part and sequential part to form the invoice number
                    newInvoiceNumber = $"{invoicepart}-{datePart}-{sequentialPart}";

                    return newInvoiceNumber;
                    // If no previous invoice number, start with the first one
                }
                else
                {
                    // Extract the sequential part from the last invoice number
                    string sequentialPart = lastInvoiceNumber.Substring(lastInvoiceNumber.LastIndexOf('-') + 1);
                    int lastSequentialNumber = int.Parse(sequentialPart);
                    string invoicepart = "PR";
                    string datePart = DateTime.Today.ToString("yyMMdd");
                    // Increment the sequential number
                    int nextSequentialNumber = lastSequentialNumber + 1;

                    // Generate the new invoice number
                    newInvoiceNumber = $"{invoicepart}-{datePart}-{nextSequentialNumber:D5}";
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
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'PR-%' ORDER BY InvoiceNo DESC";
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
        private void PurchaseReturnInvoice_KeyDown(object sender, KeyEventArgs e)
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

            if (e.Control && e.KeyCode == Keys.C)
            {
                CurrencySelection currencySelection = new CurrencySelection();
                currencySelection.DataSent += currencySelection_DataSent;
                currencySelection.ShowDialog();
            }
        }

        private void currencySelection_DataSent(CurrencyData receivedCurrency)
        {
            // Use the received data (e.g., display it in a label)
            currencylbl.Text = receivedCurrency.Name + (" : ") + receivedCurrency.Symbol;
            currencyidlbl.Text = receivedCurrency.CurrencyId.ToString();
            currencynamelbl.Text = receivedCurrency.Name.ToString();
            currencysymbollbl.Text = receivedCurrency.Symbol.ToString();
            currencystringlbl.Text = receivedCurrency.CurrencyString.ToString();
            currencyconversionratelbl.Text = receivedCurrency.ConversionRate.ToString();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvpurchasequotationproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                int productid = Convert.ToInt32(dgvpurchaseproducts.CurrentRow.Cells[0].Value);
                if (productid > 0)
                {
                    foreach (DataGridViewRow row in dgvpurchaseproducts.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            dgvpurchaseproducts.Rows.Remove(row);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select One Row");
                }
            }
        }
        private void selectsuppliertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectsuppliertxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(SupplierSelectionForm));
                if (openForm == null)
                {
                    SupplierSelectionForm supplierSelection = new SupplierSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };
                    supplierSelection.FormClosed += delegate
                    {
                        UpdateSupplierTextBox();
                    };
                    CommonFunction.DisposeOnClose(supplierSelection);
                    supplierSelection.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void UpdateSupplierTextBox()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.suppliernameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.suppliernameglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.suppliercodeglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.suppliercodeglobal) && 
                GlobalVariables.supplieridglobal > 0)
            {
                supplieridlbl.Text = GlobalVariables.supplieridglobal.ToString();
                selectsuppliertxtbox.Text = GlobalVariables.suppliernameglobal;
                suppliercodetxtbox.Text = GlobalVariables.suppliercodeglobal;
                companytxtbox.Text = GlobalVariables.suppliercompanyName;
            }

        }
        private bool AreAnyTextBoxesFilled()
        {
            if (selectsuppliertxtbox.Text.Trim().Length > 0) { return true; }
            if (selectproducttxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvpurchaseproducts.Rows.Count > 0) { return true; }
            return false; // No TextBox is filled
        }
        private void selectsuppliertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(selectsuppliertxtbox.Text))
                {
                    Form openForm = CommonFunction.IsFormOpen(typeof(SupplierSelectionForm));
                    if (openForm == null)
                    {
                        SupplierSelectionForm supplierSelection = new SupplierSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        supplierSelection.FormClosed += delegate
                        {
                            UpdateSupplierTextBox();
                        };
                        CommonFunction.DisposeOnClose(supplierSelection);
                        supplierSelection.ShowDialog();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
        }
        private void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectproducttxtbox.Text))
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
                        UpdateProductTextBox();
                    };
                    CommonFunction.DisposeOnClose(productSelection);
                    productSelection.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void UpdateProductTextBox()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.productnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productnameglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.productmfrglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productmfrglobal) && 
                GlobalVariables.productidglobal > 0)
            {
                selectproducttxtbox.Text = GlobalVariables.productnameglobal;
                mfrtxtbox.Text = GlobalVariables.productmfrglobal;
                productidlbl.Text = GlobalVariables.productidglobal.ToString();
            }

        }
        private void selectproducttxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                if (string.IsNullOrEmpty(selectproducttxtbox.Text))
                {
                    Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
                    if (openForm == null)
                    {
                        ProductSelectionForm productSelectionForm = new ProductSelectionForm
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        productSelectionForm.FormClosed += delegate
                        {
                            UpdateProductTextBox();
                        };
                        CommonFunction.DisposeOnClose(productSelectionForm);
                        productSelectionForm.ShowDialog();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
        }
        private void dgvpurchaseproducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CommonFunction.CalculateTotalColumn(9,dgvpurchaseproducts,nettotaltxtbox);
            CommonFunction.CalculateTotalVatColumn(8, dgvpurchaseproducts, totalvattxtbox);
            CommonFunction.CalculateTotalDiscountColumn(7,dgvpurchaseproducts,totaldiscounttxtbox);
        }
        private void dgvpurchaseproducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CommonFunction.CalculateTotalColumn(9, dgvpurchaseproducts, nettotaltxtbox);
            CommonFunction.CalculateTotalVatColumn(8, dgvpurchaseproducts, totalvattxtbox);
            CommonFunction.CalculateTotalDiscountColumn(7, dgvpurchaseproducts, totaldiscounttxtbox);
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string invoiceno = string.Empty;
                errorProvider.Clear();
                bool isInserted = false;
                if (invoicenotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(invoicenotxtbox, "Please Enter Invoice no");
                    invoicenotxtbox.Focus();
                    return;
                }
                
                if (suppliercodetxtbox.Text.Trim().Length == 0 && selectsuppliertxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectsuppliertxtbox, "Please Select a Supplier");
                    selectsuppliertxtbox.Focus();
                    return;
                }

                if(savebtn.Text == "UPDATE")
                {
                    string invoicecode = Guid.NewGuid().ToString();
                    invoiceno = CheckInvoiceBeforeInsert();
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    int supplierid = Convert.ToInt32(supplieridlbl.Text.ToString());
                    string suppliercode = suppliercodetxtbox.Text;
                    string supplierName = selectsuppliertxtbox.Text;
                    string invoiceRef = invoicereftxtbox.Text;
                    float netTotal = float.Parse(nettotaltxtbox.Text.ToString());
                    float netVat = float.Parse(totalvattxtbox.Text.ToString());
                    float netDiscount = float.Parse(totaldiscounttxtbox.Text.ToString());
                    float shippingCharges = string.IsNullOrWhiteSpace(shippingchargestxtbox.Text) ? 0 : float.Parse(shippingchargestxtbox.Text);
                    int currencyid = Convert.ToInt32(currencyidlbl.Text);
                    string currencyname = currencynamelbl.Text.ToString();
                    string currencysymbol = currencysymbollbl.Text.ToString();
                    float conversionRate = float.Parse(currencyconversionratelbl.Text);
                    string tableName = "InvoiceTable";
                    string whereClause = "InvoiceNo = '" + invoiceno + "'";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceno },
                        { "invoicedate", invoiceDate },
                        { "ClientID", supplierid },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek },
                        { "InvoiceCode", invoicecode },
                        { "NetTotal", netTotal },
                        { "ClientName", supplierName },
                        { "TotalVat", netVat },
                        { "TotalDiscount", netDiscount },
                        { "FreightShippingCharges", shippingCharges },
                        { "InvoiceRefrence", invoiceRef },
                        { "Currencyid", currencyid },
                        { "CurrencyName", currencyname },
                        { "CurrencySymbol", currencysymbol },
                        { "ConversionRate", conversionRate }
                    };

                    bool insertinvoice = DatabaseAccess.ExecuteQuery(tableName, "INSERT", columnData);

                    if (insertinvoice)
                    {
                        bool isAdded = UpdateInvoiceDetailsData(invoiceno, invoicecode);
                        if (isAdded)
                        {
                            ReturnReportView returnReport = new ReturnReportView(invoiceno);
                            returnReport.MdiParent = Application.OpenForms["Dashboard"];
                            CommonFunction.DisposeOnClose(returnReport);
                            returnReport.Show();
                            this.Close();
                        }
                    }

                }
                else
                {
                    string invoicecode = Guid.NewGuid().ToString();
                    invoiceno = CheckInvoiceBeforeInsert();
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    int supplierid = Convert.ToInt32(supplieridlbl.Text.ToString());
                    string suppliercode = suppliercodetxtbox.Text;
                    string supplierName = selectsuppliertxtbox.Text;
                    string invoiceRef = invoicereftxtbox.Text;
                    float netTotal = float.Parse(nettotaltxtbox.Text.ToString());
                    float netVat = float.Parse(totalvattxtbox.Text.ToString());
                    float netDiscount = float.Parse(totaldiscounttxtbox.Text.ToString());
                    float shippingCharges = string.IsNullOrWhiteSpace(shippingchargestxtbox.Text) ? 0 : float.Parse(shippingchargestxtbox.Text);
                    int currencyid = Convert.ToInt32(currencyidlbl.Text);
                    string currencyname = currencynamelbl.Text.ToString();
                    string currencysymbol = currencysymbollbl.Text.ToString();
                    float conversionrate = float.Parse(currencyconversionratelbl.Text);
                    string tableName = "InvoiceTable";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceno },
                        { "invoicedate", invoiceDate },
                        { "ClientID", supplierid },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek },
                        { "InvoiceCode", invoicecode },
                        { "NetTotal", netTotal },
                        { "ClientName", supplierName },
                        { "TotalVat", netVat },
                        { "TotalDiscount", netDiscount },
                        { "FreightShippingCharges", shippingCharges },
                        { "InvoiceRefrence", invoiceRef },
                        { "Currencyid", currencyid },
                        { "CurrencyName", currencyname },
                        { "CurrencySymbol", currencysymbol },
                        { "ConversionRate", conversionrate }
                    };

                    bool insertinvoice = DatabaseAccess.ExecuteQuery(tableName, "INSERT", columnData);

                    if (insertinvoice)
                    {
                        foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                        {
                            if (row.IsNewRow) { continue; }

                            string mfr = row.Cells["mfrcolumn"].Value.ToString();
                            int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                            string productname = row.Cells["productnamecolumn"].Value.ToString();
                            int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                            int unitid = Convert.ToInt32(row.Cells["unitidcolumn"].Value.ToString());
                            float saleprice = float.Parse(row.Cells["pricecolumn"].Value.ToString());
                            float discount = float.Parse(row.Cells["discountcolumn"].Value.ToString());
                            float vat = float.Parse(row.Cells["vatcolumn"].Value.ToString());
                            float total = float.Parse(row.Cells["totalcolumn"].Value.ToString());
                            int warehouseid = Convert.ToInt32(row.Cells["warehouseidcolumn"].Value.ToString());
                            string itemdescription = row.Cells["itemdescriptioncolumn"].Value.ToString();
                            decimal lengthinmeter = decimal.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());
                            decimal pricepermeter = decimal.Parse(row.Cells["pricepermetercolumn"].Value.ToString());

                            string subtable = "InvoiceDetailsTable";
                            var subColumnData = new Dictionary<string, object>
                            {
                                { "InvoiceNo", invoiceno },
                                { "Invoicecode", invoicecode },
                                { "Productid", productid },
                                { "Quantity", quantity },
                                { "ProductName", productname },
                                { "MFR", mfr },
                                { "ItemWiseDiscount", discount },
                                { "ItemWiseVAT", vat },
                                { "Warehouseid", warehouseid },
                                { "ItemTotal", total },
                                { "Unitid", unitid },
                                { "AddInventory", true },
                                { "PricePerMeter", pricepermeter },
                                { "LengthInMeter", lengthinmeter },
                                { "ItemDescription", itemdescription },
                                { "MinusInventory", true },
                                { "UnitSalePrice", saleprice }
                            };
                            bool insertprod = DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData);
                        }
                        isInserted = true;
                    }


                    if (isInserted)
                    {
                        ReturnReportView returnReport = new ReturnReportView(invoiceno);
                        returnReport.MdiParent = Application.OpenForms["Dashboard"];
                        CommonFunction.DisposeOnClose(returnReport);
                        returnReport.Show();
                        this.Close();
                    }
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private bool UpdateInvoiceDetailsData(string invoiceNo, string invoiceCode)
        {
            bool isInserted = false;
            InsertBackUpData(invoiceNo, invoiceCode);
            DeleteInvoiceDetail(invoiceNo, "InvoiceDetailsTable");

            foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
            {
                if (row.IsNewRow) { continue; }

                string mfr = row.Cells["mfrcolumn"].Value.ToString();
                int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                string productname = row.Cells["productnamecolumn"].Value.ToString();
                int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                int unitid = Convert.ToInt32(row.Cells["unitidcolumn"].Value.ToString());
                float saleprice = float.Parse(row.Cells["pricecolumn"].Value.ToString());
                float discount = float.Parse(row.Cells["discountcolumn"].Value.ToString());
                float vat = float.Parse(row.Cells["vatcolumn"].Value.ToString());
                float total = float.Parse(row.Cells["totalcolumn"].Value.ToString());
                int warehouseid = Convert.ToInt32(row.Cells["warehouseidcolumn"].Value.ToString());
                string itemdescription = row.Cells["itemdescriptioncolumn"].Value.ToString();
                decimal lengthinmeter = decimal.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());
                decimal pricepermeter = decimal.Parse(row.Cells["pricepermetercolumn"].Value.ToString());

                string subtable = "InvoiceDetailsTable";
                var subColumnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo },
                    { "Invoicecode", invoiceCode },
                    { "Productid", productid },
                    { "Quantity", quantity },
                    { "ProductName", productname },
                    { "MFR", mfr },
                    { "ItemWiseDiscount", discount },
                    { "ItemWiseVAT", vat },
                    { "Warehouseid", warehouseid },
                    { "ItemTotal", total },
                    { "Unitid", unitid },
                    { "AddInventory", true },
                    { "PricePerMeter", pricepermeter },
                    { "LengthInMeter", lengthinmeter },
                    { "ItemDescription", itemdescription },
                    { "MinusInventory", true },
                    { "UnitSalePrice", saleprice }
                };
                bool insertprod = DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData);
            }

            return true;
        }

        private void DeleteInvoiceDetail(string invoiceNo, string tablename)
        {
            try
            {
                string tableName = tablename;
                string whereClause = "InvoiceNo = @InvoiceNo";

                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo }
                };

                DatabaseAccess.ExecuteQuery(tableName, "DELETE", columnData, whereClause);

            }
            catch (Exception ex) { throw ex; }
        }

        private void InsertBackUpData(string invoiceNo, string invoicecode)
        {
            foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
            {
                if (row.IsNewRow) { continue; }

                string mfr = row.Cells["mfrcolumn"].Value.ToString();
                int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                string productname = row.Cells["productnamecolumn"].Value.ToString();
                int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                int unitid = Convert.ToInt32(row.Cells["unitidcolumn"].Value.ToString());
                float saleprice = float.Parse(row.Cells["pricecolumn"].Value.ToString());
                float discount = float.Parse(row.Cells["discountcolumn"].Value.ToString());
                float vat = float.Parse(row.Cells["vatcolumn"].Value.ToString());
                float total = float.Parse(row.Cells["totalcolumn"].Value.ToString());
                int warehouseid = Convert.ToInt32(row.Cells["warehouseidcolumn"].Value.ToString());
                string itemdescription = row.Cells["itemdescriptioncolumn"].Value.ToString();
                decimal lengthinmeter = decimal.Parse(row.Cells["lengthinmetercolumn"].Value.ToString());
                decimal pricepermeter = decimal.Parse(row.Cells["pricepermetercolumn"].Value.ToString());

                string subtable = "InvoiceDetailsTableBackUp";
                var subColumnData = new Dictionary<string, object>
                        {
                            { "InvoiceNo", invoiceNo },
                            { "Invoicecode", invoicecode },
                            { "Productid", productid },
                            { "Quantity", quantity },
                            { "ProductName", productname },
                            { "MFR", mfr },
                            { "ItemWiseDiscount", discount },
                            { "ItemWiseVAT", vat },
                            { "Warehouseid", warehouseid },
                            { "ItemTotal", total },
                            { "Unitid", unitid },
                            { "AddInventory", true },
                            { "PricePerMeter", pricepermeter },
                            { "LengthInMeter", lengthinmeter },
                            { "ItemDescription", itemdescription },
                            { "MinusInventory", true },
                            { "UnitSalePrice", saleprice }
                        };
                DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData);
            }

        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mfrtxtbox.Text) && !string.IsNullOrEmpty(selectproducttxtbox.Text) &&
                !string.IsNullOrEmpty(qtytxtbox.Text) &&
                !string.IsNullOrWhiteSpace(mfrtxtbox.Text) && !string.IsNullOrWhiteSpace(selectproducttxtbox.Text) &&
                !string.IsNullOrWhiteSpace(qtytxtbox.Text))
            {
                string mfr = mfrtxtbox.Text;
                string productid = productidlbl.Text;
                string productname = selectproducttxtbox.Text;
                string qty = qtytxtbox.Text;
                int unitid = Convert.ToInt32(unitidlbl.Text);
                string unitname = unitnamelbl.Text;
                decimal vatamount = decimal.Parse(productvatlbl.Text);
                decimal discount = decimal.Parse(productdiscountlbl.Text);
                float unitprice = float.Parse(unitsalepricelbl.Text);
                decimal finalitemwise = decimal.Parse(totalcolumnlbl.Text);
                int warehouseid = Convert.ToInt32(warehouseidlbl.Text);
                string itemwisedescription = itemdescriptionlbl.Text;
                decimal lengthinmeterproduct = decimal.Parse(lengthinmeterlbl.Text);
                decimal priceinmeter = decimal.Parse(pricepermeterlbl.Text);

                bool productExists = false;
                foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["productid"].Value != null && row.Cells["productid"].Value.ToString() == productidlbl.Text.ToString())
                        {
                            int currentQuantity = Convert.ToInt32(row.Cells["qtycolumn"].Value);
                            row.Cells["qtycolumn"].Value = currentQuantity + Convert.ToInt32(qtytxtbox.Text);
                            productExists = true;
                            break;
                        }
                    }
                }

                if (!productExists)
                {
                    dgvpurchaseproducts.Rows.Add(mfr, productid, productname, qty, unitid, unitname, unitprice
                        , discount, vatamount, finalitemwise, warehouseid, itemwisedescription, lengthinmeterproduct, priceinmeter);
                }

                mfrtxtbox.Text = string.Empty;
                selectproducttxtbox.Text = string.Empty;
                productidlbl.Text = string.Empty;
                qtytxtbox.Text = string.Empty;
                GlobalVariables.unitidglobal = 0;
                GlobalVariables.productpriceglobal = 0;
                GlobalVariables.productitemwisevatamount = 0;
                GlobalVariables.productdiscountamountitemwise = 0;
                GlobalVariables.productfinalamountwithvatanddiscountitemwise = 0;
                GlobalVariables.warehouseidglobal = 0;
                GlobalVariables.productitemwisedescriptiongloabl = string.Empty;
                GlobalVariables.productinmeterlength = 0;
                GlobalVariables.productinmeterprice = 0;
                GlobalVariables.productcostprice = 0;
                GlobalVariables.productstandardprice = 0;
                GlobalVariables.productlowestlength = 0;
                GlobalVariables.productsaleprice = 0;
                selectproducttxtbox.Focus();
            }
        }

        private void qtytxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void qtytxtbox_Leave(object sender, EventArgs e)
        {
            int itemqty = Convert.ToInt32(qtytxtbox.Text);
            if (itemqty > 0)
            {
                string getwarehousedata = "SELECT WarehouseID,Name FROM WarehouseTable";
                DataTable warehousedata = DatabaseAccess.Retrive(getwarehousedata);

                if (warehousedata != null)
                {
                    if (warehousedata.Rows.Count > 0)
                    {
                        WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata)
                        {
                            WindowState = FormWindowState.Normal,
                            StartPosition = FormStartPosition.CenterParent,
                        };

                        warehouseSelection.FormClosed += WarehouseSelection_FormClosed;

                        CommonFunction.DisposeOnClose(warehouseSelection);
                        warehouseSelection.ShowDialog();
                    }
                }
            }
        }

        private void WarehouseSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Dispose of the current form (warehouseQty)
                CommonFunction.DisposeOnClose((WarehouseSelection)sender);

                // Create and show VATForm after WarehouseQty is closed
                VATForm vATForm = new VATForm(Convert.ToInt32(qtytxtbox.Text), false)
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };
                vATForm.FormClosed += delegate
                {
                    UpdateProductData();
                };
                // Apply DisposeOnClose to VATForm
                CommonFunction.DisposeOnClose(vATForm);
                vATForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProductData()
        {
            warehouseidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
            itemdescriptionlbl.Text = GlobalVariables.productitemwisedescriptiongloabl.ToString();
            unitsalepricelbl.Text = GlobalVariables.productpriceglobal.ToString();
            pricepermeterlbl.Text = GlobalVariables.productinmeterprice.ToString();
            lengthinmeterlbl.Text = GlobalVariables.productinmeterlength.ToString();
            totalcolumnlbl.Text = GlobalVariables.productfinalamountwithvatanddiscountitemwise.ToString();
            unitnamelbl.Text = GlobalVariables.unitnameglobal.ToString();
            unitidlbl.Text = GlobalVariables.unitidglobal.ToString();
            productdiscountlbl.Text = GlobalVariables.productdiscountamountitemwise.ToString();
            productvatlbl.Text = GlobalVariables.productitemwisevatamount.ToString();
        }

        private void dgvpurchaseproducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CommonFunction.CalculateTotalColumn(9, dgvpurchaseproducts, nettotaltxtbox);
            CommonFunction.CalculateTotalVatColumn(8, dgvpurchaseproducts, totalvattxtbox);
            CommonFunction.CalculateTotalDiscountColumn(7, dgvpurchaseproducts, totaldiscounttxtbox);
        }
    }
}
