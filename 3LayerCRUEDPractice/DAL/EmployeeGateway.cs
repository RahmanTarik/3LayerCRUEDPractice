using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3LayerCRUEDPractice.MODEL;

namespace _3LayerCRUEDPractice.DAL
{
    public class EmployeeGateway
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;

        public Employee GetEmployeeByRegNo(string regNo)
        {

            SqlConnection aSqlConnection = new SqlConnection(connectionString);
            string query1 = "SELECT * FROM EmployeeInfo WHERE RegNo = '" + regNo + "'";
            SqlCommand sqlCommandcommand = new SqlCommand(query1, aSqlConnection);
            aSqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommandcommand.ExecuteReader();
            Employee aemployee = null;
            while (sqlDataReader.Read())
            {
                if (aemployee == null)
                {
                    aemployee = new Employee();
                }

                aemployee.Id = int.Parse(sqlDataReader[0].ToString());
                aemployee.RegNo = sqlDataReader["RegNo"].ToString();
                aemployee.Name = sqlDataReader["Name"].ToString();
                aemployee.Designation = sqlDataReader["Designation"].ToString();
                aemployee.Address = sqlDataReader["Address"].ToString();
            }
            sqlDataReader.Close();
            aSqlConnection.Close();
            return aemployee;
        }

        public int Save(Employee aEmployee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("INSERT INTO EmployeeInfo VALUES ('{0}','{1}','{2}','{3}')", aEmployee.RegNo,
                aEmployee.Name,
                aEmployee.Designation, aEmployee.Address);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public int Update(Employee employee)
        {
            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "UPDATE EmployeeInfo SET Name = '" + employee.Name + "', Designation = '" + employee.Designation + "',  Address = '" + employee.Address +
                           "' WHERE ID =" + employee.Id;
            SqlCommand acommand = new SqlCommand(query, aConnection);
            aConnection.Open();
            int rowAffected = acommand.ExecuteNonQuery();
            aConnection.Close();
            return rowAffected;
        }

        public int Delete(Employee employee)
        {
            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "DELETE EmployeeInfo WHERE ID =" + employee.Id;
            SqlCommand acommand = new SqlCommand(query, aConnection);
            aConnection.Open();
            int rowAffected = acommand.ExecuteNonQuery();
            aConnection.Close();
            return rowAffected;
        }

        List<Employee> employees = new List<Employee>();
        public List<Employee> GetAllEmployee()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM EmployeeInfo";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Employee aEmployee = new Employee();

                aEmployee.Id = int.Parse(reader[0].ToString());
                aEmployee.RegNo = reader["RegNo"].ToString();
                aEmployee.Name = reader["Name"].ToString();
                aEmployee.Designation = reader["Designation"].ToString();
                aEmployee.Address = reader["Address"].ToString();
                employees.Add(aEmployee);
            }
            reader.Close();
            connection.Close();
            return employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM EmployeeInfo WHERE ID = '" + employeeId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Employee aEmployee = null;
            while (reader.Read())
            {
                if (aEmployee == null)
                {
                    aEmployee = new Employee();
                }
                aEmployee.Id = int.Parse(reader[0].ToString());
                aEmployee.RegNo = reader["RegNo"].ToString();
                aEmployee.Name = reader["Name"].ToString();
                aEmployee.Designation = reader["Designation"].ToString();
                aEmployee.Address = reader["Address"].ToString();

            }
            reader.Close();
            connection.Close();
            return aEmployee;
        }
    }
}


