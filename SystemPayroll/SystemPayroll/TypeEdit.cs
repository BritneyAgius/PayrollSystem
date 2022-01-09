using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemPayroll
{
    class TypeEdit
    {
    }

    public partial class Employee
    {
        public Employee(string ID, string Name, string Surname, string NI_Number, string Address, string Email, int Designation, double bonus)
        {
            this.ID = ID;
            this.Name = Name;
            this.Surname = Surname;
            this.NII_Number = NI_Number;
            this.Address = Address; 
            this.Email = Email;
            this.Designation = Designation;
            this.Bonus = Bonus;
        }
    }

    public partial class Designation
    {
        public Designation(int ID, string Title, decimal Yearly_Income, decimal Hours_Per_Week, decimal Overtime)
        {
            this.ID = ID;
            this.Title = Title;
            this.Yearly_Income = Yearly_Income;
            this.Hours_Per_Week = Hours_Per_Week;
            this.OvertimeAmount = Overtime;
        }
    }

    public partial class Tax_Rate
    {
        public Tax_Rate()
        {
        }

        public Tax_Rate(int ID, decimal Income_From, decimal Income_To, decimal Rate)
        {
            this.ID= ID; 
            this.Income_From = Income_From; 
            this.Income_To = Income_To; 
            this.Rate = Rate;
        }
    }

    public partial class Payslip
    {
        public Payslip()
        {
        }

        public Payslip(int ID, DateTime Date_From, DateTime Date_To, decimal Hours_Worked, string Employee, decimal Overtime)
        {
            this.ID = ID;
            this.Date_From = Date_From; 
            this.Date_To = Date_To;
            this.Hours_Worked = Hours_Worked;
            this.Employee = Employee;
            this.Overtime = Overtime;
        }
    }
}
