using Microsoft.EntityFrameworkCore;
using System;

namespace InventoryManagementSystem
{
    class Program
    {
        //static username="";
        static int choice;
        //static int logout=0;
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t\t\tInventory Management System\n" +
                "\n\tWe handle the process by which you track your goods throughout your entire supply chain, from purchasing to production to end sales. It governs how you approach inventory management for your business." +
                "\nThank you visiting us. Please login into our system to enjoy our facilities. \n------------------------------------------------------------------------------------------------------------------------\n");
            string username = "", password = "";

            Console.Write("Enter Username: ");
            username = Console.ReadLine();


            if (AdminOperations.isUsernameAvailable(username) == 1)
            {
                Console.Write("Enter Password: ");
                password = Console.ReadLine();

                if (AdminOperations.isValidated(password) == 1) {
                    Console.WriteLine("\nYou are logged in successfully. We are redirecting you to our menu. Just a moment");
                    Console.ReadKey();

                    Console.Clear();
                    login();
                }
                else
                {
                    Console.WriteLine("Password does not match. Please check with admin.");
                }
                 
                
            }else
                {
                    Console.WriteLine("User Does not exist in our system. Please register yourself with admin.");
                }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

        }

        public static void login()
        {

            //addRole();
            while (choice==0)
            {
                

                //Console.WriteLine("Please login. Choices are as follows\n1. Admin \n2. User\n0. Exit\n----------------------------------------");
                //choice = Convert.ToInt32(Console.ReadLine());
                switch (AdminOperations.loggedIn)
                {
                    case 1:
                        {
                            AdminOperations.AdminMenu();
                            break;
                        }

                    case 2:
                        {
                            UserOperations.UserMenu();
                                                       
                            //logout = 0;
                            continue;
                        }
                   
                    default:
                        {
                            Console.WriteLine("Wrong choice entered. Please try again. ");
                            break;
                        }
                }
            }
        }
        //public static void addRole()
        //{
        //    var ctx = new MyDebContext();
        //    ROLE adminObj = new ROLE() {Role_Name="admin" };
        //    ROLE userObj = new ROLE() {Role_Name="user" };
        //    ctx.ROLES.Add(adminObj);
        //    ctx.ROLES.Add(userObj);
        //}
    }
    class MyDebContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server =.; Database = AngularReact; Trusted_Connection = True; ");
            //optionsBuilder.UseSqlServer(@"Server =SUPRIYAKOL-VD\SQL2017; Database=InventoryMgtSystem; User ID=sa; Password=cybage@123456;");
            optionsBuilder.UseSqlServer(@"Server =SUPRIYAKOL-VD\SQL2017; Database=IMS; User ID=sa; Password=cybage@123456;");
        }
        public virtual DbSet<USERS> USERS { get; set; }
        //public virtual DbSet<INVOICE> INVOICE_DATA { get; set; }
        public virtual DbSet<PRODUCT_CATEGORIES> PRODUCT_CATEGORIES { get; set; }
        //public virtual DbSet<STORAGE> STORAGES { get; set; }
        public virtual DbSet<PRODUCTS> PRODUCTS { get; set; }
        public virtual DbSet<ROLE> ROLES { get; }
        //public virtual DbSet<SHIPPING> SHIPPING { get; set; }

    }


}
