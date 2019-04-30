using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForAvtoPark
{
    public class Truck : Car
    {
        private int _loadCapacity;

        private int LoadCapacity
        {
            set
            {

                if (value < _weight && value > 0)
                    _loadCapacity = value;
                else throw new CustomException("Invalid value");
            }
        }

        public Truck(int maxSpeed, string brand, Manufacturer m, int weight, int id, int loadCapacity)
            : base(maxSpeed, brand, m, weight, id)
        {
            LoadCapacity = loadCapacity;

            _coeffBoost = 1;

        }

        public void LoadTruck(Car car)
        {
            if (car._weight <= this._weight - this._loadCapacity)
                _coeffBoost = 1;
            else
                _coeffBoost = (_weight - _loadCapacity) / (double)car._weight;

        }

        public override string ToString()
        {
            return $"Id: {_id}, Brand: {_brand}, Manufacture: {_manufacture.Name}, Weight: {_weight}, loadCapacity: {_loadCapacity}";
        }
    }
}
