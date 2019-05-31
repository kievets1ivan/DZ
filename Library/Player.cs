using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{

    public abstract class Player
    {
        protected Random Rnd;
        protected int MinValue;
        protected int MaxValue;

        public Player(int min, int max)
        {
            MinValue = min;
            MaxValue = max;
            Rnd = new Random();
        }

        abstract public int GuessNumber();
    }
}
