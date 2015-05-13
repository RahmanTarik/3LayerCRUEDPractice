using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3LayerCRUEDPractice.DAL;
using _3LayerCRUEDPractice.MODEL;

namespace _3LayerCRUEDPractice.BLL
{
    public class EmployeeManager
    {
        EmployeeGateway aGateway = new EmployeeGateway();
        public bool IsRegNoexists(string regNo)
        {

            Employee employee = aGateway.GetEmployeeByRegNo(regNo);
            if (employee != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Save(Employee aEmployee)
        {
            bool isRegNoExists = IsRegNoexists(aEmployee.RegNo);
            if (isRegNoExists)
            {
                return "Registration Number Already Exists";
            }

            int result = aGateway.Save(aEmployee);
            if (result > 0)
            {
                return "Employee Saved Successfully";
            }
            
             return "Failed to Save Employee";
            
        }

        public List<Employee> GetAllEmployee()
        {
            return aGateway.GetAllEmployee();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            Employee aEmployee = aGateway.GetEmployeeById(employeeId);
            return aEmployee;
        }

        public string Update(Employee aEmployee)
        {
            int result = aGateway.Update(aEmployee);
            if (result>0)
            {
                return "Employee Updated Successfully !!";
            }
            return "Failed to Update Employee";
        }

        public string Delete(Employee aEmployee)
        {
            int result = aGateway.Delete(aEmployee);
            if (result > 0)
            {
                return "Employee Deleted Successfully !!";
            }
            return "Failed to delete Employee";
        }
    }
}
