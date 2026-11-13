using EFCORE04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Identity.Client;
using System.Net;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EFCORE04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)

            {
                Console.WriteLine("========== BANK MANAGEMENT SYSTEM ==========");
                Console.WriteLine("1. Add a new Customer");
                Console.WriteLine("2. Open a new Account for a Customer");
                Console.WriteLine("3. Update Account Status");
                Console.WriteLine("4. Remove an Account from a Customer");
                Console.WriteLine("5. List all Customers (with accounts)");
                Console.WriteLine("0. Exit");

                Console.Write("\nChoose an option: ");

                string? choic = Console.ReadLine();

                using (var context = new ApplicationDbContext())
                {

                    switch (choic)
                    {
                        case "1":
                            AddCustomer(context);
                            break;
                        case "2":
                            OpenAccont(context);
                            break;
                        case "3":
                            UpdateAccountStatus(context);
                            break;
                        case "4":
                            RemoveAccount(context);
                            break;
                        case "5":
                            ListCustomer(context);
                            break;
                        case "0":
                            isRunning = false;
                            Console.WriteLine("GoodBye");
                            continue;
                        default:
                            Console.WriteLine("Invalid choice! Please choose a number from 0 to 5.");
                            break;
                    }
                }
                Console.WriteLine("\nPress any key to return to the menu...");

                Console.ReadKey();
            }
        }

        static void AddCustomer(ApplicationDbContext context)
        {
            Console.Write("Full Name:");

            string name = Console.ReadLine();

            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dob) || dob >= DateTime.Today)
            {
                Console.WriteLine("Invalid date of birth!");
                return;
            }

            Console.Write("Address:");

            string adderss = Console.ReadLine();


            Console.Write("Email :");

            string emall = Console.ReadLine();

            Console.Write(" PhonNumber:");

            string phonnumber = Console.ReadLine();
            Console.Write(" CustomerType:");

            string customerstype = Console.ReadLine();

            Console.Write(" NationlId:");

            string nationalld = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(adderss)
                || !emall.Contains('@') || nationalld.Length != 14
                || !nationalld.All(char.IsDigit)
                || !phonnumber.All(char.IsDigit)
                || (phonnumber.Length < 10)
                || (customerstype != "Individual" && customerstype != "Business"))
            {
                Console.WriteLine("Invalid customer information!");
                return;
            }

            Customers customers = new Customers
            {
                FullName = name,
                Adderss = adderss,
                DataOfBirth = dob,
                Emall = emall,
                PhonNumber = phonnumber,
                CustomersType = customerstype,
                Nationalld = nationalld

            };
            context.Customers.Add(customers);
            context.SaveChanges();
        }





        static void OpenAccont(ApplicationDbContext context)
        {
            Console.Write("Account Number: ");
            if (!int.TryParse(Console.ReadLine(), out int accounnumber))
            {
                Console.WriteLine("Invalid account number!");
                return;
            }

            if (context.Accounts.Any(a => a.AccounNumber == accounnumber))
            {
                Console.WriteLine("Account number already exists!");
                return;
            }


            Console.Write("AccounType: ");
            string accountype = Console.ReadLine();

            if (!int.TryParse(Console.ReadLine(), out int braid))
            {
                Console.WriteLine("Invalid branch code!");
                return;
            }

            Console.Write("customersId: ");
            if (!int.TryParse(Console.ReadLine(), out int CustomersId))
            {
                Console.WriteLine("Invalid customer ID!");
                return;
            }

            Console.Write("OwnershipType: ");

            string ownershiptype = Console.ReadLine();

            bool branchExists = context.Branches.Any(b => b.Code == braid);

            if (!branchExists)
            {
                Console.WriteLine("Branch does not exist!");
                return;

            }

            bool customerExists = context.Customers.Any(c => c.Id == CustomersId);
            if (!customerExists)
            {
                Console.WriteLine("Customer  does not exist!");
                return;

            }



            AccountCustomers ACCOUNTCUSTOMER = new AccountCustomers
            {
                customersId = CustomersId,
                accountsId = accounnumber,
                OwnershipType = ownershiptype,
                OwnershipStartdata = DateTime.Now,
                AccountStatus = "Active"

            };



            Accounts ACCOUNTS = new Accounts
            {

                AccounNumber = accounnumber,
                CrrentBalace = 0,
                AccounType = accountype,
                OpeingData = DateTime.Now,
                BraId = braid

            };

            context.Accounts.Add(ACCOUNTS);
            context.AccountCustomers.Add(ACCOUNTCUSTOMER);
            context.SaveChanges();
            Console.WriteLine("Account opened successfully!");


        }











        static void UpdateAccountStatus(ApplicationDbContext context)
        {
            Console.Write("CustomersId:  ");

            if (!int.TryParse(Console.ReadLine(), out int CUStomersId))
            {
                Console.WriteLine("Invalid account number!");
                return;
            }
            Console.Write("AccountsId:  ");

            if (!int.TryParse(Console.ReadLine(), out int ACCountsId))
            {
                Console.WriteLine("Invalid account number!");
                return;
            }

            var accountCustomer = context.AccountCustomers
                .FirstOrDefault(AC => AC.customersId == CUStomersId && AC.accountsId == ACCountsId);

            if (accountCustomer == null)
            {
                Console.WriteLine("Account relationship not found!");
                return;
            }
            accountCustomer.AccountStatus = accountCustomer.AccountStatus == "Active" ? "Inactive" : "Active";
            context.SaveChanges();
            Console.WriteLine($"Account status updated to: {accountCustomer.AccountStatus}");
        }










        static void RemoveAccount(ApplicationDbContext context)
        {
            Console.Write("CustomersId:  ");

            if (!int.TryParse(Console.ReadLine(), out int CUStomersId))
            {
                Console.WriteLine("Invalid account number!");
                return;
            }
            Console.Write("AccountsId:  ");

            if (!int.TryParse(Console.ReadLine(), out int ACCountsId))
            {
                Console.WriteLine("Invalid account number!");
                return;
            }

            var accountCustomer = context.AccountCustomers
                .FirstOrDefault(AC => AC.customersId == CUStomersId && AC.accountsId == ACCountsId);

            if (accountCustomer == null)
            {
                Console.WriteLine("Account relationship not found!");
                return;
            }

            context.AccountCustomers.Remove(accountCustomer);
            context.SaveChanges();
            Console.WriteLine("Account removed from customer successfully!");

        }
        static void ListCustomer(ApplicationDbContext context)

        {
            var customers = context.Customers.Include(C => C.AccountCustomers).ThenInclude(CA => CA.accounts).ToList();
            if (!customers.Any())
            {
                Console.WriteLine("No customers found!");
                return;

            }
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Id);
                Console.WriteLine(customer.FullName);
                Console.WriteLine(customer.Nationalld);
                Console.WriteLine(customer.Emall);
                Console.WriteLine(customer.PhonNumber);
                Console.WriteLine(customer.CustomersType);
                if (!customer.AccountCustomers.Any())

                {
                    Console.WriteLine("No accounts found.");
                    return;
                }
                foreach (var item in customer.AccountCustomers)
                {
                    Console.WriteLine(item.accounts.AccounNumber);
                    Console.WriteLine(item.accounts.AccounType);
                    Console.WriteLine(item.accounts.CrrentBalace);
                    Console.WriteLine(item.OwnershipType);
                    Console.WriteLine(item.AccountStatus);
                }
            }



        }
    }
}

