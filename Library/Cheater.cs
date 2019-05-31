using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Cheater : Player
    {
        List<int> _notebook;

        public Cheater(int min, int max) : base(min, max) { }

        public void GetCheatList(List<int> cheatList)
        {
            _notebook = cheatList;
        }

        public override int GuessNumber()
        {
            int temp = Rnd.Next(MinValue, MaxValue);

            while (_notebook.Contains(temp))
            {
                temp = Rnd.Next(MinValue, MaxValue);
            }

            return temp;

        }

    }
}
