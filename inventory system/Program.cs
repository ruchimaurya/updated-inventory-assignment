using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_system
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> listofitems = new List<Product> ();

            listofitems.Add(new Product( "lettuce", 10.5, 50, "Leafy green" ));
            listofitems.Add(new Product( "cabbage", 20, 100, "Cruciferous" ));
            listofitems.Add(new Product( "pumpkin", 30, 30, "Marrow "));
            listofitems.Add(new Product("cauliflower", 10, 25, "Cruciferous" ));
            listofitems.Add( new Product("zucchini", 20.5, 50,"Marrow" ));
            listofitems.Add( new Product("yam", 30, 50, "Root "));
            listofitems.Add( new Product( "spinach", 10, 100, "Leafy green") );
            listofitems.Add( new Product("broccoli",20.2, 75, "Cruciferous" ));
            listofitems.Add( new Product("Garlic", 30, 20, "Leafy green" ));
            listofitems.Add( new Product("silverbeet",10, 50, "Marrow" ));

            var count = listofitems.Count();
            //add potato
            Console.WriteLine("Total number of products in list:" + count);

            listofitems.Add(new Product("Potato", 10, 50, "Root"));

            Console.WriteLine("Total number of products in list:" + listofitems.Count());




            IEnumerable<Product> results = listofitems.Where(x => x.type == "Leafy green");

            foreach (var i in results)
            {

                Console.WriteLine(i);

            }

            listofitems.Remove(new Product("Garlic", 30, 20, "Leafy green"));

            print();

            //var index = listofitems.FindIndex(c => c.name == "cabbage");

            //Console.WriteLine(index);

            listofitems.Find(p => p.name == "cabbage").quantity += 50;

            print();

            var pr1 = billing("lettuce",1);
            var pr2 = billing("zucchini",2);
            var pr3 = billing("broccoli", 1);

            var total = pr1 + pr2 + pr3;

            Console.WriteLine("Total amount:" + (int)Math.Round(total));

            print();

            //display

            void print()
            {
                foreach (var i in listofitems)
                {

                    Console.WriteLine(i);

                }
            }

            double billing(string name, double qty)
            {
                double amount=0;
                var index = listofitems.FindIndex(c => c.name == name);
                var avail = listofitems[index].quantity;
                if (qty<=avail)
                {
                    var price = listofitems[index].price;
                    amount = price * qty;
                    listofitems[index].quantity =avail- qty;
                    
                }
                else
                {
                    Console.WriteLine("{0} is not available", name);
                }

                return amount;
            }

            Console.Read();


        }
 
    }
}
