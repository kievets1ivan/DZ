using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForAvtoPark
{
    public class Manufacturer
    {

        public Manufacturer(string Name, int limit)
        {
            _name = Name;
            _limit = limit;
            _id = 1;
            _listOfCars = new List<Car>();
            _listOfSportCars = new List<SportCar>();
            _listOfTrucks = new List<Truck>();

        }

        public SportCar CreateSportCar(int sizeOfNitro)
        {
            try
            {
                if (_listOfCars.Count < _limit)
                {

                    var x = new SportCar(80, this._name + " car", this, 500, _id++, sizeOfNitro);
                    _listOfCars.Add(x);
                    _listOfSportCars.Add(x);
                    return x;
                }
                else
                    throw new CustomException("You've already created max quantity of cars for today");
            }
            catch (CustomException)
            {
                return null;
            }
        }
        public Truck CreateTruck(int loadCapacity)
        {
            try
            {
                if (_listOfCars.Count < _limit)
                {

                    var x = new Truck(60, this._name + " truck", this, 2000, _id++, loadCapacity);
                    _listOfCars.Add(x);
                    _listOfTrucks.Add(x);
                    return x;
                }
                else
                    throw new CustomException("You've already created max quantity of cars for today");
            }
            catch (CustomException)
            {
                return null;
            }
        }

        public void ShowListOfSportCars()
        {
            foreach (var x in _listOfSportCars)
                Console.WriteLine(x);
        }

        public void ShowListOfTrucks()
        {
            foreach (var x in _listOfTrucks)
                Console.WriteLine(x);
        }


        public SportCar GetSportCar(int id)
        {
            try
            {
                foreach (var x in _listOfSportCars)
                    if (id == x._id)
                        return x;
                throw new CustomException("Nonexistent car");
            }
            catch (CustomException)
            {
                return null;
            }
        }

        public Truck GetTruck(int id)
        {
            try
            {
                foreach (var x in _listOfTrucks)
                    if (id == x._id)
                        return x;
                throw new CustomException("Nonexistent car");
            }
            catch (CustomException)
            {
                return null;
            }
        }


        public string Name { get => _name; }

        private string _name;
        private int _limit;
        private int _id;
        private List<Car> _listOfCars;
        private List<SportCar> _listOfSportCars;
        private List<Truck> _listOfTrucks;

    }
}
