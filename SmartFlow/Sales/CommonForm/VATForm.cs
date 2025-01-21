using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Sales.CommonForm
{
    public partial class VATForm : Form
    {
        private int _itemqty = 0;
        private float _vatPercentage = 0;
        private float _discount = 0;
        private bool _ispurchase = false;
        public VATForm(int itemQty,bool ispurchaseform)
        {
            InitializeComponent();
            _itemqty = itemQty;
            _ispurchase = ispurchaseform;
        }
        private async void VATForm_Load(object sender, EventArgs e)
        {
            // Format and display VAT and Discount
            vattxtbox.Text = _vatPercentage.ToString("N2");
            discounttxtbox.Text = _discount.ToString("N2");

            // Show or hide cost price fields based on the purchase condition
            costpricelbl.Visible = _ispurchase;
            costpricetxtbox.Visible = _ispurchase;

            // Fill unit data for the combo box
            await CommonFunction.FillUnitDataAsync(unitcombobox);

        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessProductDetails();
            }
            catch (Exception ex)
            {
                // Log the exception (optional, depending on your logging framework)
                // For example: Logger.LogError(ex);

                // Show an error message to the user (if appropriate)
                MessageBox.Show("An error occurred while processing product details. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Optionally rethrow the exception or handle it differently
                // throw; // Rethrow if needed, or you can skip throwing if not necessary
            }
        }

        private void ProcessProductDetails()
        {
            // Clear previous errors
            errorProvider.Clear();

            // Validate VAT
            if (!ValidateVat(out float vat))
                return;

            // Validate Unit Selection
            if (!ValidateComboBoxSelection(unitcombobox, "Please Select Unit."))
                return;

            // Validate fields specific to purchase
            if (_ispurchase && !ValidatePurchaseFields())
                return;

            // Assign VAT-related global variables if VAT is entered
            if (vat > 0)
            {
                AssignVatGlobalVariables(vat);
            }

            // Assign Unit-related global variables
            /*GlobalVariables.unitidglobal = Convert.ToInt32(unitcombobox.SelectedValue);*/
            AssignPurchasePriceGlobalVariables();

            // Assign Length and Description global variables
            AssignLengthAndDescriptionGlobalVariables();

            // Retrieve and assign Unit Name
            AssignUnitNameGlobalVariable();

            // Process Discount if applicable
            ProcessDiscount();

            // Calculate and assign final total
            AssignFinalTotal();

            // Close the form after processing
            this.Close();
        }

        private bool ValidateVat(out float vat)
        {
            vat = 0;
            if (!string.IsNullOrWhiteSpace(vattxtbox.Text))
            {
                if (!float.TryParse(vattxtbox.Text, out vat))
                {
                    errorProvider.SetError(vattxtbox, "Invalid VAT value.");
                    vattxtbox.Focus();
                    return false;
                }
            }

            if (vat == 0 && !novatchkbox.Checked)
            {
                errorProvider.SetError(vattxtbox, "Please Enter VAT.");
                vattxtbox.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateComboBoxSelection(ComboBox comboBox, string errorMessage)
        {
            if (comboBox.SelectedIndex == 0)
            {
                errorProvider.SetError(comboBox, errorMessage);
                comboBox.Focus();
                return false;
            }
            return true;
        }

        private bool ValidatePurchaseFields()
        {
            if (!ValidateTextBox(costpricetxtbox, "Please Enter Cost Price."))
            {
                return false;
            }
            return true;
        }

        private bool ValidateTextBox(TextBox textBox, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider.SetError(textBox, errorMessage);
                textBox.Focus();
                return false;
            }
            return true;
        }

        private void AssignVatGlobalVariables(float vat)
        {
            GlobalVariables.productitemwisevatpercentage = decimal.Parse(vattxtbox.Text);
            GlobalVariables.productitemwisevatamount = decimal.Parse(vatamountlbl.Text);
            GlobalVariables.producttotalwithvatitemwise = decimal.Parse(totalwithvatlbl.Text);
        }

        private void AssignPurchasePriceGlobalVariables()
        {
            if (_ispurchase)
            {
                GlobalVariables.productcostprice = decimal.Parse(costpricetxtbox.Text);
            }

            if (!lengthinmetertxtbox.Visible)
            {
                GlobalVariables.productpriceglobal = float.Parse(pricetxtbox.Text);
            }
            else
            {
                GlobalVariables.productinmeterprice = decimal.Parse(pricetxtbox.Text);
                GlobalVariables.productpriceglobal = float.Parse(label6.Text) / _itemqty;
            }
        }

        private void AssignLengthAndDescriptionGlobalVariables()
        {
            GlobalVariables.productinmeterlength = decimal.TryParse(lengthinmetertxtbox.Text, out var length) ? length : 0;
            GlobalVariables.productitemwisedescriptiongloabl = itemdescriptiontxtbox.Text.Trim().ToUpper();
        }

        private async void AssignUnitNameGlobalVariable()
        {
            string query = $"SELECT UnitName FROM UnitTable WHERE UnitID = '{GlobalVariables.unitidglobal}'";
            DataTable unitData = await DatabaseAccess.RetriveAsync(query);

            if (unitData != null && unitData.Rows.Count > 0)
            {
                GlobalVariables.unitnameglobal = unitData.Rows[0]["UnitName"].ToString();
            }
        }

        private void ProcessDiscount()
        {
            if (fixedamountradio.Checked || percentageradio.Checked)
            {
                GlobalVariables.isproductdiscounted = true;
                GlobalVariables.productdiscounttype = percentageradio.Checked;
                GlobalVariables.discountpercentage = float.Parse(discounttxtbox.Text);
                GlobalVariables.productdiscountamountitemwise = decimal.TryParse(discountamountlbl.Text, out var discountAmount) ? discountAmount : 0;
            }
        }

        private void AssignFinalTotal()
        {
            decimal total = decimal.TryParse(totalwithvatanddiscountlbl.Text, out var finalTotal) ? finalTotal : 0;
            GlobalVariables.productfinalamountwithvatanddiscountitemwise = total > 0 ? total : decimal.Parse(label6.Text);
        }

        private void vattxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for a valid character (digits, control characters, and the decimal point)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void discounttxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for a valid character (digits, control characters, and the decimal point)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void fixedamountradio_CheckedChanged(object sender, EventArgs e)
        {
            if (fixedamountradio.Checked)
            {
                discounttxtbox.Enabled = true;
            }
            else
            {
                discounttxtbox.Enabled = false;
            }
        }
        private void percentageradio_CheckedChanged(object sender, EventArgs e)
        {
            if (percentageradio.Checked)
            {
                discounttxtbox.Enabled = true;
            }
            else
            {
                discounttxtbox.Enabled = false;
            }
        }
        private void discounttxtbox_TextChanged(object sender, EventArgs e)
        {
            CalculateDiscountedTotal();
        }

        private void CalculateDiscountedTotal()
        {
            decimal finalAmount;

            // Try parsing VAT total, fallback to label6.Text if not available
            bool isAmountWithoutVatParsed = decimal.TryParse(label6.Text, out decimal amountWithoutVat);

            bool isDiscountTotalParsed = decimal.TryParse(discounttxtbox.Text, out decimal discountTotal);
            if (!isDiscountTotalParsed)
            {
                MessageBox.Show("Invalid discount value.");
                return;  // Exit if parsing fails
            }

            if (fixedamountradio.Checked)
            {
                // Fixed amount discount
                discountamountlbl.Text = discountTotal.ToString("N2");
                discountamountlbl.Visible = true;

                // Calculate final amount after discount
                finalAmount = amountWithoutVat - discountTotal;
                totalwithvatanddiscountlbl.Text = finalAmount.ToString("N2");
                totalamountafterdiscount.Text = finalAmount.ToString("N2");
            }
            else
            {
                // Percentage-based discount
                if (discountTotal < 0 || discountTotal > 100)
                {
                    MessageBox.Show("Discount percentage must be between 0 and 100.");
                    return;  // Exit if discount percentage is invalid
                }

                decimal discountAmount = amountWithoutVat * (discountTotal / 100);
                discountamountlbl.Text = discountAmount.ToString("N2");
                discountamountlbl.Visible = true;

                // Calculate final amount after discount
                finalAmount = amountWithoutVat - discountAmount;
                totalwithvatanddiscountlbl.Text = finalAmount.ToString("N2");
                totalamountafterdiscount.Text = finalAmount.ToString("N2");
            }

            // Calculate total with VAT (if required)
            CalculateTotalWithVAT();

            // Ensure total labels are visible
            totalwithvatanddiscountlbl.Visible = true;

        }

        private void vattxtbox_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalWithVAT();
        }

        private void CalculateTotalWithVAT()
        {
            // Initialize variables for price and VAT rate
            decimal price = 0;
            decimal vatRate = 0;

            // Attempt to parse price from totalamountafterdiscount
            bool isPriceParsed = decimal.TryParse(totalamountafterdiscount.Text, out price);
            // Fallback to label6.Text if totalamountafterdiscount is invalid or <= 0
            if (!isPriceParsed || price <= 0)
            {
                isPriceParsed = decimal.TryParse(label6.Text, out price);
            }

            // Attempt to parse VAT rate
            bool isVatRateParsed = decimal.TryParse(vattxtbox.Text, out vatRate);

            if (!isPriceParsed || price <= 0)
            {
                // Show error message if price is invalid
                errorProvider.SetError(totalamountafterdiscount, "Invalid price value. Please check your inputs.");
                return;
            }

            if (!isVatRateParsed || vatRate < 0 || vatRate > 100)
            {
                // Show error message if VAT rate is invalid
                errorProvider.SetError(vattxtbox, "Invalid VAT percentage. Please enter a value between 0 and 100.");
                return;
            }

            // Clear previous errors if inputs are valid
            errorProvider.Clear();

            // Calculate VAT amount and total with VAT
            decimal vatAmount = price * (vatRate / 100);
            decimal totalAmountWithVat = price + vatAmount;

            // Update labels
            vatamountlbl.Text = vatAmount.ToString("N2");
            vatamountlbl.Visible = true;

            totalwithvatlbl.Text = totalAmountWithVat.ToString("N2");
            totalwithvatlbl.Visible = true;

            totalwithvatanddiscountlbl.Text = totalAmountWithVat.ToString("N2");
            totalwithvatanddiscountlbl.Visible = true;

        }

        private void novatchkbox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                float vat = 0;

                // Parse VAT value only if the TextBox is not empty
                if (!string.IsNullOrWhiteSpace(vattxtbox.Text))
                {
                    // Try parsing the value, and handle invalid input
                    if (!float.TryParse(vattxtbox.Text, out vat))
                    {
                        errorProvider.SetError(vattxtbox, "Invalid VAT value. Please enter a valid number.");
                        return;
                    }
                }

                // Set VAT TextBox value to the formatted percentage if VAT is greater than 0
                if (vat > 0)
                {
                    vattxtbox.Text = _vatPercentage.ToString("N2");
                }

                // Enable or disable the VAT TextBox based on the checkbox state
                vattxtbox.Enabled = !novatchkbox.Checked;

                // Clear any previous error
                errorProvider.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pricepermetertxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for a valid character (digits, control characters, and the decimal point)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void lengthinmetertxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for a valid character (digits, control characters, and the decimal point)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void serialnotxtbox_TextChanged(object sender, EventArgs e)
        {
            itemdescriptiontxtbox.Text.ToUpper();
        }

        private void unitcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GlobalVariables.unitidglobal = unitcombobox.SelectedValue != null
                    && int.TryParse(unitcombobox.SelectedValue.ToString(), out int value) ? value : 0;

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
                    throw new InvalidOperationException("No valid item selected in the Unit ComboBox.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pricetxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                // Check if a valid item is selected in the ComboBox
                if (unitcombobox.SelectedItem is DataRowView selectedRow)
                {
                    string unitName = selectedRow["UnitName"]?.ToString() ?? string.Empty;

                    // Validate and process the price for non-METER units
                    if (!unitName.Equals("METER", StringComparison.OrdinalIgnoreCase))
                    {
                        if (float.TryParse(pricetxtbox.Text, out float price))
                        {
                            if (price <= 0)
                            {
                                throw new ArgumentException("Price must be greater than 0.");
                            }

                            // Calculate and update the total price
                            float totalPrice = _itemqty * price;
                            label6.Text = totalPrice.ToString("0.00");
                            label6.Visible = true;
                            label1.Visible = true;

                            // Update total with VAT and discount
                            if (float.TryParse(vattxtbox.Text, out float vatRate) && vatRate >= 0)
                            {
                                float vatAmount = totalPrice * (vatRate / 100);
                                float totalWithVat = totalPrice + vatAmount;

                                // Check for discount and calculate the final total
                                if (float.TryParse(discounttxtbox.Text, out float discount) && discount >= 0)
                                {
                                    float discountAmount = discount <= 100 ? totalWithVat * (discount / 100) : discount;
                                    float totalWithVatAndDiscount = totalWithVat - discountAmount;

                                    // Update the respective labels
                                    totalwithvatanddiscountlbl.Text = totalWithVatAndDiscount.ToString("0.00");
                                    totalwithvatanddiscountlbl.Visible = true;
                                }
                                else
                                {
                                    throw new ArgumentException("Invalid discount value.");
                                }
                            }
                            else
                            {
                                throw new ArgumentException("Invalid VAT value.");
                            }
                        }
                        else
                        {
                            throw new FormatException("Invalid price entered. Please enter a valid numeric value.");
                        }
                    }
                    else
                    {
                        // Handle the "METER" case or any other scenarios separately if needed
                        throw new InvalidOperationException("Unit is set to 'METER'. This operation is not applicable.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("No valid item is selected in the Unit ComboBox.");
                }
            }
            catch (Exception ex)
            {
                // Log or show the error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Optionally, reset the affected fields
                label6.Text = "0.00";
                totalwithvatanddiscountlbl.Text = "0.00";
                label6.Visible = true;
                totalwithvatanddiscountlbl.Visible = true;
            }

        }

        private void lengthinmetertxtbox_Leave(object sender, EventArgs e)
        {
            try
            {
                // Ensure the necessary textboxes are filled
                if (string.IsNullOrWhiteSpace(pricetxtbox.Text))
                    throw new ArgumentException("Price is required and cannot be empty.");
                if (string.IsNullOrWhiteSpace(lengthinmetertxtbox.Text))
                    throw new ArgumentException("Length in meters is required and cannot be empty.");

                // Parse and validate input values
                if (!float.TryParse(pricetxtbox.Text, out float price) || price <= 0)
                    throw new FormatException("Invalid price. Please enter a valid positive number.");
                if (!float.TryParse(lengthinmetertxtbox.Text, out float lengthInMeters) || lengthInMeters <= 0)
                    throw new FormatException("Invalid length in meters. Please enter a valid positive number.");
                if (_itemqty <= 0)
                    throw new ArgumentException("Quantity must be greater than 0.");

                // Calculate the total price
                float totalPrice = _itemqty * price * lengthInMeters;
                label6.Text = totalPrice.ToString("N2");
                label6.Visible = true;
                label1.Visible = true;

                // Update total with VAT and discount
                if (float.TryParse(vattxtbox.Text, out float vatRate) && vatRate >= 0)
                {
                    float vatAmount = totalPrice * (vatRate / 100);
                    float totalWithVat = totalPrice + vatAmount;

                    // Handle discount
                    if (float.TryParse(discounttxtbox.Text, out float discount) && discount >= 0)
                    {
                        float discountAmount = discount <= 100 ? totalWithVat * (discount / 100) : discount;
                        float totalWithVatAndDiscount = totalWithVat - discountAmount;

                        // Update labels
                        totalwithvatanddiscountlbl.Text = totalWithVatAndDiscount.ToString("N2");
                        totalwithvatanddiscountlbl.Visible = true;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid discount value. Please provide a valid discount.");
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid VAT value. Please provide a valid VAT percentage.");
                }
            }
            catch (Exception ex)
            {
                // Display error message
                MessageBox.Show($"Error: {ex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Reset fields if necessary
                label6.Text = "0.00";
                totalwithvatanddiscountlbl.Text = "0.00";
                label6.Visible = true;
                totalwithvatanddiscountlbl.Visible = true;
            }

        }
    }
}
