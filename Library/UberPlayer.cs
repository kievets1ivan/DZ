using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class UberPlayer : Player
    {
        public UberPlayer(int min, int max): base(min, max) { }
        public override int GuessNumber()
        {
            return MinValue++;
        }

    }
}
