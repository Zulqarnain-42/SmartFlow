using ExcelDataReader;
using SmartFlow.General;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using SmartFlow.Common;
using SmartFlow.Purchase;

namespace SmartFlow.Masters
{
    public partial class UploadExcel : Form
    {
        DataTableCollection tableCollection;
        public UploadExcel()
        {
            InitializeComponent();
        }

        private void selectfilebtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*" })
                {
                    if(openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        bool isExcelOpen = IsProcessOpen("EXCEL");

                        if (isExcelOpen)
                        {
                            MessageBox.Show("Excel is currently open.Close the file and try again.");
                        }
                        else
                        {
                            txtfilename.Text = openFileDialog.FileName;

                            using (FileStream stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                            {
                                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                                {
                                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                    {
                                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true },
                                    });

                                    tableCollection = result.Tables;
                                    comboBox2.Items.Clear();
                                    foreach (DataTable table in tableCollection)
                                    {
                                        comboBox2.Items.Add(table.TableName);
                                    }
                                }
                            }
                        }
                        
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(selectwarehousetxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousetxtbox,"Please Select Warehouse");
                    selectwarehousetxtbox.Focus();
                    return;
                }

                string query = string.Empty;
                bool result = false;
                foreach (DataGridViewRow row in dataGridViewExcel.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string mfr = Convert.ToString(row.Cells[0].Value);
                        string quantity = Convert.ToString(row.Cells[2].Value);
                        string serialnumber = Convert.ToString(row.Cells[1].Value);
                        int anynumber;
                        serialnumber = serialnumber.Replace("'", "").Replace("\"", "");
                        if (int.TryParse(quantity, out anynumber))
                        {
                            if (quantity.Length > 0)
                            {
                                query = string.Format("SELECT ProductID,ProductCode,ProductName FROM ProductTable WHERE MFR LIKE '" + mfr + "'");
                                DataTable dataTable = new DataTable();
                                dataTable = DatabaseAccess.Retrive(query);
                                var productcode = Guid.NewGuid();
                                if (dataTable != null)
                                {
                                    if (dataTable.Rows.Count > 0)
                                    {
                                        query = string.Format("INSERT INTO StockTable (ProductID,Quantity,WarehouseId,CreatedAt,CreatedDay) VALUES " +
                                            "('" + Convert.ToInt32(dataTable.Rows[0]["ProductID"]) + "'," +
                                            "'" + quantity + "','" + selectwarehousetxtbox.Text + "'," +
                                            "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                            "'" + DateTime.Now.DayOfWeek + "')");

                                        result = DatabaseAccess.Insert(query);
                                        if (result)
                                        {
                                            string query1 = string.Empty;
                                            string[] values = serialnumber.Split(';');
                                            if (string.IsNullOrEmpty(serialnumber))
                                            {
                                                int start = 0;
                                                while (start < anynumber)
                                                {
                                                    serialnumber = GenerateRandomSerialNumber();
                                                    query1 = string.Format("INSERT INTO SerialNoTable (ProductCode,SerialNo,CreatedAt,CreatedDay) " +
                                                "VALUES ('" + dataTable.Rows[0]["ProductCode"].ToString() + "','" + serialnumber + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "')");
                                                    DatabaseAccess.Insert(query1);
                                                    start++;
                                                }
                                            }
                                            else
                                            {
                                                int count = 0;
                                                foreach (string value in values)
                                                {
                                                    if (!string.IsNullOrEmpty(value))
                                                    {
                                                        count++;
                                                        string cleanedValue = value.TrimStart(',');
                                                        if (cleanedValue.Length > 0)
                                                        {
                                                            query1 = string.Format("INSERT INTO SerialNoTable (ProductCode,SerialNo,CreatedAt,CreatedDay) " +
                                                        "VALUES ('" + dataTable.Rows[0]["ProductCode"].ToString() + "','" + cleanedValue + "'," +
                                                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                                        "'" + DateTime.Now.DayOfWeek + "')");
                                                            DatabaseAccess.Insert(query1);
                                                        }
                                                    }
                                                }

                                                int diff = anynumber - count;

                                                if (diff > 0)
                                                {
                                                    int start = 0;
                                                    while (start < diff)
                                                    {
                                                        serialnumber = GenerateRandomSerialNumber();
                                                        query1 = string.Format("INSERT INTO SerialNoTable (ProductCode,SerialNo,CreatedAt,CreatedDay) " +
                                                    "VALUES ('" + dataTable.Rows[0]["ProductCode"].ToString() + "','" + serialnumber + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "')");
                                                        DatabaseAccess.Insert(query1);
                                                        start++;
                                                    }
                                                }
                                            }

                                        }
                                    }
                                    else
                                    {
                                        
                                        query = string.Format("INSERT INTO ProductTable (ProductCode,UPC,MFR,ProductName,CreatedAt,CreatedDay) " +
                                            "VALUES ('{0}','{1}','{2}','{3}','{4}')", productcode , quantity, mfr, serialnumber, DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"),
                                            DateTime.Now.DayOfWeek);
                                        result = DatabaseAccess.Insert(query);
                                        if (result)
                                        {
                                            MessageBox.Show("Done");
                                            string query1 = string.Empty;
                                            string[] values = serialnumber.Split(';');
                                            if (string.IsNullOrEmpty(serialnumber))
                                            {
                                                int start = 0;
                                                while (start < anynumber)
                                                {
                                                    serialnumber = GenerateRandomSerialNumber();
                                                    query1 = string.Format("INSERT INTO SerialNoTable (ProductCode,SerialNo,CreatedAt,CreatedDay) " +
                                                "VALUES ('" + productcode + "','" + serialnumber + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                                "'" + DateTime.Now.DayOfWeek + "')");
                                                    DatabaseAccess.Insert(query1);
                                                    start++;
                                                }
                                            }
                                            else
                                            {
                                                int count = 0;
                                                foreach (string value in values)
                                                {
                                                    if (!string.IsNullOrEmpty(value))
                                                    {
                                                        count++;
                                                        string cleanedValue = value.TrimStart(',');
                                                        if (cleanedValue.Length > 0)
                                                        {
                                                            query1 = string.Format("INSERT INTO SerialNoTable (ProductCode,SerialNo,CreatedAt,CreatedDay) " +
                                                        "VALUES ('" + productcode + "','" + cleanedValue + "'," +
                                                        "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                                        "'" + DateTime.Now.DayOfWeek + "')");
                                                            DatabaseAccess.Insert(query1);
                                                        }
                                                    }
                                                }

                                                int diff = anynumber - count;

                                                if (diff > 0)
                                                {
                                                    int start = 0;
                                                    while (start < diff)
                                                    {
                                                        serialnumber = GenerateRandomSerialNumber();
                                                        query1 = string.Format("INSERT INTO SerialNoTable (ProductCode,SerialNo,CreatedAt,CreatedDay) " +
                                                    "VALUES ('" + productcode + "','" + serialnumber + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                                    "'" + DateTime.Now.DayOfWeek + "')");
                                                        DatabaseAccess.Insert(query1);
                                                        start++;
                                                    }
                                                }
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    query = string.Format("INSERT INTO ProductTable (ProductCode,Quantity,MFR,CreatedAt,CreatedDay) VALUES ('{0}','{1}','{2}','{3}','{4}')", 
                                        productcode, quantity, mfr, DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"),DateTime.Now.DayOfWeek);
                                    result = DatabaseAccess.Insert(query);
                                    if (result)
                                    {
                                        string query1 = string.Empty;
                                        string[] values = serialnumber.Split(';');
                                        if (string.IsNullOrEmpty(serialnumber))
                                        {
                                            int start = 0;
                                            while (start < anynumber)
                                            {
                                                serialnumber = GenerateRandomSerialNumber();
                                                query1 = string.Format("INSERT INTO SerialNoTable (ProductCode,SerialNo,CreatedAt,CreatedDay) " +
                                            "VALUES ('" + productcode + "','" + serialnumber + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "')");
                                                DatabaseAccess.Insert(query1);
                                                start++;
                                            }
                                        }
                                        else
                                        {
                                            int count = 0;
                                            foreach (string value in values)
                                            {
                                                if (!string.IsNullOrEmpty(value))
                                                {
                                                    count++;
                                                    string cleanedValue = value.TrimStart(',');
                                                    if (cleanedValue.Length > 0)
                                                    {
                                                        query1 = string.Format("INSERT INTO SerialNoTable (ProductCode,SerialNo,CreatedAt,CreatedDay) " +
                                                    "VALUES ('" + productcode + "','" + cleanedValue + "'," +
                                                    "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "'," +
                                                    "'" + DateTime.Now.DayOfWeek + "')");
                                                        DatabaseAccess.Insert(query1);
                                                    }
                                                }
                                            }

                                            int diff = anynumber - count;

                                            if (diff > 0)
                                            {
                                                int start = 0;
                                                while (start < diff)
                                                {
                                                    serialnumber = GenerateRandomSerialNumber();
                                                    query1 = string.Format("INSERT INTO SerialNoTable (ProductCode,SerialNo,CreatedAt,CreatedDay) " +
                                                "VALUES ('" + productcode + "','" + serialnumber + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "')");
                                                    DatabaseAccess.Insert(query1);
                                                    start++;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }

                if (result)
                {
                    MessageBox.Show("Saved Successfully!");
                }
            }
            catch(Exception ex) { throw ex; }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadExcel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = true; // Prevent further processing of the key event
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[comboBox2.SelectedItem.ToString()];
            dataGridViewExcel.DataSource = dt;
        }

        static bool IsProcessOpen(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
        }

        static string GenerateRandomSerialNumber()
        {
            Random random = new Random();
            const string chars = "0123456789";
            char[] serialChars = new char[10];

            for (int i = 0; i < serialChars.Length; i++)
            {
                serialChars[i] = chars[random.Next(chars.Length)];
            }

            string serialNumber = new string(serialChars);
            string query = "SELECT SerialNo FROM SerialNoTable WHERE SerialNo = '" + serialNumber+"'";
            DataTable dt = DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    serialNumber = GenerateRandomSerialNumber();
                }
            }
            return serialNumber;
        }

        private void UploadExcel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AreAnyTextBoxesFilled())
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Do you really want to close?",
                                                      "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancel the closing event
                }
            }
        }

        private bool AreAnyTextBoxesFilled()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return true; // At least one TextBox is filled
                }
            }
            return false; // No TextBox is filled
        }

        private void selectwarehouse_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(WarehouseSelection));
            if (openForm == null) 
            {
                WarehouseSelection warehouseSelection = new WarehouseSelection();
                warehouseSelection.ShowDialog();
            }
            else
            {
                openForm.BringToFront();
            }
        }
    }
}
