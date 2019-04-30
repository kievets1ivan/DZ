using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForAvtoPark
{
    public class SportCar : Car
    {

        private int _sizeOfNitro;

        private int SizeOfNitro
        {
            set
            {
                if (value < 50 && value > 0)
                    _sizeOfNitro = value;
                else throw new CustomException("Invalid value");
            }
        }



        public SportCar(int maxSpeed, string brand, Manufacturer m, int weight, int id, int sizeOfNitro)
            : base(maxSpeed, brand, m, weight, id)
        {
            SizeOfNitro = sizeOfNitro;
            _coeffBoost = 1 + (double)_sizeOfNitro / 100;
        }

        public void UseNitro()
        {
            if (_sizeOfNitro > 0)
            {
                Speed *= _coeffBoost;

                _sizeOfNitro -= 5;
            }
        }

        public override string ToString()
        {
            return $"Id: {_id}, Brand: {_brand}, Manufacture: {_manufacture.Name}, Weight: {_weight}, nitro: {_sizeOfNitro}";
        }
    }
}
