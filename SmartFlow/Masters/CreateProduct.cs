using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace SmartFlow.Masters
{
    public partial class CreateProduct : Form
    {
        private int randomNumber = 0;
        public CreateProduct()
        {
            InitializeComponent();
        }
        public CreateProduct(int ProductID)
        {
            InitializeComponent();
            productidlbl.Text = ProductID.ToString();
        }
        public CreateProduct(int ProductID,string formtitle)
        {
            InitializeComponent();
            productidlbl.Text = ProductID.ToString();
            headinglbl.Text = formtitle;
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(savebtn.Text == "Update")
                {
                    errorProvider.Clear();

                    if (nametxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(nametxtbox, "Please Enter Name.");
                        nametxtbox.Focus();
                        return;
                    }

                    if(mfrtextBox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(mfrtextBox, "Please Enter Mfr.");
                        mfrtextBox.Focus(); 
                        return;
                    }

                    if(cmbbrand.SelectedIndex == 0)
                    {
                        errorProvider.SetError(cmbbrand,"Please Select Brand.");
                        cmbbrand.Focus();
                        return;
                    }

                    string duplicateinfo = await checkduplicate();

                    if (duplicateinfo != null)
                    {
                        MessageBox.Show(duplicateinfo, "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (randomNumber > 0)
                        {
                            string updateresult = await UpdateProduct();
                            if (updateresult == "Product updated successfully!")
                            {
                                DeleteBundleData(Convert.ToInt32(productidlbl.Text));
                                AddDataToDatabase(Convert.ToInt32(productidlbl.Text), productcodelbl.Text);
                                MessageBox.Show("Item Updated Successfully!");
                            }
                        }
                        else
                        {
                            string updateresult = await UpdateProduct();
                            if(updateresult == "Product updated successfully!")
                            {
                                DeleteBundleData(Convert.ToInt32(productidlbl.Text));
                                AddDataToDatabase(Convert.ToInt32(productidlbl.Text), productcodelbl.Text);
                                MessageBox.Show("Item Updated Successfully!");
                            }
                        }
                    }
                }
                else
                {
                    errorProvider.Clear();

                    if (nametxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(nametxtbox, "Please Enter Name.");
                        nametxtbox.Focus();
                        return;
                    }

                    if(mfrtextBox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(mfrtextBox, "Please Enter Mfr");
                        mfrtextBox.Focus();
                        return;
                    }
                    string duplicateinfo = await checkduplicate();

                    if (duplicateinfo != null)
                    {
                        MessageBox.Show(duplicateinfo, "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        decimal saleUnitPrice = TryParseDecimal(salepricetxtbox.Text.Trim());
                        decimal lowestPrice = TryParseDecimal(lowestpricetxtbox.Text.Trim());
                        decimal wholeSalePrice = TryParseDecimal(wholesalepricetxtbox.Text.Trim());
                        decimal standardPrice = TryParseDecimal(standardpricetxtbox.Text.Trim());
                        int stockThresholdQty = TryParseInt(stockalerttxtbox.Text.Trim());
                        decimal length = TryParseDecimal(lengthtextBox.Text.Trim());
                        decimal width = TryParseDecimal(widthtextBox.Text.Trim());
                        decimal height = TryParseDecimal(heighttextBox.Text.Trim());
                        decimal weight = TryParseDecimal(weighttextBox.Text.Trim());
                        decimal discountPercentage = TryParseDecimal(discountpercentagetxtbox.Text.Trim());
                        // Data to insert

                        var data = new Dictionary<string, object>
                        {
                            { "ProductName", nametxtbox.Text  },
                            { "SaleUnitPrice", saleUnitPrice },
                            { "LowestPrice", lowestPrice },
                            { "WholeSalePrice", wholeSalePrice },
                            { "StandardPrice", standardPrice },
                            { "StockTrasholdQty", stockThresholdQty },
                            { "CreatedAt", DateTime.Now },
                            { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                            { "UPC", upctextBox.Text.Trim() },
                            { "EAN", eantextBox.Text.Trim() },
                            { "Length", length },
                            { "Width", width },
                            { "Height", height },
                            { "Weight", weight },
                            { "MFR", mfrtextBox.Text.Trim() },
                            { "ProductCode", Guid.NewGuid() },
                            { "Barcode", randomNumber },
                            { "DiscountPercentage", discountPercentage },
                            { "IsBundle", checkBox1.Checked },
                            { "HSCode", hscodetxtbox.Text.Trim() },
                            { "SecondMFr", secondmfrtxtbox.Text.Trim() },
                            { "COO", cootxtbox.Text.Trim() },
                            { "SecondUpc", secondupctxtbox.Text.Trim() },
                            { "ThirdMfr", thirdmfrtxtbox.Text.Trim() },
                            { "ThirdUPC", thirdupctxtbox.Text.Trim() },
                            { "IsCustomProduct", isCustomcheck.Checked },
                            { "BrandId", cmbbrand.SelectedValue }
                        };
                        
                        // Insert data and get the result

                        int result = await DatabaseAccess.InsertDataIdAsync("ProductTable", data);
                        if (result > 0)
                        {
                            AddDataToDatabase(result, data["ProductCode"].ToString());
                            MessageBox.Show("Item Added Successfully!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the item.");
                        }
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<string> checkduplicate()
        {
            int brandid = Convert.ToInt32(cmbbrand.SelectedValue);
            string query = string.Format(@"SELECT ProductID,ProductName,MFR,UPC,EAN,SecondMFr,SecondUpc,ProductCode," +
                        "SaleUnitPrice,LowestPrice,ThirdMfr,ThirdUPC,IsCustomProduct,BrandId FROM ProductTable WHERE MFR = @MFR " +
                        "AND UPC = @UPC AND EAN = @EAN " +
                        "AND SecondMFr = @SecondMFr AND SecondUpc = @SecondUpc AND BrandId = @BrandId");

            var parameters = new Dictionary<string, object>
            {
                { "MFR", mfrtextBox.Text },
                { "UPC" , upctextBox.Text },
                { "EAN" , eantextBox.Text },
                { "SecondMFr" , secondmfrtxtbox.Text },
                { "SecondUpc" , secondupctxtbox.Text },
                { "ThirdMfr" , thirdmfrtxtbox.Text },
                { "ThirdUPC" , thirdupctxtbox.Text },
                { "IsCustomProduct", isCustomcheck.Checked },
                { "BrandId", brandid }
            };

            DataTable dt = await DatabaseAccess.RetrieveDataAsync(query, parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                string productTitle = dt.Rows[0]["ProductName"].ToString();
                string productmfr = dt.Rows[0]["MFR"].ToString();
                string productUpc = dt.Rows[0]["UPC"].ToString();
                string productean = dt.Rows[0]["EAN"].ToString();
                string productsecondmfr = dt.Rows[0]["SecondMFr"].ToString();
                string productsecondupc = dt.Rows[0]["SecondUpc"].ToString();
                string productthirdmfr = dt.Rows[0]["ThirdMfr"].ToString();
                string productthirdupc = dt.Rows[0]["ThirdUPC"].ToString();
                bool isCustom = Convert.ToBoolean(dt.Rows[0]["IsCustomProduct"]);

                if (nametxtbox.Text == productTitle && mfrtextBox.Text == productmfr && upctextBox.Text == productUpc && eantextBox.Text == productean &&
                    secondmfrtxtbox.Text == productsecondmfr && secondupctxtbox.Text == productsecondupc && thirdmfrtxtbox.Text == productthirdmfr 
                    && isCustomcheck.Checked == isCustom)
                {
                    return $"Duplicate found: Product Name = {productTitle}, MFR = {productmfr}, UPC = {productUpc}, EAN = {productean}," +
                        $"SecondMFR = {productsecondmfr}, SecondUPC = {productsecondupc}, ThirdMfr = {productthirdmfr}, Custom Product = {isCustom}.";
                }

            }
            return null;
        }

        private async Task<string> UpdateProduct()
        {
            string tableName = "ProductTable";
            string whereClause = "ProductID = '" + productidlbl.Text + "'";

            decimal saleUnitPrice = TryParseDecimal(salepricetxtbox.Text.Trim());
            decimal lowestPrice = TryParseDecimal(lowestpricetxtbox.Text.Trim());
            decimal wholeSalePrice = TryParseDecimal(wholesalepricetxtbox.Text.Trim());
            decimal standardPrice = TryParseDecimal(standardpricetxtbox.Text.Trim());
            int stockThresholdQty = TryParseInt(stockalerttxtbox.Text.Trim());
            decimal length = TryParseDecimal(lengthtextBox.Text.Trim());
            decimal width = TryParseDecimal(widthtextBox.Text.Trim());
            decimal height = TryParseDecimal(heighttextBox.Text.Trim());
            decimal weight = TryParseDecimal(weighttextBox.Text.Trim());
            decimal discountPercentage = TryParseDecimal(discountpercentagetxtbox.Text.Trim());

            var columnData = new Dictionary<string, object>
            {
                { "ProductName", nametxtbox.Text  },
                { "SaleUnitPrice", saleUnitPrice },
                { "LowestPrice", lowestPrice },
                { "WholeSalePrice", wholeSalePrice },
                { "StandardPrice", standardPrice },
                { "StockTrasholdQty", stockThresholdQty },
                { "CreatedAt", DateTime.Now },
                { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                { "UPC", upctextBox.Text.Trim() },
                { "EAN", eantextBox.Text.Trim() },
                { "Length", length },
                { "Width", width },
                { "Height", height },
                { "Weight", weight },
                { "MFR", mfrtextBox.Text.Trim() },
                { "ProductCode", Guid.NewGuid() },
                { "DiscountPercentage", discountPercentage },
                { "IsBundle", checkBox1.Checked },
                { "HSCode", hscodetxtbox.Text.Trim() },
                { "SecondMFr", secondmfrtxtbox.Text.Trim() },
                { "COO", cootxtbox.Text.Trim() },
                { "SecondUpc", secondupctxtbox.Text.Trim() },
                { "ThirdMfr", thirdmfrtxtbox.Text.Trim() },
                { "ThirdUPC", thirdupctxtbox.Text.Trim() },
                { "IsCustomProduct", isCustomcheck.Checked },
                { "BrandId", cmbbrand.SelectedValue }
            };

            bool isUpdated = await DatabaseAccess.ExecuteQueryAsync(tableName, "UPDATE", columnData, whereClause);

            return isUpdated ? "Product updated successfully!" : "Failed to update the product.";
        }

        private decimal TryParseDecimal(string input)
        {
            if (decimal.TryParse(input, out decimal result))
                return result;

            return 0; // Default value if parsing fails
        }

        private int TryParseInt(string input)
        {
            if (int.TryParse(input, out int result))
                return result;

            return 0; // Default value if parsing fails
        }

        private async void FindRecord(int productid)
        {
            try
            {
                bool isChecked = false;
                string query = string.Format("SELECT ProductID,ProductName,ProductCode,SaleUnitPrice,LowestPrice,WholeSalePrice,StandardPrice," +
                    "StockTrasholdQty,StockCode,CompanyID,UPC,EAN,Length,Width,Height,Weight,MFR,Barcode,ProductCode,DiscountPercentage,IsBundle," +
                    "HSCode,SecondMFr,COO,SecondUpc,ThirdMfr,ThirdUPC,IsCustomProduct,BrandId FROM ProductTable WHERE ProductID = @ProductID");

                var parameters = new Dictionary<string, object>
                {
                    { "ProductID", productid }
                };

                DataTable dataTable = await DatabaseAccess.RetrieveDataAsync(query, parameters);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    productcodelbl.Text = dataTable.Rows[0]["ProductCode"].ToString();
                    nametxtbox.Text = dataTable.Rows[0]["ProductName"].ToString();
                    stockalerttxtbox.Text = dataTable.Rows[0]["StockTrasholdQty"].ToString();
                    mfrtextBox.Text = dataTable.Rows[0]["MFR"].ToString();
                    upctextBox.Text = dataTable.Rows[0]["UPC"].ToString();
                    eantextBox.Text = dataTable.Rows[0]["EAN"].ToString();
                    lengthtextBox.Text = dataTable.Rows[0]["Length"].ToString();
                    widthtextBox.Text = dataTable.Rows[0]["Width"].ToString();
                    heighttextBox.Text = dataTable.Rows[0]["Height"].ToString();
                    weighttextBox.Text = dataTable.Rows[0]["Weight"].ToString();
                    standardpricetxtbox.Text = dataTable.Rows[0]["StandardPrice"].ToString();
                    wholesalepricetxtbox.Text = dataTable.Rows[0]["WholeSalePrice"].ToString();
                    lowestpricetxtbox.Text = dataTable.Rows[0]["LowestPrice"].ToString();
                    salepricetxtbox.Text = dataTable.Rows[0]["SaleUnitPrice"].ToString();
                    string barcode = dataTable.Rows[0]["Barcode"].ToString();
                    discountpercentagetxtbox.Text = dataTable.Rows[0]["DiscountPercentage"].ToString();
                    isChecked = Convert.ToBoolean(dataTable.Rows[0]["IsBundle"].ToString());
                    hscodetxtbox.Text = dataTable.Rows[0]["HSCode"].ToString();
                    secondmfrtxtbox.Text = dataTable.Rows[0]["SecondMFr"].ToString();
                    cootxtbox.Text = dataTable.Rows[0]["COO"].ToString();
                    secondupctxtbox.Text = dataTable.Rows[0]["SecondUpc"].ToString();
                    thirdmfrtxtbox.Text = dataTable.Rows[0]["ThirdMfr"].ToString();
                    thirdupctxtbox.Text = dataTable.Rows[0]["ThirdUPC"].ToString();
                    isCustomcheck.Checked = Convert.ToBoolean(dataTable.Rows[0]["IsCustomProduct"]);
                    cmbbrand.SelectedValue = dataTable.Rows[0]["BrandId"];
                    
                    if(isChecked != false)
                    {
                        checkBox1.Checked = isChecked;
                        FillBundleDataGridView(productid);
                    }

                    if (isCustomcheck.Checked != false) 
                    {
                        isCustomcheck.Enabled = true;
                    }
                    else
                    {
                        isCustomcheck.Enabled = false;
                    }
                    
                    if (string.IsNullOrEmpty(barcode))
                    {
                        GenerateBarcode();
                    }
                    else
                    {
                        var writer = new BarcodeWriter
                        {
                            Format = BarcodeFormat.CODE_128,
                            Options = new ZXing.Common.EncodingOptions
                            {
                                Height = 50,
                                Width = 80,
                            }
                        };
                        var barcodeImage = writer.Write(barcode.ToString());
                        pictureBox1.Image = barcodeImage;
                    }
                    if(headinglbl.Text == "Product Details")
                    {
                        productcodelbl.Enabled = false;
                        nametxtbox.Enabled = false;
                        stockalerttxtbox.Enabled = false;
                        mfrtextBox.Enabled = false;
                        upctextBox.Enabled = false;
                        eantextBox.Enabled = false;
                        lengthtextBox.Enabled = false;
                        widthtextBox.Enabled = false;
                        heighttextBox.Enabled = false;
                        weighttextBox.Enabled = false;
                        standardpricetxtbox.Enabled = false;
                        wholesalepricetxtbox.Enabled = false;
                        lowestpricetxtbox.Enabled = false;
                        salepricetxtbox.Enabled = false;
                        discountpercentagetxtbox.Enabled = false;
                        hscodetxtbox.Enabled = false;
                        secondmfrtxtbox.Enabled = false;
                        cootxtbox.Enabled = false;
                        savebtn.Visible = false;
                        checkBox1.Enabled = false;
                        includestxtbox.Enabled = false;
                        secondupctxtbox.Enabled = false;
                        thirdmfrtxtbox.Enabled = false;
                        thirdupctxtbox.Enabled = false;
                        isCustomcheck.Enabled = false;
                        qtycheckbtn.Enabled = true;
                    }
                    else 
                    {
                        isCustomcheck.Enabled = false;
                        qtycheckbtn.Enabled = true;
                        savebtn.Text = "Update";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FillBundleDataGridView(int productid)
        {
            try
            {
                string querybundle = "SELECT IncludeItem FROM ProductBundleTable WHERE ProductId = '" + productid + "'";
                DataTable bundledata = await DatabaseAccess.RetriveAsync(querybundle);
                if (bundledata != null)
                {
                    if (bundledata.Rows.Count > 0)
                    {
                        includestxtbox.Text = bundledata.Rows[0]["IncludeItem"].ToString();
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CreateProduct_KeyDown(object sender, KeyEventArgs e)
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

        private async void CreateProduct_Load(object sender, EventArgs e)
        {
            await CommonFunction.PopulateBrandComboBoxAsync(cmbbrand);
            this.lowestpricetxtbox.BringToFront();
            this.salepricetxtbox.BringToFront();
            this.discountpercentagetxtbox.BringToFront();
            this.wholesalepricetxtbox.BringToFront();
            string labeldata = productidlbl.Text;
            if (labeldata != "productid")
            {
                FindRecord(Convert.ToInt32(productidlbl.Text));
            }
            else
            {
                GenerateBarcode();
            }
        }

        private async void GenerateBarcode()
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 50,
                    Width = 80,
                }
            };

            Random rnd = new Random();
            randomNumber = rnd.Next(10000000, 99999999);
            bool isUnique = false;
            while (!isUnique)
            {
                string query = $"SELECT Barcode FROM ProductTable WHERE Barcode = {randomNumber}";
                DataTable dt = await DatabaseAccess.RetriveAsync(query);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(dt.Rows[0]["Barcode"]);
                        if (count == 0)
                        {
                            isUnique = true;
                        }
                        else
                        {
                            // Number already exists, generate a new one
                            randomNumber = rnd.Next(10000000, 99999999);
                        }
                    }
                    else
                    {
                        isUnique = true;
                    }
                }
            }
            var barcodeImage = writer.Write(randomNumber.ToString());
            pictureBox1.Image = barcodeImage;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            includestxtbox.Text = "";
            includestxtbox.Visible = checkBox1.Checked;
            includelbl.Visible = checkBox1.Checked;
        }

        private async void AddDataToDatabase(int productid,string productcode)
        {
            try
            {
                if (includestxtbox.Text.Trim().Length > 0)
                {
                    string tableName = "ProductBundleTable";

                    var columnData = new Dictionary<string, object>
                    {
                        { "ProductId", productid  },
                        { "IncludeItem", includestxtbox.Text },
                        { "ProductCode", productcode },
                        { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                        { "CreatedDay", DateTime.Now.DayOfWeek }
                    };

                    await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);
                }
            }catch (Exception ex) { throw ex; }
        }

        private async void DeleteBundleData(int productid)
        {
            try
            {
                string tableName = "ProductBundleTable";
                string whereClause = "ProductId = @ProductID";

                var columnData = new Dictionary<string, object>
                {
                    { "ProductID", productid }
                };

                await DatabaseAccess.ExecuteQueryAsync(tableName, "DELETE", columnData, whereClause);

            }catch (Exception ex) { throw ex; }
        }
        private void nametxtbox_TextChanged(object sender, EventArgs e)
        {
            // Save the current caret position
            int currentPosition = nametxtbox.SelectionStart;

            // Apply text transformations
            string newText = nametxtbox.Text.TrimStart().Replace(Environment.NewLine, " ");

            // Set the transformed text back
            nametxtbox.Text = newText;

            // Adjust the caret position to account for transformations
            nametxtbox.SelectionStart = Math.Min(currentPosition, nametxtbox.Text.Length);
        }
        private bool AreAnyTextBoxesFilled()
        {
            if (nametxtbox.Text.Trim().Length > 0) { return true; }
            if (stockalerttxtbox.Text.Trim().Length > 0) { return true; }
            if (mfrtextBox.Text.Trim().Length > 0) { return true; }
            if (upctextBox.Text.Trim().Length > 0) { return true; }
            if (eantextBox.Text.Trim().Length > 0) { return true; }
            if (lengthtextBox.Text.Trim().Length > 0) { return true; }
            if (widthtextBox.Text.Trim().Length > 0) { return true; }
            if (heighttextBox.Text.Trim().Length > 0) { return true; }
            if (weighttextBox.Text.Trim().Length > 0) { return true; }
            if (cootxtbox.Text.Trim().Length > 0) { return true; }
            if (standardpricetxtbox.Text.Trim().Length > 0) { return true; }
            if (wholesalepricetxtbox.Text.Trim().Length > 0) { return true; }
            if (lowestpricetxtbox.Text.Trim().Length > 0) { return true; }
            if (salepricetxtbox.Text.Trim().Length > 0) { return true; }
            if (discountpercentagetxtbox.Text.Trim().Length > 0) { return true; }
            if (hscodetxtbox.Text.Trim().Length > 0) { return true; }
            if (secondmfrtxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
        private async void qtycheckbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(productidlbl.Text) && !string.IsNullOrWhiteSpace(productidlbl.Text))
                {
                    // Prepare the parameter for the stored procedure
                    int productID = int.Parse(productidlbl.Text); // assuming ProductID is an integer

                    // Create the command to call the stored procedure
                    string storedProcedure = "GetTotalQuantity";

                    // Create parameters for the stored procedure
                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@ProductID", SqlDbType.Int) { Value = productID }
                    };

                    // Retrieve the result from the stored procedure
                    DataTable stockqty = await DatabaseAccess.RetriveAsync(storedProcedure, parameters);

                    if (stockqty.Rows.Count > 0 && stockqty != null)
                    {
                        string totalQty = stockqty.Rows[0]["TotalQuantity"].ToString();
                        qtylbl.Visible = true;
                        qtylbl.Text = "In Stock: " + totalQty;
                    }
                    else
                    {
                        qtylbl.Visible = true;
                        // If no stock quantity is found, you can set the label to show "0" or any other message
                        qtylbl.Text = "Out Of Stock: 0";
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async void isCustomcheck_CheckedChanged(object sender, EventArgs e)
        {
            if (isCustomcheck.Checked)
            {
                mfrtextBox.Enabled = false;
                secondmfrtxtbox.Enabled = false;
                thirdmfrtxtbox.Enabled = false;
                upctextBox.Enabled = false;
                secondupctxtbox.Enabled = false;
                thirdupctxtbox.Enabled = false;

                if(string.IsNullOrEmpty(mfrtextBox.Text))
                {
                    mfrtextBox.Text = await GenerateUniqueCode();
                }
            }
            else
            {
                mfrtextBox.Enabled = true;
                secondmfrtxtbox.Enabled = true;
                thirdmfrtxtbox.Enabled = true;
                upctextBox.Enabled = true;
                secondupctxtbox.Enabled = true;
                thirdupctxtbox.Enabled = true;
                mfrtextBox.Text = string.Empty;
            }
        }

        private async Task<string> GenerateUniqueCode()
        {
            string generatedCode;
            bool isCodeUnique;

            do
            {
                // Generate a random 8-digit code with prefix "FAB"
                Random random = new Random();
                int randomNumber = random.Next(10000, 100000); // 8-digit range
                generatedCode = "FAB" + randomNumber;

                // Check if the code exists in the database asynchronously
                isCodeUnique = await DatabaseAccess.CheckIfCodeExistsInDatabaseAsync(generatedCode);

            } while (!isCodeUnique); // Repeat if the code is not unique

            return generatedCode; // Return the unique code
        }


        private async void serialnobtn_Click(object sender, EventArgs e)
        {
            int productid = Convert.ToInt32(productidlbl.Text);

            if (productid > 0) 
            {
                DataTable serialData = await GetBoxSerialData(productid);

                if (serialData != null && serialData.Rows.Count > 0)
                {
                    serialnotxtbox.Clear(); // Clear previous data

                    foreach (DataRow row in serialData.Rows)
                    {
                        string serialNo = row["SerialNo"].ToString();

                        // Append formatted text to RichTextBox
                        serialnotxtbox.AppendText($"Serial No: {serialNo}\n");
                    }
                }
                else
                {
                    serialnotxtbox.Text = "No serial numbers found for this Product ID.";
                }
            }

        }

        private async Task<DataTable> GetBoxSerialData(int productId)
        {
            string query = @"SELECT BoxSerialNoId, ProductId, SerialNo, CreatedAt, UpdatedAt, AddedBy, 
                            CreatedDay, UpdatedDay, IsSold, ProductMfr 
                     FROM BoxSerialNoTable 
                     WHERE ProductId = @ProductId";

            var parameters = new Dictionary<string, object>
            {
                { "@ProductId", productId }
            };

            return await DatabaseAccess.RetriveAsync(query, parameters);
        }

        private void addserialbtn_Click(object sender, EventArgs e)
        {
            int productid = Convert.ToInt32(productidlbl.Text);
            if(productid > 0)
            {
                ProductSerialNo productSerialNo = new ProductSerialNo(productid);
                CommonFunction.DisposeOnClose(productSerialNo);
                productSerialNo.ShowDialog();
            }
        }
    }
}
