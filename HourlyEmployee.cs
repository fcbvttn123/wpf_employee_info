using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_NganVu
{
    internal class HourlyEmployee : Employee
    {
        public double HoursWorked { get; set; }
        public double HoursWage { get; set; }

        public HourlyEmployee(string empType, string empName, int empId, double hoursWorked, double hoursWage) : base(empType, empName, empId)
        {
            HoursWorked = hoursWorked;
            HoursWage = hoursWage;
        }

        public override double GrossEarnings
        {
            get
            {
                if (HoursWorked <= 40)
                {
                    return HoursWorked * HoursWage;
                }
                else
                {
                    return 40 * HoursWage + (HoursWorked - 40) * HoursWage * 1.5;
                }
            }
        }
    }
}
