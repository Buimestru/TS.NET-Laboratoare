using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst_L1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Model Designer First");
            TestPerson();
            TesTOneToMany();
            //TestManyToMany();
            Console.ReadKey();
        }
        static void TestPerson()
        {
            using (Model1Container context = new Model1Container())
            {
                Person p = new Person();
                Console.WriteLine("Give the First Name");
                p.FirstName = Console.ReadLine();
                Console.WriteLine("Give the Midle Name");
                p.MidleName = Console.ReadLine();
                Console.WriteLine("Give the Last Name");
                p.LastName = Console.ReadLine();
                Console.WriteLine("Give the Telephone Number");
                p.TelephonNumber = Console.ReadLine();
                context.People.Add(p);
                context.SaveChanges();
                var items = context.People;
                foreach (var x in items)
                    Console.WriteLine("{0} {1}", x.Id, x.FirstName);
            }
        }

        static void TesTOneToMany()
        {
            Console.WriteLine("One to many association");
            using (ModelOneToManyContainer context =
           new ModelOneToManyContainer())
            {
               
                Customer c = new Customer();
                Console.WriteLine("Give the Customer Name");
                c.Name = Console.ReadLine();
                Console.WriteLine("Give the Customer City");
                c.City = Console.ReadLine();
                Console.WriteLine("Give the number of orders");
                context.Customers.Add(c);
                int nrOfOrders = Int32.Parse(Console.ReadLine());
                for(int i=1; i<=nrOfOrders; i++)
                {
                    Order o = new Order();
                    Console.WriteLine("Give the Total Value of order");
                    o.TotalValue = Decimal.Parse(Console.ReadLine());
                    o.Date = DateTime.Now;
                    o.Customer = c;
                    context.Orders.Add(o);
                }
                context.SaveChanges();
                
                var items = context.Customers.Include("Orders");
                foreach (var x in items)
                {
                    Console.WriteLine("Customer : {0}, {1}, {2}",
                            x.CustomerId, x.Name, x.City);
                    foreach (var ox in x.Orders)
                        Console.WriteLine("\tOrders: {0}, {1}, {2}",
                               ox.OrderId, ox.Date, ox.TotalValue);
                }
            }
        }

        static void TestManyToMany()
        {
            using(ModelManyToManyContainer context = new ModelManyToManyContainer())
            {
                string answer = "";
                Console.WriteLine("Do you want to introduce an album? (y/n)");
                answer = Console.ReadLine();
                if (answer.Contains("y"))
                {
                    Album album = new Album();
                    Console.WriteLine("Give the album name");
                    context.Albums.Add(album);
                    context.SaveChanges();
                }
                Console.WriteLine("Do you want to introduce an artist? (y/n)");
                answer = Console.ReadLine();
                if (answer.Contains("y"))
                {
                    Artist artist = new Artist();
                    Console.WriteLine("Give the artist's  first name");
                    artist.FirstName = Console.ReadLine();
                    Console.WriteLine("Give the artist's last name ");
                    artist.LastName = Console.ReadLine();
                    context.Artists.Add(artist);
                    context.SaveChanges();
                }
                Console.WriteLine("Do you want to link an album to an artist? (y/n)");
                answer = Console.ReadLine();
                if (answer.Contains("y"))
                {
                    AlbumArtist albumArtist = new AlbumArtist();
                    Console.WriteLine("Give the artist's  id");
                    albumArtist.Artists_ArtistId = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Give the album's id ");
                    albumArtist.Albums_AlbumId = Int32.Parse(Console.ReadLine());
                    //context.AlbumArtists.Add(albumArtist);
                    Artist artist = context.Artists.FirstOrDefault(a => a.ArtistId == albumArtist.Artists_ArtistId);
                    Album album = context.Albums.FirstOrDefault(a => a.AlbumId == albumArtist.Albums_AlbumId);
                    artist.Albums.Add(album);
                    album.Artists.Add(artist);
                    context.Entry<Artist>(artist).CurrentValues.SetValues(artist);
                    context.Entry<Album>(album).CurrentValues.SetValues(album);
                    //context.Albums.First(a => a.AlbumId == albumArtist.Albums_AlbumId).Artists.Add(artist);
                    //context.Artists.FirstOrDefault(a => a.ArtistId == albumArtist.Artists_ArtistId).Albums.Add(album);
                    context.SaveChanges();
                }
                var items = context.Albums.Include("Artists");
                foreach (var x in items)
                {
                    Console.Write("Album : {0}, {1} ",
                            x.AlbumId, x.AlbumName);
                    foreach(var y in x.Artists)
                    {
                        Console.Write("Artist : {0}, {1}, {2}",
                            y.ArtistId, y.FirstName, y.LastName);
                    }
                    Console.WriteLine();
                }
            }

        }

    }
}
