using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_demo1
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Boolean checkresult;
            MortgageCredit Customer = new MortgageCredit();
            Customer.input();
            checkresult = Customer.Check();
            Customer.HouseMortgage();
            Customer.Print(checkresult);
        }
    }
    class MortgageCredit
    {
        public float rate;
        public Boolean checkresult;
        public double creditamount;
        public Boolean housetype;
        int age;
        int income;
        int date_mortgage;
        int mortgage_credit;
        //Boolean check_result;
        public MortgageCredit()
        {
            rate = 0.04f;
        }

        public void input()
        {
            Console.WriteLine("Please enter your age followed by ENTER:");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your income followed by ENTER:");
            income = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How much would you like to borrow followed by ENTER:");
            mortgage_credit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How long would you like your mortgage for (years) followed by ENTER:");
            date_mortgage = Convert.ToInt32(Console.ReadLine());
        }
        public Boolean Check()
        {
            if (age>=18 && income >= 15000 && mortgage_credit <= income * date_mortgage * 0.3 ? true : false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void HouseMortgage()
        {
            creditamount = mortgage_credit * (rate / 12) * Math.Pow((1 + rate / 12), 12 * date_mortgage) / (Math.Pow((1 + rate / 12),12* date_mortgage) - 1);
        }
        public void Print(Boolean checkresult)
        {
            if(checkresult)
            {
                Console.WriteLine("This is your result:");
                Console.WriteLine("Your credit was accepted");
                Console.WriteLine("The total credit amount offered is: " + creditamount);
                Console.WriteLine("The interest rate of the credit is: " + rate);
                Console.WriteLine("Thank you for visiting!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your credit was rejected");
                Console.ReadLine();

            }
        }
    }
}
