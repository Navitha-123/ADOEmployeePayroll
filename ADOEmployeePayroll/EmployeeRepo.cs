using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEmployeePayroll
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employee_payrollADO;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel model = new EmployeeModel();  
                using(connection)
                {
                    string query = @"select EmployeeId,EmployeeName,phonenumber,Address,Department,Gender,Basicpay,Deduction,Taxablepay,Tax,Netpay,StartDate,City,Country";
                    SqlCommand cmd = new SqlCommand(query, connection); 
                    connection.Open();  
                    SqlDataReader reader = cmd.ExecuteReader(); 
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            model.EmployeeID = reader.GetInt32(0);
                            model.EmployeeName = reader.GetString(1);
                            model.phonenumber = Convert.ToInt64(reader["Phonenumber"]);
                            model.Address = Convert.ToString(reader["Address"]);
                            model.Departent = Convert.ToString(reader["Department"]);
                            model.Gender = Convert.ToChar(reader["Gender"]);
                            model.Basicpay = Convert.ToDouble(reader["Basicpay"]);
                            model.Deduction = Convert.ToDouble(reader["Deduction"]);
                            model.Taxablepay = Convert.ToDouble(reader["Taxablepay"]);
                            model.Tax = Convert.ToDouble(reader["Tax"]);
                            model.NetPay = Convert.ToDouble(reader["Netpay"]);
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", model.EmployeeID,model.EmployeeName,model.phonenumber,model.Address,model.Departent,model.Gender);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeedetails", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", employeeModel.phonenumber);
                    command.Parameters.AddWithValue("@Address", employeeModel.Address);
                    command.Parameters.AddWithValue("@Department", employeeModel.Departent);
                    command.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    command.Parameters.AddWithValue("@BasicPay", employeeModel.Basicpay);
                    command.Parameters.AddWithValue("@Deduction", employeeModel.Deduction);
                    command.Parameters.AddWithValue("@TaxablePay", employeeModel.Taxablepay);
                    command.Parameters.AddWithValue("@Tax", employeeModel.Tax);
                    command.Parameters.AddWithValue("@NetPay", employeeModel.NetPay);
                    //command.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    command.Parameters.AddWithValue("@City", employeeModel.city);
                    command.Parameters.AddWithValue("@Country", employeeModel.Country);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                        return true;
                    return false;
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
