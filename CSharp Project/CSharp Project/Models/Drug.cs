using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Project.Models
{
    class Drug
    {
        public string Name { get; set; }
        public DrugType Type { get; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int Id { get; }
        public object ShowDrugList { get; internal set; }
        private static int _id = 0;
        
        public Drug()
        {
            _id++;
            Id = _id;
        }

        public Drug(string name, int price, int count, DrugType type) : this()
        {
            Name = name;
            Price = price;
            Count = count;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Id}-  Drug name: {Name},  Count: {Count} pc.,  Price: {Price} EUR,  Type: {Type}";
        }
    }
}
