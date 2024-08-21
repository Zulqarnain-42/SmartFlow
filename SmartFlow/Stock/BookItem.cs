using SmartFlow.Common;
using SmartFlow.Purchase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Stock
{
    public partial class BookItem : Form
    {
        public BookItem()
        {
            InitializeComponent();
        }
        private void BookItem_Load(object sender, EventArgs e)
        {
            startdatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            enddatetxtbox.Text = DateTime.Now.AddDays(20).ToString("dd/MM/yyyy");
        }
        private void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();

                if (invoicenotxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(invoicenotxtbox, "Please Enter Invoice No.");
                    invoicenotxtbox.Focus();
                    return;
                }
                else
                {
                    string query = string.Format("");
                    DataTable invoicedata = DatabaseAccess.Retrive(query);
                    if (invoicedata.Rows.Count > 0)
                    {

                    }
                }
            }catch(Exception ex) { throw ex; }
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if(selectwarehousetxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(selectwarehousetxtbox,"Please Select a Warehouse");
                    selectwarehousetxtbox.Focus();
                    return;
                }

                if(bookinglocationtxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(bookinglocationtxtbox,"Please Select Booking Location.");
                    bookinglocationtxtbox.Focus();
                    return;
                }

                if(importantnotestxtbox.Text.Trim().Length == 0)
                {
                    errorProvider.SetError(importantnotestxtbox,"Please Enter Description.");
                    importantnotestxtbox.Focus();
                    return;
                }

                string importantNotes = CommonFunction.CleanText(importantnotestxtbox.Text);

            }catch (Exception ex) { throw ex; }
        }
        private void selectwarehousetxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(WarehouseSelection));
            if(openForm == null)
            {

            }
            else
            {
                openForm.BringToFront();
            }
        }
        private void BookItem_KeyDown(object sender, KeyEventArgs e)
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
        private bool AreAnyTextBoxesFilled()
        {
            if (invoicenotxtbox.Text.Trim().Length > 0) { return true; }
            if (selectwarehousetxtbox.Text.Trim().Length > 0) { return true; }
            if (bookinglocationtxtbox.Text.Trim().Length > 0) { return true; }
            if (importantnotestxtbox.Text.Trim().Length > 0) { return true; }
            return false; // No TextBox is filled
        }
    }
}
