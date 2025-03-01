using ExcelDataReader;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using static System.Windows.Forms.AxHost;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace SmartFlow.Masters
{
    public partial class ExcelAccounts : Form
    {
        DataTableCollection tableCollection;
        public ExcelAccounts()
        {
            InitializeComponent();
        }

        private void selectfilebtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
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
                                    sheetCombo.Items.Clear();
                                    foreach (DataTable table in tableCollection)
                                    {
                                        sheetCombo.Items.Add(table.TableName);
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        static bool IsProcessOpen(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void selectAccounttxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountGroupSelection));
                if (openForm == null)
                {
                    AccountGroupSelection selectionForm = new AccountGroupSelection
                    {
                        WindowState = FormWindowState.Normal,
                        StartPosition = FormStartPosition.CenterScreen,
                    };

                    selectionForm.AccountDataSelected += UpdateAccountInfo;
                    CommonFunction.DisposeOnClose(selectionForm);
                    selectionForm.ShowDialog();
                }
                else
                {
                    openForm.BringToFront();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async void UpdateAccountInfo(object sender, AccountData e)
        {
            try
            {
                // Simulate some async work (e.g., fetching additional data or processing)
                await Task.Run(() =>
                {
                    // Perform any long-running or async operations here (if needed)
                    // For example, querying a database, calling an API, etc.

                    int accountid = e.AccountId;
                    string accountname = e.AccountName;
                    int accountheadid = e.AccountHeadId;

                    // If you need to update UI controls, ensure that it's done on the UI thread
                    // If you update textboxes, labels, etc., do it like this:
                    this.Invoke(new Action(() =>
                    {
                        // Assuming these are TextBox controls
                        accountgroupidlabel.Text = accountid.ToString();
                        selectAccounttxtbox.Text = accountname.ToString();
                        accountheadidlbl.Text = accountheadid.ToString();
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

        private void sheetCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[sheetCombo.SelectedItem.ToString()];
            dataGridViewExcel.DataSource = dt;
        }

        private async void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                string accountCode = string.Empty; 
                if (selectAccounttxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectAccounttxtbox,"Please Select Account.");
                    selectAccounttxtbox.Focus();
                    return;
                }

                int accountgroupid = Convert.ToInt32(accountgroupidlabel.Text);
                string accountgroupName = selectAccounttxtbox.Text;
                bool result = false;

                foreach (DataGridViewRow row in dataGridViewExcel.Rows)
                {
                    if (accountgroupName == "Customers" || accountgroupName == "Reseller")
                    {
                        string initialize = "CU";
                        accountCode = await GenerateRandomAccountCode(initialize);
                    }
                    else if (accountgroupName == "Suppliers")
                    {
                        string initialize = "SU";
                        accountCode = await GenerateRandomAccountCode(initialize);
                    }

                    if (!row.IsNewRow)
                    {
                        string accountname = row.Cells[0].Value.ToString();
                        string guidcode = Guid.NewGuid().ToString();
                        string getaccounthead = "SELECT AccountControlID,AccountControlName,AccountHead_ID,AccountControlCode,Alias FROM AccountControlTable " +
                        "WHERE AccountControlID = '" + accountgroupid + "'";

                        DataTable accountcontrol = await DatabaseAccess.RetriveAsync(getaccounthead);
                        if (accountcontrol != null)
                        {
                            if (accountcontrol.Rows.Count > 0)
                            {
                                int accountHeadID = 0;
                                foreach (DataRow rowhead in accountcontrol.Rows)
                                {
                                    accountHeadID = Convert.ToInt32(rowhead["AccountHead_ID"]);
                                }

                                string query = "INSERT INTO AccountSubControlTable (AccountHead_ID,AccountControl_ID,AccountSubControlName,AccountSubControlCode,CreatedAt," +
                                "CreatedDay,CodeAccount) VALUES ('" + accountHeadID + "','" + accountgroupid + "','" + accountname + "'," +
                                "'" + Guid.NewGuid() + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") + "','" + DateTime.Now.DayOfWeek + "','" + accountCode + "'); " +
                                "SELECT SCOPE_IDENTITY();";
                                string tableName = "AccountSubControlTable";

                                var columnData = new Dictionary<string, object>
                                {
                                    { "AccountHead_ID", accountHeadID },
                                    { "AccountControl_ID", accountgroupid },
                                    { "AccountSubControlName", accountname },
                                    { "AccountSubControlCode", guidcode },
                                    { "CreatedAt", DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss") },
                                    { "CreatedDay", DateTime.Now.DayOfWeek.ToString() },
                                    { "CodeAccount", accountCode }
                                };

                                // Assuming ExecuteQueryAsync is an asynchronous method for executing the query
                                bool isInserted = await DatabaseAccess.ExecuteQueryAsync(tableName, "INSERT", columnData);
                            }
                        }
                    }
                }
                if (result)
                {
                    MessageBox.Show("Saved Successfully.");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        static async Task<string> GenerateRandomAccountCode(string intializer)
        {
            Random random = new Random();
            const string chars = "0123456789";
            char[] serialChars = new char[6];

            for (int i = 0; i < serialChars.Length; i++)
            {
                serialChars[i] = chars[random.Next(chars.Length)];
            }

            string serialNumber = new string(serialChars);
            string query = "SELECT CodeAccount FROM AccountSubControlTable WHERE CodeAccount = '" + serialNumber + "'";
            DataTable dt = await DatabaseAccess.RetriveAsync(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    serialNumber = await GenerateRandomAccountCode(intializer);
                }
            }
            return serialNumber = String.Concat(intializer, serialNumber); ;
        }
    }
}
