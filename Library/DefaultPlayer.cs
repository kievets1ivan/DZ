using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class DefaultPlayer : Player
    {
        public DefaultPlayer(int min, int max) : base(min, max) { }
        public override int GuessNumber()
        {
            return Rnd.Next(MinValue, MaxValue);
        }
    }
}
