using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemPayroll
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuHandler menuHandler = new MenuHandler();
            menuHandler.MenuDisplay(); //Displays menu
        }
    }
}
