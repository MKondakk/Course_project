using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoorseProdject01.Classes;

namespace CoorseProdject01
{
    static class Program
    {
       //public Globals 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignUpForm());

        }
    }
}
