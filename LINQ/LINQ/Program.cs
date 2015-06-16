using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace LINQ
{
    class Program
    {
        /* Practice your LINQ!
         * You can use the methods in Data Loader to load products, customers, and some sample numbers
         * 
         * NumbersA, NumbersB, and NumbersC contain some ints
         * 
         * The product data is flat, with just product information
         * 
         * The customer data is hierarchical as customers have zero to many orders
         */
        static void Main()
        {
            ////1. Find all products that are out of stock.
            //Exercise1();
            //Console.ReadLine();

            ////2. Find all products that are in stock and cost more than 3.00 per unit.
            //Exercise2();
            //Console.ReadLine();

            ////3. Find all customers in Washington, print their name then their orders. (Region == "WA")
            //Execise3();
            //Console.ReadLine();

            ////4. Create a new sequence with just the names of the products.
            //Exercise4();
            //Console.ReadLine();

            //Exercise5();
            //Console.ReadLine();

            //Exercise6();
            //Console.ReadLine();

            //Exercise7();
            //Console.ReadLine();

            //Exercise8();
            //Console.ReadLine();

            //Exercise9();
            //Console.ReadLine();

            //Exercise10();
            //Console.ReadLine();

            //Exercise11();
            //Console.ReadLine();

            //Exercise12();
            //Console.ReadLine();

            //Exercise13();
            //Console.ReadLine();

            //Exercise14();
            //Console.ReadLine();

            //Exercise15();
            //Console.ReadLine();

            //Exercise16();
            //Console.ReadLine();

            //Exercise17();
            //Console.ReadLine();

            //Exercise18();
            //Console.ReadLine();

            //Exercise19();
            //Console.ReadLine();

            //Exercise20();
            //Console.ReadLine();

            //Exercise21();
            //Console.ReadLine();

            //Exercise22();
            //Console.ReadLine();

            //Exercise23();
            //Console.ReadLine();

            Exercise24();
            Console.ReadLine();

            //Exercise25();
            //Console.ReadLine();

            //Exercise26();
            //Console.ReadLine();

            //Exercise27();
            //Console.ReadLine();

            //Exercise28();
            //Console.ReadLine();

            //Exercise29();
            //Console.ReadLine();

            //Exercise30();
            //Console.ReadLine();

            //Exercise31();
            //Console.ReadLine();

            //Exercise32();
            //Console.ReadLine();

            //Exercise33();
            //Console.ReadLine();

            //Exercise34();
            //Console.ReadLine();

            //Exercise35();
            //Console.ReadLine();

            //Exercise36();
            //Console.ReadLine();

            //Exercise37();
            //Console.ReadLine();

            //Exercise38();
            //Console.ReadLine();

            //Exercise39();
            //Console.ReadLine();

            //Exercise40();
            //Console.ReadLine();
        }

        private static void Exercise1()
        {
            var products = DataLoader.LoadProducts();

            var results = products.Where(p => p.UnitsInStock == 0);

            foreach (var product in results)
            {
                Console.WriteLine("{0} - {1}", product.ProductID, product.ProductName);
            }
        }

        private static void Exercise2()
        {
            var products = DataLoader.LoadProducts();

            var inStock = products.Where(p => p.UnitsInStock > 0);

            var results = inStock.Where(p => p.UnitPrice > 3);

            foreach (var r in results)
            {
                Console.WriteLine("{0} - {1} - ${2}", r.ProductID, r.ProductName, Convert.ToDouble(r.UnitPrice));
            }
        }

        private static void Execise3()
        {
            var customers = DataLoader.LoadCustomers();

            var results = customers.Where(c => c.Region == "WA");

            foreach (var r in results)
            {
                Console.WriteLine("{0}:", r.CompanyName);
                foreach (var o in r.Orders)
                {
                    Console.WriteLine("Order #{0} - {1}/{2}/{3} - ${4}\n", o.OrderID, o.OrderDate.Day,o.OrderDate.Month,o.OrderDate.Year, o.Total);
                }
                Console.WriteLine();
            }
        }

        private static void Exercise4()
        {
            var products = DataLoader.LoadProducts();

            var productNames = from p in products select p.ProductName;

            foreach (var n in productNames)
            {
                Console.WriteLine("{0}", n);
            }
        }

        private static void Exercise5()
        {//5. Create a new sequence of products and unit prices where the unit prices are increased by 25%.
            var products = DataLoader.LoadProducts();

            var increasedPrices = from p in products
                select new {Name = p.ProductName, Price = Convert.ToDouble(p.UnitPrice)*1.25};
                

            foreach (var p in increasedPrices)
            {
                Console.WriteLine("{0} price increased to ${1}", p.Name, p.Price);
                foreach (var op in products)
                {
                    if (op.ProductName == p.Name)
                    {
                        Console.WriteLine("Old price was ${0}. \n", Convert.ToDouble(op.UnitPrice));
                    }
                }
               
            }

        }

        private static void Exercise6()
        {//6. Create a new sequence of just product names in all upper case.
            var products = DataLoader.LoadProducts();

            var upperCaseProducts = from p in products
                select p.ProductName.ToUpper();

            foreach (var name in upperCaseProducts)
            {
                Console.WriteLine("{0}",name);
            }
        }

        private static void Exercise7()
        {//7. Create a new sequence with products with even numbers of units in stock.
            var products = DataLoader.LoadProducts();

            var evenStock = products.Where(p => p.UnitsInStock%2 == 0 && p.UnitsInStock!=0);

            foreach (var s in evenStock)
            {
                Console.WriteLine("{0} - {1}",s.ProductName, s.UnitsInStock);
            }
        }

        private static void Exercise8()
        {//8. Create a new sequence of products with ProductName, Category, and rename UnitPrice to Price.
            var products = DataLoader.LoadProducts();

            var pStreamLine = from p in products
                select new {ProductName = p.ProductName, Category = p.Category, Price = p.UnitPrice};

            foreach (var p in pStreamLine)
            {
                Console.WriteLine("{0} - {1} - ${2}", p.ProductName, p.Category, Convert.ToDouble(p.Price));
            }

        }

        private static void Exercise9()
        {//9. Make a query that returns all pairs of numbers from both arrays such that 
            //the number from numbersA is less than the number from numbersB.

            
        }

        private static void Exercise10()
        {//10. Select CustomerID, OrderID, and Total where the order total is less than 500.00.

            var customers = DataLoader.LoadCustomers();

            //var orders = from c in customers
            //    select c.Orders;

            //var cheapCustomers = orders.Where(t=>)
            
            foreach (var c in customers)
            {
                foreach (var o in c.Orders)
                {
                    if (o.Total < 500)
                    {
                        Console.WriteLine("Customer: {0} - Order#: {1} - Total: ${2}", c.CustomerID, o.OrderID, Convert.ToDouble(o.Total));
                    }  
                }
            }


           
        }

        private static void Exercise11()
        {//11. Write a query to take only the first 3 elements from NumbersA.
            var arrayA = DataLoader.NumbersA;
            //Console.WriteLine("{0} , {1} , {2}", arrayA[0], arrayA[1], arrayA[2]);
            var results = arrayA.Take(3);
            foreach (var a in results)
            {
                Console.WriteLine("{0}", a);
            }
        }

        private static void Exercise12()
        {//12. Get only the first 3 orders from customers in Washington.

            var customers = DataLoader.LoadCustomers();

            var customersWA = customers.Where(c => c.Region == "WA");

            var count = 0;

           foreach (var c in customersWA)
            {
                foreach (var o in c.Orders)
                {
                    if (count < 3)
                    {
                        Console.WriteLine("{0} - {1} - {2}", c.CompanyName, o.OrderID, o.Total);
                    }
                    count++;
                }
            }

        }

        private static void Exercise13()
        {//13. Skip the first 3 elements of NumbersA.
            var arrayA = DataLoader.NumbersA;

            //for (int i = 3; i < arrayA.Length; i++)
            //{
            //   Console.WriteLine("{0}",arrayA.ElementAt(i)) ;
            //}

            var results = arrayA.Skip(3);
            foreach (var a in results)
            {
                Console.WriteLine("{0}", a);
            }
        }

        private static void Exercise14()
        {//14. Get all except the first two orders from customers in Washington.
            var customers = DataLoader.LoadCustomers();

            var customersWa = customers.Where(c => c.Region == "WA");

            foreach (var c in customersWa)
            {
                //Console.WriteLine("{0}",c.CompanyName);
                foreach (var o in c.Orders.Skip(2))
                {

                    Console.WriteLine("{0}-{1}", o.OrderID, c.CompanyName);
                }
            }
        }

        private static void Exercise15()
        {//15. Get all the elements in NumbersC from the beginning until an element is greater or equal to 6.
            var arrayC = DataLoader.NumbersC;

            foreach (var c in arrayC)
            {
                if (c < 6)
                {
                    Console.Write("{0} - ", c);
                }
                else
                {
                    return;
                }
                
            }

        }

        private static void Exercise16()
        {//16. Return elements starting from the beginning of NumbersC until a 
         //    number is hit that is less than its position in the array.
            var arrayC = DataLoader.NumbersC;

            int index = 0;

            foreach (var c in arrayC)
            {
                if (c > index)
                {
                   Console.WriteLine("{0} is at index {1}.", c, index);
                    index++;
                }
                else
                {
                    return;
                }
            }

        }

        private static void Exercise17()
        {//17. Return elements from NumbersC starting from the first element divisible by 3.
            var arrayC = DataLoader.NumbersC;

            int firstIndex = 0;

            while(arrayC.ElementAt(firstIndex)%3 != 0)
            {
                firstIndex++;
            }

            foreach (var c in arrayC.Skip(firstIndex))
            {
                Console.Write("{0} ", c);
            }

        }

        private static void Exercise18()
        {//18. Order products alphabetically by name.
            var products = DataLoader.LoadProducts();

            var pName = from p in products 
                        orderby p.ProductName ascending 
                        select p;

            foreach (var p in pName)
            {
                Console.WriteLine("{0}",p.ProductName);
            }

            
        }

        private static void Exercise19()
        {//19. Order products by UnitsInStock descending.
            var products = DataLoader.LoadProducts();

            var pUnitStock = from p in products
                orderby p.UnitsInStock descending
                select p;

            foreach (var p in pUnitStock)
            {
                Console.WriteLine("{0} - {1}", p.ProductName, p.UnitsInStock);
            }
        }

        private static void Exercise20()
        {//20. Sort the list of products, first by category, and then by unit price, from highest to lowest.
            var products = DataLoader.LoadProducts();

            var pCategory = from p in products
                orderby p.Category
                group p by p.Category;
                
            foreach (var pCat in pCategory)
            {
                var pCatPrice = from p in pCat
                    orderby p.UnitPrice descending
                    select p;

                foreach (var p in pCatPrice)
                {
                    Console.WriteLine("{2} - {0} - {1}", p.ProductName, p.UnitPrice, p.Category);
                }
            }

        }

        private static void Exercise21()
        {//21. Reverse NumbersC.
            var arrayC = DataLoader.NumbersC;

            var reverse = arrayC.Reverse();

            foreach (var c in reverse)
            {
                Console.Write("{0} - ", c);
            }
        }

        private static void Exercise22()
        {//22. Display the elements of NumbersC grouped by their remainder when divided by 5.
            var arrayC = DataLoader.NumbersC;

            var group5 = from c in arrayC
                group c by c%5;

            //var group5Sort = from g in group5
            //    orderby g
            //    select g;

            foreach (var g in group5)
            {
                foreach (var cN in g)
                {
                    Console.WriteLine("{0} - {1}", g.Key,cN );
                }
            }


        }

        private static void Exercise23()
        {//23. Display products by Category.
            var products = DataLoader.LoadProducts();

            var pCat = from p in products
                group p by p.Category;

            foreach (var p in pCat)
            {
                foreach (var c in p)
                {
                    Console.WriteLine("{0} - {1}", c.Category, c.ProductName);
                }
            }
        }

        private static void Exercise24()
        {//24. Group customer orders by year, then by month.
            var customers = DataLoader.LoadCustomers();

            var cOrders = from c in customers
                from o in c.Orders
                group o by o.OrderDate.Year;
                

            foreach (var oYear in cOrders)
            {
                Console.Write("{0}:\t", oYear.Key);
                var orderMonth = oYear.ToList();
                var oMonth = from o in orderMonth
                    group o by o.OrderDate.Month;
                    
                foreach (var o in oMonth)
                {
                    Console.Write("{0}, ", o.Key);
                }
            Console.WriteLine();
            }
            

        }

        private static void Exercise25()
        {//25. Create a list of unique product category names.
            var products = DataLoader.LoadProducts();

            var pCat = from p in products
                       group p by p.Category;

            foreach (var p in pCat)
            {
                Console.WriteLine("{0}", p.Key);
            }
        }

        private static void Exercise26()
        {//26. Get a list of unique values from NumbersA and NumbersB.
            var arrayA = DataLoader.NumbersA;
            var arrayB = DataLoader.NumbersB;

            //var arrayAB = arrayA.Concat(arrayB);

            //var uniqueAB = arrayAB.Distinct();

            var unionAB = arrayA.Union(arrayB);

            //foreach (var a in arrayA)
            //{
            //    Console.Write("{0} ",a);
            //}
            //Console.WriteLine();

            //foreach (var b in arrayB)
            //{
            //    Console.Write("{0} ", b);
            //}
            //Console.WriteLine();

            foreach (var ab in unionAB)
            {
                Console.Write("{0} ", ab);
            }
        }

        private static void Exercise27()
        {//27. Get a list of the shared values from NumbersA and NumbersB.
            var arrayA = DataLoader.NumbersA;
            var arrayB = DataLoader.NumbersB;

            var arrayAB = arrayA.Intersect(arrayB);

            foreach (var aB in arrayAB)
            {
                Console.Write("{0} ",aB);
            }

        }

        private static void Exercise28()
        {//28. Get a list of values in NumbersA that are not also in NumbersB.
            var arrayA = DataLoader.NumbersA;
            var arrayB = DataLoader.NumbersB;

            var aOnly = arrayA.Except(arrayB);

            foreach (var a in aOnly)
            {
               Console.Write("{0} -", a);
            }

        }

        private static void Exercise29()
        {//29. Select only the first product with ProductID = 12 (not a list).
            var products = DataLoader.LoadProducts();

            var products12 = from p in products where (p.ProductID == 12) select p;

            foreach (var p in products12)
            {
                Console.Write("{0} - {1}", p.ProductID, p.ProductName);
            }

        }

        private static void Exercise30()
        {//30. Write code to check if ProductID 789 exists.
            var products = DataLoader.LoadProducts();

            var pID = from p in products
                select p.ProductID;

            if (pID.Contains(789))
            {
                Console.WriteLine("Product ID 789 exists.");
            }
            else
                Console.WriteLine("Product ID 789 does not exist.");
         }

        private static void Exercise31()
        {//31. Get a list of categories that have at least one product out of stock.
            var products = DataLoader.LoadProducts();

            var unitsInStock = products.Where(p => p.UnitsInStock == 0);

            var categories = from u in unitsInStock select u.Category;

            var uniqueCat = categories.Distinct();

            foreach (var p in uniqueCat)
            {
               Console.WriteLine("{0}", p);
            }

        }

        private static void Exercise32()
        {//32. Determine if NumbersB contains only numbers less than 9.
            var arrayB = DataLoader.NumbersB;

            Console.WriteLine(arrayB.All(b => b < 9) ? "All elements are less than 9" : "Contains elements greater than 9");
        }

        private static void Exercise33()
        {//33. Get a grouped a list of products only for categories that have all of their products in stock.
            var products = DataLoader.LoadProducts();

            var categories = from p in products.ToList()
                group p by p.Category;

            foreach (var p in categories)
            {
                if (p.All(u => u.UnitsInStock != 0))
                {
                    Console.WriteLine("{0}",p.Key);
                }
            }
            
        }

        private static void Exercise34()
        {//34. Count the number of odds in NumbersA.
            var arrayA = DataLoader.NumbersA;

            int count = arrayA.Count(a => a%2 == 1);

            Console.WriteLine(count);

        }

        private static void Exercise35()
        {//35. Display a list of CustomerIDs and only the count of their orders.
            var customers = DataLoader.LoadCustomers();

            foreach (var c in customers)
            {
                Console.WriteLine("Customer ID: {0} Order Quantity: {1}",c.CustomerID,c.Orders.Count());
            }

        }

        private static void Exercise36()
        {//36. Display a list of categories and the count of their products.
            var products = DataLoader.LoadProducts();

            var pCat = products.GroupBy(p=>p.Category);

            foreach (var p in pCat)
            {
                int count =  p.Count();
                Console.WriteLine("Category {0} has {1} products.", p.Key, count);
            }
        }

        private static void Exercise37()
        {//37. Display the total units in stock for each category.
            var products = DataLoader.LoadProducts();

            var pCat = products.GroupBy(p => p.Category);

            foreach (var p in pCat)
            {
                int units = 0;
                foreach (var u in products)
                {
                    
                    if (u.Category == p.Key)
                    {
                        units += u.UnitsInStock;
                    }
                }
                Console.WriteLine("Category {0} has {1} units in stock.", p.Key, units);
            }
            
        }

        private static void Exercise38()
        {//38. Display the lowest priced product in each category.
            var products = DataLoader.LoadProducts();

            var pCat = products.GroupBy(p => p.Category);

            foreach (var p in pCat)
            {

                var units = products.Where(u=> u.Category==p.Key);
                var price = units.Min(u => u.UnitPrice);
                Console.WriteLine("Category {0} cheapest item costs ${1:N}", p.Key, price);
            }
            
        }

        private static void Exercise39()
        {
            var products = DataLoader.LoadProducts();

            var pCat = products.GroupBy(p => p.Category);

            foreach (var p in pCat)
            {

                var units = products.Where(u => u.Category == p.Key);
                var price = units.Max(u => u.UnitPrice);
                Console.WriteLine("Category {0} most expensive item costs ${1:N}", p.Key, price);
            }
        }

        private static void Exercise40()
        {
            var products = DataLoader.LoadProducts();

            var pCat = products.GroupBy(p => p.Category);

            foreach (var p in pCat)
            {

                var units = products.Where(u => u.Category == p.Key);
                var price = units.Average(u => u.UnitPrice);
                Console.WriteLine("Category {0} has an average item cost of ${1:N}", p.Key, price);
            }
        }
    }
}
