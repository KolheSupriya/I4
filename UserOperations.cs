using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    class UserOperations
    {
        
        static int user_choice=1;
        static string alphaPattern = "^[A-Za-z_]\\w{4,15}$";
        static string alphaNumPattern = "^[A-Za-z0-9]";
        static string allPattern = "^.*$";

        //static string numPatternNonzero = "^[1-9]\\w{1,100}$";
        //        static string numPattern = "^[0-9]\\w{1,100}$";
        static string numPattern = "[0-9]{1,100}";
        
        static Regex numRegex = new Regex(numPattern);

        
        //public static void checkCredentials()
        //{
        //    Console.Clear();
        //    string pattern = "^[A-Z][a-zA-Z]*$";
        //    Regex regex = new Regex(pattern);
        //    Console.WriteLine("Username: ");
        //    string username = Console.ReadLine();
        //    if (!regex.IsMatch(username))
        //    {
        //        var ctx = new MyDebContext();




        //        var find = ctx.USERS.First(x => x.User_Name == username);
        //        Console.WriteLine(find);
        //        //if (ctx.SaveChanges() > 0)
        //        //{
        //        //    Console.WriteLine("Table Updated");
        //        //}

        //    }
        //    Console.WriteLine("Password: ");
        //}

        public static void getProductUserAccess(int productAccess)
        {
            var ctx = new MyDebContext();
            var findProductData = ctx.PRODUCTS.First(x => x.Products_ID == productAccess);
            var findProductName = ctx.PRODUCT_CATEGORIES.First(x => x.Product_Category_ID == Convert.ToInt32(findProductData.Product_Category_ID));
            Console.WriteLine("Category Name: " + findProductName.Product_Name);
            Console.WriteLine("Product Name: " + findProductData.SubProduct_Name);
            Console.WriteLine("Description: " + findProductData.Description);
            Console.WriteLine("Current Storage: " + findProductData.Current_Storage);
            Console.WriteLine("Sold: " + findProductData.Sold);
            Console.WriteLine("Remaining Quantity: " + findProductData.Remaining_Quantity);
            Console.WriteLine("Unit Price: " + findProductData.Unit_Price);
            Console.WriteLine("Total Selling Amount: " + findProductData.Total_Selling_Amount);
            Console.WriteLine("Last Modified On: " + findProductData.ModifiedOn);
        }

        public static void updateProductData()
        {
            var ctx = new MyDebContext();
            while (user_choice != 0)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------\nWhat operation do you wish to perform?\n" +
                    "1. Update Price\n" +
                    "2. Update Current Storage\n" +
                    "3. Update Sold\n" +
                    "0. Return\n" +
                    "----------------------------------------");
                user_choice = Convert.ToInt32(Console.ReadLine());
                switch (user_choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter product ID: ");
                            int productId = Convert.ToInt32(Console.ReadLine());
                            var find = ctx.PRODUCTS.First(x => x.Products_ID == productId);
                            Console.WriteLine("Enter new Price: ");
                            find.Unit_Price= Convert.ToInt32(Console.ReadLine());
                            find.Total_Selling_Amount = find.Sold * find.Unit_Price;
                            if (ctx.SaveChanges() > 0)
                            {
                                
                                Console.WriteLine("Result-> Product Updated");
                            }
                            else
                            {
                                Console.WriteLine("Result-> Product not Updated. Please check data");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter product ID: ");
                            int productId = Convert.ToInt32(Console.ReadLine());
                            var find = ctx.PRODUCTS.First(x => x.Products_ID == productId);
                            Console.WriteLine("Enter new storage count: ");
                            int newStorage = Convert.ToInt32(Console.ReadLine());
                            find.Current_Storage = find.Current_Storage + newStorage;
                            if (ctx.SaveChanges() > 0)
                            {

                                Console.WriteLine("Result-> Product Updated");
                            }
                            else
                            {
                                Console.WriteLine("Result-> Product not Updated. Please check data");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter product ID: ");
                            int productId = Convert.ToInt32(Console.ReadLine());
                            var find = ctx.PRODUCTS.First(x => x.Products_ID == productId);
                            Console.WriteLine("Enter sold count: ");
                            int newSoldCount = Convert.ToInt32(Console.ReadLine());
                            find.Sold = find.Sold + newSoldCount;
                            find.Remaining_Quantity = find.Current_Storage - find.Sold;
                            find.Total_Selling_Amount = find.Sold * find.Unit_Price;
                            if (ctx.SaveChanges() > 0)
                            {

                                Console.WriteLine("Result-> Product Updated");
                            }
                            else
                            {
                                Console.WriteLine("Result-> Product not Updated. Please check data");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 0:
                        {
                            Console.Clear();
                            Program.login();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter correct choice");
                            break;
                        }
                }
            }
        }
                    
        public static void addProduct()
        {
            var ctx = new MyDebContext();
            Console.WriteLine("----------------------------------------\nEnter following details:");
            //Console.Write("Product Name: ");
            string productName = "", description = "";
            Console.Write("Product Name: ");
            productName = Console.ReadLine();
            while (!Regex.Match(productName, alphaPattern).Success)
            {
                Console.Write("Please enter product name: (Only alphabets are allowed and length must be between 4,15): ");
                productName = Console.ReadLine();
            }
            Console.Write("Product Description: ");
            description = Console.ReadLine();
            while (!Regex.Match(description, allPattern).Success)
            {
                Console.WriteLine("Please enter product description: (Only alphabets, numbers are allowed and length must be between 1,100): ");
                description = Console.ReadLine();
            }


            PRODUCT_CATEGORIES data = new PRODUCT_CATEGORIES() { Product_Name = productName, Description = description };
            ctx.PRODUCT_CATEGORIES.Add(data);
            if (ctx.SaveChanges() > 0)
            {
                Console.WriteLine("Result-> New product Added");
            }
            else
            {
                Console.WriteLine("Result-> Product not added. Please confront admin");
            }
            Console.ReadKey();
        }
        public static void addSubproduct()
        {
            var ctx = new MyDebContext();
            //int categoryId=0, currentStorage=0, sold = 0, remainingQuantity = 0, unitPrice = 0, totalSellingAmount = 0;
            string categoryId = "", currentStorage = "", sold = "", unitPrice = "";
            int remainingQuantity, totalSellingAmount;
            string subProductName = "", description = "";
            Console.WriteLine("----------------------------------------\nEnter following details:");
            Console.Write("Category ID: ");
            categoryId = Console.ReadLine();
            while (!numRegex.IsMatch(categoryId))
            {
                Console.Write("Please enter product ID: (Only numbers are allowed)");
                categoryId = Console.ReadLine();
            }
            //while (!Regex.Match(categoryId, numPattern).Success)
            //{
            //    Console.WriteLine("Please enter product ID: (Only alphabets are allowed)");
            //    categoryId = Console.ReadLine();

            //}

            //Console.WriteLine("Subproduct Name: ");
            //subProductName = Console.ReadLine();
            while (!Regex.Match(subProductName, alphaNumPattern).Success)
            {
                Console.Write("Please enter sub-product name: (Only alphabets,numbers are allowed and at most length must be 30)");
                subProductName = Console.ReadLine();
            }
            //subProductName = Console.ReadLine();
            Console.Write("Product Description: ");
            description = Console.ReadLine();

            while (!Regex.Match(description, allPattern).Success)
            {
                Console.Write("Please enter product description: (Only alphabets,numbers are allowed and length must be between 1,100)");
                description = Console.ReadLine();
            }
            //description = Console.ReadLine();
            Console.Write("Current Storage: ");
            currentStorage = Console.ReadLine();
            while (!numRegex.IsMatch(currentStorage))
            {
                Console.Write("Please enter current storage: (Only numbers are allowed)");
                currentStorage = Console.ReadLine();
            }
            //currentStorage = Convert.ToInt32(Console.ReadLine());
            Console.Write("Sold: ");
            sold = Console.ReadLine();

            while (!numRegex.IsMatch(sold))
            {
                Console.Write("Please enter sold quantity: (Only numbers are allowed");
                sold = Console.ReadLine();
            }
            //sold = Convert.ToInt32(Console.ReadLine());
            remainingQuantity = Convert.ToInt32(currentStorage) - Convert.ToInt32(sold);
            Console.Write("Unit Price: ");
            unitPrice = Console.ReadLine();
            while (!numRegex.IsMatch(unitPrice))
            {
                Console.Write("Please enter sold quantity: (Only numbers are allowed");
                unitPrice = Console.ReadLine();
            }
            //unitPrice = Convert.ToInt32(Console.ReadLine());
            totalSellingAmount = Convert.ToInt32(unitPrice) * Convert.ToInt32(sold);
            PRODUCTS data = new PRODUCTS() { Product_Category_ID = Convert.ToInt32(categoryId), SubProduct_Name = subProductName, Description = description, Current_Storage = Convert.ToInt32(currentStorage), Sold = Convert.ToInt32(sold), Remaining_Quantity = remainingQuantity, Unit_Price = Convert.ToInt32(unitPrice), Total_Selling_Amount = totalSellingAmount };
            ctx.PRODUCTS.Add(data);
            if (ctx.SaveChanges() > 0)
            {
                Console.WriteLine("Result-> New product subcategory Added");
            }
            else
            {
                Console.WriteLine("Result-> Product subcategory not added. Please confront admin");
            }
            Console.ReadKey();
        }
        public static void UserMenu()
        {

            //Boolean exit = false ;
            var ctx = new MyDebContext();
            //Console.WriteLine("inside usermenu");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------\nWhat operation do you wish to perform?\n" +
                    "1. Add Product\n" +
                    "2. Add Subproduct\n" +
                    "3. Get product Data\n" +
                    "4: Update\n" +
                    "5: Remove Subproduct\n" +
                    "6. Remove Product\n" +
                    "0. Logout\n----------------------------------------");
                user_choice = Convert.ToInt32(Console.ReadLine());
                switch (user_choice)
                {
                    case 1:
                        {
                            addProduct();
                            break;
                        }
                    case 2:
                        {
                            addSubproduct();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Please enter userID: ");
                            var findUserData = ctx.USERS.First(x => x.User_ID == Convert.ToInt32( Console.ReadLine()));
                            getProductUserAccess(findUserData.Product_Access);
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            updateProductData();
                            break;
                        }
                    case 5:
                        {
                            
                            break;
                        }
                    case 6:
                        {
                            
                            break;
                        }
                    case 0:
                        {
                            Console.Write("Are you sure you want to logout? (y/n)");
                            if ("y" == Console.ReadLine().ToLower())
                            {
                                AdminOperations.loggedIn = 0;
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
                            break;
                        }
                }
            }

        }
    }
}
