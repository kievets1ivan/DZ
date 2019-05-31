using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class UberCheater : Player
    {
        List<int> _notebook;

        public UberCheater(int min, int max) : base(min, max) { }

        public void GetCheatList(List<int> cheatList)
        {
            _notebook = cheatList;
        }

        public override int GuessNumber()
        {
            int temp = MinValue;

            while (_notebook.Contains(temp))
            {
                temp++;
            }

            return temp;

        }


    }
}
