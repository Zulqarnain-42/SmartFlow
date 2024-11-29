using SmartFlow.Common;
using System;
using System.Windows.Forms;

namespace SmartFlow.Masters
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        public Employee(int employeeid)
        {
            InitializeComponent();
            this.employeeidlbl.Text = employeeid.ToString();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            dateofjoiningdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            contractexpirydate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            GlobalVariables.employeeNationalityGlobal = nationalitytxtbox.Text;
            GlobalVariables.employeeEducationGlobal = educationtxtbox.Text;
            GlobalVariables.employeedateofjoiningGlobal  = DateTime.Parse(dateofjoiningdate.Text);
            GlobalVariables.employeeDesignationGlobal = designationtxtbox.Text;
            GlobalVariables.employeeDepartmentGlobal = departmenttxtbox.Text;
            GlobalVariables.employeeContractTypeGlobal = contracttypetxtbox.Text;
            GlobalVariables.employeeContractExpiryGlobal = DateTime.Parse(contractexpirydate.Text);
        }
        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
