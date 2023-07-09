using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_NganVu
{
    internal class SalariedEmployee : Employee
    {
        public double FixedWeeklySalary { get; set; }

        public SalariedEmployee(string empType, string empName, int empId, double fixedWeeklySalary) : base(empType, empName, empId)
        {

            FixedWeeklySalary = fixedWeeklySalary;

        }

        public override double GrossEarnings
        {
            get { return FixedWeeklySalary; }
        }
    }
}
