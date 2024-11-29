using System;
using System.Windows.Forms;

namespace SmartFlow.Transactions
{
    public partial class FindTransactionForm : Form
    {
        public FindTransactionForm()
        {
            InitializeComponent();
        }
        private void FindTransactionForm_Load(object sender, EventArgs e)
        {
            invoicedatetxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
