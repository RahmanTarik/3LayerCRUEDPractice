using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using _3LayerCRUEDPractice.BLL;
using _3LayerCRUEDPractice.MODEL;

namespace _3LayerCRUEDPractice
{
    public partial class EmployeeInfoForm : Form
    {
        public EmployeeInfoForm()
        {
            InitializeComponent();
        }

        private EmployeeManager manager = new EmployeeManager();
        List<Employee> employees = new List<Employee>();
        private int _employeeId = 0;
        private void saveButton_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (nameTextBox.Text != String.Empty && regNoTextBox.Text != String.Empty && designationTextBox.Text != String.Empty && addressTextBox.Text != String.Empty)
            {
                Employee aEmployee = new Employee();
                aEmployee.RegNo = regNoTextBox.Text;
                aEmployee.Name = nameTextBox.Text;
                aEmployee.Designation = designationTextBox.Text;
                aEmployee.Address = addressTextBox.Text;
                MessageBox.Show(manager.Save(aEmployee));
                LoadAllData();
                ClearText();
            }
            else
            {
                if (regNoTextBox.Text == String.Empty)
                {
                    msg = "Please Enter Your Registration Number";
                }
                else if (nameTextBox.Text == String.Empty)
                {
                    msg = "Please Enter Your Name";
                }
                else if (designationTextBox.Text == String.Empty)
                {
                    msg = "Please Enter Your Designation";
                }
                else if(addressTextBox.Text == String.Empty)
                {
                    msg = "Please Enter Your Address";
                }
                MessageBox.Show(msg);
            }
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void employeeListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (employeeListView.SelectedItems.Count >0)
            {
                ListViewItem firstSelectedListViewItem = employeeListView.SelectedItems[0];
                int employeeId = int.Parse(firstSelectedListViewItem.Text);

                Employee employee = manager.GetEmployeeById(employeeId);
                nameTextBox.Text = employee.Name;
                regNoTextBox.Text = employee.RegNo;
                designationTextBox.Text = employee.Designation;
                addressTextBox.Text = employee.Address;

                this._employeeId = employee.Id;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != String.Empty && regNoTextBox.Text != String.Empty &&
                designationTextBox.Text != String.Empty && addressTextBox.Text != String.Empty)
            {
                Employee aEmployee = new Employee();
                aEmployee.Id = _employeeId;
                aEmployee.RegNo = regNoTextBox.Text;
                aEmployee.Name = nameTextBox.Text;
                aEmployee.Designation = designationTextBox.Text;
                aEmployee.Address = addressTextBox.Text;
                MessageBox.Show(manager.Update(aEmployee));
                LoadAllData();
                ClearText();
            }
            else
            {
                MessageBox.Show("Please Select Employee");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != String.Empty && regNoTextBox.Text != String.Empty &&
                designationTextBox.Text != String.Empty && addressTextBox.Text != String.Empty)
            {
            Employee aEmployee = new Employee();
            aEmployee.Id = _employeeId;
            aEmployee.RegNo = regNoTextBox.Text;
            aEmployee.Name = nameTextBox.Text;
            aEmployee.Designation = designationTextBox.Text;
            aEmployee.Address = addressTextBox.Text;
            MessageBox.Show(manager.Delete(aEmployee));
            LoadAllData();
            ClearText();
            }
            else
            {
                MessageBox.Show("Please Select Employee");
            }
        }

        private void LoadAllData()
        {
            employees.Clear();
            employees = manager.GetAllEmployee();
            employeeListView.Items.Clear();
            foreach (Employee employee in employees)
            {
                ListViewItem item = new ListViewItem(employee.Id.ToString());
                item.SubItems.Add(employee.RegNo);
                item.SubItems.Add(employee.Name);
                item.SubItems.Add(employee.Designation);
                item.SubItems.Add(employee.Address);
                employeeListView.Items.Add(item);
            }
        }

        private void ClearText()
        {
            nameTextBox.Clear();
            regNoTextBox.Clear();
            designationTextBox.Clear();
            addressTextBox.Clear();
        }

        private void EmployeeInfoForm_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        
    }
}
