using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ThisGame
    {
        List<Player> _players;
        List<int> _commonAnswers;

        int _minValue;
        int _maxValue;
        int _quantityOfAttempts;
        

        public ThisGame(int min, int max, int quantityOfAttempts)
        {
            _quantityOfAttempts = quantityOfAttempts;
            _minValue = min;
            _maxValue = max;
            _players = new List<Player>();
            _commonAnswers = new List<int>();
        }

        /*public void AddPlayerToGame(Player player)
        {
            if(player.GetType() == typeof(Cheater))
            {
                Cheater tempPlayer = player as Cheater;
                tempPlayer.GetCheatList(_commonAnswers);
                _players.Add(tempPlayer);
            }

        }*/
        public void AddDefaultPlayer()
        {
            _players.Add(new DefaultPlayer(_minValue, _maxValue));

        }

        public void StartGame()
        {

            for(int i= 0; i< _quantityOfAttempts;i++)
            {
                //_players[i].GuessNumber();

            }


        }






    }
}
