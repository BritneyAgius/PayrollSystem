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

        public void MenuDisplay() //Displays Menu
        {
            int option = Menu();
            Console.Clear();
            MainMenuFlow(option);
        }

        private int Menu() //Menu
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
            switch (option) //Directs to different methods accoding to the user's choice (input from menu)
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
                    PayslipDetails();
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
            Int32.TryParse(Console.ReadLine(), out int Designation); //Convert to int

            Console.WriteLine("Bonus:");
            Double.TryParse(Console.ReadLine(), out double Bonus); //Convert to Double

            Employee employee = new Employee(IDCard, FirstName, LastName, NINumber, Address, Email, Designation, Bonus);

            db.Employee.Add(employee);
            try 
            {
                db.SaveChanges(); //Save to database
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException); //Shows error
            }
        }

        private void EditEmployee() //Edit employee
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1(); //Connect to SSMS database

            Console.WriteLine("Enter Employee ID: ");
            string EmployeeID = Console.ReadLine();

            var employee = (from e in db.Employee
                            where e.ID == EmployeeID
                            select e).FirstOrDefault(); //Get employee from database (first or deafult)

            if (employee == null) //If employee ID is incorect do this:
            {
                Console.Clear();
                Console.WriteLine("Incorrect Employee ID");
                ReturnToMainMenu();
            }

            //Edit chosen employee
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

            if(employee != null) //If employee fields all have written /inputted data
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
                db.SaveChanges(); //Save employee info in database - no field should be null
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException); //Shows error
            }
        }

        private void AddDesignation() //Add designation
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1(); //Connect to SSMS database

            Console.WriteLine("Add Designation");

            Console.WriteLine("\nDesignation ID:");
            Int32.TryParse(Console.ReadLine(), out int DesignationID); //Convert to Int

            Console.WriteLine("Title:");
            String Title = Console.ReadLine(); //Convert to String

            Console.WriteLine("Yearly Income:");
            Decimal.TryParse(Console.ReadLine(), out decimal YearlyIncome); //Convert to Decimal

            Console.WriteLine("Hours Per Week:");
            Decimal.TryParse(Console.ReadLine(), out decimal HoursPerWeek); //Convert to Decimal

            Console.WriteLine("Overtime Amount:");
            Decimal.TryParse(Console.ReadLine(), out decimal Overtime); //Convert to Decimal

            Designation designation = new Designation(DesignationID, Title, YearlyIncome, HoursPerWeek, Overtime);

            db.Designation.Add(designation);
            try
            {
                db.SaveChanges(); //Save in database
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException); //Shows error
            }
        }

        private void EditDesignation() //Edit designation
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1(); //Connect to SSMS database

            Console.WriteLine("Enter Designation ID: ");
            Int32.TryParse(Console.ReadLine(), out int DesignationID);

            var designation = (from d in db.Designation
                               where d.ID == DesignationID
                               select d).FirstOrDefault(); //Get designation info from databse base (first or deafult)

            if (designation == null) //If designation ID is incorect do this:
            {
                Console.Clear();
                Console.WriteLine("Incorrect Designation ID");
                ReturnToMainMenu();
            }

            //Edit chosen designation
            Console.Clear();
            Console.WriteLine("Title:");
            String Title = Console.ReadLine();

            Console.WriteLine("Yearly Income:");
            Decimal.TryParse(Console.ReadLine(), out decimal YearlyIncome);

            Console.WriteLine("Hours Per Week:");
            Decimal.TryParse(Console.ReadLine(), out decimal HoursPerWeek);

            Console.WriteLine("Overtime Amount:");
            Decimal.TryParse(Console.ReadLine(), out decimal Overtime);

            if (designation != null) //If designation fields all have written /inputted data
            {
                designation.Title = Title;
                designation.Yearly_Income = YearlyIncome;
                designation.Hours_Per_Week = HoursPerWeek;
                designation.OvertimeAmount = Overtime;
            }

            try
            {
                db.SaveChanges(); //Save designation info in database - no field should be null
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException); //Shows error
            }
        }

        private void AddTaxRate() //Add tax rate
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1(); //Connect to SSMS database

            Console.WriteLine("Add New Tax Rate");

            Console.WriteLine("\nTax Rate ID:");
            Int32.TryParse(Console.ReadLine(), out int TaxRateID); //Convert to int

            Console.WriteLine("Starting Income:");
            Decimal.TryParse(Console.ReadLine(), out decimal StartingIncome); //Convert to Decimal

            Console.WriteLine("Ending Income:");
            Decimal.TryParse(Console.ReadLine(), out decimal EndingIncome); //Convert to Decimal

            Console.WriteLine("Rate:");
            Decimal.TryParse(Console.ReadLine(), out decimal Rate); //Convert to Decimal

            Tax_Rate tax_Rate = new Tax_Rate(TaxRateID, StartingIncome, EndingIncome, Rate);

            db.Tax_Rate.Add(tax_Rate);
            try
            {
                db.SaveChanges(); //Save to database
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException); //Shows error
            }
        }

        private void EditTaxRate() //Edit tax rate
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1(); //Connect to SSMS database

            Console.WriteLine("Enter Tax Rate ID: ");
            Int32.TryParse(Console.ReadLine(), out int TaxRateID); //Convert to int

            var taxRate = (from tr in db.Tax_Rate
                           where tr.ID == TaxRateID
                           select tr).FirstOrDefault(); //Get tax rate from database (first or deafult)

            if (taxRate == null) //If tax rate ID is incorect do this:
            {
                Console.Clear();
                Console.WriteLine("Incorrect Tax Rate ID");
                ReturnToMainMenu();
            }

            Console.Clear();
            Console.WriteLine("Starting Income:");
            Decimal.TryParse(Console.ReadLine(), out decimal StartingIncome); //Convert to Decimal

            Console.WriteLine("Ending Income:");
            Decimal.TryParse(Console.ReadLine(), out decimal EndingIncome); //Convert to Decimal

            Console.WriteLine("Rate:");
            Decimal.TryParse(Console.ReadLine(), out decimal Rate); //Convert to Decimal

            if (taxRate != null) //If tax rate fields all have written /inputted data
            {
                taxRate.Income_To = StartingIncome;
                taxRate.Income_From = EndingIncome;
                taxRate.Rate = Rate;
            }

            try
            {
                db.SaveChanges(); //Save tax rate info in database - no field should be null
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException); //Shows error
            }
        } 

        private void AddPayslip() //Add payslip  
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1(); //Connect to SSMS database
            Manager manager = new Manager();
            Employee employee = new Employee();

            Console.WriteLine("Add New Payslip");

            Console.WriteLine("\nPayslip ID:");
            Int32.TryParse(Console.ReadLine(), out int PayslipID); //Convert to int

            Console.WriteLine("Month (MM):");
            Int32.TryParse(Console.ReadLine(), out int month); //Convert to int

            Console.WriteLine("Year (yyyy):");
            Int32.TryParse(Console.ReadLine(), out int year); //Convert to int

            Console.WriteLine("Hours Worked:");
            Decimal.TryParse(Console.ReadLine(), out decimal HoursWorked); //Convert to Decimal

            Console.WriteLine("Overtime Hours:");
            Decimal.TryParse(Console.ReadLine(), out decimal Overtime); //Convert to Decimal

            Console.WriteLine("Employee:");
            string Employee = Console.ReadLine(); //Convert to String

            DateTime DateFrom = new DateTime(year, month, 1);
            DateTime DateTo = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            Payslip payslip = new Payslip(PayslipID, DateFrom, DateTo, HoursWorked, Employee, Overtime);

            db.Payslip.Add(payslip);
            try
            {
                db.SaveChanges(); //Save to database

                var PayslipEmp = (from p in db.Payslip
                                  where p.Employee == Employee
                                  where p.Date_From.Month == month
                                  where p.Date_From.Year == year
                                  select p).FirstOrDefault(); //Get payslip info from database (first or deafult)
                int payslipId;
                List<string> payslipInfo = new List<string>(); //Creates a list

                if (PayslipEmp != null) 
                {
                    var payslips = from p in db.Payslip
                                   select p.ID;
                    payslipId = payslips.Count(); //Counts how many payslips are in the database to use last payslip
                }
                else
                {
                    payslipId = PayslipEmp.ID; //If payslip already exists use payslip ID that user inputted
                }

                var Details = (from p in db.Payslip
                               where p.ID == payslipId
                               join Employee e in db.Employee
                               on p.Employee equals e.ID
                               join Designation d in db.Designation
                               on e.Designation equals d.ID
                               select new
                               { e.ID, e.Name, e.Surname, e.NII_Number, e.Bonus, d.Title, d.Yearly_Income, d.OvertimeAmount, p.Date_From,
                                 p.Date_To, p.Hours_Worked, p.Overtime }).FirstOrDefault(); //Retrives payslip info to generate

                var Rate = (from t in db.Tax_Rate
                            where Details.Yearly_Income >= t.Income_From && Details.Yearly_Income <= t.Income_To
                            select t.Rate).FirstOrDefault(); //Retrives tax rate info to generate

                decimal Monthly = Math.Round(Details.Yearly_Income / (Details.Hours_Worked * 52) * (Details.Hours_Worked * 52) / 12, 2); //formula from Internet
                decimal OvertimeAmount; //Overtime calculations
                if (Details.OvertimeAmount.HasValue)
                {
                    OvertimeAmount = (decimal)(Details.OvertimeAmount * Details.Overtime); //Convert to Decimal
                }
                else
                {
                    OvertimeAmount = 0; //if overtime is null set it to 0
                }

                //Calculations
                decimal gross = Monthly + Overtime;
                decimal tax = (Monthly + Overtime) * (Rate / 100);
                decimal net = (Monthly + Overtime - (Monthly + Overtime) * (Rate / 100));

                if (Details.Bonus != 0) //Is not equal to 0 (if the employee has a bonus)
                {
                    //Calculations based on bonus
                    decimal grossPay = gross + Convert.ToDecimal(Details.Bonus); 
                    decimal taxAmount = grossPay * (Rate / 100);
                    decimal netAmount = (grossPay) - (grossPay * (Rate / 100));
                    string[] info = { Details.ID, Details.Name, Details.Surname, Details.NII_Number, Details.Title,
                                  Details.Date_From.ToString("dd MMMM yyyy"), Details.Date_To.ToString("dd MMMM yyyy"),
                                  (Details.Hours_Worked * 4).ToString(), Monthly.ToString(), Details.Overtime.ToString(),
                                  OvertimeAmount.ToString(), gross.ToString(), Rate.ToString(), tax.ToString(), net.ToString(),
                                  Details.Bonus.ToString(), grossPay.ToString(), taxAmount.ToString(), netAmount.ToString()}; //Inputting payslip info in a list
                    payslipInfo.AddRange(info); //Inputting more than one value in a list through a single statement
                    manager.GeneratePayslip(payslipInfo); //Call the generate payslip method from the manager class
                }
                else
                {
                    //Inputting payslip info in a list
                    string[] info = { Details.ID, Details.Name, Details.Surname, Details.NII_Number, Details.Title,
                                  Details.Date_From.ToString("dd MMMM yyyy"), Details.Date_To.ToString("dd MMMM yyyy"),
                                  (Details.Hours_Worked * 4).ToString(), Monthly.ToString(), Details.Overtime.ToString(),
                                  Overtime.ToString(), gross.ToString(), Rate.ToString(), tax.ToString(), net.ToString(),
                                  Details.Bonus.ToString()}; //Inputting info in a list
                    payslipInfo.AddRange(info); //Inputting more than one value in a list through a single statement
                    employee.GeneratePayslip(payslipInfo); //Call the generate payslip method from the manager class
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException); //Shows error
            }
        }

        private void EditPayslip() //Edit payslip
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1();  //Connect to SSMS database
            Manager manager = new Manager();
            Employee employee = new Employee();

            Console.WriteLine("Enter Employee ID Card: ");
            string employeeId = Console.ReadLine();

            var id = (from e in db.Employee
                      where e.ID == employeeId
                      select e).FirstOrDefault(); //Get payslip from database (first or deafult)

            if (id == null) //If employee ID is incorect do this:
            {
                Console.Clear();
                Console.WriteLine("Incorrect Employee ID Card");
                ReturnToMainMenu();
            }

            Console.WriteLine("Enter Payslip Month");
            Int32.TryParse(Console.ReadLine(), out int month); //Convert to Int
            var MonthNum = (from p in db.Payslip
                            where p.Date_From.Month == month
                            select p).FirstOrDefault(); //Get month from databse base (first or deafult)

            if (MonthNum == null) //If no month is found in payslips
            {
                Console.Clear();
                Console.WriteLine("Incorrect Month");
                ReturnToMainMenu();
            }

            Console.WriteLine("Enter Payslip Year");
            Int32.TryParse(Console.ReadLine(), out int year); //Convert to Int
            var YearNum = (from p in db.Payslip
                           where p.Date_From.Year == year
                           select p).FirstOrDefault(); //Get year info from databse base (first or deafult)

            if (YearNum == null) //If no year is found in payslips
            {
                Console.Clear();
                Console.WriteLine("Incorrect Year");
                ReturnToMainMenu();
            }

            Console.Clear();
            Console.WriteLine("Payslip Date From (dd-MM-yyyy):"); //MM Month while mm minute
            DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime FromDate); //CultureInfo: date format
            Console.WriteLine("Payslip Date To (dd-MM-yyyy):");
            DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ToDate); //TryParseExtract is only usefd with DateTime

            Console.WriteLine("Hours Worked:");
            Decimal.TryParse(Console.ReadLine(), out decimal Hours); //Convert to Decimal

            Console.WriteLine("Overtime Hours:");
            Decimal.TryParse(Console.ReadLine(), out decimal Overtime); //Convert to Decimal

            var Payslip = (from p in db.Payslip
                           where p.Employee == employeeId
                           where p.Date_From.Month == month
                           where p.Date_From.Year == year
                           select p).FirstOrDefault(); //Get payslip info from databse base (first or deafult)

            if (Payslip != null) //If payslip fields all have written /inputted data
            {
                Payslip.Date_From = FromDate;
                Payslip.Date_To = ToDate;
                Payslip.Hours_Worked = Hours;
                Payslip.Overtime = Overtime;
            }

            try
            {
                db.SaveChanges(); //Save to database

                var PayslipEmp = (from p in db.Payslip
                                       where p.Employee == employeeId
                                  where p.Date_From.Month == month
                                       where p.Date_From.Year == year
                                       select p).FirstOrDefault();
                int payslip;
                List<string> payslipInfo = new List<string>(); //List

                if (PayslipEmp != null)
                {
                    var payslips = from p in db.Payslip
                                   select p.ID;
                    payslip = payslips.Count(); //Counts how many payslips are in the database to use last payslip
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
                               select new
                               { e.ID,  e.Name, e.Surname, e.NII_Number, e.Bonus, d.Title, d.Yearly_Income, d.OvertimeAmount, p.Date_From,
                                 p.Date_To, p.Hours_Worked, p.Overtime }).FirstOrDefault(); //Get details from databse base (first or deafult)

                var Rate = (from t in db.Tax_Rate
                            where Details.Yearly_Income >= t.Income_From && Details.Yearly_Income <= t.Income_To
                            select t.Rate).FirstOrDefault(); //Get rate from databse base (first or deafult)

                decimal Monthly = Math.Round(Details.Yearly_Income / (Details.Hours_Worked * 52) * (Details.Hours_Worked * 52) / 12, 2); //formula from Internet
                decimal OvertimeAmount;
                if (Details.OvertimeAmount.HasValue)
                {
                    OvertimeAmount = (decimal)(Details.OvertimeAmount * Details.Overtime); //Calculations
                }
                else
                {
                    OvertimeAmount = 0; //Change to 0
                }
                //Calculations
                decimal gross = Monthly + Overtime;
                decimal tax = (Monthly + Overtime) * (Rate / 100);
                decimal net = (Monthly + Overtime - (Monthly + Overtime) * (Rate / 100));

                if (Details.Bonus != 0)
                {
                    //Bonus Calculations
                    decimal grossPay = gross + Convert.ToDecimal(Details.Bonus);
                    decimal taxAmount = grossPay * (Rate / 100);
                    decimal netAmount = (grossPay) - (grossPay * (Rate / 100));
                    string[] info = { Details.ID, Details.Name, Details.Surname, Details.NII_Number, Details.Title,
                                  Details.Date_From.ToString("dd MMMM yyyy"), Details.Date_To.ToString("dd MMMM yyyy"),
                                  (Details.Hours_Worked * 4).ToString(), Monthly.ToString(), Details.Overtime.ToString(),
                                  OvertimeAmount.ToString(), gross.ToString(), Rate.ToString(), tax.ToString(), net.ToString(),
                                  Details.Bonus.ToString(), grossPay.ToString(), taxAmount.ToString(), netAmount.ToString()}; //Inputting info in a list
                    payslipInfo.AddRange(info); //Inputting more than one value in a list through a single statement
                    manager.GeneratePayslip(payslipInfo); //Call the generate payslip method from the manager class
                }
                else
                {
                    string[] info = { Details.ID, Details.Name, Details.Surname, Details.NII_Number, Details.Title,
                                  Details.Date_From.ToString("dd MMMM yyyy"), Details.Date_To.ToString("dd MMMM yyyy"),
                                  (Details.Hours_Worked * 4).ToString(), Monthly.ToString(), Details.Overtime.ToString(),
                                  Overtime.ToString(), gross.ToString(), Rate.ToString(), tax.ToString(), net.ToString(),
                                  Details.Bonus.ToString()}; //Inputting info in a list
                    payslipInfo.AddRange(info); //Inputting more than one value in a list through a single statement
                    employee.GeneratePayslip(payslipInfo); //Call the generate payslip method from the manager class
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.InnerException); //Shows error
            }
        }

        private void PayslipDetails()
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1(); //Connect to SSMS database

            Manager manager = new Manager();
            Employee employee = new Employee();
            int counter = 0;
            int counter2 = 0;

            Console.WriteLine("Enter Employee ID Card: ");
            string employeeId = Console.ReadLine();

            var id = (from e in db.Employee
                      where e.ID == employeeId
                      select e).FirstOrDefault(); //Get employee from database (first or deafult)

            if (id == null) //If employee ID is incorect do this:
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
                            select p).FirstOrDefault(); //Get month from databse base (first or deafult)

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
                           select p).FirstOrDefault(); //Get year from databse base (first or deafult)

            if (YearNum == null) //If a year for that specific month and employee increments a counter
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

                //Checks if payslip exists or not
                if(checks != null)
                {
                    Console.WriteLine("Payslip already exists");
                    counter2++; //2nd counter
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
                                     select new { d.Hours_Per_Week }).FirstOrDefault(); //Get hours from databse base (first or deafult)

                        Payslip NewPayslip = new Payslip(PayslipID.Count() + 1, DateFrom, DateTo, Hours.Hours_Per_Week, employeeId, 0);
                        db.Payslip.Add(NewPayslip);
                        db.SaveChanges(); //Save in database
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
            List<string> payslipInfo = new List<string>(); //list

            if(counter != 0)
            {
                var payslips = from p in db.Payslip
                               select p.ID;
                payslip = payslips.Count(); //Counts how many payslips are in the database to use last payslip
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
                            select new {e.ID, e.Name, e.Surname, e.NII_Number, e.Bonus, d.Title, d.Yearly_Income, d.OvertimeAmount, 
                                p.Date_From, p.Date_To, p.Hours_Worked, p.Overtime}).FirstOrDefault(); //Get details from database (first or deafult)

            var Rate = (from t in db.Tax_Rate
                        where Details.Yearly_Income >= t.Income_From && Details.Yearly_Income <= t.Income_To
                        select t.Rate).FirstOrDefault(); //Get rate info from database (first or deafult)

            decimal Monthly = Math.Round(Details.Yearly_Income / (Details.Hours_Worked * 52) * (Details.Hours_Worked * 52) / 12, 2); //formula from Internet
            decimal Overtime;

            //Calculations
            if(Details.OvertimeAmount.HasValue)
            {
                Overtime = (decimal)(Details.OvertimeAmount * Details.Overtime);
            }
            else
            {
                Overtime = 0;
            }
            decimal gross = Monthly + Overtime;
            decimal tax = (Monthly + Overtime) * (Rate / 100);
            decimal net = (Monthly + Overtime - (Monthly + Overtime) * (Rate / 100));

            if(Details.Bonus != 0)
            {
                decimal grossPay = gross + Convert.ToDecimal(Details.Bonus);
                decimal taxAmount = grossPay * (Rate / 100);
                decimal netAmount = (grossPay) - (grossPay * (Rate / 100));
                string[] info = { Details.ID, Details.Name, Details.Surname, Details.NII_Number, Details.Title, 
                                  Details.Date_From.ToString("dd MMMM yyyy"), Details.Date_To.ToString("dd MMMM yyyy"), 
                                  (Details.Hours_Worked * 4).ToString(), Monthly.ToString(), Details.Overtime.ToString(),
                                  Overtime.ToString(), gross.ToString(), Rate.ToString(), tax.ToString(), net.ToString(),
                                  Details.Bonus.ToString(), grossPay.ToString(), taxAmount.ToString(), netAmount.ToString()}; //Inputting info in a list
                payslipInfo.AddRange(info); //Inputting more than one value in a list through a single statement
                manager.GeneratePayslip(payslipInfo); //Call the generate payslip method from the manager class
            }
            else
            {
                string[] info = { Details.ID, Details.Name, Details.Surname, Details.NII_Number, Details.Title,
                                  Details.Date_From.ToString("dd MMMM yyyy"), Details.Date_To.ToString("dd MMMM yyyy"),
                                  (Details.Hours_Worked * 4).ToString(), Monthly.ToString(), Details.Overtime.ToString(),
                                  Overtime.ToString(), gross.ToString(), Rate.ToString(), tax.ToString(), net.ToString(),
                                  Details.Bonus.ToString()}; //Inputting info in a list
                payslipInfo.AddRange(info); //Inputting more than one value in a list through a single statement
                employee.GeneratePayslip(payslipInfo); //Call the generate payslip method from the manager class
            }

            counter = 0;
        } //Payslip details

        private void EmployeeSalaries()
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1();  //Connect to SSMS database
            int counter = 0;

            Console.WriteLine("Enter Month");
            string userInputMonth = Console.ReadLine();
            Int32.TryParse(userInputMonth, out int month); //Convert to int
            var MonthNum = (from e in db.Employee
                            join Designation d in db.Designation
                            on e.Designation equals d.ID
                            orderby d.Yearly_Income descending
                            select e).ToList();

            if (MonthNum == null)
            {
                counter++;
            }

            if(counter != 0) //If month is incorrect
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
                        monthly = Math.Round((Emp.Yearly_Income / (Emp.Hours_Worked * 52) * (Emp.Hours_Worked * 52) / 12), 2); //Round to 2dp
                    }
                    else
                    {
                        var Emp2 = (from emp in db.Employee
                                    where emp.ID == e.ID
                                    join Designation d in db.Designation
                                    on emp.Designation equals d.ID
                                    select new { emp.ID, emp.Name, emp.Surname, d.Hours_Per_Week, d.Yearly_Income }).FirstOrDefault();

                        name = Emp2.Name + " " + Emp2.Surname;
                        monthly = Math.Round((Emp2.Yearly_Income / (Emp2.Hours_Per_Week * 52) * (Emp2.Hours_Per_Week * 52) / 12), 2); //Round to 2dp
                    }

                    Console.WriteLine("Employee Name - " + name + "\t\t" + "Gross Pay - " + monthly + "\t\t"); //Show employee and gross pay
                }
            }
            else
            {
                //If there are no employees in the list /database
                Console.WriteLine("No Employees");
                ReturnToMainMenu();
            }
        } //Employee salaries

        private void TotalHoursWorkedForEachEmployee() //Total hours worked for each employee
        {
            PayrollSystemEntities1 db = new PayrollSystemEntities1(); //Connect to SSMS database
            Console.Clear();
            Console.Write("Choose Start Month: ");
            int startMonth = int.Parse(Console.ReadLine()); //Convert to int
            Console.Write("Choose Start Year: ");
            int startYear = int.Parse(Console.ReadLine()); //Convert to int
            Console.Write("Choose End Month:");
            int endMonth = int.Parse(Console.ReadLine()); //Convert to int
            Console.Write("Choose End Year:");
            int endYear = int.Parse(Console.ReadLine()); //Convert to int

            var firstDayOfMonth = new DateTime(startYear, startMonth, 1);
            var lastDayOfMonth = new DateTime(endYear, endMonth, 1).AddMonths(1).AddDays(-1);

            var empList = (from payslip in db.Payslip
                           where (firstDayOfMonth >= payslip.Date_From &&
                                  firstDayOfMonth <= payslip.Date_To) ||
                                 (lastDayOfMonth >= payslip.Date_From &&
                                 lastDayOfMonth <= payslip.Date_To)
                           group payslip by payslip.Employee into g
                           select new { Employee = g.Key, Hours = g.Sum(x => x.Hours_Worked) }).OrderBy(g => g.Hours);

            Console.WriteLine();
            Console.WriteLine("Employee Worked Hours:");
            foreach (var payslip in empList)
            {
                Console.WriteLine("Employee ID: {0} - Hours Worked: {1}", payslip.Employee, payslip.Hours); //Shows employee and their worked hours
            }
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
            ReturnToMainMenu();
        }

        private void ReturnToMainMenu() //Return to Main Menu
        {
            Console.WriteLine("\nEnter any key to return to the Main Menu"); // \n = Skips a line before this line of code
            Console.ReadKey();
            MenuDisplay();
        }
    }
}
