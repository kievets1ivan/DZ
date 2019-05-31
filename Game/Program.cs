using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Game
{
    class Program
    {
        public enum TypePlayer
        {
            DefaultPlayer = 0,
            PlayerNotebook = 1,
            UberPlayer = 2,
            Cheater = 3,
            UberCheater = 4
        }

        public delegate void MyDel();

        static public class GameCaption
        {
            static public string enterQuantityOfPlayers = "Enter quantity of players: ";
            static public string enterMinValue = "Enter min value: ";
            static public string enterMaxValue = "Enter max value: ";
            static public string enterNumber = "Enter number: ";
            static public string enterName = "Enter Name: ";
            static public string showTypesOfPlayer = 
                "0 - DefaultPlayer\n" +
                "1 - PlayerNotebook\n"  +
                "2 - UberPlayer\n" +
                "3 - Cheater\n" +
                "4 - UberCheater";


        }

        static public int GetIntVar (string caption)
        {
            int temp;
            Console.WriteLine(caption);
            if(int.TryParse(Console.ReadLine(),out temp))
            {
                return temp;
            }

            return 0;
        }

        static public TypePlayer GetTypeOfPlayer(string caption)
        {
            Console.WriteLine(caption);
            int number = GetIntVar(GameCaption.enterNumber);

            return (TypePlayer)number;
        }


        static void Main(string[] args)
        {

            int minValue = GetIntVar(GameCaption.enterMinValue);
            int maxValue = GetIntVar(GameCaption.enterMaxValue);
            int quantityOfPlayers = GetIntVar(GameCaption.enterQuantityOfPlayers);

            var g = new ThisGame(minValue, maxValue, quantityOfPlayers);


            var dict = new Dictionary<TypePlayer, MyDel>();

            dict.Add(TypePlayer.DefaultPlayer, new MyDel(g.AddDefaultPlayer));

            
            
            for(int i = 0; i < quantityOfPlayers; i++)
            {
                Console.WriteLine(GameCaption.enterName);
                string nameOfPlayer = Console.ReadLine();
                TypePlayer typePlayer = GetTypeOfPlayer(GameCaption.showTypesOfPlayer);

                
            }



            /*var _notebook = new List<int>();
            int temp = new Random().Next(0, 21);

            for (int i = 0; i < 10; i++)
            {
                while (_notebook.Contains(temp))
                {
                    temp = new Random().Next(0, 21);
                }

                _notebook.Add(temp);
            }

            foreach(var t in _notebook)
                Console.WriteLine(t+ " ");*/



            /*var n = new UberCheater(0, 21);

            var common = new List<int>() { 0, 1, 2, 3, 4, 5, 8, 9, 11};

            n.GetCheatList(common);

            for (int i = 0; i < 10; i++)
            {
                int x = n.GuessNumber();
                Console.WriteLine(x);
                common.Add(x);
            }*/
        }
        
    }
}
