using SmartFlow.Common;
using SmartFlow.Common.Forms;
using SmartFlow.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class StockTransfer : Form
    {
        private int invoiceCounter = 1;
        public StockTransfer()
        {
            InitializeComponent();
        }
        private void StockTransfer_Load(object sender, EventArgs e)
        {
            stocktransferidlbl.Text = GenerateNextInvoiceNumber();
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(selectwarehousefromtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousefromtxtbox,"Please Select Warehouse From you want to transfer the item.");
                    selectwarehousefromtxtbox.Focus();
                    return;
                }

                if(selectwarehousetotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousetotxtbox,"Please Select Warehouse you want to transfer.");
                    selectwarehousetotxtbox.Focus();
                    return;
                }

                if(selectwarehousefromtxtbox.Text == selectwarehousetotxtbox.Text)
                {
                    errorProvider.SetError(selectwarehousetotxtbox,"Select Different Warehouse for Transfer.");
                    selectwarehousetotxtbox.Focus();
                    return;
                }

                if(mfrtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(mfrtxtbox,"Please Select a Product.");
                    mfrtxtbox.Focus();
                    return;
                }

                if(qtytxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(qtytxtbox,"Please Enter Quantity.");
                    qtytxtbox.Focus();
                    return;
                }

                bool productExists = false;
                foreach(DataGridViewRow row in dgvproducts.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["ProductID"].Value!=null && row.Cells["ProductID"].Value.ToString()== productidlbl.Text.ToString())
                        {
                            int currentQuantity = Convert.ToInt32(row.Cells["productquantity"].Value);
                            row.Cells["productquantity"].Value = currentQuantity + Convert.ToInt32(qtytxtbox.Text);
                            productExists = true;
                            break;
                        }
                    }
                }

                if (!productExists)
                {
                    dgvproducts.Rows.Add(productidlbl.Text,mfrtxtbox.Text, productnamelbl.Text, productupclbl.Text,  
                        productbarcodelbl.Text, qtytxtbox.Text);
                }

                mfrtxtbox.Text = string.Empty;
                qtytxtbox.Text = string.Empty;
                productidlbl.Text = string.Empty;
                productnamelbl.Text = string.Empty;
                productupclbl.Text = string.Empty;
                productbarcodelbl.Text = string.Empty;
                mfrtxtbox.Focus();

            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(selectwarehousefromtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousefromtxtbox,"Please Select Warehouse from.");
                    selectwarehousefromtxtbox.Focus();
                    return;
                }

                if(selectwarehousetotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousetotxtbox,"Please Select Warehouse to.");
                    selectwarehousetotxtbox.Focus();
                    return;
                }

                if(selectwarehousefromtxtbox.Text == selectwarehousetotxtbox.Text)
                {
                    errorProvider.SetError(selectwarehousetotxtbox,"Select Different Warehouse");
                    selectwarehousetotxtbox.Focus();
                    return;
                }

                if(string.IsNullOrEmpty(descriptiontxtbox.Text) && string.IsNullOrWhiteSpace(descriptiontxtbox.Text))
                {
                    errorProvider.SetError(descriptiontxtbox,"Please Enter Description.");
                    descriptiontxtbox.Focus();
                    return;
                }

                bool isInserted = InsertStockTransfer();

                if (isInserted) 
                {
                    MessageBox.Show("Saved Successfully.");
                }

                /*string addtransferdata = string.Empty;
                string invoiceno = stocktransferidlbl.Text;
                string description = descriptiontxtbox.Text;

                addtransferdata = string.Format("INSERT INTO StockCustomizedTable (Code,CreatedAt,CreatedDay,InvoiceNo,Description) VALUES ('" + Guid.NewGuid() + "'," +
                                "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + invoiceno + "','" + description + "'); " +
                                "SELECT SCOPE_IDENTITY();");
                int stockcustomid = 0;
                int warehouseid = Convert.ToInt32(warehousetoidlbl.Text);
                int warehousefromid = Convert.ToInt32(warehousefromidlbl.Text);

                foreach (DataGridViewRow row in dgvproducts.Rows)
                {
                    if (!row.IsNewRow)
                    { 
                        string productid = Convert.ToString(row.Cells[0].Value);
                        string productname = Convert.ToString(row.Cells[1].Value);
                        string upc = Convert.ToString(row.Cells[2].Value);
                        string price = Convert.ToString(row.Cells[3].Value);
                        string barcode = Convert.ToString(row.Cells[4].Value);
                        int quantity = Convert.ToInt32(row.Cells[6].Value.ToString());
                        
                        if (stockcustomid > 0)
                        {
                            
                            string insertstock = string.Format("INSERT INTO StockTable (ProductID,CreatedAt,CreatedDay,WarehouseId,TransferFromWarehouseID," +
                                "TransferToWarehouseID,TransformQty,TransToQty,RefrenceLink,StockCustom_ID,Quantity) VALUES ('" + productid + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                "'" + DateTime.Now.DayOfWeek + "','" + warehouseid + "','" + warehousefromid + "','" + warehouseid + "'," +
                                "'" + quantity + "','" + quantity + "','" + descriptiontxtbox.Text + "','" + stockcustomid + "','" + quantity + "')");

                            bool result = false;

                        }
                        savebtn.Enabled = false;
                        

                    }
                    
                }
                MessageBox.Show("Saved Successfully!");*/
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private string CheckInvoiceBeforeInsert()
        {
            try
            {
                string lastInvoiceNumber = GetLastInvoiceNumber();
                string newInvoiceNumber = stocktransferidlbl.Text;

                if (String.Compare(newInvoiceNumber, lastInvoiceNumber) <= 0)
                {
                    return GenerateNextInvoiceNumber();
                }
                else
                {
                    return stocktransferidlbl.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
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
                    string invoicepart = "ST";
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
                    string invoicepart = "ST";
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
                string datePart = DateTime.Today.ToString("yyMMdd");
                string query = $"SELECT TOP 1 InvoiceNo FROM StockCustomizedTable WHERE InvoiceNo LIKE 'ST-{datePart}-%' ORDER BY InvoiceNo DESC";
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
        private void dgvproducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                int productid = Convert.ToInt32(dgvproducts.CurrentRow.Cells[0].Value);
                if (productid > 0)
                {
                    foreach (DataGridViewRow row in dgvproducts.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            dgvproducts.Rows.Remove(row);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select One Row");
                }
            }
        }
        private void StockTransfer_KeyDown(object sender, KeyEventArgs e)
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
        private void mfrtxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
                if (openForm == null)
                {
                    ProductSelectionForm productSelectionForm = new ProductSelectionForm();
                   
                    productSelectionForm.FormClosed += delegate
                    {
                        UpdateProductTextBox();
                    };
                    CommonFunction.DisposeOnClose(productSelectionForm);
                    productSelectionForm.Show();
                }
                else
                {
                    openForm.BringToFront();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void UpdateProductTextBox()
        {
            mfrtxtbox.Text = GlobalVariables.productmfrglobal;
            productidlbl.Text = GlobalVariables.productidglobal.ToString();
            productnamelbl.Text = GlobalVariables.productnameglobal.ToString();
            productupclbl.Text = GlobalVariables.productupcglobal.ToString();
            productbarcodelbl.Text = GlobalVariables.productbarcodeglobal.ToString();
        }
        private void selectwarehousefromtxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectwarehousefromtxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(WarehouseSelection));
                if (openForm == null)
                {
                    string getwarehousedata = "SELECT WarehouseID,Name,Address,City,Code FROM WarehouseTable";
                    DataTable warehousedata = DatabaseAccess.Retrive(getwarehousedata);

                    if (warehousedata != null)
                    {
                        if (warehousedata.Rows.Count > 0)
                        {
                            WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata)
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterScreen,
                            };

                            warehouseSelection.FormClosed += delegate
                            {
                                UpdateWarehouseFromTextBox();
                            };

                            CommonFunction.DisposeOnClose(warehouseSelection);
                            warehouseSelection.ShowDialog();
                        }
                    }

                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void UpdateWarehouseFromTextBox()
        {
            if(!string.IsNullOrEmpty(GlobalVariables.warehousenameglobal) && GlobalVariables.warehouseidglobal > 0)
            {
                selectwarehousefromtxtbox.Text = GlobalVariables.warehousenameglobal.ToString();
                warehousefromidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
            }
        }
        private void selectwarehousetotxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(selectwarehousetotxtbox.Text))
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(WarehouseSelection));
                if (openForm == null)
                {
                    string getwarehousedata = "SELECT WarehouseID,Name,Address,City,Code FROM WarehouseTable";
                    DataTable warehousedata = DatabaseAccess.Retrive(getwarehousedata);

                    if (warehousedata != null)
                    {
                        if (warehousedata.Rows.Count > 0)
                        {
                            WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata)
                            {
                                WindowState = FormWindowState.Normal,
                                StartPosition = FormStartPosition.CenterScreen,
                            };

                            warehouseSelection.FormClosed += delegate
                            {
                                UpdateWarehouseToTextBox();
                            };

                            CommonFunction.DisposeOnClose(warehouseSelection);
                            warehouseSelection.ShowDialog();
                        }
                    }

                }
                else
                {
                    openForm.BringToFront();
                }
            }
            
        }
        private void UpdateWarehouseToTextBox() 
        {
            selectwarehousetotxtbox.Text = GlobalVariables.warehousenameglobal.ToString();
            warehousetoidlbl.Text = GlobalVariables.warehouseidglobal.ToString();
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (selectwarehousefromtxtbox.Text.Trim().Length > 0) { return true; }
            if (mfrtxtbox.Text.Trim().Length > 0) { return true;}
            if (selectwarehousetotxtbox.Text.Trim().Length > 0) { return true;}
            if (qtytxtbox.Text.Trim().Length > 0) { return true;}
            if (descriptiontxtbox.Text.Trim().Length > 0) { return true; }
            if (dgvproducts.Rows.Count > 0) { return true; }
            return false; // No TextBox is filled
        }
        private void selectwarehousetotxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(WarehouseSelection));
                if (openForm == null)
                {
                    string getwarehousedata = "SELECT WarehouseID,Name,Address,City,Code FROM WarehouseTable";
                    DataTable warehousedata = DatabaseAccess.Retrive(getwarehousedata);

                    if (warehousedata != null)
                    {
                        if (warehousedata.Rows.Count > 0)
                        {
                            WarehouseSelection warehouseSelection = new WarehouseSelection(warehousedata);
                            
                            warehouseSelection.FormClosed += delegate
                            {
                                UpdateWarehouseToTextBox();
                            };
                            CommonFunction.DisposeOnClose(warehouseSelection);
                            warehouseSelection.Show();
                        }
                    }

                }
                else
                {
                    openForm.BringToFront();
                }
            }
        }
        private void mfrtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(ProductSelectionForm));
                if (openForm == null)
                {
                    ProductSelectionForm productSelectionForm = new ProductSelectionForm();
                    
                    productSelectionForm.FormClosed += delegate
                    {
                        UpdateProductTextBox();
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

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool InsertStockTransfer()
        {
            string InvoiceNo = CheckInvoiceBeforeInsert();
            // Update AccountGroupingTable
            string tableName = "StockCustomizedTable";

            var columnData = new Dictionary<string, object>
            {
                { "Code", Guid.NewGuid().ToString() },
                { "InvoiceNo", InvoiceNo },
                { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "Description", descriptiontxtbox.Text }
            };

            // Call the common function for the update
            int result = DatabaseAccess.InsertDataId(tableName, columnData);

            if (result > 0)
            {
                string subtableName = "StockTable";
                // Insert into AccountGroupingDetailsTable for each DataGridView row
                foreach (DataGridViewRow row in dgvproducts.Rows)
                {
                    if (row.IsNewRow) continue;

                    int productID = Convert.ToInt32(row.Cells["productid"].Value);
                    int warehousetoid = Convert.ToInt32(warehousetoidlbl.Text);
                    int warehousefromid = Convert.ToInt32(warehousefromidlbl.Text);
                    int quantity = Convert.ToInt32(row.Cells["productquantity"].Value);
                    string productMfr = row.Cells["productmfr"].Value.ToString();

                    var detailData = new Dictionary<string, object>
                    {
                        { "ProductID", productID },
                        { "CreatedAt", DateTime.Now.ToString("") },
                        { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                        { "TransferFromWarehouseID", warehousefromid },
                        { "TransferToWarehouseID", warehousetoid },
                        { "StockCustom_ID", result },
                        { "Quantity", quantity },
                        { "ProductMfr", productMfr }
                    };

                    bool subresult = DatabaseAccess.ExecuteQuery(subtableName, "INSERT", detailData);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
