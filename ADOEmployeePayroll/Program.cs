namespace ADOEmployeePayroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to employee payroll ADO");
            EmployeeModel model = new EmployeeModel();  
            EmployeeRepo repo = new EmployeeRepo();
            model.EmployeeName = "Ashwitha";
            model.phonenumber = 9456789021;
            model.Address = "Banglore";
            model.Departent = "HR";
            model.Gender = 'F';
            model.Basicpay = 20000;
            model.Deduction = 1500;
            model.Taxablepay = 1000;
            model.Tax = 500;
            model.NetPay = 15000;
            model.city = "Banglore";
            model.Country = "India";
            //repo.AddEmployee(model)
            repo.GetAllEmployee();

        }
    }
}