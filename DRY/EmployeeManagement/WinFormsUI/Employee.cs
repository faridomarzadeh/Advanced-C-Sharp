using EmployeeProcessingLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void btnIdGenerator_Click(object sender, EventArgs e)
        {
            IEmployeeProcessor employeeProcessor = new EmployeeProcessor();
            displayTextBox.Text = employeeProcessor.GenerateID(firstName.Text, lastName.Text);
        }
    }
}
