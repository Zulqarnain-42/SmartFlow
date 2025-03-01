using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFlow.Common.CommonForms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;  // Removes window border
            this.StartPosition = FormStartPosition.CenterScreen; // Centers form
            this.BackColor = Color.White;  // You can customize the background color
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Optionally, you can add a loading label or an animated control here
            Label loadingLabel = new Label
            {
                Text = "Loading, please wait...",
                Location = new Point(50, 50),
                AutoSize = true
            };
            this.Controls.Add(loadingLabel);
        }
    }
}
