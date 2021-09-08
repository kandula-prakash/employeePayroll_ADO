using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
     public class EmployeeRepo
    {
        public static string connectionString = "Data Source=(LocalDb)\\localDb;Integrated Security = True";
            SqlConnection connection=new SqlConnection(connectionString);

        public void GetEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
             
                using (this.connection)
                {
                    string query = @"SELECT EmpolyeeID,EmployeeName,PhoneNumber,Address,Department,Gender,BasicPay,Deduction,TaxblePay,Tax,NetPay,StartDate,City,Country
                                 FROM employee_payroll;";

                    this.connection.Open();

                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        Console.WriteLine($"{"Name",10} {"BasicPay",10} {"Start",25} {"Gender",5} {"PhoneNumber",15} {"Address",20} {"Department",10} {"Deduction",10} {"TaxablePay",10} {"IncomeTax",10} {"NetPay",10}");
                        Console.Write($"{new string('-', 145)}\n");


                        while (dr.Read())
                           
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.PhoneNumber = dr.GetString(2);
                            employeeModel.Address = dr.GetString(3);
                            employeeModel.Department = dr.GetString(4);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(5));
                            employeeModel.BasicPay = dr.GetDouble(6);
                            employeeModel.Deductions = dr.GetDouble(7);
                            employeeModel.TaxablePay = dr.GetDouble(8);
                            employeeModel.Tax = dr.GetDouble(9);
                            employeeModel.NetPay = dr.GetDouble(10);
                           // employeeModel.StartDate = dr.GetDouble(11);
                            employeeModel.City = dr.GetString(12);
                            employeeModel.Country = dr.GetString(13);

                            //display the retrived record
                            Console.WriteLine($"{employeeModel.EmployeeName,10} {employeeModel.BasicPay,10} {employeeModel.StartDate,25} {employeeModel.Gender,5} {employeeModel.PhoneNumber,15} {employeeModel.Address,20} {employeeModel.Department,10} {employeeModel.Deductions,10} {employeeModel.TaxablePay,10} {employeeModel.IncomeTax,10} {employeeModel.NetPay,10}");
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine("no data found.");
                    }
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }   

        }
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection);
                SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                command.Parameters.AddWithValue("@Address", model.Address);
                command.Parameters.AddWithValue("@Department", model.Department);
                command.Parameters.AddWithValue("@Gender", model.Gender);
                command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                command.Parameters.AddWithValue("@Dedauction", model.Deductions);
                command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                command.Parameters.AddWithValue("@Tax", model.Tax);
                command.Parameters.AddWithValue("@NetPay", model.NetPay);
                command.Parameters.AddWithValue("@StartDate", model.StartDate);
                command.Parameters.AddWithValue("@City", model.City);
                command.Parameters.AddWithValue("@Country", model.Country);
                this.connection.Open();
                var result = command.ExecuteNonQuery();
                this.connection.Close();
                if (result !=0)
                {
                    return true;
                }
                return false;
                
               




            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
    }
}
