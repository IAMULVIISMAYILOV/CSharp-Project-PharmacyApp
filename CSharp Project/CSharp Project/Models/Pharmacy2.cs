using CSharp_Project.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Project.Models
{
    partial class Pharmacy
    {

        public override string ToString()
        {
            return $"{Name}";
        }

        public bool AddDrug(Drug drug)
        {
            bool isFalse = false;
            foreach (Drug allDrug in _drugs)

            {
                if (allDrug.Name == drug.Name)
                {
                    allDrug.Count += drug.Count;
                    isFalse = true;
                }

            }

            if (isFalse != true)
            {
                _drugs.Add(drug);
            }

            return false;
        }

        public List<Drug> InfoDrug(string name)
        {
            var infoDrug = _drugs.FindAll(x => x.Name.ToLower().Contains(name.ToLower()));

            return infoDrug;
        }

        public void ShowDrugList()
        {

            Helper.Print(ConsoleColor.DarkYellow, $"{Id} {Name} ");

            if (_drugs.Count == 0)
            {
                return;
            }

            foreach (Drug drug in _drugs)
            {
                Helper.Print(ConsoleColor.Green, drug.ToString());
            }

        }

        public bool SaleDrug(string drug, int count, double payment)
        {
            Drug existDrug = _drugs.Find((x => x.Name.ToLower() == drug.ToLower()));
            if (existDrug == null)
            {
                Helper.Print(ConsoleColor.Red, "This drug is not available");
            }

            else if (existDrug.Price * count > payment)
            {
                Helper.Print(ConsoleColor.Red, "Not eonough fund to buy");
                double result = existDrug.Price * count;
                Console.WriteLine($"{result - payment}  not enough");
            }

            else if (existDrug.Count < count)
            {
                Helper.Print(ConsoleColor.Red, "The amount of drugs is not enough to buy");
                Helper.Print(ConsoleColor.Red, count - existDrug.Count + " " + " " + "not enough drugs");
                return false;
            }


            Helper.Print(ConsoleColor.DarkYellow, $"Purchasing of {existDrug} completed successfully, the rest of money {payment - (existDrug.Price * count)} EUR");
            existDrug.Count -= count;

            return true;
        }
    }
}
