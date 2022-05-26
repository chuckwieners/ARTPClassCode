using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTPLibrary
{
    public class Product
    {
        //fields
        //NOPE

        //properties
        public int ID { get; }
        public string Name { get; set; }
        public string ModelNumber { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //ctors
        public Product(int id, string modelNumber, string name,
            string description, decimal price)
        {
            ID = id; //readonly
            Name = name;
            ModelNumber = modelNumber;
            Description = description;
            Price = price;
        }

        //methods

        //ToString()
        public override string ToString() =>
       $"ID: {ID}\nName: {Name}\nModel Number: {ModelNumber}\nPrice: {Price:c}\nDescription: {Description}";
    }
}
