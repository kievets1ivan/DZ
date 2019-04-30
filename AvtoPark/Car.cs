using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForAvtoPark
{
    public abstract class Car
    {
        public readonly int _id;
        protected readonly int _maxSpeed;
        protected readonly string _brand;
        protected readonly Manufacturer _manufacture;
        public readonly int _weight;
        protected double _coeffBoost;
        protected double _speed;
        public double Speed
        {
            get { return _speed; }
            protected set
            {
                _speed = value;

                if (_speed == _maxSpeed)
                {
                    for (int i = 0; i < 5; i++)
                        Breaking();
                }
                else if (_speed > _maxSpeed)
                {
                    _speed = _maxSpeed - _coeffBoost;
                }
            }
        }

        public Car(int maxSpeed, string brand, Manufacturer m, int weight, int id)
        {
            _maxSpeed = maxSpeed;
            _brand = brand;
            _manufacture = m;
            _weight = weight;
            _id = id;
            _speed = 0;
        }

        public void Run()
        {
            Speed += _coeffBoost;
        }

        public void Breaking()
        {
            Speed--;
        }

    }
}
