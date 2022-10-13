using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEmployeePayroll
{
    public class EmployeeModel
    {
        
            public int EmployeeID { get; set; }
            public string EmployeeName { get; set; }
            public long phonenumber { get; set; }

            public string Address { get; set; }
            public string Departent { get; set; }
            public char Gender { get; set; }
            public double Basicpay { get; set; }
            public double Deduction { get; set; }
            public double Taxablepay { get; set; }
            public double Tax { get; set; }
            public double NetPay { get; set; }
            public DateTime StartDate { get; set; }
            public string city { get; set; }
            public string Country { get; set; }



        
    }
}
