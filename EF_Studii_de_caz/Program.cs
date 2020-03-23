using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Studii_de_caz
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstSceneTest();
            SecondSceneTest();
            ThirdSceneTest();
            FourthSceneTest();
            FifthSceneTest();
            Console.ReadKey();
        }
        static void FirstSceneTest()
        {
            Console.WriteLine("Test Model Self References");
            using (ModelSelfReferences context = new ModelSelfReferences())
            {
                var items = context.SelfReferences;

                Console.WriteLine("Do you want to insert a row in a table? (y/n)");
                string ans = Console.ReadLine();
                if (ans.Contains("y"))
                {
                    SelfReference data = new SelfReference();
                    Console.WriteLine("Give the name");
                    data.Name = Console.ReadLine();
                    Console.WriteLine("Does this reference have a parent reference? (y/n)");
                    ans = Console.ReadLine();
                    if (ans.Contains("y"))
                    {
                        Console.WriteLine("Give the parent reference id");
                        int id = Int32.Parse(Console.ReadLine());
                        foreach (var x in items)
                        {
                            if (x.SelfReferenceId == id)
                            {
                                data.ParentSelfReference = x;
                                x.References.Add(data);
                            }
                        }
                    }

                    context.SelfReferences.Add(data);
                    context.SaveChanges();
                }
                Console.WriteLine("The table content is:");
                foreach (var x in items)
                {
                    Console.Write("{0} Name({1}) ParentSelfReferenceId({2}) ",
                        x.SelfReferenceId, x.Name, x.ParentSelfReferenceId);
                    Console.Write("References{");
                    foreach (var y in x.References)
                    {
                        Console.Write("({0} {1}) ", y.SelfReferenceId, y.Name);
                    }
                    Console.Write("};");
                    Console.WriteLine();
                }

            }
        }

        static void SecondSceneTest()
        {
            using (var context = new ProductContext())
            {
                var product = new Product();
                while (true)
                {
                    Console.WriteLine("Do you want to introduce a product? (y/n)");
                    string ans = Console.ReadLine();
                    if (ans.Contains("y"))
                    {
                        Console.WriteLine("Give the SKU");
                        product.SKU = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Give the Description");
                        product.Description = Console.ReadLine();
                        Console.WriteLine("Give the Price");
                        product.Price = Decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Give the ImageURL");
                        product.ImageURL = Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                };
                context.Products.Add(product);
                context.SaveChanges();
            }
            using (var context = new ProductContext())
            {
                foreach (var p in context.Products)
                {
                    Console.WriteLine("{0} {1} {2} {3}", p.SKU, p.Description,
                    p.Price.ToString("C"), p.ImageURL);
                }
            }

        }

        static void ThirdSceneTest()
        {
            byte[] thumbBits = new byte[100];
            byte[] fullBits = new byte[2000];
            using (var context = new PhotographContext())
            {
                Console.WriteLine("Do you want to introduce a photo? (y/n)");
                string ans = Console.ReadLine();
                if (ans.Contains("y"))
                {
                    var photo = new Photograph();
                    Console.WriteLine("Introduce the title");
                    photo.Title = Console.ReadLine();
                    photo.ThumbnailBits = thumbBits;
                  
                    var fullImage = new PhotographFullImage
                    {
                        HighResolutionBits = fullBits
                    };
                    photo.PhotographFullImage = fullImage;
                    context.Photographs.Add(photo);
                    context.SaveChanges();
                }
            }
            using (var context = new PhotographContext())
            {
                foreach (var photo in context.Photographs)
                {
                    Console.WriteLine("Photo: {0}, ThumbnailSize {1} bytes",
                    photo.Title, photo.ThumbnailBits.Length);
                    // explicitly load the "expensive" entity,
                    context.Entry(photo)
                    .Reference(p => p.PhotographFullImage).Load();
                    Console.WriteLine("Full Image Size: {0} bytes",
                    photo.PhotographFullImage.HighResolutionBits.Length);
                }

            }
        }

        static void FourthSceneTest()
        {
            using (var context = new SceneFourContext())
{
                Console.WriteLine("Do you want to introduce a business information? (y/n)");
                string ans = Console.ReadLine();
                if (ans.Contains("y"))
                {
                    var business = new Business();
                    Console.WriteLine("Introduce the bussines name");
                    business.Name = Console.ReadLine();
                    Console.WriteLine("Introduce the bussines License Number");
                    business.LicenseNumber = Console.ReadLine();
                    context.Businesses.Add(business);
                    var retail = new Retail();
                    Console.WriteLine("Introduce the retail name");
                    retail.Name = Console.ReadLine();
                    Console.WriteLine("Introduce the retail License Number");
                    retail.LicenseNumber = Console.ReadLine();
                    Console.WriteLine("Introduce the retail address");
                    retail.Address = Console.ReadLine();
                    Console.WriteLine("Introduce the retail city");
                    retail.City = Console.ReadLine();
                    Console.WriteLine("Introduce the retail state");
                    retail.State = Console.ReadLine();
                    Console.WriteLine("Introduce the retail ZIPCode");
                    retail.ZIPCode = Console.ReadLine();
                    context.Businesses.Add(retail);
                    var web = new eCommerce();
                    Console.WriteLine("Introduce eCommerce name");
                    web.Name = Console.ReadLine();
                    Console.WriteLine("Introduce eCommerce License Number");
                    web.LicenseNumber = Console.ReadLine();
                    Console.WriteLine("Introduce eCommerce URL");
                    web.URL = Console.ReadLine();
                    context.Businesses.Add(web);
                    context.SaveChanges();
                }
            }
            using (var context = new SceneFourContext())
{
                Console.WriteLine("\n--- All Businesses ---");
                foreach (var b in context.Businesses)
                {
                    Console.WriteLine("{0} (#{1})", b.Name, b.LicenseNumber);
                }
                Console.WriteLine("\n--- Retail Businesses ---");
                foreach (var r in context.Businesses.OfType<Retail>())
                {
                    Console.WriteLine("{0} (#{1})", r.Name, r.LicenseNumber);
                    Console.WriteLine("{0}", r.Address);
                    Console.WriteLine("{0}, {1} {2}", r.City, r.State, r.ZIPCode);
                }
                Console.WriteLine("\n--- eCommerce Businesses ---");
                foreach (var e in context.Businesses.OfType<eCommerce>())
                {
                    Console.WriteLine("{0} (#{1})", e.Name, e.LicenseNumber);
                    Console.WriteLine("Online address is: {0}", e.URL);
                }
            }
        }

        static void FifthSceneTest()
        {
            using (var context = new SceneFiveContext())
{
                Console.WriteLine("How many full time employee do you want to introduce?");
                int count = Int32.Parse(Console.ReadLine());
                for (int i = 1; i <= count; i++)
                {
                    var fte = new FullTimeEmployee();
                    Console.WriteLine("Introduce the employee's first name");
                    fte.FirstName = Console.ReadLine();
                    Console.WriteLine("Introduce the employee's last name");
                    fte.LastName = Console.ReadLine();
                    Console.WriteLine("Introduce the employee's salary");
                    fte.Salary = Decimal.Parse(Console.ReadLine());
                    context.Employees.Add(fte);
                }

                Console.WriteLine("How many hourly employee do you want to introduce?");
                count = Int32.Parse(Console.ReadLine());
                for (int i = 1; i <= count; i++)
                {
                    var hourly = new HourlyEmployee();
                    Console.WriteLine("Introduce the employee's first name");
                    hourly.FirstName = Console.ReadLine();
                    Console.WriteLine("Introduce the employee's last name");
                    hourly.LastName = Console.ReadLine();
                    Console.WriteLine("Introduce the employee's wage");
                    hourly.Wage = Decimal.Parse(Console.ReadLine());
                    context.Employees.Add(hourly);
                }
                context.SaveChanges();
            }
            using (var context = new SceneFiveContext())
{
                Console.WriteLine("--- All Employees ---");
                foreach (var emp in context.Employees)
                {
                    bool fullTime = emp is HourlyEmployee ? false : true;
                    Console.WriteLine("{0} {1} ({2})", emp.FirstName, emp.LastName,
                    fullTime ? "Full Time" : "Hourly");
                }
                Console.WriteLine("--- Full Time ---");
                foreach (var fte in context.Employees.OfType<FullTimeEmployee>())
                {
                    Console.WriteLine("{0} {1}", fte.FirstName, fte.LastName);
                }
                Console.WriteLine("--- Hourly ---");
                foreach (var hourly in context.Employees.OfType<HourlyEmployee>())
                {
                    Console.WriteLine("{0} {1}", hourly.FirstName,
                    hourly.LastName);
                }
            }
        }
    }
}
