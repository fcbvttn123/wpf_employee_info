using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_NganVu
{
    internal class CommissionEmployee : Employee
    {
        public double GrossSale { get; set; }
        public double CommissionRate { get; set; }

        public CommissionEmployee(string empType, string empName, int empId, double grossSale, double commissionRate): base(empType, empName, empId)
        {
            GrossSale = grossSale;
            CommissionRate = commissionRate;
        }

        public override double GrossEarnings
        {
            get
            {
                return GrossSale * (CommissionRate/100);
            }
        }
    }
}
