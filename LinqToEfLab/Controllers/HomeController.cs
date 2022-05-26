using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinqToEfLab.Controllers
{
    public class HomeController : Controller
    {

        //establish the database context
        NorthwindEntities ctx = new NorthwindEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UntypedView()
        {
            #region LinqToEF MiniLab - Student Controller
            #region Example: Together Example
            //Return all products with a price between $12 and $50
            //Only display the name and the price.
            //Get a Count of all of the items and display the count.
            var togetherExample = ctx.Products.Where(p => p.UnitPrice >= 12 && p.UnitPrice <= 50);
            //keyword version
            var togetherExampleKW = from p in ctx.Products
                                    where p.UnitPrice > 12 && p.UnitPrice <= 50
                                    select p;

            //use the viewbag to marshall data between the controller and the view
            ViewBag.TogetherExample = togetherExample;
            ViewBag.Count = togetherExample.Count();

            #endregion

            //Write the query in whatever format is most comfortable for you.
            //Resolve all of the query questions. When done, come back and comment out
            //the query you have and try the other syntax.
            //(Method first, come back and do keyword)

            #region 1) Dairy Products - Name and Category Name
            //return all products that are in the category of "Dairy Products"
            //only output the product name and the category name

            #endregion

            #region 2) 10 or more products in category
            //Return the category/categories that have more than 10 products
            //display the category name and the number of products

            #endregion

            #region 3) German Suppliers
            //Return a list of suppliers (Name and their Country)
            //that reside in Germany

            #endregion

            #region 4) Chef Products
            //Return a list of products that has Chef in the name alphabetically

            #endregion

            #region 5) Okra Price
            //Retrieve and display the Current Cost of Louisiana Hot Spiced Okra,
            //the Number in Stock, and its name


            #endregion

            #region 6) Products with units on order
            //Return all of the product names that have pending units on
            //order - Display the product name AND how many units on order

            #endregion

            #region 7) Active products < 10 highest price first
            //List all Active products that less than $10
            //(highest price first) - Display the Product name and price

            #endregion

            #region 8)Discontinued Prods, How many in stock, Total Price of each
            //List all discontinued items and how many we have in stock
            //with their total price

            #endregion
            #endregion

            return View();
        }
        public ActionResult InstructorSolutions()
        {
            //These are just the 8 questions and the together example.  Additional query Solutions
            //are below

            //Solutions Below Include BOTH Method AND Keyword Syntax
            #region LinqToEF MiniLab - Instructor Solutions
            #region Example: Together Example
            //Return all products with a price between $12 and $50
            //Only display the name and the price.
            //Get a Count of all of the items and display the count.

            var togetherExample = ctx.Products.Where(price => price.UnitPrice >= 12 &&
            price.UnitPrice <= 50);

            //var teKeyword = from p in ctx.Products
            //                where p.UnitPrice >= 12 &&
            //                        p.UnitPrice <= 50
            //                select p;


            ViewBag.TogetherExample = togetherExample;
            ViewBag.Count = togetherExample.Count();

            #endregion



            #region 1) Dairy Products - Name and Category Name
            //return all products that are in the category of "Dairy Products"
            //only output the product name and the category name
            var dairyProducts = from p in ctx.Products
                                where p.Category.CategoryName.Contains("dairy")
                                select p;

            //method
            //var dairyProducts = ctx.Products.Where(p.Category.CategoryName.Contains("dairy"));

            ViewBag.MiniOne = dairyProducts;
            ViewBag.MiniOneCount = dairyProducts.Count();

            #endregion

            #region 2) 10 or more products in category
            //Return the category categories that have more than 10 products
            //display the category name and the number of products
            var _10orMoreProdsInCat =
                ctx.Categories.Where(c => c.Products.Count >= 10);

            //Keyword
            //var _10orMoreProdsInCat = from c in ctx.Categories
            //                          where c.Products.Count >= 10
            //                          select c;
            ViewBag.MiniTwo = _10orMoreProdsInCat;
            ViewBag.MiniTwoCount = _10orMoreProdsInCat.Count();

            #endregion

            #region 3) German Suppliers
            //Return a list of suppliers (Name and their Country) 
            //that reside in Germany
            var germanSuppliers =
                ctx.Suppliers.Where(s => s.Country.Contains("germany"));

            //keyword
            //var germanSuppliers = from s in ctx.Suppliers
            //                      where s.Country.Contains("germany")
            //                      select s;

            ViewBag.MiniThree = germanSuppliers;
            ViewBag.MiniThreeCount = germanSuppliers.Count();


            #endregion

            #region 4) Chef Products
            //Return a list of products that has Chef in the name alphabetically
            var chefProdAlpha = from p in ctx.Products
                                where p.ProductName.ToLower().Contains("chef")
                                orderby p.ProductName
                                select p;

            //method
            //var chefProdAlpha = ctx.Products.Where(p => p.ProductName.ToLower().Contains("chef"))
            //    .OrderBy(p => p.ProductName);

            ViewBag.MiniFour = chefProdAlpha;
            ViewBag.MiniFourCount = chefProdAlpha.Count();

            #endregion

            #region 5) Okra Price
            //Retrieve and display the Current Cost of Louisiana Hot Spiced Okra,
            //the Number in Stock, and its name


            #region Multiple Okra Results
            //var okra =
            //    from p in ctx.Products
            //    where p.ProductName.Contains("hot spiced okra")
            //    select p;

            ////method
            ////var okra = ctx.Products.Where(p => p.ProductName.Contains("hot spiced okra"));
            //ViewBag.MiniFiveCount = okra.Count();
            #endregion

            #region Single Okra Results
            //ONLY RETURNS 1 ITEM - Update to omit the loop
            Product okra = (from p in ctx.Products
                            where p.ProductName.Contains("hot spiced okras")
                            select p).FirstOrDefault();//.Single();

            //method
            //Product okra = ctx.Products.Where(p => p.ProductName.Contains("hot spiced okra")).FirstOrDefault();//.Single();
            #endregion

            #region Send to View Based on Results
            ViewBag.MiniFive = okra;
            if (ViewBag.MiniFive != null)
            {
                ViewBag.MiniFiveCount = 1;
                ViewBag.MiniFive = okra;
            }
            else
            {
                ViewBag.MiniFive = "[-No Results-]";
                ViewBag.MiniFiveCount = 0;
            }

            #endregion
            #endregion

            #region 6) Products with units on order
            //Return all of the product names that have pending units on 
            //order - Display the product name AND how many units on order
            var productsOnOrder =
                ctx.Products.Where(p => p.UnitsOnOrder != 0
                && p.UnitsOnOrder != null);

            //keyword
            //var productsOnOrder = from p in ctx.Products
            //                      where p.UnitsOnOrder != 0
            //                      && p.UnitsOnOrder != null
            //                      select p;

            ViewBag.MiniSix = productsOnOrder;
            ViewBag.MiniSixCount = productsOnOrder.Count();

            #endregion

            #region 7) Active products < 10 highest price first
            //List all Active products that less than $10 
            //(highest price first) - Display the Product name and price
            var activeProdLessThan10 =
                from p in ctx.Products
                where p.Discontinued == false
                && p.UnitPrice < 10
                orderby p.UnitPrice descending
                select p;

            //method
            //var activeProdLessThan10 = ctx.Products.Where(p => p.Discontinued == false
            //    && p.UnitPrice < 10).OrderByDescending(p => p.UnitPrice);

            ViewBag.MiniSeven = activeProdLessThan10;
            ViewBag.MiniSevenCount = activeProdLessThan10.Count();
            #endregion

            #region 8)Discontinued Prods, How many in stock, Total Price of each
            //List all discontinued items and how many we have in stock 
            //with their total price
            var discontinuedProducts =
                ctx.Products.Where(p =>
                    p.Discontinued == true
                    && p.UnitsInStock > 0);

            //keyword
            //var discontinuedProducts = from p in ctx.Products
            //                           where p.Discontinued == true
            //                           && p.UnitsInStock > 0
            //                           select p;

            ViewBag.MiniEight = discontinuedProducts;
            ViewBag.MiniEightCount = discontinuedProducts.Count();
            ViewBag.MiniEightTotal = discontinuedProducts.Sum(p => p.UnitPrice * p.UnitsInStock);
            #endregion
            #endregion  
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}