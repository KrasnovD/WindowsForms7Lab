using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labka7
{
    public struct Person
    {
        public string lastName;
        public string name;
        public string otchestvo;
        public double srednBall;
        public int year;
        public Person(string tempLastName,
        string tempName,
        string tempOtchestvo,
        int tempyear, double tempsrednBall)
        {
            lastName = tempLastName;
            name = tempName;
            otchestvo = tempOtchestvo;
            srednBall = tempsrednBall;
            year = tempyear;

        }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}
