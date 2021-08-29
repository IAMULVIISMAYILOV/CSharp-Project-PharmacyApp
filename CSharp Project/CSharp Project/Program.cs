using CSharp_Project.Models;
using CSharp_Project.Models.Utils;
using System;
using System.Collections.Generic;

namespace CSharp_Project
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Pharmacy> pharmacies = new List<Pharmacy>();


            while (true)
            {
                Helper.Print(ConsoleColor.DarkYellow, "1. Create a pharmacy 2. Add drug 3. Show pharmacy drugs 4. Info about drug 5. Sale drug" +
                    " 6. Exit");

                string result = Console.ReadLine();
                bool isInt = int.TryParse(result, out int selection);
                if (isInt && (selection >= 1 && selection <= 6))
                {
                    if (selection == 6)
                    {
                        Helper.Print(ConsoleColor.Green, "Exiting from menu...");
                        break;
                    }

                    switch (selection)
                    {
                        case 1:

                            Helper.Print(ConsoleColor.Green, "Enter the name of the pharmacy");
                            string pharmacyName = Console.ReadLine();
                            Pharmacy pharmacy = new Pharmacy(pharmacyName);

                            bool isExistPharmacy = pharmacies.Exists(x => x.Name.ToLower() == pharmacy.Name.ToLower());
                            if (isExistPharmacy == false)
                            {
                                pharmacies.Add(pharmacy);
                                Helper.Print(ConsoleColor.Yellow, $"{pharmacy} pharmacy is created");
                            }
                            else
                                Console.WriteLine("Pharmacy is existed already. Enter another name for pharmacy.");

                            break;

                        case 2:


                            Helper.Print(ConsoleColor.Green, "Enter the name of drug");
                            string name = Console.ReadLine();

                            Helper.Print(ConsoleColor.Green, "Enter the count of drug");
                            int count = int.Parse(Console.ReadLine());

                            Helper.Print(ConsoleColor.Green, "Enter the price of drug");
                            int price = int.Parse(Console.ReadLine());

                            Helper.Print(ConsoleColor.Green, "Enter the type of drug");
                            string type = (Console.ReadLine());

                            DrugType newType = new DrugType(type);

                        key1:

                            Helper.Print(ConsoleColor.Yellow, "Choose from existing pharmacy");
                            foreach (Pharmacy item in pharmacies)
                            {
                                Helper.Print(ConsoleColor.Yellow, item.ToString());
                            }

                            string selectedPharmacy = Console.ReadLine();
                            Pharmacy existPharmacy = pharmacies.Find(x => x.Name.ToLower() == selectedPharmacy.ToLower());
                            if (existPharmacy == null)
                            {
                                Helper.Print(ConsoleColor.Red, $"{selectedPharmacy} named pharmacy is not existed.");

                                goto key1;
                            }

                            Drug newDrug = new Drug(name, price, count, newType);
                            existPharmacy.AddDrug(newDrug);

                            Helper.Print(ConsoleColor.Yellow, "Drug has been added to the pharmacy");

                            break;

                        case 3:


                            Helper.Print(ConsoleColor.Yellow, "Select from available pharmacies");
                            foreach (Pharmacy item in pharmacies)
                            {
                                Helper.Print(ConsoleColor.Green, item.ToString());
                            }

                            string selectedAvailablePharmacy = Console.ReadLine();
                            Pharmacy existNewPharmacy = pharmacies.Find(x => x.Name.ToLower() == selectedAvailablePharmacy.ToLower());

                            if (existNewPharmacy != null)
                            {
                                existNewPharmacy.ShowDrugList();
                            }

                            else
                            {
                                Helper.Print(ConsoleColor.Red, " this pharmacy is not existed");

                                goto case 3;
                            }


                            break;

                        case 4:

                            Helper.Print(ConsoleColor.Green, "Enter the name of drug you are looking for");
                        key2:

                            string name_ = Console.ReadLine();
                            bool isStringName = int.TryParse(name_, out int info);

                            if (isStringName)
                            {
                                Helper.Print(ConsoleColor.Red, "Do not enter the number");
                                goto key2;
                            }



                            foreach (var drug in pharmacies)
                            {
                                List<Drug> drugs = drug.InfoDrug(name_);
                                foreach (var item in drugs)
                                {
                                    Console.WriteLine(item);
                                }
                            }

                            break;

                        case 5:

                            Helper.Print(ConsoleColor.Green, "Select from available pharmacies");
                            foreach (Pharmacy item in pharmacies)
                            {
                                Console.WriteLine(item.ToString());
                            }

                            selectedPharmacy = Console.ReadLine();
                            existPharmacy = pharmacies.Find(x => x.Name.ToLower() == selectedPharmacy.ToLower());
                            if (existPharmacy == null)
                            {
                                Helper.Print(ConsoleColor.Red, "This pharmacy is not available");

                                goto case 5;
                            }

                        Key3:
                            Helper.Print(ConsoleColor.Green, "Enter the name of required drug");
                            existPharmacy.ShowDrugList();
                            string saleInfo = Console.ReadLine();

                            Helper.Print(ConsoleColor.Green, "Enter the count");
                            result = Console.ReadLine();
                            isInt = int.TryParse(result, out int countInfo);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, "Enter the number!");
                            }

                            Helper.Print(ConsoleColor.Green, "Enter the payment");
                            result = Console.ReadLine();
                            isInt = double.TryParse(result, out double paymentInfo);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, "Enter the number!");
                            }

                            bool saleDrug = existPharmacy.SaleDrug(saleInfo, countInfo, paymentInfo);
                            if (!saleDrug)
                            {
                                Helper.Print(ConsoleColor.Red, "Select an avialable drug");
                                goto Key3;
                            }

                            break;
                    }
                }

                else

                    Helper.Print(ConsoleColor.DarkBlue, "Make the right choice");
            }
        }
    }
}
