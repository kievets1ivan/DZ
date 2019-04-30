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

        public static Management GetChoice()
        {
            try
            {
                Console.WriteLine("Enter menu item:");
                Console.WriteLine("1 - Management first vendor");
                Console.WriteLine("2 - Management first vendor");
                Console.WriteLine("0 - Exit");

                Management x = (Management)Enum.Parse(typeof(Management), Console.ReadLine());

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

        public enum Management
        {
            Exit = 0,
            Vendor1 = 1,
            Vendor2 = 2
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

            Manufacturer m1 = new Manufacturer("BMW", 3);
            Manufacturer m2 = new Manufacturer("Audi", 3);

            Management choice = 0;

            do
            {
                choice = GetChoice();

                switch (choice)
                {
                    case Management.Vendor1:
                        VendorsManagment(m1);
                        break;
                    case Management.Vendor2:
                        VendorsManagment(m2);
                        break;
                    case Management.Exit:
                        break;
                    default:
                        Console.WriteLine(AdditionalCaption.WrongInput);
                        break;
                }
            } while (choice != Management.Exit);

        }
    }
}