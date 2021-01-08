using System;

namespace Exercice_3
{
    class Program
    {
        //4 players and 3 turns to win
        public static void TestCase1()
        {
            GameBoard gameBoard = new GameBoard(0); 
            GameMaster gameMaster = new GameMaster(4, 1, gameBoard);
            gameMaster.startGame();
        }

        //6 players and 2 turns to win
        public static void TestCase2()
        {
            GameBoard gameBoard = new GameBoard(0); 
            GameMaster gameMaster = new GameMaster(6, 0, gameBoard);
            gameMaster.startGame();
        }

        public static void Main(string[] args)
        {            
            //TestCase1();
            TestCase2();
        }
    }
}
