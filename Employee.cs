using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_NganVu
{
    abstract class Employee
    {
        public string EmployeeType { get; set; }

        public string EmployeeName { get; set; }

        public int EmployeeId { get; set; }

        public Employee(string empType, string empName, int empId)
        {
            EmployeeType = empType;
            EmployeeName = empName;
            EmployeeId = empId;
        }

        public abstract double GrossEarnings { get; }

        public double Tax
        {
            get
            {
                return GrossEarnings * 0.2;
            }
        }
        public double NetEarnings
        {
            get
            {
                return GrossEarnings - Tax;
            }
        }
    }
}
