using DocumentFormat.OpenXml.Wordprocessing;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase.ReportViewer;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static SmartFlow.DatabaseAccess;

namespace SmartFlow.Purchase
{
    public partial class PurchaseQuotationInvoice : Form
    {
        private int invoiceCounter = 1;
        private DataTable _dtinvoice;
        private DataTable _dtinvoicedetails;
        private int _dragRowIndex = -1;
        public PurchaseQuotationInvoice()
        {
            InitializeComponent();
        }

        public PurchaseQuotationInvoice(DataTable dtInvoice,DataTable dtInvoiceDetail)
        {
            InitializeComponent();
            this._dtinvoice = dtInvoice;
            this._dtinvoicedetails = dtInvoiceDetail;
        }

        private void PurchaseQuotationInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                if (_dtinvoice != null && _dtinvoice.Rows.Count > 0 && _dtinvoicedetails != null && _dtinvoicedetails.Rows.Count > 0)
                {
                    DataRow row = _dtinvoice.Rows[0];

                    // Set Invoice Data
                    invoicenotxtbox.Text = row["InvoiceNo"]?.ToString() ?? string.Empty;
                    codetxtbox.Text = row["CodeAccount"]?.ToString() ?? string.Empty;

                    // Safely handle DateTime conversion with fallback for empty or invalid data
                    if (DateTime.TryParse(row["invoicedate"]?.ToString(), out DateTime invoiceDate))
                    {
                        invoicedatetxtbox.Text = invoiceDate.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        invoicedatetxtbox.Text = string.Empty; // Fallback if DateTime is invalid
                    }

                    selectsuppliertxtbox.Text = row["ClientName"]?.ToString() ?? string.Empty;
                    supplieridlbl.Text = row["ClientID"]?.ToString() ?? string.Empty;
                    invoicecodelbl.Text = row["InvoiceCode"]?.ToString() ?? string.Empty;
                    companytxtbox.Text = row["CompanyName"]?.ToString() ?? string.Empty;

                    // Fill DataGridView with Invoice Details
                    foreach (DataRow invoiceDetailsRow in _dtinvoicedetails.Rows)
                    {
                        int detailsRowIndex = dgvpurchaseproducts.Rows.Add();
                        dgvpurchaseproducts.Rows[detailsRowIndex].Cells["mfrcolumn"].Value = invoiceDetailsRow["MFR"]?.ToString() ?? string.Empty;
                        dgvpurchaseproducts.Rows[detailsRowIndex].Cells["productid"].Value = invoiceDetailsRow["Productid"]?.ToString() ?? string.Empty;
                        dgvpurchaseproducts.Rows[detailsRowIndex].Cells["productnamecolumn"].Value = invoiceDetailsRow["ProductName"]?.ToString() ?? string.Empty;
                        dgvpurchaseproducts.Rows[detailsRowIndex].Cells["qtycolumn"].Value = invoiceDetailsRow["Quantity"] != DBNull.Value ? Convert.ToInt32(invoiceDetailsRow["Quantity"]) : 0;
                    }

                    savebtn.Text = "UPDATE";
                }
                else
                {
                    // Handle case when invoice or invoice details are null or empty
                    invoicenotxtbox.Text = GenerateNextInvoiceNumber();
                    invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the invoice data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string GenerateNextInvoiceNumber()
        {
            try
            {
                // Get the last invoice number (this could be fetched from a database or a file)
                string lastInvoiceNumber = GetLastInvoiceNumber();
                string newInvoiceNumber;
                int invoiceCounter = 1; // Default counter value, could be adjusted based on your requirement

                if (lastInvoiceNumber == null)
                {
                    // Generate the invoice number using the current date and a sequential number
                    string invoicePart = "PQ";
                    string datePart = DateTime.Today.ToString("yyMMdd");
                    string sequentialPart = invoiceCounter.ToString("D5"); // Assuming a 5-digit sequential number

                    // Increment the invoice counter for the next invoice
                    invoiceCounter++;

                    // Concatenate the date part and sequential part to form the invoice number
                    newInvoiceNumber = $"{invoicePart}-{datePart}-{sequentialPart}";

                    return newInvoiceNumber; // If no previous invoice number, start with the first one
                }
                else
                {
                    // Extract the sequential part from the last invoice number
                    string sequentialPart = lastInvoiceNumber.Substring(lastInvoiceNumber.LastIndexOf('-') + 1);
                    int lastSequentialNumber = int.Parse(sequentialPart);
                    string invoicePart = "PQ";
                    string datePart = DateTime.Today.ToString("yyMMdd");

                    // Increment the sequential number
                    int nextSequentialNumber = lastSequentialNumber + 1;

                    // Generate the new invoice number with the incremented sequence
                    newInvoiceNumber = $"{invoicePart}-{datePart}-{nextSequentialNumber:D5}";
                }

                return newInvoiceNumber;
            }
            catch (Exception ex)
            {
                // Display error message
                MessageBox.Show($"Error generating invoice number: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        private string CheckInvoiceBeforeInsert()
        {
            try
            {
                // Fetch the last invoice number from the system (database or file)
                string lastInvoiceNumber = GetLastInvoiceNumber();
                string newInvoiceNumber = invoicenotxtbox.Text;

                // Check if the invoice number is valid
                if (string.IsNullOrEmpty(lastInvoiceNumber) || string.IsNullOrEmpty(newInvoiceNumber))
                {
                    MessageBox.Show("Invoice number is not valid. Please check the invoice numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Compare the new invoice number with the last one
                if (String.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    // Generate and return the next invoice number if the new one is not greater
                    return GenerateNextInvoiceNumber();
                }
                else
                {
                    // Return the entered invoice number if it's valid and greater than the last one
                    return newInvoiceNumber;
                }
            }
            catch (Exception ex)
            {
                // Display error message and return null in case of an error
                MessageBox.Show($"Error checking invoice number: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        private string GetLastInvoiceNumber()
        {
            string lastInvoiceNumber = null;
            try
            {
                string query = "SELECT TOP 1 InvoiceNo FROM InvoiceTable WHERE InvoiceNo LIKE 'PQ-%' ORDER BY InvoiceNo DESC";
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

        private void newbtn_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseQuotationInvoice purchaseQuotationInvoice = new PurchaseQuotationInvoice();

                // Check if MdiParent is null
                if (this.MdiParent != null)
                {
                    purchaseQuotationInvoice.MdiParent = this.MdiParent;
                }
                else
                {
                    // Handle the case when MdiParent is null
                    MessageBox.Show("MdiParent is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                CommonFunction.DisposeOnClose(purchaseQuotationInvoice);
                purchaseQuotationInvoice.Show();
            }
            catch (Exception ex)
            {
                // Error handling to catch any issues during the form instantiation or other operations
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool IsInserted = false;
                string invoiceno = string.Empty;
                if (invoicenotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(invoicenotxtbox,"Please Enter Invoice no");
                    invoicenotxtbox.Focus();
                    return;
                }

                if(codetxtbox.Text.Trim().Length == 0 && selectsuppliertxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectsuppliertxtbox,"Please Select a Supplier");
                    selectsuppliertxtbox.Focus();
                    return;
                }

                if (savebtn.Text == "UPDATE")
                {
                    invoiceno = invoicenotxtbox.Text;
                    
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);
                    string invoiceCode = invoicecodelbl.Text;
                    int supplierId = Convert.ToInt32(supplieridlbl.Text);
                    string suppliercode = codetxtbox.Text;
                    string supplierName = selectsuppliertxtbox.Text;
                    string tableName = "InvoiceTable";
                    string whereClause = "InvoiceNo = '" + invoiceno + "'";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceno },
                        { "invoicedate", invoiceDate },
                        { "ClientID", supplierId },
                        { "UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "UpdatedDay", DateTime.Now.DayOfWeek },
                        { "ClientName", supplierName }
                    };

                    bool isUpdated = DatabaseAccess.ExecuteQuery(tableName, "UPDATE", columnData, whereClause);
                    if (isUpdated)
                    {
                        UpdateInvoiceDetailsData(invoiceno, invoiceCode);
                    }
                }
                else
                {
                    invoiceno = CheckInvoiceBeforeInsert();
                    DateTime invoiceDate = DateTime.Parse(invoicedatetxtbox.Text);

                    int supplierId = Convert.ToInt32(supplieridlbl.Text);
                    string suppliercode = codetxtbox.Text;
                    string supplierName = selectsuppliertxtbox.Text;
                    string invoicecode = Guid.NewGuid().ToString();
                    string tableName = "InvoiceTable";

                    var columnData = new Dictionary<string, object>
                    {
                        { "InvoiceNo", invoiceno },
                        { "invoicedate", invoiceDate },
                        { "ClientID", supplierId },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek },
                        { "InvoiceCode", invoicecode },
                        { "ClientName", supplierName }
                    };

                    bool insertquote = DatabaseAccess.ExecuteQuery(tableName, "INSERT", columnData);

                    if (insertquote)
                    {
                        foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                        {
                            if (row.IsNewRow) { continue; }

                            int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                            int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                            string productname = row.Cells["productnamecolumn"].Value.ToString();
                            string mfr = row.Cells["mfrcolumn"].Value.ToString();

                            string subtable = "InvoiceDetailsTable";
                            var subColumnData = new Dictionary<string, object>
                            {
                                { "InvoiceNo", invoiceno },
                                { "Invoicecode", invoicecode },
                                { "Productid", productid },
                                { "Quantity", quantity },
                                { "ItemSerialNoid", null },
                                { "ProductName", productname },
                                { "MFR", mfr },
                                { "AddInventory", false },
                                { "MinusInventory", false }
                            };

                            IsInserted = DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData);
                        }

                        IsInserted = true;
                    }
                }

                if (IsInserted)
                {
                    this.Close();
                    QuotationReportView quotationReportView = new QuotationReportView(invoiceno);
                    quotationReportView.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(quotationReportView);
                    quotationReportView.Show();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void UpdateInvoiceDetailsData(string invoiceNo,string invoiceCode)
        {
            /*bool detailadded = false;
            try
            {
                // Start a transaction
                using (var transaction = DatabaseAccess.BeginTransaction())
                {
                    // Insert backup data
                    InsertBackUpData(invoiceNo, invoiceCode);

                    // Delete existing invoice details
                    DeleteInvoiceDetail(invoiceNo);

                    // Insert new invoice details
                    foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
                    {
                        if (row.IsNewRow) { continue; }

                        int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                        int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                        string productname = row.Cells["productnamecolumn"].Value.ToString();
                        string mfr = row.Cells["mfrcolumn"].Value.ToString();

                        string subtable = "InvoiceDetailsTable";
                        var subColumnData = new Dictionary<string, object>
            {
                { "InvoiceNo", invoiceNo },
                { "Invoicecode", invoiceCode },
                { "Productid", productid },
                { "Quantity", quantity },
                { "ItemSerialNoid", null },
                { "ProductName", productname },
                { "MFR", mfr },
                 { "AddInventory", false },
                                { "MinusInventory", false }
            };

                        // Execute insert for each row
                        detailadded = DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData, transaction);
                        if (!detailadded)
                        {
                            // Rollback transaction if insertion fails
                            transaction.Rollback();
                            MessageBox.Show("Error inserting details into the invoice.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Commit the transaction if everything goes smoothly
                    transaction.Commit();

                    // After successful insertion, close the form and show report
                    this.Close();
                    QuotationReportView quotationReportView = new QuotationReportView(invoiceNo);
                    quotationReportView.MdiParent = Application.OpenForms["Dashboard"];
                    CommonFunction.DisposeOnClose(quotationReportView);
                    quotationReportView.Show();
                }
            }
            catch (Exception ex)
            {
                // In case of any error, show the error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
*/

        }

        private void InsertBackUpData(string invoiceNo, string invoicecode)
        {
            foreach (DataGridViewRow row in dgvpurchaseproducts.Rows)
            {
                if (row.IsNewRow) { continue; }

                int productid = Convert.ToInt32(row.Cells["productid"].Value.ToString());
                int quantity = Convert.ToInt32(row.Cells["qtycolumn"].Value.ToString());
                string productname = row.Cells["productnamecolumn"].Value.ToString();
                string mfr = row.Cells["mfrcolumn"].Value.ToString();

                string subtable = "InvoiceDetailsTable";
                var subColumnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo },
                    { "Invoicecode", invoicecode },
                    { "Productid", productid },
                    { "Quantity", quantity },
                    { "ItemSerialNoid", null },
                    { "ProductName", productname },
                    { "MFR", mfr },
                     { "AddInventory", false },
                                { "MinusInventory", false }
                };

                DatabaseAccess.ExecuteQuery(subtable, "INSERT", subColumnData);
            }
        }

        private void DeleteInvoiceDetail(string invoiceNo)
        {
            try
            {
                string tableName = "InvoiceDetailsTable";
                string whereClause = "InvoiceNo = @InvoiceNo";

                var columnData = new Dictionary<string, object>
                {
                    { "InvoiceNo", invoiceNo }
                };

                DatabaseAccess.ExecuteQuery(tableName, "DELETE", columnData, whereClause);

            }
            catch (Exception ex) { throw ex; }
        }

        private void dgvpurchasequotationproduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dgvpurchaseproducts != null)
                {
                    if (dgvpurchaseproducts.Rows.Count > 0)
                    {
                        if(dgvpurchaseproducts.SelectedRows.Count == 1)
                        {
                            mfrtxtbox.Text = dgvpurchaseproducts.CurrentRow.Cells[0].Value.ToString();
                            productidlbl.Text = dgvpurchaseproducts.CurrentRow.Cells[1].Value.ToString();
                            selectproducttxtbox.Text = dgvpurchaseproducts.CurrentRow.Cells[2].Value.ToString();
                            qtytxtbox.Text = dgvpurchaseproducts.CurrentRow.Cells[3].Value.ToString();
                            foreach (DataGridViewRow row in dgvpurchaseproducts.SelectedRows)
                            {
                                if (!row.IsNewRow)
                                {
                                    dgvpurchaseproducts.Rows.Remove(row);
                                }
                            }
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
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvpurchasequotationproduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                int productid = Convert.ToInt32(dgvpurchaseproducts.CurrentRow.Cells[1].Value);
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

        private void UpdateSupplierTextBox()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.suppliernameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.suppliernameglobal) && 
                !string.IsNullOrEmpty(GlobalVariables.suppliercodeglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.suppliercodeglobal) && 
                GlobalVariables.supplieridglobal > 0)
            {
                selectsuppliertxtbox.Text = GlobalVariables.suppliernameglobal;
                supplieridlbl.Text = GlobalVariables.supplieridglobal.ToString();
                codetxtbox.Text = GlobalVariables.suppliercodeglobal;
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
            if (e.KeyCode == Keys.Enter) 
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(SupplierSelectionForm));
                if (openForm == null)
                {
                    SupplierSelectionForm supplierSelection = new SupplierSelectionForm
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterParent,
                    };

                    supplierSelection.FormClosing += delegate
                    {
                        UpdateSupplierTextBox();
                    };
                    CommonFunction.DisposeOnClose(supplierSelection);
                    supplierSelection.Show();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }

        private void selectsuppliertxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(SupplierSelectionForm));
            if (openForm == null)
            {
                SupplierSelectionForm supplierSelection = new SupplierSelectionForm
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterParent,
                };

                supplierSelection.FormClosing += delegate
                {
                    UpdateSupplierTextBox();
                };
                CommonFunction.DisposeOnClose(supplierSelection);
                supplierSelection.Show();
            }
            else
            {
                openForm.BringToFront();
            }
        }

        private void PurchaseQuotationInvoice_KeyDown(object sender, KeyEventArgs e)
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

        private void selectproducttxtbox_MouseClick(object sender, MouseEventArgs e)
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

        private void UpdateProductTextBox()
        {
            if (!string.IsNullOrEmpty(GlobalVariables.productnameglobal) && !string.IsNullOrWhiteSpace(GlobalVariables.productnameglobal) &&
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
                        productSelection.Show();
                    }
                    else
                    {
                        openForm.BringToFront();
                    }
                }
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(selectproducttxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectproducttxtbox,"Please Select Product.");
                    selectproducttxtbox.Focus();
                    return;
                }

                if(qtytxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(qtytxtbox,"Please Enter Quantity.");
                    qtytxtbox.Focus();
                    return;
                }

                int productid = Convert.ToInt32(productidlbl.Text);
                string productName = selectproducttxtbox.Text;
                string productMfr = mfrtxtbox.Text;
                int qty = Convert.ToInt32(qtytxtbox.Text);

                dgvpurchaseproducts.Rows.Add(productMfr,productid,productName,qty);

                productidlbl.Text = string.Empty;
                selectproducttxtbox.Text = string.Empty;
                mfrtxtbox.Text = string.Empty;
                qtytxtbox.Text = string.Empty;
                selectproducttxtbox.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void qtytxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace, and digits
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
