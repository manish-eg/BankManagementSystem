﻿using BankManagementSystem.Interface;
using BankManagementSystem.Model;
using System;
using System.Text.RegularExpressions;

namespace BankManagementSystem.Controller
{
    public sealed class CustomerController : ICustomer
    {
        public void CreateAccount(CustomerModel customer)
        {
            AccountModel.AccountNumber++;
            Program.CustomerTable.Add(AccountModel.AccountNumber, customer);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAccount created successfully!!");
            Console.WriteLine($"\nYour account number is {AccountModel.AccountNumber}");
            Console.WriteLine($"\nYour IFSC code is {customer.AccountDetails.BranchModel.IFSCCode}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void EditDetails(long accountNumber)
        {
            CustomerModel customerModel;
            customerModel = (CustomerModel)Program.CustomerTable[accountNumber];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Account details:");
            ViewDetails(accountNumber);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nSelect the field you want to update: \n1.Name\n2.DOB\n3.Address\n4.Phone Number\n5.Exit");
            Console.ForegroundColor=ConsoleColor.White;
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.WriteLine("Enter new name:");
                    string replaceName = Console.ReadLine();
                    customerModel.CustomerName = replaceName;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Details updated successfully\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Enter updated date of birth:");
                    DateTime updateDOB = Convert.ToDateTime(Console.ReadLine());
                    customerModel.DateOfBirth = updateDOB;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Details updated successfully\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.WriteLine("Enter new Address:");
                    Console.Write("Location: ");
                    string updatedLocation = Console.ReadLine();

                    Console.Write("\nCity: ");
                    string updatedCity = Console.ReadLine();

                    Console.Write("\nPincode: ");
                    int updatedPincode = Convert.ToInt32(Console.ReadLine());

                    Console.Write("\nCountry: ");
                    string updatedCountry = Console.ReadLine();
                    customerModel.CustomerAddress.LocationAddress = updatedLocation;
                    customerModel.CustomerAddress.City = updatedCity;
                    customerModel.CustomerAddress.PinCode = updatedPincode;
                    customerModel.CustomerAddress.Country = updatedCountry;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Details updated successfully\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Enter new Phone number:");
                    long updatePhoneNumber = Convert.ToInt64(Console.ReadLine());
                    customerModel.PhoneNumber = updatePhoneNumber;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Details updated successfully\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 5:
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter correct option!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
        public void ViewDetails(long accountNumber)
        {

            CustomerModel customer;
            customer = (CustomerModel)Program.CustomerTable[accountNumber];
            Program.DisplayBankName();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Customer name: " + customer.CustomerName);
            Console.WriteLine("Customer DOB: " + customer.DateOfBirth);
            Console.WriteLine("Customer address: " + customer.CustomerAddress.LocationAddress + ", " + customer.CustomerAddress.City + ", \n" + customer.CustomerAddress.PinCode + ", " + customer.CustomerAddress.Country);
            Console.WriteLine("Customer phone number: " + customer.PhoneNumber);
            Console.WriteLine("Account number: " + accountNumber);
            Console.WriteLine("Account type: " + customer.AccountDetails.AccountType);
            Console.WriteLine("Date created: " + customer.AccountDetails.DateOfCreation);
            Console.WriteLine("Branch Name: " + customer.AccountDetails.BranchModel.BranchName);
            Console.WriteLine("IFSC code: " + customer.AccountDetails.BranchModel.IFSCCode);
            Console.WriteLine("Branch Address: " + customer.AccountDetails.BranchModel.branchAddress.LocationAddress + ", " + customer.AccountDetails.BranchModel.branchAddress.City + ", \n" + customer.AccountDetails.BranchModel.branchAddress.PinCode + ", " + customer.AccountDetails.BranchModel.branchAddress.Country);
            Console.ForegroundColor= ConsoleColor.White;
        }
        public static bool CustomerValidate(long accountNumber, string password)
        {

            if (!Program.CustomerTable.ContainsKey(accountNumber)) return false;
            if (password == "") return false;

            CustomerModel customerObj = (CustomerModel)Program.CustomerTable[accountNumber];

            if (!customerObj.Password.Equals(password)) return false;

            return true;
        }

        public bool IsValidEmail(string email)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
