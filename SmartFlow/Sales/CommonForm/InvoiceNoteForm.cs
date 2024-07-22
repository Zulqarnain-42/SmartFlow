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

namespace SmartFlow.Sales
{
    public partial class InvoiceNoteForm : Form
    {
        private DateTime lastEnterPressTime;
        private const int doubleEnterThreshold = 500; // Time in milliseconds
        public InvoiceNoteForm()
        {
            InitializeComponent();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(specialnotestxtbox.Text) && !string.IsNullOrWhiteSpace(specialnotestxtbox.Text))
                {
                    GlobalVariables.invoicespecialnote = specialnotestxtbox.Text;
                }
                this.Close();

            }catch(Exception ex) { throw ex; }
        }
        private void InvoiceNoteForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Enter) 
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan timeDiff = currentTime - lastEnterPressTime;

                if (timeDiff.TotalMilliseconds <= doubleEnterThreshold)
                {
                    // Double Enter detected
                    savebtn.Focus();
                    lastEnterPressTime = DateTime.MinValue; // Reset to prevent multiple triggers
                }
                else
                {
                    // First Enter press detected
                    lastEnterPressTime = currentTime;
                }

                e.Handled = true; // Prevent the beep sound on Enter key press
                e.SuppressKeyPress = true; // Prevent the beep sound on Enter key press
            }
        }
    }
}
