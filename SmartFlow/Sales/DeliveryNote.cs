using System;
using System.Windows.Forms;

namespace SmartFlow.Sales
{
    public partial class DeliveryNote : Form
    {
        public DeliveryNote()
        {
            InitializeComponent();
        }

        private void DeliveryNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                    this.Close();
                    e.Handled = true;
            }
        }
    }
}
