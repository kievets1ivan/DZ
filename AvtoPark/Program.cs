using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryForAvtoPark;

namespace ConsoleApp2
{
    class Program
    {
        public static void ShowNamesOfVendors(List<Manufacturer> listOfVendors)
        {
            foreach(var i in listOfVendors)
                Console.WriteLine(i.Name);

            Console.WriteLine("Exit");
            Console.WriteLine(AdditionalCaption.EnterNameOfVendor);
        }


        public static void DriveSportCar(SportCar c)
        {

            for (int i = 0; i < 100; i++)
            {
                c.Run();
                if (i >= 10)
                    c.UseNitro();
                Console.WriteLine(c.Speed);
            }

        }

        public static void MoveCarWithTruck(Truck t, SportCar c)
        {
            t.LoadTruck(c);

            for (int i = 0; i < 100; i++)
            {
                t.Run();
                Console.WriteLine(t.Speed);
            }

        }



        public static void VendorsManagment(Manufacturer m)
        {
            AuthorityVendors caseOfVendor = 0;

            do
            {
                caseOfVendor = GetCase();

                switch (caseOfVendor)
                {
                    case AuthorityVendors.CreateSportCar:
                        m.CreateSportCar(GetInt32(AdditionalCaption.EnterNitroCaption));
                        break;

                    case AuthorityVendors.CreateTruck:
                        m.CreateTruck(GetInt32(AdditionalCaption.EnterLoadCapacityCaption));
                        break;

                    case AuthorityVendors.DriveSportCar:
                        m.ShowListOfSportCars();
                        var c = m.GetSportCar(GetInt32(AdditionalCaption.EnterIndexOfCar));
                        if(c != null)
                            DriveSportCar(c);
                        break;

                    case AuthorityVendors.MoveCarWithTruck:
                        m.ShowListOfTrucks();
                        var t = m.GetTruck(GetInt32(AdditionalCaption.EnterIndexOfCar));
                        if (t != null)
                        {
                            m.ShowListOfSportCars();
                            c = m.GetSportCar(GetInt32(AdditionalCaption.EnterIndexOfCar));
                            if (c != null)
                                MoveCarWithTruck(t, c);
                        }

                        break;
                    case AuthorityVendors.Exit:
                        break;
                    default:
                        Console.WriteLine(AdditionalCaption.WrongInput);
                        break;


                }
            } while (caseOfVendor != 0);

        }

        static class AdditionalCaption
        {
            public const string EnterNameOfVendor = "Enter name of vendor: ";
            public const string EnterNitroCaption = "Enter size of nitro of sport car: ";
            public const string EnterLoadCapacityCaption = "Enter load capacity of truck: ";
            public const string WrongInput = "Wrong input";
            public const string EnterIndexOfCar = "Enter id of car";
        }

        public static int GetInt32(string message)
        {
            try
            {
                Console.WriteLine(message);
                var x = Convert.ToInt32(Console.ReadLine());

                return x;
            }
            catch
            {
                Console.WriteLine(AdditionalCaption.WrongInput);
                return 0;
            }
        }

        public static AuthorityVendors GetCase()
        {
            try
            {
                Console.WriteLine("Enter menu item:");
                Console.WriteLine("1 - Create sport car");
                Console.WriteLine("2 - Create truck");
                Console.WriteLine("3 - Drive sport car");
                Console.WriteLine("4 - Move sport car with a truck");
                Console.WriteLine("0 - Exit");

                AuthorityVendors x = (AuthorityVendors)Enum.Parse(typeof(AuthorityVendors), Console.ReadLine());

                return x;
            }
            catch
            {
                Console.WriteLine(AdditionalCaption.WrongInput);
                return 0;
            }
        }

        public enum AuthorityVendors
        {
            Exit = 0,
            CreateSportCar = 1,
            CreateTruck = 2,
            DriveSportCar = 3,
            MoveCarWithTruck = 4
        }


        static void Main(string[] args)
        {

            List<Manufacturer> listOfVendors = new List<Manufacturer>
            {
                new Manufacturer("BMW", 3),
                new Manufacturer("Audi", 3)
            };

            string tempName = " ";
            bool found = false;
            

            while (true)
            {
                ShowNamesOfVendors(listOfVendors);
                tempName = Console.ReadLine();

                if (tempName == "Exit")
                    break;

                foreach (var x in listOfVendors)
                {
                    if (tempName == x.Name)
                    {
                        VendorsManagment(x);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine(AdditionalCaption.WrongInput);
                }
                found = false;
            }
        }
    }
}