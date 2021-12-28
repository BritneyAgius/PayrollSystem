using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void AddEmployee()
        {
            Console.WriteLine("Add Employee");
        }

        private void EditEmployee()
        {
            Console.WriteLine("Edit Employee");
        }

        private void AddDesignation()
        {
            Console.WriteLine("Add Designation");
        }

        private void EditDesignation()
        {
            Console.WriteLine("Edit Designation");
        }

        private void AddTaxRate()
        {
            Console.WriteLine("Add Tax Rate");
        }

        private void EditTaxRate()
        {
            Console.WriteLine("Edit Tax Rate");
        }

        private void AddPayslip()
        {
            Console.WriteLine("Add Payslip");
        }

        private void EditPayslip()
        {
            Console.WriteLine("Edit Payslip");
        }

        private void GeneratePayslip()
        {
            Console.WriteLine("Generate Payslip");
        }

        private void EmployeeSalaries()
        {
            Console.WriteLine("Employee Salaries");
        }

        private void TotalHoursWorkedForEachEmployee()
        {
            Console.WriteLine("Total Hours Worked For Each Employee");
        }

        private void ReturnToMainMenu()
        {
            Console.WriteLine("\nEnter any key to return to the Main Menu"); // \n = Skips a line
            Console.ReadKey();
            MenuDisplay();
        }
    }
}
