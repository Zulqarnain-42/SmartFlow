using System;
using System.Data;
using System.Text.RegularExpressions;
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
            productid.Text = ProductID.ToString();
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void savebtn_Click(object sender, EventArgs e)
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

                    if (stockalerttxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(stockalerttxtbox, "Please Enter Stock Alert.");
                        stockalerttxtbox.Focus();
                        return;
                    }

                    string title = nametxtbox.Text;
                    string includes = includestxtbox.Text;

                    if (title.Contains("'") || title.Contains("\""))
                    {
                        title = Regex.Replace(title, @"[""']", "");
                    }

                    if (includes.Contains("'") || includes.Contains("\""))
                    {
                        includes = Regex.Replace(includes, @"[""']", "");
                    }

                    string query = string.Format(@"SELECT ProductID,ProductName,ProductCode," +
                        "SaleUnitPrice,LowestPrice FROM ProductTable WHERE ProductName = '%" + title + "%' " +
                        "AND StockTrasholdQty = '" + stockalerttxtbox.Text + "' " +
                        "AND MFR = '" + mfrtextBox.Text + "' AND UPC = '" + upctextBox.Text + "' AND EAN = '" + eantextBox.Text + "' " +
                        "AND Length = '" + lengthtextBox.Text + "' AND Width = '" + widthtextBox.Text + "' " +
                        "AND Height = '" + heighttextBox.Text + "' AND Weight = '" + weighttextBox.Text + "' " +
                        "AND StandardPrice = '" + standardpricetxtbox.Text + "' " +
                        "AND WholeSalePrice = '" + wholesalepricetxtbox.Text+ "' AND LowestPrice = '" + lowestpricetxtbox.Text + "' " +
                        "AND SaleUnitPrice = '" + salepricetxtbox.Text + "' AND HSCode = '" + hscodetxtbox.Text + "' AND SecondMFr = '" + secondmfrtxtbox.Text + "' " +
                        "AND COO = '" + cootxtbox.Text + "'");

                    DataTable dt = DatabaseAccess.Retrive(query);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Item Exist Already.");
                        }
                        else
                        {
                            if (randomNumber > 0)
                            {
                                query = "UPDATE ProductTable SET " +
                                        "ProductName = '" + title + "'," +
                                        "SaleUnitPrice = '" + salepricetxtbox.Text + "'," +
                                        "LowestPrice = '" + lowestpricetxtbox.Text + "'," +
                                        "WholeSalePrice = '" + wholesalepricetxtbox.Text + "'," +
                                        "StandardPrice = '" + standardpricetxtbox.Text + "'," +
                                        "StockTrasholdQty = '" + stockalerttxtbox.Text + "'," +
                                        "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                        "UpdatedDay = '" + DateTime.Now.DayOfWeek + "'," +
                                        "UPC = '" + upctextBox.Text + "'," +
                                        "EAN = '" + eantextBox.Text + "'," +
                                        "Length = '" + lengthtextBox.Text + "'," +
                                        "Width = '" + widthtextBox.Text + "'," +
                                        "Height = '" + heighttextBox.Text + "'," +
                                        "Weight = '" + weighttextBox.Text + "'," +
                                        "IsBundle = '" + checkBox1.Checked + "'," +
                                        "Barcode = '" + randomNumber + "',DiscountPercentage = '" + discountpercentagetxtbox.Text + "', COO = '" + cootxtbox.Text + "'," +
                                        "MFR = '" + mfrtextBox.Text + "',HSCode = '" + hscodetxtbox.Text + "',SecondMFr = '" + secondmfrtxtbox.Text + "'" +
                                        " WHERE ProductID = " + productid.Text + "";
                                DeleteBundleData(Convert.ToInt32(productid.Text));
                                AddDataToDatabase(Convert.ToInt32(productid.Text), productcodelbl.Text);
                            }
                            else
                            {
                                query = "UPDATE ProductTable SET " +
                                           "ProductName = '" + title + "'," +
                                           "SaleUnitPrice = '" + salepricetxtbox.Text + "'," +
                                           "LowestPrice = '" + lowestpricetxtbox.Text + "'," +
                                           "WholeSalePrice = '" + wholesalepricetxtbox.Text + "'," +
                                           "StandardPrice = '" + standardpricetxtbox.Text + "'," +
                                           "StockTrasholdQty = '" + stockalerttxtbox.Text + "'," +
                                           "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                           "UpdatedDay = '" + DateTime.Now.DayOfWeek + "'," +
                                           "UPC = '" + upctextBox.Text + "'," +
                                           "EAN = '" + eantextBox.Text + "'," +
                                           "Length = '" + lengthtextBox.Text + "'," +
                                           "Width = '" + widthtextBox.Text + "'," +
                                           "Height = '" + heighttextBox.Text + "'," +
                                           "Weight = '" + weighttextBox.Text + "'," +
                                           "IsBundle = '" + checkBox1.Checked + "',HSCode = '" + hscodetxtbox.Text + "'," +
                                           "MFR = '" + mfrtextBox.Text + "',DiscountPercentage = '" + discountpercentagetxtbox.Text + "', COO = '" + cootxtbox.Text + "'," +
                                           "SecondMFr = '" + secondmfrtxtbox.Text + "'" +
                                           " WHERE ProductID = " + productid.Text + "";
                                DeleteBundleData(Convert.ToInt32(productid.Text));
                                AddDataToDatabase(Convert.ToInt32(productid.Text), productcodelbl.Text);

                            }

                            bool result = DatabaseAccess.Update(query);
                            if (result)
                            {
                                MessageBox.Show("Item Updated Successfully!");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong.");
                            }
                        }
                    }
                    else
                    {
                        if (randomNumber > 0)
                        {
                            query = "UPDATE ProductTable SET " +
                                    "ProductName = '" + title + "'," +
                                    "SaleUnitPrice = '" + salepricetxtbox.Text.Trim() + "'," +
                                    "LowestPrice = '" + lowestpricetxtbox.Text.Trim() + "'," +
                                    "WholeSalePrice = '" + wholesalepricetxtbox.Text.Trim() + "'," +
                                    "StandardPrice = '" + standardpricetxtbox.Text.Trim() + "'," +
                                    "StockTrasholdQty = '" + stockalerttxtbox.Text.Trim() + "'," +
                                    "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                    "UpdatedDay = '" + DateTime.Now.DayOfWeek + "'," +
                                    "UPC = '" + upctextBox.Text.Trim() + "'," +
                                    "EAN = '" + eantextBox.Text.Trim() + "'," +
                                    "Length = '" + lengthtextBox.Text.Trim() + "'," +
                                    "Width = '" + widthtextBox.Text.Trim() + "'," +
                                    "Height = '" + heighttextBox.Text.Trim() + "'," +
                                    "Weight = '" + weighttextBox.Text.Trim() + "'," +
                                    "IsBundle = '" + checkBox1.Checked + "'," +
                                    "Barcode = '" + randomNumber + "',DiscountPercentage = '" + discountpercentagetxtbox.Text.Trim() + "',COO = '"+cootxtbox.Text+"'," +
                                    "MFR = '" + mfrtextBox.Text.Trim() + "',HSCode = '" + hscodetxtbox.Text + "',SecondMFr = '" + secondmfrtxtbox.Text + "'" +
                                    " WHERE ProductID = " + productid.Text + "";
                            DeleteBundleData(Convert.ToInt32(productid.Text));
                            AddDataToDatabase(Convert.ToInt32(productid.Text), productcodelbl.Text);

                        }
                        else
                        {
                            query = "UPDATE ProductTable SET " +
                                    "ProductName = '" + title + "'," +
                                    "SaleUnitPrice = '" + salepricetxtbox.Text.Trim() + "'," +
                                    "LowestPrice = '" + lowestpricetxtbox.Text.Trim() + "'," +
                                    "WholeSalePrice = '" + wholesalepricetxtbox.Text.Trim() + "'," +
                                    "StandardPrice = '" + standardpricetxtbox.Text.Trim() + "'," +
                                    "StockTrasholdQty = '" + stockalerttxtbox.Text.Trim() + "'," +
                                    "UpdatedAt = '" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                    "UpdatedDay = '" + DateTime.Now.DayOfWeek + "'," +
                                    "UPC = '" + upctextBox.Text.Trim() + "'," +
                                    "EAN = '" + eantextBox.Text.Trim() + "'," +
                                    "Length = '" + lengthtextBox.Text.Trim() + "'," +
                                    "Width = '" + widthtextBox.Text.Trim() + "'," +
                                    "Height = '" + heighttextBox.Text.Trim() + "'," +
                                    "IsBundle = '" + checkBox1.Checked + "'," +
                                    "Weight = '" + weighttextBox.Text.Trim() + "',DiscountPercentage = '" + discountpercentagetxtbox.Text.Trim() + "',COO = '" + cootxtbox.Text + "'" +
                                    "MFR = '" + mfrtextBox.Text.Trim() + "',HSCode = '" + hscodetxtbox.Text + "',SecondMFr = '" + secondmfrtxtbox.Text + "'" +
                                    " WHERE ProductID = " + productid.Text + "";
                            DeleteBundleData(Convert.ToInt32(productid.Text));
                            AddDataToDatabase(Convert.ToInt32(productid.Text), productcodelbl.Text);

                        }

                        bool result = DatabaseAccess.Update(query);
                        if (result)
                        {
                            MessageBox.Show("Item Updated Successfully!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Something is wrong.");
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

                    if (stockalerttxtbox.Text.Trim().Length == 0)
                    {
                        errorProvider.SetError(stockalerttxtbox, "Please Enter Stock Alert.");
                        stockalerttxtbox.Focus();
                        return;
                    }

                    string title = nametxtbox.Text;
                    string includes = includestxtbox.Text;

                    if (title.Contains("'") || title.Contains("\""))
                    {
                        title = Regex.Replace(title, @"[""']", "");
                    }

                    if (includes.Contains("'") || includes.Contains("\""))
                    {
                        includes = Regex.Replace(includes, @"[""']", "");
                    }

                    string productcode = Guid.NewGuid().ToString();

                    string query = string.Format("SELECT ProductName,UPC,MFR FROM ProductTable WHERE MFR = '" + mfrtextBox.Text.Trim() + "' AND UPC = '" + upctextBox.Text + "' " +
                        "AND ProductName = '" + nametxtbox.Text + "'");
                    DataTable dt = DatabaseAccess.Retrive(query);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Item Exist Already");
                        }
                        else
                        {
                            query = "INSERT INTO ProductTable (ProductName,SaleUnitPrice,LowestPrice,WholeSalePrice," +
                                        "StandardPrice,StockTrasholdQty,CreatedAt,CreatedDay,UPC,EAN,Length,Width,Height," +
                                        "Weight,MFR,ProductCode,Barcode,DiscountPercentage,IsBundle,HSCode,SecondMFr,COO) VALUES " +
                                        "('" + title + "'," +
                                        "'" + salepricetxtbox.Text.Trim() + "'," +
                                        "'" + lowestpricetxtbox.Text.Trim() + "','" + wholesalepricetxtbox.Text.Trim() + "','" + standardpricetxtbox.Text.Trim() + "'," +
                                        "'" + stockalerttxtbox.Text.Trim() + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                        "'" + DateTime.Now.DayOfWeek + "','" + upctextBox.Text.Trim() + "'," +
                                        "'" + eantextBox.Text.Trim() + "','" + lengthtextBox.Text.Trim() + "','" + widthtextBox.Text.Trim() + "'," +
                                        "'" + heighttextBox.Text.Trim() + "','" + weighttextBox.Text.Trim() + "'," +
                                        "'" + mfrtextBox.Text.Trim() + "','" + productcode + "','" + randomNumber + "','" + discountpercentagetxtbox.Text.Trim() + "'," +
                                        "'" + checkBox1.Checked + "','" + hscodetxtbox.Text + "','" + secondmfrtxtbox.Text + "','"+cootxtbox.Text+"'); SELECT SCOPE_IDENTITY();";

                            int result = DatabaseAccess.InsertId(query);
                            if (result > 0)
                            {
                                AddDataToDatabase(result, productcode);
                                MessageBox.Show("Item Added Successfully!");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong");
                            }
                        }
                    }
                    else
                    {
                        query = "INSERT INTO ProductTable (ProductName,SaleUnitPrice,LowestPrice,WholeSalePrice," +
                                "StandardPrice,StockTrasholdQty,CreatedAt,BrandID,CreatedDay,UPC,EAN,Length,Width,Height,Weight,MFR," +
                                "ProductCode,Barcode,DiscountPercentage,IsBundle,HSCode,SecondMFr,COO) VALUES " +
                                "('" + title + "'," +
                                "'" + salepricetxtbox.Text.Trim() + "'," +
                                "'" + lowestpricetxtbox.Text.Trim() + "','" + wholesalepricetxtbox.Text.Trim() + "','" + standardpricetxtbox.Text.Trim() + "'," +
                                "'" + stockalerttxtbox.Text.Trim() + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                "'" + DateTime.Now.DayOfWeek + "','" + upctextBox.Text.Trim() + "'," +
                                "'" + eantextBox.Text.Trim() + "','" + lengthtextBox.Text.Trim() + "','" + widthtextBox.Text.Trim() + "','" + heighttextBox.Text.Trim() + "'," +
                                "'" + weighttextBox.Text.Trim() + "'," +
                                "'" + mfrtextBox.Text.Trim() + "','" + productcode + "','" + randomNumber + "','" + discountpercentagetxtbox.Text.Trim() + "'," +
                                "'" + checkBox1.Checked + "','" + hscodetxtbox.Text + "','" + secondmfrtxtbox.Text + "','"+cootxtbox.Text+"'); SELECT SCOPE_IDENTITY();";

                        int result = DatabaseAccess.InsertId(query);
                        if (result > 0)
                        {
                            AddDataToDatabase(result,productcode);
                            MessageBox.Show("Item Added Successfully!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Something is wrong");
                        }
                    }
                }
                
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        private void FindRecord(int productid)
        {
            try
            {
                bool isChecked = false;
                string query = string.Format("SELECT ProductID,ProductName,ProductCode,SaleUnitPrice,LowestPrice,WholeSalePrice,StandardPrice," +
                    "StockTrasholdQty,StockCode,CompanyID,UPC,EAN,Length,Width,Height" +
                    ",Weight,MFR,Barcode,ProductCode,DiscountPercentage,IsBundle,HSCode,SecondMFr,COO FROM ProductTable WHERE ProductID = " + productid + "");
                DataTable dataTable = new DataTable();
                dataTable = DatabaseAccess.Retrive(query);

                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
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

                        if(isChecked != false)
                        {
                            checkBox1.Checked = isChecked;
                            FillBundleDataGridView(productid);
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
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void FillBundleDataGridView(int productid)
        {
            try
            {
                string querybundle = "SELECT IncludeItem FROM ProductBundleTable WHERE ProductId = '"+productid+"'";
                DataTable bundledata = DatabaseAccess.Retrive(querybundle);
                if (bundledata != null)
                {
                    if (bundledata.Rows.Count > 0)
                    {
                        includestxtbox.Text = bundledata.Rows[0]["IncludeItem"].ToString();
                    }
                }

            }
            catch (Exception ex) { throw ex; }
        }
        private void CreateProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }
        private void CreateProduct_Load(object sender, EventArgs e)
        {
            string labeldata = productid.Text;
            if(labeldata != "productid")
            {
                savebtn.Text = "Update";
                FindRecord(Convert.ToInt32(productid.Text));
            }
            else
            {
                GenerateBarcode();
            }
        }
        private void GenerateBarcode()
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
                DataTable dt = DatabaseAccess.Retrive(query);
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
        private void AddDataToDatabase(int productid,string productcode)
        {
            try
            {
                if(includestxtbox.Text.Trim().Length > 0)
                {
                    string addquery = "INSERT INTO ProductBundleTable (ProductId,IncludeItem,ProductCode,CreatedAt,CreatedDay) " +
                            "VALUES ('" + productid + "','" + includestxtbox.Text.Trim() + "','" + productcode + "'," +
                            "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "')";
                    DatabaseAccess.Insert(addquery);
                }
            }catch (Exception ex) { throw ex; }
        }
        private void DeleteBundleData(int productid)
        {
            try
            {
                string delbundlequery = "DELETE FROM ProductBundleTable WHERE ProductId = '"+productid+"'";
                DatabaseAccess.Delete(delbundlequery);

            }catch (Exception ex) { throw ex; }
        }
        private void nametxtbox_TextChanged(object sender, EventArgs e)
        {
            nametxtbox.Text = nametxtbox.Text.Replace(Environment.NewLine, " ");
        }
    }
}
