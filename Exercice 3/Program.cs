using System;

namespace Exercice_3
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n_players = 4;
            int scenario = 0;
            GameBoard gameBoard = new GameBoard(0); 
            GameMaster gameMaster = new GameMaster(n_players, scenario, gameBoard);
            gameMaster.startGame();
            
        }
    }
}
