using DocumentFormat.OpenXml.Bibliography;
using Microsoft.IdentityModel.Tokens;
using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SmartFlow.Sales.CommonForm
{
    public partial class EditItemInvoice : Form
    {
        public delegate void DataUpdatedHandler(int rowIndex, string productmfr, string productname, int productid, int quantity, int unitid,
            string unitname, decimal price, decimal vat, decimal discount, decimal itemtotal, int warehouseid, string itemdescription,
            decimal lengthinmeter, decimal priceinmeter, decimal vatpercentage, decimal discountpercentage, bool discounttype);

        public event DataUpdatedHandler DataUpdated;

        private int _rowIndex = 0;
        private string _productmfr = string.Empty;
        private string _productname = string.Empty;
        private int _productid = 0;
        private int _quantity = 0;
        private int _unitid = 0;
        private string _unitname = string.Empty;
        private float _price = 0;
        private float _vat = 0;
        private float _discount = 0;
        private float _itemtotal = 0;
        private int _warehouseid = 0;
        private string _itemdescription = string.Empty;
        private float _lengthinmeter = 0;
        private float _priceinmeter = 0;
        private float _vatpercentage = 0;
        private float _discountpercentage = 0;
        private bool _discounttype = false;
        private bool _isPurchaseInvoice = false;

        public EditItemInvoice(int rowindex,string productmfr,string productname,int productid,int quantity,int unitid,string unitname,float price,
            float vat,float discount,float itemtotal,int warehouseid,string itemdescription,float lengthinmeter,float priceinmeter,float vatpercentage, float discountpercentage, bool discounttype, 
            bool purchaseinvoice)
        {
            InitializeComponent();
            this._rowIndex = rowindex;
            this._productmfr = productmfr;
            this._productname = productname;
            this._productid = productid;
            this._quantity = quantity;
            this._unitid = unitid;
            this._unitname = unitname;
            this._vat = vat;
            this._price = price;
            this._discount = discount;
            this._itemtotal = itemtotal;
            this._warehouseid = warehouseid;
            this._itemdescription = itemdescription;
            this._lengthinmeter = lengthinmeter;
            this._priceinmeter = priceinmeter;
            this._vatpercentage = vatpercentage;
            this._discountpercentage = discountpercentage;
            this._discounttype = discounttype;
            this._isPurchaseInvoice = purchaseinvoice;
        }

        private async void EditItemInvoice_Load(object sender, EventArgs e)
        {
            await CommonFunction.FillUnitDataAsync(unitcombobox);
            await CommonFunction.FillWarehouseDataAsync(warehousecombo);
            label1.Text = string.IsNullOrEmpty(_productmfr) ? "" : _productmfr;
            label2.Text = string.IsNullOrEmpty(_productname) ? "" : _productname;
            qtytxtbox.Text = _quantity > 0 ? _quantity.ToString() : "0";
            pricetxtbox.Text = _price > 0 ? _price.ToString("N2") : "0.00";
            lengthinmetertxtbox.Text = _lengthinmeter > 0 ? _lengthinmeter.ToString("N2") : "0.00";
            discounttxtbox.Text = _discountpercentage >= 0 ? _discountpercentage.ToString("N2") : "0.00";
            vattxtbox.Text = _vatpercentage >= 0 ? _vatpercentage.ToString("N2") : "0.00";
            itemdescriptiontxtbox.Text = string.IsNullOrEmpty(_itemdescription) ? "" : _itemdescription;

            // Handling nullable combobox values
            unitcombobox.SelectedValue = _unitid > 0 ? _unitid : (object)DBNull.Value;
            warehousecombo.SelectedValue = _warehouseid > 0 ? _warehouseid : (object)DBNull.Value;

            totalwithvatanddiscountlbl.Text = _itemtotal >= 0 ? _itemtotal.ToString("N2") : "0.00";
            unitidlbl.Text = _unitid > 0 ? _unitid.ToString() : "";
            warehouseidlbl.Text = _warehouseid > 0 ? _warehouseid.ToString() : "";
            productidlbl.Text = _productid > 0 ? _productid.ToString() : "";
            rowindexlbl.Text = _rowIndex >= 0 ? _rowIndex.ToString() : "";
            vatamountlbl.Text = _vat >= 0 ? _vat.ToString("N2") : "0.00";
            discountamtlbl.Text = _discount >= 0 ? _discount.ToString("N2") : "0.00";

            if (_discounttype)
            {
                percentageradio.Checked = true;
            }
            else
            {
                if(_discountpercentage > 0 && _discount > 0)
                {
                    fixedamountradio.Checked = true;
                    discountamtlbl.Visible = false;
                }
                else
                {
                    nodiscountradio.Checked = true;
                    discounttxtbox.Visible = false;
                    discountamtlbl.Visible = false;
                }
            }

            if(_isPurchaseInvoice == true)
            {
                warehousecombo.Visible = true;
                warehouseselectionlbl.Visible = true;
            }
            else
            {
                warehousecombo.Visible = false;
                warehouseselectionlbl.Visible = false;
            }
        }

        private void unitcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    // Ensure unitcombobox.SelectedValue is not null before parsing
                    if (unitcombobox.SelectedValue != null && int.TryParse(unitcombobox.SelectedValue.ToString(), out int value))
                    {
                        GlobalVariables.unitidglobal = value;
                    }
                    else
                    {
                        GlobalVariables.unitidglobal = 0; // Default value
                    }

                    // Ensure SelectedItem is of type DataRowView before accessing properties
                    if (unitcombobox.SelectedItem is DataRowView selectedRow)
                    {
                        string unitName = selectedRow["UnitName"]?.ToString() ?? string.Empty;

                        if (unitName.Equals("METER", StringComparison.OrdinalIgnoreCase))
                        {
                            // Configure for "METER"
                            pricelbl.Visible = true;
                            pricetxtbox.Visible = true;
                            pricelbl.Text = "PRICE PER METER";

                            lengthinmeterlbl.Visible = true;
                            lengthinmetertxtbox.Visible = true;
                        }
                        else
                        {
                            // Configure for other units
                            pricelbl.Visible = true;
                            pricetxtbox.Visible = true;
                            pricelbl.Text = "ITEM PRICE";

                            lengthinmeterlbl.Visible = false;
                            lengthinmetertxtbox.Visible = false;
                        }
                    }
                    else
                    {
                        // Handle case where SelectedItem is null or invalid
                        MessageBox.Show("Please select a valid unit from the dropdown.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        GlobalVariables.unitidglobal = 0;
                    }
                }
                catch (Exception ex)
                {
                    // Log error for debugging purposes
                    Console.WriteLine($"Error in unit selection: {ex.Message}");

                    // Show user-friendly error message
                    MessageBox.Show("An unexpected error occurred while selecting the unit. Please try again.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fixedamountradio_CheckedChanged(object sender, EventArgs e)
        {
            if (fixedamountradio.Checked) 
            {
                discounttxtbox.Visible = true;
                discountamtlbl.Visible = true;
            }
        }

        private void nodiscountradio_CheckedChanged(object sender, EventArgs e)
        {
            if (nodiscountradio.Checked)
            {
                discounttxtbox.Visible = false;
                discountamtlbl.Visible = false;
            }
        }

        private void percentageradio_CheckedChanged(object sender, EventArgs e)
        {
            if (percentageradio.Checked)
            {
                discounttxtbox.Visible= true;
                discountamtlbl.Visible= true;
            }
        }

        private void Calculate()
        {
            try
            {
                // Validate and parse quantity (should be a positive integer)
                if (!int.TryParse(qtytxtbox.Text, out int quantity) || quantity <= 0)
                {
                    ShowError("Please enter a valid positive quantity.", qtytxtbox);
                    return;
                }

                // Validate and parse price (should be non-negative)
                if (!decimal.TryParse(pricetxtbox.Text, out decimal price) || price < 0)
                {
                    ShowError("Please enter a valid price (0 or higher).", pricetxtbox);
                    return;
                }

                // Validate and parse VAT percentage (zero is allowed)
                if (!decimal.TryParse(vattxtbox.Text, out decimal vatPercentage) || vatPercentage < 0)
                {
                    ShowError("Please enter a valid VAT percentage (0 or higher).", vattxtbox);
                    return;
                }

                // Initialize discount variables
                decimal discount = 0;
                decimal discountAmount = 0;

                // Validate and parse discount
                if (!string.IsNullOrWhiteSpace(discounttxtbox.Text))
                {
                    if (!decimal.TryParse(discounttxtbox.Text, out discount) || discount < 0)
                    {
                        ShowError("Please enter a valid discount value (0 or higher).", discounttxtbox);
                        return;
                    }
                }

                // Step 1: Calculate Initial Total (without VAT)
                decimal totalWithoutVat = quantity * price;

                // Step 2: Apply Discount
                if (fixedamountradio.Checked)
                {
                    discountAmount = discount; // Fixed amount discount
                }
                else if (percentageradio.Checked)
                {
                    discountAmount = (discount / 100) * totalWithoutVat; // Percentage-based discount
                }
                decimal totalAfterDiscount = totalWithoutVat - discountAmount;

                // Step 3: Calculate VAT Amount
                decimal vatAmount = Math.Round((totalAfterDiscount * vatPercentage) / 100, 2, MidpointRounding.AwayFromZero);

                // Step 4: Calculate Final Total (Including VAT)
                decimal totalWithVat = totalAfterDiscount + vatAmount;

                // Update UI Labels
                discountamtlbl.Text = discountAmount.ToString("N2");
                vatamountlbl.Text = vatAmount.ToString("N2");
                totalwithvatanddiscountlbl.Text = totalWithVat.ToString("N2");

                // Optional: Adjust Price Based on VAT
                if (vatPercentage > 0)
                {
                    pricetxtbox.Text = Math.Round(price, 2, MidpointRounding.AwayFromZero).ToString("N2");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in calculation: {ex.Message}");
                MessageBox.Show("An error occurred while calculating the total. Please check your input and try again.",
                                "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Utility Method for Error Handling
        private void ShowError(string message, Control control)
        {
            MessageBox.Show(message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }
    


        private void qtytxtbox_Leave(object sender, EventArgs e)
        {
            Calculate();
        }

        private void pricetxtbox_Leave(object sender, EventArgs e)
        {
            Calculate();
        }

        private void discounttxtbox_Leave(object sender, EventArgs e)
        {
            Calculate();
        }

        private void vattxtbox_Leave(object sender, EventArgs e)
        {
            Calculate();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            Calculate();
            // Get updated values from controls
            // Strings: Assign empty string ("") if null or empty
            string productmfr = string.IsNullOrEmpty(label1.Text) ? "" : label1.Text;
            string productname = string.IsNullOrEmpty(label2.Text) ? "" : label2.Text;
            string unitname = string.IsNullOrEmpty(unitcombobox.Text) ? "" : unitcombobox.Text;
            string itemdescription = string.IsNullOrEmpty(itemdescriptiontxtbox.Text) ? "" : itemdescriptiontxtbox.Text;

            // Integers: Assign 0 if null, empty, or conversion fails
            int productid = int.TryParse(productidlbl.Text, out int pid) ? pid : 0;
            int quantity = int.TryParse(qtytxtbox.Text, out int qty) ? qty : 0;
            int unitid = int.TryParse(unitidlbl.Text, out int uid) ? uid : 0;
            int warehouseid = int.TryParse(warehouseidlbl.Text, out int wid) ? wid : 0;

            // Decimals: Assign 0 if null, empty, or conversion fails
            decimal price = decimal.TryParse(pricetxtbox.Text, out decimal p) ? p : 0;
            decimal vat = decimal.TryParse(vatamountlbl.Text, out decimal v) ? v : 0;
            decimal discount = decimal.TryParse(discountamtlbl.Text, out decimal d) ? d : 0;
            decimal itemtotal = decimal.TryParse(totalwithvatanddiscountlbl.Text, out decimal it) ? it : 0;
            decimal lengthinmeter = decimal.TryParse(lengthinmetertxtbox.Text, out decimal lm) ? lm : 0;
            decimal priceinmeter = decimal.TryParse(pricetxtbox.Text, out decimal pm) ? pm : 0;
            decimal vatpercentage = decimal.TryParse(vattxtbox.Text, out decimal vp) ? vp : 0;
            decimal discountpercentage = decimal.TryParse(discounttxtbox.Text, out decimal dp) ? dp : 0;

            // Boolean: Defaults to false if unchecked
            bool discounttype = percentageradio.Checked;


            // Trigger the event and pass updated data
            DataUpdated?.Invoke(_rowIndex, productmfr, productname, productid, quantity, unitid, unitname, price, vat, discount, itemtotal, 
                warehouseid, itemdescription, lengthinmeter, priceinmeter, vatpercentage, discountpercentage, discounttype);

            // Close the form
            this.Close();
        }
    }
}
