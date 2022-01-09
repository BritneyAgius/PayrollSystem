using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SystemPayroll
{
    class MenuHandler
    {

        public void MenuDisplay()
        {
            int option = Menu();
            Console.Clear();
            MainMenuFlow(option);
        }

        private int Menu()
        {
            Console.Clear();
            Console.WriteLine("Main Menu:");
            Console.WriteLine();
            Console.WriteLine("1 - Add Employee");
            Console.WriteLine("2 - Edit Employee");
            Console.WriteLine("3 - Add Designation");
            Console.WriteLine("4 - Edit Designation");
            Console.WriteLine("5 - Add Tax Rate");
            Console.WriteLine("6 - Edit Tax Rate");
            Console.WriteLine("7 - Add Payslip");
            Console.WriteLine("8 - Edit Payslip");
            Console.WriteLine("9 - Generate Payslip");
            Console.WriteLine("10 - Employee Salaries");
            Console.WriteLine("11 - Total Hours Worked For Each Employee");
            Console.WriteLine();
            Console.Write("Choice: ");

            int option; //Initialisation of variable 'option'

            try //If an integer is inputted, try to do the following:
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception) //If an error is returned, do this:
            {
                option = 0; //Directs the user to the deafult case
            }

            return option;
        }

        private void MainMenuFlow(int option)
        {
            switch (option)
            {
                case 1:
                    AddEmployee();
                    ReturnToMainMenu();
                    break;
                case 2:
                    EditEmployee();
                    ReturnToMainMenu();
                    break;
                case 3:
                    AddDesignation();
                    ReturnToMainMenu();
                    break;
                case 4:
                    EditDesignation();
                    ReturnToMainMenu();
                    break;
                case 5:
                    AddTaxRate();
                    ReturnToMainMenu();
                    break;
                case 6:
                    EditTaxRate();
                    ReturnToMainMenu();
                    break;
                case 7:
                    AddPayslip();
                    ReturnToMainMenu();
                    break;
                case 8:
                    EditPayslip();
                    ReturnToMainMenu();
                    break;
                case 9:
                    GeneratePayslip();
                    ReturnToMainMenu();
                    break;
                case 10:
                    EmployeeSalaries();
                    ReturnToMainMenu();
                    break;
                case 11:
                    TotalHoursWorkedForEachEmployee();
                    ReturnToMainMenu();
                    break;
                default:
                    Console.WriteLine("Incorrect Choice - Please Try again");
                    ReturnToMainMenu();
                    break;
            }
        }

        private void AddEmployee() //Add new employe
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1(); //Connect to SSMS database

            Console.WriteLine("Add New Employee");

            Console.WriteLine("\nID Card Number:"); 
            string IDCard = Console.ReadLine();

            Console.WriteLine("First Name:"); 
            string  FirstName = Console.ReadLine();

            Console.WriteLine("Last Name:");
            string LastName = Console.ReadLine();

            Console.WriteLine("NI Number:");
            string  NINumber = Console.ReadLine();

            Console.WriteLine("Address:");
            string  Address = Console.ReadLine();

            Console.WriteLine("Email:");
            string Email = Console.ReadLine();  

            Console.WriteLine("Designaton:");
            Int32.TryParse(Console.ReadLine(), out int Designation);

            Console.WriteLine("Bonus:");
            Double.TryParse(Console.ReadLine(), out double Bonus);

            Employee employee = new Employee(IDCard, FirstName, LastName, NINumber, Address, Email, Designation, Bonus);

            db.Employee.Add(employee);
            try 
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException);
            }
        }

        private void EditEmployee()
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1();

            Console.WriteLine("Enter Employee ID: ");
            string EmployeeID = Console.ReadLine();

            var employee = (from e in db.Employee
                            where e.ID == EmployeeID
                            select e).FirstOrDefault();

            if (employee == null)
            {
                Console.Clear();
                Console.WriteLine("Incorrect Employee ID");
                ReturnToMainMenu();
            }

            Console.Clear();
            Console.WriteLine("First Name:");
            string FirstName = Console.ReadLine();

            Console.WriteLine("Last Name:");
            string LastName = Console.ReadLine();

            Console.WriteLine("NI Number:");
            string NINumber = Console.ReadLine();

            Console.WriteLine("Address:");
            string Address = Console.ReadLine();

            Console.WriteLine("Email:");
            string Email = Console.ReadLine();

            Console.WriteLine("Designaton:");
            Int32.TryParse(Console.ReadLine(), out int Designation);

            Console.WriteLine("Bonus:");
            Double.TryParse(Console.ReadLine(), out double Bonus);           

            if(employee != null)
            {
                employee.Name = FirstName;
                employee.Surname = LastName;
                employee.NII_Number = NINumber;
                employee.Address = Address;
                employee.Email = Email;
                employee.Designation = Designation;
                employee.Bonus = Bonus;
            }            

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException);
            }
        }

        private void AddDesignation()
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1(); //Connect to SSMS database

            Console.WriteLine("Add Designation");

            Console.WriteLine("\nDesignation ID:");
            Int32.TryParse(Console.ReadLine(), out int DesignationID);

            Console.WriteLine("Title:");
            String Title = Console.ReadLine();

            Console.WriteLine("Yearly Income:");
            Decimal.TryParse(Console.ReadLine(), out decimal YearlyIncome);

            Console.WriteLine("Hours Per Week:");
            Decimal.TryParse(Console.ReadLine(), out decimal HoursPerWeek);

            Console.WriteLine("Overtime Amount:");
            Decimal.TryParse(Console.ReadLine(), out decimal Overtime);

            Designation designation = new Designation(DesignationID, Title, YearlyIncome, HoursPerWeek, Overtime);

            db.Designation.Add(designation);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void EditDesignation()
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1();

            Console.WriteLine("Enter Designation ID: ");
            Int32.TryParse(Console.ReadLine(), out int DesignationID);

            var designation = (from d in db.Designation
                               where d.ID == DesignationID
                               select d).FirstOrDefault();

            if (designation == null)
            {
                Console.Clear();
                Console.WriteLine("Incorrect Designation ID");
                ReturnToMainMenu();
            }

            Console.Clear();
            Console.WriteLine("Title:");
            String Title = Console.ReadLine();

            Console.WriteLine("Yearly Income:");
            Decimal.TryParse(Console.ReadLine(), out decimal YearlyIncome);

            Console.WriteLine("Hours Per Week:");
            Decimal.TryParse(Console.ReadLine(), out decimal HoursPerWeek);

            Console.WriteLine("Overtime Amount:");
            Decimal.TryParse(Console.ReadLine(), out decimal Overtime);

            if (designation != null)
            {
                designation.Title = Title;
                designation.Yearly_Income = YearlyIncome;
                designation.Hours_Per_Week = HoursPerWeek;
                designation.OvertimeAmount = Overtime;
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException);
            }
        }

        private void AddTaxRate()
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1(); //Connect to SSMS database

            Console.WriteLine("Add New Tax Rate");

            Console.WriteLine("\nTax Rate ID:");
            Int32.TryParse(Console.ReadLine(), out int TaxRateID);

            Console.WriteLine("Starting Income:");
            Decimal.TryParse(Console.ReadLine(), out decimal StartingIncome);

            Console.WriteLine("Ending Income:");
            Decimal.TryParse(Console.ReadLine(), out decimal EndingIncome);

            Console.WriteLine("Rate:");
            Decimal.TryParse(Console.ReadLine(), out decimal Rate);

            Tax_Rate tax_Rate = new Tax_Rate(TaxRateID, StartingIncome, EndingIncome, Rate);

            db.Tax_Rate.Add(tax_Rate);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException);
            }
        }

        private void EditTaxRate()
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1();

            Console.WriteLine("Enter Tax Rate ID: ");
            Int32.TryParse(Console.ReadLine(), out int TaxRateID);

            var taxRate = (from tr in db.Tax_Rate
                           where tr.ID == TaxRateID
                           select tr).FirstOrDefault();

            if (taxRate == null)
            {
                Console.Clear();
                Console.WriteLine("Incorrect Tax Rate ID");
                ReturnToMainMenu();
            }

            Console.Clear();
            Console.WriteLine("Starting Income:");
            Decimal.TryParse(Console.ReadLine(), out decimal StartingIncome);

            Console.WriteLine("Ending Income:");
            Decimal.TryParse(Console.ReadLine(), out decimal EndingIncome);

            Console.WriteLine("Rate:");
            Decimal.TryParse(Console.ReadLine(), out decimal Rate);

            if (taxRate != null)
            {
                taxRate.Income_To = StartingIncome;
                taxRate.Income_From = EndingIncome;
                taxRate.Rate = Rate;
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException);
            }
        } 

        private void AddPayslip()
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1(); //Connect to SSMS database

            Console.WriteLine("Add New Payslip");

            Console.WriteLine("\nPayslip ID:");
            Int32.TryParse(Console.ReadLine(), out int PayslipID);

            Console.WriteLine("Starting Date (dd-mm-yyyy):");
            DateTime.TryParse(Console.ReadLine(), out DateTime StartingDate);

            Console.WriteLine("Ending Date (dd-mm-yyyy):");
            DateTime.TryParse(Console.ReadLine(), out DateTime EndingDate);

            Console.WriteLine("Hours Worked:");
            Decimal.TryParse(Console.ReadLine(), out decimal HoursWorked);

            Console.WriteLine("Overtime Hours:");
            Decimal.TryParse(Console.ReadLine(), out decimal Overtime);

            Console.WriteLine("Employee:");
            string Employee = Console.ReadLine();

            Payslip payslip = new Payslip(PayslipID, StartingDate, EndingDate, HoursWorked, Employee, Overtime);

            db.Payslip.Add(payslip);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException);
            }
        }

        private void EditPayslip()
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1();

            Console.WriteLine("Enter Employee ID Card: ");
            string employeeId = Console.ReadLine();

            var id = (from e in db.Employee
                      where e.ID == employeeId
                      select e).FirstOrDefault();

            if (id == null)
            {
                Console.Clear();
                Console.WriteLine("Incorrect Employee ID Card");
                ReturnToMainMenu();
            }

            Console.WriteLine("Enter Payslip Month");
            Int32.TryParse(Console.ReadLine(), out int month);
            var MonthNum = (from p in db.Payslip
                            where p.Date_From.Month == month
                            select p).FirstOrDefault();

            if (MonthNum == null)
            {
                Console.Clear();
                Console.WriteLine("Incorrect Month");
                ReturnToMainMenu();
            }

            Console.WriteLine("Enter Payslip Year");
            Int32.TryParse(Console.ReadLine(), out int year);
            var YearNum = (from p in db.Payslip
                           where p.Date_From.Year == year
                           select p).FirstOrDefault();

            if (YearNum == null)
            {
                Console.Clear();
                Console.WriteLine("Incorrect Year");
                ReturnToMainMenu();
            }

            Console.Clear();
            Console.WriteLine("Payslip Date From (dd-MM-yyyy):");
            DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime FromDate);

            Console.WriteLine("Payslip Date To (dd-MM-yyyy):");
            DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ToDate);

            Console.WriteLine("Hours Worked:");
            Decimal.TryParse(Console.ReadLine(), out decimal Hours);

            Console.WriteLine("Overtime Hours:");
            Decimal.TryParse(Console.ReadLine(), out decimal Overtime);

            var Payslip = (from p in db.Payslip
                           where p.Employee == employeeId
                           where p.Date_From.Month == month
                           where p.Date_From.Year == year
                           select p).FirstOrDefault();

            if (Payslip != null)
            {
                Payslip.Date_From = FromDate;
                Payslip.Date_To = ToDate;
                Payslip.Hours_Worked = Hours;
                Payslip.Overtime = Overtime;
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException);
            }
        }

        private void GeneratePayslip()
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1();
            int counter = 0;
            int counter2 = 0;

            Console.WriteLine("Enter Employee ID Card: ");
            string employeeId = Console.ReadLine();

            var id = (from e in db.Employee
                      where e.ID == employeeId
                      select e).FirstOrDefault();

            if (id == null)
            {
                Console.Clear();
                Console.WriteLine("Incorrect Employee ID Card");
                ReturnToMainMenu();
            }

            Console.WriteLine("Enter Payslip Month");
            string userInputMonth = Console.ReadLine();
            Int32.TryParse(userInputMonth, out int month);
            var MonthNum = (from p in db.Payslip
                            where p.Employee == employeeId
                            where p.Date_From.Month == month
                            select p).FirstOrDefault();

            if (MonthNum == null)
            {
                counter++;
            }

            Console.WriteLine("Enter Payslip Year");
            string userInputYear = Console.ReadLine();
            Int32.TryParse(userInputYear, out int year);
            var YearNum = (from p in db.Payslip
                           where p.Employee == employeeId
                           where p.Date_From.Month == month
                           where p.Date_From.Year == year
                           select p).FirstOrDefault();

            if (YearNum == null)
            {
                counter++;
            }

            if(counter != 0)
            {
                var checks = (from p in db.Payslip
                              where p.Date_From.Month == month
                              where p.Date_From.Year == year
                              where p.Employee == employeeId
                              select p).FirstOrDefault();
                
                if(checks != null)
                {
                    Console.WriteLine("Payslip already exists");
                    counter2++;
                }

                if (counter2 != 0)
                {
                    Console.WriteLine("Invalid Inputs");
                    counter = 0;                    
                }
                else
                {
                    try
                    {
                        DateTime DateFrom = new DateTime(year, month, 1);
                        DateTime DateTo = new DateTime(year, month, DateTime.DaysInMonth(year, month));

                        var PayslipID = from p in db.Payslip
                                        select p;
                        var Hours = (from e in db.Employee
                                     where e.ID == employeeId
                                     join Designation d in db.Designation
                                     on e.Designation equals d.ID
                                     select new { d.Hours_Per_Week }).FirstOrDefault();

                        Payslip NewPayslip = new Payslip(PayslipID.Count() + 1, DateFrom, DateTo, Hours.Hours_Per_Week, employeeId, 0);
                        db.Payslip.Add(NewPayslip);
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Could not add payslip");
                        ReturnToMainMenu();
                    }
                }
            }

            counter2 = 0;
            int payslip;

            if(counter != 0)
            {
                var payslips = from p in db.Payslip
                               select p.ID;
                payslip = payslips.Count();
            }
            else
            {
                payslip = YearNum.ID;
            }

            var Details = (from p in db.Payslip
                            where p.ID == payslip
                            join Employee e in db.Employee
                            on p.Employee equals e.ID
                            join Designation d in db.Designation
                            on e.Designation equals d.ID
                            select new {e.ID, e.Name, e.Surname, e.NII_Number, d.Title, d.Yearly_Income, d.OvertimeAmount, p.Date_From, p.Date_To, 
                                p.Hours_Worked, p.Overtime}).FirstOrDefault();

            var Rate = (from t in db.Tax_Rate
                        where Details.Yearly_Income >= t.Income_From && Details.Yearly_Income <= t.Income_To
                        select t.Rate).FirstOrDefault();

            decimal Monthly = Math.Round(Details.Yearly_Income / (Details.Hours_Worked * 52) * (Details.Hours_Worked * 52) / 12, 2); //formula from Internet
            decimal Overtime;
            if(Details.OvertimeAmount.HasValue)
            {
                Overtime = (decimal)(Details.OvertimeAmount * Details.Overtime);
            }
            else
            {
                Overtime = 0;
            }

            Console.Clear();
            Console.WriteLine("Employee ID: " + Details.ID + "\nName & Surname: " + Details.Name + " " + Details.Surname);
            Console.WriteLine("NI: " + Details.NII_Number + " Designation: " + Details.Title);
            Console.WriteLine("Pay Period: " + Details.Date_From.ToString("dd MMMM yyyy") + " - " + 
                              Details.Date_To.ToString("dd MMMM yyyy"));
            Console.WriteLine("Description + Hours + Amount (Eur)");
            Console.WriteLine("Basic: " + Details.Hours_Worked * 4 + " hours " + Monthly + " (Eur)"); //4 weeks in a month
            Console.WriteLine("Overtime: " + Details.Overtime + " hours " + Overtime + " (Eur)");
            Console.WriteLine("Gross Pay: " + (Monthly + Overtime));
            Console.WriteLine("Tax Rate: " + Rate + "%");
            Console.WriteLine("Tax: " + (Monthly + Overtime) * (Rate / 100));
            Console.WriteLine("Net Pay: " + (Monthly + Overtime - ((Monthly + Overtime) * Rate /100)));

            counter = 0;
        }

        private void EmployeeSalaries()
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1();
            int counter = 0;

            Console.WriteLine("Enter Month");
            string userInputMonth = Console.ReadLine();
            Int32.TryParse(userInputMonth, out int month);
            var MonthNum = (from e in db.Employee
                            join Designation d in db.Designation
                            on e.Designation equals d.ID
                            orderby d.Yearly_Income descending
                            select e).ToList();

            if (MonthNum == null)
            {
                counter++;
            }

            if(counter != 0)
            {
                Console.Clear();
                Console.WriteLine("Invalid Month");
                counter = 0;
                ReturnToMainMenu();
            }
            else
            {
                counter = 0;
            }

            if(MonthNum.Count() != 0)
            {
                decimal monthly;
                string name;

                foreach (var e in MonthNum)
                {
                    var Emp = (from p in db.Payslip
                               where p.Date_From.Month == month
                               where p.Employee == e.ID
                               join Employee emp in db.Employee
                               on p.Employee equals emp.ID
                               join Designation d in db.Designation
                               on emp.Designation equals d.ID
                               select new { p.Hours_Worked, emp.ID, emp.Name, emp.Surname, d.Yearly_Income }).FirstOrDefault();

                    if(Emp != null)
                    {
                        name = Emp.Name + " " + Emp.Surname;
                        monthly = Math.Round((Emp.Yearly_Income / (Emp.Hours_Worked * 52) * (Emp.Hours_Worked * 52) / 12), 2);
                    }
                    else
                    {
                        var Emp2 = (from emp in db.Employee
                                    where emp.ID == e.ID
                                    join Designation d in db.Designation
                                    on emp.Designation equals d.ID
                                    select new { emp.ID, emp.Name, emp.Surname, d.Hours_Per_Week, d.Yearly_Income }).FirstOrDefault();

                        name = Emp2.Name + " " + Emp2.Surname;
                        monthly = Math.Round((Emp2.Yearly_Income / (Emp2.Hours_Per_Week * 52) * (Emp2.Hours_Per_Week * 52) / 12), 2);
                    }

                    Console.WriteLine("Employee Name - " + name + "\t\t" + "Gross Pay - " + monthly + "\t\t");
                }
            }
            else
            {
                Console.WriteLine("No Employees");
                ReturnToMainMenu();
            }
        }

        private void TotalHoursWorkedForEachEmployee()
        {
            Console.WriteLine("Total Hours Worked For Each Employee");
        }

        private void ReturnToMainMenu()
        {
            Console.WriteLine("\nEnter any key to return to the Main Menu"); // \n = Skips a line before this line of code
            Console.ReadKey();
            MenuDisplay();
        }
    }
}
