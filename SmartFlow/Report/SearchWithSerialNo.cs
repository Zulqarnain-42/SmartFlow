﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Report
{
    public partial class SearchWithSerialNo : Form
    {
        public SearchWithSerialNo()
        {
            InitializeComponent();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {

        }

        private void SearchWithSerialNo_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now; // Current date and time
            DateTime startOfYear = new DateTime(now.Year, 1, 1);
            invoicedatetxtbox.Text = startOfYear.ToString("dd/MM/yyyy");
            invoicedatetotxtbox.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
