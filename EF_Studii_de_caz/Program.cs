using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Studii_de_caz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Model Self References");
            FirstSceneTest();
            SecondSceneTest();
            //ThirdSceneTest();
            Console.ReadKey();
        }
        static void FirstSceneTest()
        {
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
                var photo = new Photograph
                {
                    Title = "My Dog",
                    ThumbnailBits = thumbBits
                };
                var fullImage = new PhotographFullImage
                {
                    HighResolutionBits =
                fullBits
                };
                photo.PhotographFullImage = fullImage;
                context.Photographs.Add(photo);
                context.SaveChanges();
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
    }
}
