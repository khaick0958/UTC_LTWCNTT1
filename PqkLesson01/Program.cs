using System;
using System.Text;
using System.ComponentModel.Design;

namespace PqkLesson01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            StudentService service = new StudentService();
            MenuManager menu = new MenuManager(service);

            menu.ShowMenu();
        }
    }
}