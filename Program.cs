﻿// Xiaofei Li, Yuhua Liao, and Isabell Linde
// Group 7

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Version_A1
{
    struct Credit
    // To define a structure including some variables about customers' information
    {
        public int age;
        public int date_mortgage;
        public int mortgage_credit;
        public float rate;
        public double income;
        public double creditamount;
        public string propertytype;
    }
    class MainClass
    // This is the main class to carry out specific operations
    // In this main class, if input is not valid, errors will be caught and customers can enter information again
    {
        static void Main(string[] args)
        {
            try
            {
                Boolean input_check_result, credit_check_result;
                MortgageCredit Customer = new MortgageCredit();
                do
                {
                    Customer.Input();
                    input_check_result = Customer.Input_check();
                }
                while (!input_check_result);
                credit_check_result = Customer.Credit_check();
                Customer.HouseMortgage();
                Customer.Print(credit_check_result);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please enter your age, income and other information in number!");
                Console.ReadLine();
            }
        }
    }

    class MortgageCredit
    // This class has different methods associated with actions in calculating the amount of mortgage credit
    {
        Credit new_credit;
        const float flat_rate = 0.04f;
        // if the customer wants to use the loan to buy a flat, the yearly rate will be 4%

        const float house_rate = 0.06f;
        // if the customer wants to use the loan to buy a house, the yearly rate will be 6%

        public void Input()
        // This method aims to give customer instruction and receive their information 
        {
            Console.WriteLine("Please enter your age followed by ENTER:");
            new_credit.age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your income followed by ENTER:");
            new_credit.income = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("How much would you like to borrow followed by ENTER:");
            new_credit.mortgage_credit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How long would you like your mortgage for (years) followed by ENTER:");
            new_credit.date_mortgage = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What kind of property do you want to buy (f for flat or h for house) followed by ENTER:");
            new_credit.propertytype = Console.ReadLine();
        }
        public Boolean Input_check()
        // This method aims to check if the property type entered is valid
        {
            if (new_credit.propertytype == "h" || new_credit.propertytype == "f")
            // if the customer inputs the correct type of property
            {
                return true;
            }
            else
            // if the customer incorrectly inputs property type
            {
                Console.WriteLine("Please enter your property type in correct format!");
                Console.WriteLine("Once again:");
                return false;
            }
        }
        public Boolean Credit_check()
        // This method aims to check if the customer satisfies all the necessary requirements to obtain a mortgage
        {
            if (new_credit.age >= 18 && new_credit.income >= 15000 && new_credit.mortgage_credit <= new_credit.income * new_credit.date_mortgage * 0.3 ? true : false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void HouseMortgage()
        // This method aims to calculate the amount of mortgage credit that customers can obtain
        {
            if (new_credit.propertytype == "f")
            // if user inputs flat for property type, then the rate will be the flat rate
            {
                new_credit.rate = flat_rate;
            }
            else
            // if user inputs house for property type, then the rate will be the house rate
            {
                new_credit.rate = house_rate;
            }
            // new.creditamount is the monthly payment to the bank
            // We used the PMT formula to calculate this amount
            // M = P((r(1+r)^n) / ((1+r)^n - 1)) where M is the monthly payment, P is your principal, r is the monthly interest rate and n is how many months you would like to pay back the loan
            new_credit.creditamount = new_credit.mortgage_credit * (new_credit.rate / 12) * Math.Pow((1 + new_credit.rate / 12), 12 * new_credit.date_mortgage) / (Math.Pow((1 + new_credit.rate / 12), 12 * new_credit.date_mortgage) - 1);
        }
        public void Print(Boolean credit_check_result)
        // This mathod aims to display the result to customers
        {
            if (credit_check_result)
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("This is your result:");
                Console.WriteLine("Your credit was accepted");
                Console.WriteLine("The total credit amount offered is: {0}/per month", Math.Round(new_credit.creditamount, 2));
                Console.WriteLine("The type of your property is:{0}", new_credit.propertytype);
                Console.WriteLine("The interest rate of the credit is: {0}", new_credit.rate);
                Console.WriteLine("Thank you for visiting!");
                Console.WriteLine("*******************************************");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("Your credit was rejected");
                Console.WriteLine("*******************************************");
                Console.ReadLine();
            }
        }
    }
}


// Features that we used in our program
// Formatting Strings
// Loop Structures (while loop)
// Ternary Operator 
// Properties
// Access Modifiers
// Constructor
// Constants (the yearly rates for houses and flats are constant)
// Structs
// Static methods (in MainClass)
// Exception Handling (Try-Catch Block)