﻿using System;
using StoreApp.DataLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using StoreApplication;
using System.Text.RegularExpressions;
using System.Linq;

namespace StoreApp.Main
{
    class Program
    {
        public static RetrieveDatabaseHandler DBRHandler = new RetrieveDatabaseHandler();
        public static InputDatabaseHandler DBIHandler = new InputDatabaseHandler();
        static void Main(string[] args)
        {

            Console.WriteLine("Hello!");

            string initialInput = "0";
            string secondaryInput = "0";
            bool whileBool = true;

            //DB initialization
            string connectionString = DBRHandler.GetConnectionString();

            DbContextOptions<StoreApplicationContext> options = new DbContextOptionsBuilder<StoreApplicationContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new StoreApplicationContext(options);

            while (whileBool == true)
            {
                Console.WriteLine("Are you using this console as a manager or a customer?\n[1] Manager\n[2] Customer\n");
                initialInput = CheckAndReturnCustomerOptionChosen(Console.ReadLine(), 2);

                if (initialInput == "1") //Manager
                {
                    string managerIDInput;
                    //code for manager
                    //Can display current stocks and things for locations and other things stored
                    //Managment can stock their stores and check and edit customer data

                    Console.WriteLine("What is your manager ID?");
                    managerIDInput = Console.ReadLine();

                    //Some code to compare manager ID to the table and welcome manager options

                }
                else if (initialInput == "2") //Customer
                {
                    //code for customer
                    //Will run code to make new customer, retrieve old customer data, and place orders
                    Console.WriteLine("Welcome! Are you a returning customer?\n[1] Yes\n[2] No\n");
                    secondaryInput = CheckAndReturnCustomerOptionChosen(Console.ReadLine(), 2);
                    whileBool = false;
                }
                else //Invalid input
                {
                    Console.WriteLine("Invalid input, please type one of the following options");
                }
            }
            whileBool = true;
            if (secondaryInput == "1") //Returning Customer
            {
                foreach (DataLibrary.Entities.Customer customer in context.Customer)
                {
                    int customerID;
                    bool IDCheck = false;

                    Console.WriteLine("Welcome back! What is your customer ID?");
                    secondaryInput = Console.ReadLine();

                    while (IDCheck == false)
                    {
                        if (DBRHandler.CheckCustomerIDParsable(secondaryInput) == false)
                        {
                            Console.WriteLine("Incorrect customer ID. Please try again");
                        }
                        else //if the input only has numbers in it
                        {
                            customerID = Int32.Parse(secondaryInput);

                            DBRHandler.GetCustomerData(customerID, context);

                        }
                    }


                }
            }
            else if (secondaryInput == "2")
            {
                StoreApplication.Customer newCust = new StoreApplication.Customer();

                while (whileBool == true)
                {

                    if (newCust.CheckCustomerNotNull() == false)
                    {
                        if (newCust.firstName == null)
                        {
                            Console.WriteLine("What is your first name?");
                            newCust.firstName = Console.ReadLine();
                        }
                        else if (newCust.lastName == null)
                        {
                            Console.WriteLine("What is your last name?");
                            newCust.lastName = Console.ReadLine();
                        }
                        else if (newCust.customerAddress.CheckAddressNotNull() == false)
                        {
                            Console.WriteLine("Please enter an address. What is your street?");
                            newCust.customerAddress.street = Console.ReadLine();

                            Console.WriteLine("Please enter a city");
                            newCust.customerAddress.city = Console.ReadLine();

                            Console.WriteLine("Please enter a state");
                            newCust.customerAddress.state = Console.ReadLine();

                            Console.WriteLine("Please enter a zip");
                            newCust.customerAddress.zip = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Customer profile successfully created! Welcome, " + newCust.firstName + "!");
                        DBIHandler.AddNewCustomerData(newCust);
                        break;
                    }
                }
            }
            else if(secondaryInput == "1")
            {
                Console.WriteLine("What is your customer ID?");
                secondaryInput = Console.ReadLine();
                if (secondaryInput == "1")
                {

                }
                else if (secondaryInput == "2")
                {

                }
            }
        }
        public static void PlaceOrder()
        {
            Console.WriteLine("How many burgers would you like? : ");
            string input = Console.ReadLine();
            int burger = Int32.Parse(input);

            Console.WriteLine("How many fries would you like? : ");
            input = Console.ReadLine();
            int fries = Int32.Parse(input);

            Console.WriteLine("How many sodas would you like? : ");
            input = Console.ReadLine();
            int soda = Int32.Parse(input);
        }

        //Used for checking menue options are not null or invalid given the input, and the max number of options on a given menue
        public static string CheckAndReturnCustomerOptionChosen(string input, int maxNum)
        {
            bool correctInput = false;
            int inputInt;

            while(correctInput == false)
            {
                if (input == null)
                {
                    Console.WriteLine("Invalid input. Insert correct input option");
                }
                else
                {
                    foreach (char thing in input)
                    {
                        if (thing < '0' || thing > '9')
                        {
                            Console.WriteLine("Invalid input. Insert correct input option");
                        }
                        else
                        {
                            inputInt = Int32.Parse(input);
                            if (inputInt > maxNum)
                            {
                                Console.WriteLine("Invalid input. Insert correct input option");
                            }
                            else
                            {
                                return input;
                            }
                            return input;
                        }
                    }
                }
            }

            return input;
        }
    }
}
