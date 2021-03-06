using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Project.Models
{
    partial class Pharmacy
    {
        public string Name { get; set; }

        public int Id { get; }

        private static int _id = 0;

        public List<Drug> _drugs;
        public Pharmacy()
        {
            _id++;
            Id = _id;
            _drugs = new List<Drug>();
        }
        public Pharmacy(string name) :this()
        {
            Name = name;
        }
    }
}
