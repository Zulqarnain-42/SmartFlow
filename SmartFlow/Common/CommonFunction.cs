using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SmartFlow.Common
{
    public class CommonFunction
    {
        public static void GetSupplier(string searchvalue, DataGridView dgv)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT SupplierID [ID],SupplierName [NAME],ContactNo [MOBILE],Email [EMAIL],SupplierCode [CODE] FROM SupplierTable";
                }
                else
                {
                    query = "SELECT SupplierID [ID],SupplierName [NAME],ContactNo [MOBILE],Email [EMAIL],SupplierCode [CODE] " +
                        "FROM SupplierTable WHERE SupplierName LIKE '%" + searchvalue + "%'";
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void GetItemSerialNo(string searchvalue, int searchid, DataGridView dgv)
        {
            try
            {
                if(!string.IsNullOrEmpty(searchvalue) && !string.IsNullOrWhiteSpace(searchvalue) && searchid > 0)
                {
                    string query = string.Empty;
                    DataTable dt = new DataTable();
                    query = "SELECT SerialNOID,ProductId,SerialNo FROM SerialNoTable WHERE ProductId = '" + searchid + "' AND IsSold = '" + false + "'";
                    dt = DatabaseAccess.Retrive(query);
                    if(dt != null && dt.Rows.Count > 0)
                    {
                        dgv.DataSource = dt;
                        dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static void GetCustomer(string searchvalue, DataGridView dgv)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT CustomerID [ID],CustomerName [NAME],ContactNo [MOBILE],Email [EMAIL],CustomerCode [CODE],ContactPerson [REF] FROM CustomerTable";
                }
                else
                {
                    query = "SELECT CustomerID [ID],CustomerName [NAME],ContactNo [MOBILE],Email [EMAIL],CustomerCode [CODE],ContactPerson [REF] " +
                        "FROM CustomerTable WHERE CustomerName LIKE '%" + searchvalue + "%'";
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static void GetProduct(string searchvalue, DataGridView dgv)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if(string.IsNullOrEmpty(searchvalue) && String.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT ProductID [ID],ProductName [TITLE],StandardPrice [PRICE],UPC,EAN,MFR,Barcode [BARCODE] FROM ProductTable";
                }
                else
                {
                    query = BuildSearchQueryProduct(searchvalue);
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static void GetStockLocation(string searchvalue,DataGridView dgv) 
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT LocationID [ID],LocationName [NAME],RackNumber [RACK NUMBER] FROM LocationTable";
                }
                else
                {
                    query = "SELECT LocationID [ID],LocationName [NAME],RackNumber [RACK NUMBER] FROM LocationTable WHERE LocationName LIKE '%" + searchvalue + "%'";
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static void GetAccountInfo(string searchvalue,DataGridView dgv)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if(string.IsNullOrEmpty(searchvalue) && String.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT AccountSubControlID [ID],AccountSubControlName [ACCOUNT NAME],Email [EMAIL],MobileNo [MOBILE] FROM AccountSubControlTable";
                }
                else
                {
                    query = "SELECT AccountSubControlID [ID],AccountSubControlName [ACCOUNT NAME],Email [EMAIL],MobileNo [MOBILE] FROM AccountSubControlTable " +
                        "WHERE AccountSubControlName LIKE '%" + searchvalue + "%'";
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static void GetAccountGroupInfo(string searchvalue, DataGridView dgv)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && String.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT AccountControlID [ID],AccountControlName [Account Name],AccountHead_ID,Alias FROM AccountControlTable";
                }
                else
                {
                    query = "SELECT AccountControlID [ID],AccountControlName [Account Name],AccountHead_ID,Alias FROM AccountControlTable" +
                        "WHERE AccountControlName LIKE '%" + searchvalue + "%'";
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static void GetRoleInfo(string searchvalue, DataGridView dgv)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && String.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT RoleId [ID],RoleName [Role Name] FROM RoleTable";
                }
                else
                {
                    query = "SELECT RoleId [ID],RoleName [Role Name] FROM RoleTable" +
                        "WHERE RoleName LIKE '%" + searchvalue + "%'";
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static void GetSalesTypeInfo(string searchvalue, DataGridView dgv)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT SaleTypeID [ID],Name,Code,IsTaxable [Taxable] FROM SaleTypeTable WHERE IsActive = '" + true+"'";
                }
                else
                {
                    query = "SELECT SaleTypeID [ID],Name,Code,IsTaxable [Taxable] FROM SaleTypeTable WHERE IsActive = '" + true + "' " +
                        "AND Name LIKE '%" + searchvalue + "%'";
                }

                dt = DatabaseAccess.Retrive(query);
                if(dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static void GetPurchaseTypeInfo(string searchvalue,DataGridView dgv)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if(string.IsNullOrEmpty(searchvalue) && String.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT PurchaseTpeID [ID],Name,Code,IsTaxable [Taxable] FROM PurchaseTypeTable WHERE IsActive = '" + true + "'";
                }
                else
                {
                    query = "SELECT PurchaseTpeID [ID],Name,Code,IsTaxable [Taxable] FROM PurchaseTypeTable " +
                        "WHERE IsActive = '" + true + "' AND Name LIKE '%" + searchvalue + "%'";
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static void GetSalesManInfo(string searchvalue,DataGridView dgv)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "SELECT EmployeeID,EmployeeCode,Fullname,Email,MobileNo FROM EmployeeTable WHERE IsSalesMan = '" + true+"'";
                }
                else
                {
                    query = "SELECT EmployeeID,EmployeeCode,Fullname,Email,MobileNo FROM EmployeeTable WHERE IsSalesMan = '" + true + "' " +
                        "AND Fullname LIKE '%" + searchvalue + "%'";
                }

                dt = DatabaseAccess.Retrive(query);
                if(dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static void GetAllAccountInfo(string searchvalue, DataGridView dgv)
        {
            try
            {
                string query = string.Empty;
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(searchvalue) && string.IsNullOrWhiteSpace(searchvalue))
                {
                    query = "";
                }
                else
                {
                    query = "";
                }

                dt = DatabaseAccess.Retrive(query);
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static void GetProductQtyWarehouse(DataGridView dgv,string productmfr,int productid)
        {
            try
            {
                string getproductinventoryquery = string.Format("SELECT StockTable.WarehouseID [ID],WarehouseTable.Name [Warehouse Name]," +
                    "SUM(COALESCE(StockTable.[Quantity],0)) + COALESCE(ProductTable.Quantity, 0) + COALESCE(InvoiceDetailsTable.Quantity, 0) AS Quantity " +
                    "FROM StockTable INNER JOIN WarehouseTable ON WarehouseTable.WarehouseID = StockTable.Warehouseid " +
                    "LEFT JOIN ProductTable ON ProductTable.ProductID = StockTable.ProductID " +
                    "AND ProductTable.WarehouseID = WarehouseTable.WarehouseID " +
                    "LEFT JOIN InvoiceDetailsTable ON InvoiceDetailsTable.Productid = StockTable.ProductID " +
                    "AND InvoiceDetailsTable.Productid = ProductTable.ProductID " +
                    "AND InvoiceDetailsTable.Warehouseid = WarehouseTable.WarehouseID WHERE StockTable.ProductID = '" + productid + "' " +
                    "AND StockTable.Warehouseid IN (SELECT WarehouseID FROM WarehouseTable) " +
                    "GROUP BY StockTable.ProductID,StockTable.Warehouseid,WarehouseTable.Name,ProductTable.Quantity,InvoiceDetailsTable.Quantity " +
                    "ORDER BY StockTable.ProductID");
                
                DataTable datainventory = DatabaseAccess.Retrive(getproductinventoryquery);
                if (datainventory != null && datainventory.Rows.Count > 0) 
                {
                    dgv.DataSource = datainventory;
                    dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    string getproductopening = string.Format("SELECT ProductTable.WarehouseID [ID],WarehouseTable.Name [Warehouse Name],ProductTable.Quantity [Quantity] FROM ProductTable " +
                        "INNER JOIN WarehouseTable ON WarehouseTable.WarehouseID = ProductTable.WarehouseID WHERE ProductTable.ProductID = '" + productid + "' " +
                        "AND ProductTable.WarehouseID IN (SELECT WarehouseID FROM WarehouseTable)");

                    DataTable dataopening = DatabaseAccess.Retrive(getproductopening);

                    if(dataopening != null && dataopening.Rows.Count > 0)
                    {
                        dgv.DataSource = dataopening;
                        dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static void GetTransactionInfoProduct(DataGridView dgv,string productmfr,int productid)
        {
            try
            {
                string query = string.Format("SELECT InvoiceTable.Invoiceid [ID],InvoiceTable.InvoiceNo [Invoice No],InvoiceTable.invoicedate [Date]," +
                    "InvoiceTable.ClientID [Client ID],InvoiceTable.ClientName [Client Name],InvoiceDetailsTable.ProductName [Title],InvoiceDetailsTable.ItemSerialNo [Serial No]," +
                    "InvoiceDetailsTable.ItemWiseDiscount [Discount],InvoiceDetailsTable.ItemWiseVAT [VAT],InvoiceDetailsTable.UnitSalePrice [Price]," +
                    "InvoiceDetailsTable.MFR [MFR],InvoiceDetailsTable.Quantity [Quantity],InvoiceDetailsTable.SystemSerialNo [System Serial No] FROM InvoiceTable " +
                    "INNER JOIN InvoiceDetailsTable ON InvoiceDetailsTable.Invoicecode = InvoiceTable.InvoiceCode " +
                    "WHERE InvoiceDetailsTable.Productid = '" + productid + "' AND ClientID = '" + GlobalVariables.customeridglobal + "'");
                DataTable datatransaction = DatabaseAccess.Retrive(query);

                if(datatransaction!=null && datatransaction.Rows.Count > 0)
                {
                    dgv.DataSource= datatransaction;
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public static string BuildSearchQueryProduct(string searchTerm)
        {
            string[] terms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder queryBuilder = new StringBuilder("SELECT ProductID [ID],ProductName [TITLE],StandardPrice [PRICE],UPC,EAN,MFR,Barcode [BARCODE], (");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" + ");
                }
                queryBuilder.Append($"(CASE WHEN ProductName LIKE '%{term}%' THEN 1 ELSE 0 END)");
                queryBuilder.Append($" + (CASE WHEN MFR LIKE '%{term}%' THEN 1 ELSE 0 END)");
                queryBuilder.Append($" + (CASE WHEN UPC LIKE '%{term}%' THEN 1 ELSE 0 END)");
            }

            queryBuilder.Append(") AS RelevanceScore FROM ProductTable WHERE");

            for (int i = 0; i < terms.Length; i++)
            {
                string term = terms[i];
                if (i > 0)
                {
                    queryBuilder.Append(" AND");
                }
                queryBuilder.Append($" (ProductName LIKE '%{term}%' OR MFR LIKE '%{term}%' OR UPC LIKE '%{term}%')");
            }

            queryBuilder.Append(" ORDER BY RelevanceScore DESC");

            return queryBuilder.ToString();
        }
        public static Form IsFormOpen(Type formType)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == formType)
                {
                    return form;
                }
            }
            return null;
        }
        public static void FillCurrencyData(ComboBox combo)
        {
            try
            {
                DataTable dtCurrency = new DataTable();
                dtCurrency.Columns.Add("CurrencyId");
                dtCurrency.Columns.Add("Name");
                DataTable dt = DatabaseAccess.Retrive("SELECT CurrencyId,Name FROM CurrencyTable ORDER BY IsDefault DESC");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow currency in dt.Rows) 
                        {
                            dtCurrency.Rows.Add(currency["CurrencyId"], currency["Name"]);
                        }
                    }
                }

                combo.DataSource = dtCurrency;
                combo.ValueMember = "CurrencyId";
                combo.DisplayMember = "Name";

            }catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public static void FillUserType(ComboBox combo)
        {
            try
            {
                DataTable dtUserType = new DataTable();
                dtUserType.Columns.Add("RightId");
                dtUserType.Columns.Add("RightName");

                DataTable dt = DatabaseAccess.Retrive("SELECT RightId,RightName FROM RightsTable");

                if(dt!=null && dt.Rows.Count > 0)
                {
                    foreach(DataRow usertype in dt.Rows)
                    {
                        dtUserType.Rows.Add(usertype["RightId"], usertype["RightName"]);
                    }
                }

                combo.DataSource = dtUserType;
                combo.ValueMember = "RightId";
                combo.DisplayMember = "RightName";
            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public static void FillEmployeeData(ComboBox combo)
        {
            try
            {
                DataTable dtemployee = new DataTable();
                dtemployee.Columns.Add("AccountSubControlID");
                dtemployee.Columns.Add("AccountSubControlName");

                DataTable dt = DatabaseAccess.Retrive("SELECT AccountSubControlID,AccountSubControlName FROM AccountSubControlTable Where IsEmployee = '" + true + "'");
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow employee in dt.Rows) 
                    {
                        dtemployee.Rows.Add(employee["AccountSubControlID"], employee["AccountSubControlName"]);
                    }
                }

                combo.DataSource = dtemployee;
                combo.ValueMember = "AccountSubControlID";
                combo.DisplayMember = "AccountSubControlName";

            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static void FillUnitData(ComboBox combo)
        {
            try
            {
                DataTable dtUnit = new DataTable();
                dtUnit.Columns.Add("UnitID");
                dtUnit.Columns.Add("UnitName");

                DataTable dt = DatabaseAccess.Retrive("SELECT UnitID,UnitName FROM UnitTable ORDER BY IsDefault DESC");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow unit in dt.Rows)
                        {
                            dtUnit.Rows.Add(unit["UnitID"], unit["UnitName"]);
                        }
                    }
                }

                combo.DataSource = dtUnit;
                combo.ValueMember = "UnitID";
                combo.DisplayMember = "UnitName";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public static void ShiftFocusOnEnter(KeyEventArgs e, Control currentControl)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the "ding" sound
                var parent = currentControl.Parent;
                if (parent != null)
                {
                    // Get all controls in the parent container
                    var controls = parent.Controls.Cast<Control>()
                                        .Where(c => c.TabIndex > currentControl.TabIndex)
                                        .OrderBy(c => c.TabIndex);

                    // Focus the next control
                    var nextControl = controls.FirstOrDefault();
                    nextControl?.Focus();
                }
            }
        }

        public static void DisposeOnClose(Form form)
        {
            form.FormClosed += (sender, e) =>
            {
                form.Dispose();
            };
        }
    }
}
