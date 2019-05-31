using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class PlayerNotebook : Player
    {
        List<int> _notebook;

        public PlayerNotebook(int min, int max) : base(min, max)
        {
            _notebook = new List<int>();
        }

        public override int GuessNumber()
        {
            int temp = Rnd.Next(MinValue, MaxValue);

            while (_notebook.Contains(temp))
            {
                temp = Rnd.Next(MinValue, MaxValue);
            }

            _notebook.Add(temp);
            return temp;

        }
    }
}
