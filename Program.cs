using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to e mployee payroll");

            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel employee = new EmployeeModel();


            employee.EmployeeName = "prakash";
            employee.PhoneNumber = 8499875245;
            employee.Address = "Ballikurava";
            employee.Gender = 'M';
            employee.BasicPay = 220115;
            employee.Deduction = 1520;
            employee.TaxablePay = 200;
            employee.Tax = 300;
            employee.NetPay = 2500;    
            employee.City ="Ballikurava";
            employee.Country = "India";



           

            repo.AddEmployee(employee);

        }
    }
}
