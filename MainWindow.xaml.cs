using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MT_NganVu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    enum EmployeeType
    {
        Hourly_Employee = 1,
        Commission_Employee,
        Salaried_Employee
    }
    public partial class MainWindow : Window
    {
        int id = 0;

        List<Employee> hEmp = new List<Employee>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void radio_commission_Checked(object sender, RoutedEventArgs e)
        {
            // remove values from textbox

            textBox_gross_earning.Text = 
            textBox_tax.Text = 
            textBox_net_earning.Text = 
            textBox_name1.Text = 
            textBox_hours_worked1.Text = 
            textBox_hourly_wage1.Text = "";

            // show label and textox

            label_third_empInfo.Visibility = Visibility.Visible;

            textBox_hourly_wage1.Visibility = Visibility.Visible;

            // change text

            label_second_empInfo.Content = "Gross Sales: ";

            label_third_empInfo.Content = "Commission Rate: ";
        }

        private void radio_weekly_Checked(object sender, RoutedEventArgs e)
        {
            // remove values from textbox

            textBox_gross_earning.Text =
            textBox_tax.Text =
            textBox_net_earning.Text =
            textBox_name1.Text =
            textBox_hours_worked1.Text =
            textBox_hourly_wage1.Text = "";

            // Hide items

            label_second_empInfo.Content = "Weekly Salary: ";
            label_third_empInfo.Visibility = Visibility.Collapsed;
            textBox_hourly_wage1.Visibility = Visibility.Collapsed;
        }

        private void radio_hourly_Click(object sender, RoutedEventArgs e)
        {
            // remove values from textbox

            textBox_gross_earning.Text =
            textBox_tax.Text =
            textBox_net_earning.Text =
            textBox_name1.Text =
            textBox_hours_worked1.Text =
            textBox_hourly_wage1.Text = "";

            if (radio_hourly.IsChecked == true)
            {
                // show label and textox

                label_third_empInfo.Visibility = Visibility.Visible;

                textBox_hourly_wage1.Visibility = Visibility.Visible;

                // change text
                
                label_second_empInfo.Content = "Hours Worked: ";

                label_third_empInfo.Content = "Hourly Wage: ";
            };
        }

        private void btn_calculate_Click(object sender, RoutedEventArgs e)
        {
            // check if any field is blank

            if(textBox_name1.Text == "" || 
               //textBox_hourly_wage1.Text == "" ||
               textBox_hours_worked1.Text == "")
            {
                MessageBox.Show("Make sure all fields are filled", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            // check if text box of work hours are numbers and not negative

            double afjhdgh;

            bool isNumber1 = double.TryParse(textBox_hours_worked1.Text, out afjhdgh);

            if (!isNumber1 || afjhdgh < 0 )
            {
                MessageBox.Show("Make sure all numbers are not negative", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            // check if text box of hour salary are numbers and not negative only if it is visible

            if (textBox_hourly_wage1.Visibility == Visibility.Visible)
            {
                double kdjsbgdshbg;

                bool isNumber2 = double.TryParse(textBox_hourly_wage1.Text, out kdjsbgdshbg);

                if (!isNumber2 || kdjsbgdshbg < 0 || textBox_hourly_wage1.Text == "")
                {
                    MessageBox.Show("Make sure all numbers are not negative", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }
            }


            // check if hourly radio checked

            if (radio_hourly.IsChecked == true)
            {
                id += 1;

                addHourlyEmp();
            } 
            
            else if (radio_commission.IsChecked == true)
            {
                id += 1;
                addCommissionEmp();
            }

            else if (radio_weekly.IsChecked == true)
            {
                id += 1;
                addSalariedEmp();
            }

            // refresh list box

            refresh();
        }

        private void addHourlyEmp()
        {
            // Convert text to double 

            double hourly_wage;

            double hours_worked;

            bool isNumber1 = double.TryParse(textBox_hours_worked1.Text, out hourly_wage);

            bool isNumber2 = double.TryParse(textBox_hourly_wage1.Text, out hours_worked);

            // create new hourly employee

            Employee newEmp = new HourlyEmployee(EmployeeType.Hourly_Employee.ToString(), textBox_name1.Text, id, hourly_wage, hours_worked);

            // Assign value to boxes

            textBox_gross_earning.Text = newEmp.GrossEarnings.ToString("C");

            textBox_tax.Text = newEmp.Tax.ToString("C");

            textBox_net_earning.Text = newEmp.NetEarnings.ToString("C");

            // add to list 

            hEmp.Add(newEmp);

        }

        private void addCommissionEmp()
        {
            // Convert text to double 

            double grossSale;

            double commission_rate;

            bool isNumber1 = double.TryParse(textBox_hours_worked1.Text, out grossSale);

            bool isNumber2 = double.TryParse(textBox_hourly_wage1.Text, out commission_rate);

            // create new hourly employee

            Employee newEmp = new CommissionEmployee(EmployeeType.Commission_Employee.ToString(), textBox_name1.Text, id, grossSale, commission_rate);

            // Assign value to boxes

            textBox_gross_earning.Text = newEmp.GrossEarnings.ToString("C");

            textBox_tax.Text = newEmp.Tax.ToString("C");

            textBox_net_earning.Text = newEmp.NetEarnings.ToString("C");

            // add to list 

            hEmp.Add(newEmp);
        }

        private void addSalariedEmp()
        {
            // Convert text to double 

            double fixedWeeklySalary;

            bool isNumber1 = double.TryParse(textBox_hours_worked1.Text, out fixedWeeklySalary);

            // create new hourly employee

            Employee newEmp = new SalariedEmployee(EmployeeType.Salaried_Employee.ToString(), textBox_name1.Text, id, fixedWeeklySalary);

            // Assign value to boxes

            textBox_gross_earning.Text = newEmp.GrossEarnings.ToString("C");

            textBox_tax.Text = newEmp.Tax.ToString("C");

            textBox_net_earning.Text = newEmp.NetEarnings.ToString("C");

            // add to list 

            hEmp.Add(newEmp);
        }

        private void refresh()
        {
            var names = from emp in hEmp
                        select emp.EmployeeName;
            lstEmp.ItemsSource = names;
        }

        private void lstEmp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // check if any item selected

            if (lstEmp.SelectedItem != null)
            {
                // Get index of selected item

                Employee emp = hEmp[lstEmp.SelectedIndex];

                // Check employee type to change radio button

                if (emp.EmployeeType == EmployeeType.Commission_Employee.ToString()) {

                    // convert to hourly type
                    CommissionEmployee hemp = (CommissionEmployee)emp;

                    // check radio button

                    radio_commission.IsChecked = true;

                    // show label and textbox

                    label_third_empInfo.Visibility = Visibility.Visible;

                    textBox_hourly_wage1.Visibility = Visibility.Visible;

                    // change text

                    label_second_empInfo.Content = "Gross Sale: ";

                    label_third_empInfo.Content = "Commission Rate: ";

                    // show info

                    textBox_name1.Text = emp.EmployeeName;
                    textBox_gross_earning.Text = emp.GrossEarnings.ToString("C");
                    textBox_tax.Text = emp.Tax.ToString("C");
                    textBox_net_earning.Text = emp.NetEarnings.ToString("C");

                    textBox_hours_worked1.Text = hemp.GrossSale.ToString("C");
                    textBox_hourly_wage1.Text = hemp.CommissionRate.ToString("C");

                }

                else if (emp.EmployeeType == EmployeeType.Hourly_Employee.ToString())
                {
                    // convert to hourly type
                    HourlyEmployee hemp = (HourlyEmployee) emp;

                    // check radio button

                    radio_hourly.IsChecked = true;

                    // show label and textbox

                    label_third_empInfo.Visibility = Visibility.Visible;

                    textBox_hourly_wage1.Visibility = Visibility.Visible;

                    // change text

                    label_second_empInfo.Content = "Hours Worked: ";

                    label_third_empInfo.Content = "Hourly Wage: ";

                    // show info

                    textBox_name1.Text = emp.EmployeeName;
                    textBox_gross_earning.Text = emp.GrossEarnings.ToString("C");
                    textBox_tax.Text = emp.Tax.ToString("C");
                    textBox_net_earning.Text = emp.NetEarnings.ToString("C");

                    textBox_hours_worked1.Text = hemp.HoursWorked.ToString("C");
                    textBox_hourly_wage1.Text = hemp.HoursWage.ToString("C");
                }

                else if (emp.EmployeeType == EmployeeType.Salaried_Employee.ToString())
                {

                    // convert to salaried type
                    SalariedEmployee semp = (SalariedEmployee)emp;

                    // check radio button

                    radio_weekly.IsChecked = true;

                    // change text

                    label_second_empInfo.Content = "Weekly Salaried: ";

                    // show info

                    textBox_name1.Text = emp.EmployeeName;
                    textBox_gross_earning.Text = emp.GrossEarnings.ToString("C");
                    textBox_tax.Text = emp.Tax.ToString("C");
                    textBox_net_earning.Text = emp.NetEarnings.ToString("C");

                    textBox_hours_worked1.Text = semp.FixedWeeklySalary.ToString("C");

                }

            }
        }

        private void btn_cear_Click(object sender, RoutedEventArgs e)
        {
            // remove values from textbox

            textBox_gross_earning.Text =
            textBox_tax.Text =
            textBox_net_earning.Text =
            textBox_name1.Text =
            textBox_hours_worked1.Text =
            textBox_hourly_wage1.Text = "";

            // set up default check for radio button

            radio_hourly.IsChecked = true;

            // show label and textox

            label_third_empInfo.Visibility = Visibility.Visible;

            textBox_hourly_wage1.Visibility = Visibility.Visible;

            // change text

            label_second_empInfo.Content = "Hours Worked: ";

            label_third_empInfo.Content = "Hourly Wage: ";
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
