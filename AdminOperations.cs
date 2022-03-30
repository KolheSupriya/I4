using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    class AdminOperations
    {
        public static int loggedIn=0;
        static int user_choice;
        public static int isUsernameAvailable(string username)
        {
            var ctx = new MyDebContext();
            var users = from data in ctx.USERS select data;

            foreach (var user in users)
            {
                if (user.User_Name == username)
                {
                    return 1;
                }
            }
            return 0;
        }
        public static int isValidated(string password)
        {
            var ctx = new MyDebContext();
            var users = from data in ctx.USERS select data;

            foreach (var user in users)
            {
                if (user.Password == password)
                {
                    loggedIn = user.Role_ID;
                    return 1;
                }
            }
            return 0;
        }

        public static void deleteSubproductByID(int productId)
        {
            var ctx = new MyDebContext();
            PRODUCTS deleteProduct = new PRODUCTS() { Products_ID = productId };
            ctx.Remove(deleteProduct);
            if (ctx.SaveChanges() > 0)
            {
                Console.WriteLine("Result-> Product Deleted");
            }
        }
        public static void deleteProductByID(int productId)
        {
            var ctx = new MyDebContext();
            PRODUCT_CATEGORIES deleteProduct = new PRODUCT_CATEGORIES() { Product_Category_ID = productId };
            ctx.Remove(deleteProduct);
            if (ctx.SaveChanges() > 0)
            {
                Console.WriteLine("Result-> Product Deleted");
            }
        }

        public static void getUserDataByID()
        {
            var ctx = new MyDebContext();
            Console.Write("Please enter User ID: ");
            var findUserData = ctx.USERS.First(x => x.User_ID == Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("USER ID: "+ findUserData.User_ID);
            Console.WriteLine("Username: "+ findUserData);
            Console.WriteLine("First Name: "+ findUserData);
            Console.WriteLine("Last Name: "+ findUserData);
            Console.WriteLine("Password: "+ findUserData);
            Console.WriteLine("City: "+ findUserData);
            Console.WriteLine("Address: "+ findUserData);
            Console.WriteLine("Zip Code: "+ findUserData);
            Console.WriteLine("Email: "+ findUserData);
            Console.WriteLine(": "+ findUserData);
            UserOperations.getProductUserAccess(findUserData.Product_Access);
            
            
            

        }
        public static void getUserData()
        {

            using (var inventory = new MyDebContext())
            {
                foreach (var user in inventory.USERS.ToList())
                {
                    
                    Console.WriteLine("User ID: " + user.User_ID);
                    Console.WriteLine("Username: " + user.User_Name);
                    Console.WriteLine("First Name: " + user.First_Name);
                    Console.WriteLine("Last Name: " + user.Last_Name);
                    Console.WriteLine("Password: " + user.Password);
                    Console.WriteLine("City: " + user.City);
                    Console.WriteLine("Address: " + user.Address);
                    Console.WriteLine("Zip_Code: " + user.Zip_Code);
                    Console.WriteLine("Email: " + user.Email);

                    var findProductData = inventory.PRODUCTS.First(x => x.Products_ID == user.Product_Access);
                    var findProductName = inventory.PRODUCT_CATEGORIES.First(x => x.Product_Category_ID == Convert.ToInt32(findProductData.Product_Category_ID));
                    Console.WriteLine("Product alloted: " + findProductName.Product_Name);




                }


                //var ctx = new MyDebContext();
                //var userList = ctx.USERS.FromSqlRaw<USERS>("Select * from USERS");
                ////Console.WriteLine("User_ID , Roll_ID , User_Name , First_Name , Last_Name, Password , City , Adress , Zip_Code , Email");
                //foreach (var user in userList)
                //{
                //    Console.WriteLine("User ID: "+user.User_ID);
                //    Console.WriteLine("Username: "+user.User_Name);
                //    Console.WriteLine("First Name: "+user.First_Name);
                //    Console.WriteLine("Last Name: "+user.Last_Name);
                //    Console.WriteLine("Password: "+user.Password);
                //    Console.WriteLine("City: "+user.City);
                //    Console.WriteLine("Address: "+user.Address);
                //    Console.WriteLine("Zip_Code: "+user.Zip_Code);
                //    Console.WriteLine("Email: "+user.Email);

                //    var findProductData = ctx.PRODUCTS.First(x => x.Products_ID == user.Product_Access);
                //    var findProductName = ctx.PRODUCT_CATEGORIES.First(x => x.Product_Category_ID == Convert.ToInt32(findProductData.Product_Category_ID));
                //    Console.WriteLine("Product alloted: "+findProductName.Product_Name);


                //Console.WriteLine(user.User_ID + "  " + user.Role_ID + "  " + user.User_Name + "  " + user.First_Name + "  " + user.Last_Name + "  " + user.Password + "  " + user.City + "  " + user.Address + "  " + user.Zip_Code + "   " + user.Email);
            }

    }

        public static void removeUser(int userID)
        {
            var ctx = new MyDebContext();
            USERS u = new USERS() { User_ID = userID };
            if (u.Role_ID == 2)
            {
                ctx.USERS.Remove(u);
                if (ctx.SaveChanges() > 0)
                {
                    Console.WriteLine("Result-> User " + u.Email + " deleted successfully");
                }
                else
                {
                    Console.WriteLine("Result-> User " + u.Email + " not deleted successfully. Please confront admin");
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("This operation can't be performed.\nReason: Admin is required to perform major operations.");
            }

        }
        public static void AdminMenu()
        {
            var ctx = new MyDebContext();
            //Console.WriteLine("inside usermenu");
            while (true)
            {
                Console.WriteLine("----------------------------------------\nWhat operation do you wish to perform?\n" +
                    "1. Add User\n" +
                    "2. Add Product\n" +
                    "3. Add Subproduct\n" +
                    "4. Get User Data by ID\n" +
                    "5. Get All User's Data\n" +
                    "6. Delete sub-product\n" +
                    "7. Delete Product\n" +
                    "8. Delete User\n"+
                    "0. Logout\n" +
                    "----------------------------------------");
                user_choice = Convert.ToInt32(Console.ReadLine());
                switch (user_choice)
                {
                    case 1:
                        {
                            Console.WriteLine("----------------------------------------\nEnter following details:");
                            Console.WriteLine("Role_ID ,User_Name,First_Name,Last_Name,Password,City,Address,Zip_Code,Email ");
                            Console.Write("Role ID: ");
                            int roleId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Username: ");
                            string User_Name = Console.ReadLine();
                            Console.Write("First Name: ");
                            string First_Name = Console.ReadLine();
                            Console.Write("Last Name: ");
                            string Last_Name = Console.ReadLine();
                            Console.Write("Password: ");
                            string Password = Console.ReadLine();
                            Console.Write("City: ");
                            string City = Console.ReadLine();
                            Console.Write("Address: ");
                            string Address = Console.ReadLine();
                            Console.Write("Zip Code: ");
                            int Zip_Code = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Email: ");
                            string Email = Console.ReadLine();
                            Console.Write("Alloted product ID: ");
                            int productIncharge = Convert.ToInt32(Console.ReadLine());

                            USERS data = new USERS() {Product_Access=productIncharge, Role_ID = roleId, User_Name = User_Name, First_Name = First_Name, Last_Name = Last_Name, Password = Password, City = City, Address = Address, Zip_Code = Zip_Code, Email = Email };
                            ctx.USERS.Add(data);
                            if (ctx.SaveChanges() > 0)
                            {
                                Console.WriteLine("Result-> User Added");
                            }
                            else
                            {
                                Console.WriteLine("Result-> User not added. Please confirm details");
                            }

                             Console.ReadKey(); break;
                        }
                    case 2:
                        {
                            UserOperations.addProduct();
                             Console.ReadKey(); break;
                        }
                    case 3:
                        {
                            UserOperations.addSubproduct();
                             Console.ReadKey(); break;
                        }
                    case 4:
                        {
                            getUserDataByID();
                             Console.ReadKey(); break;
                        }
                    case 5:
                        {
                            getUserData();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter sub-product id you wish to delete: ");
                            deleteSubproductByID(Convert.ToInt32(Console.ReadLine()));
                            
                             Console.ReadKey(); break;
                        }
                    case 7:
                    case 8:
                        {
                            Console.Write("Please enter user ID to delete: ");
                            int deleteUserID = Convert.ToInt32(Console.ReadLine());
                            removeUser(deleteUserID);
                            break;
                        }
                        {
                            Console.WriteLine("Enter product id you wish to delete: ");
                            deleteProductByID(Convert.ToInt32(Console.ReadLine()));
                             Console.ReadKey(); break;
                        }
                    case 0:
                        {
                            Console.Write("Are you sure you want to logout? (y/n)");
                            if ("y"==Console.ReadLine().ToLower())
                            {
                                AdminOperations.loggedIn =0;
                                System.Environment.Exit(0);
                            }
                            else
                            {
                                continue;
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter correct choice");
                             Console.ReadKey(); break;
                        }
                }
            }
        }

    }
}
