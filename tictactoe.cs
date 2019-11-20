using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            int ROW_LENGTH = 3;
            int COL_LENGTH = 3;
            bool isGameOver = false;
            bool isPlayerOneTurn = true;

            int[,] board = new int[ROW_LENGTH, COL_LENGTH];

             Player playerOne = new Player(1, true);
             Player playerTwo = new Player(2, false);

            for (int row = 0; row < ROW_LENGTH; row++)
            {
                for (int col = 0; col < COL_LENGTH; col++)
                {
                    Console.Write(board[row, col] + " ");
                }
                Console.WriteLine();
            }

            while (!isGameOver) {

                playGame(isPlayerOneTurn,board);
                isPlayerOneTurn = !isPlayerOneTurn;
                for (int row = 0; row < ROW_LENGTH; row++)
                {
                    for (int col = 0; col < COL_LENGTH; col++)
                    {
                        Console.Write(board[row, col] + " ");
                    }
                    Console.WriteLine();
                }

                int winner = checkIsGameOver(board);
                if (winner == 1)
                {
                    Console.WriteLine("PLAYER ONE WINS!");
                    isGameOver = true;
                }
                else if (winner == 2)
                {
                    Console.WriteLine("PLAYER TWO WINS!");
                    isGameOver = true;
                }
                else { }
            }
            
        }

        public static int[,] playGame(bool isPlayer1,int[,] boardPlay){
            int chosenRow;
            int chosenCol;
            Console.WriteLine("what row would you like to play on(0-2)?");
            Int32.TryParse(Console.ReadLine(), out chosenRow);
            Console.WriteLine("what col would you like to play on(0-2)?");
            Int32.TryParse(Console.ReadLine(), out chosenCol);

            if (isPlayer1)
            {
                boardPlay[chosenRow, chosenCol] = 1;
            }
            else {
                boardPlay[chosenRow, chosenCol] = 2;
            }

            return boardPlay;
        }


        public static int checkIsGameOver(int[,] boardCheck) {
            for (int row = 0; row < 3; row++) {
                if (boardCheck[row, 0] == boardCheck[row, 1] && boardCheck[row, 0] == boardCheck[row, 2]
                    && boardCheck[row, 0] == 1)
                {
                    return 1;
                }
            }

            for (int col = 0; col < 3; col++)
            {
                if (boardCheck[0, col] == boardCheck[1, col] && boardCheck[0, col] == boardCheck[2, col]
                    && boardCheck[0, col] == 1)
                {
                    return 2;
                }
            }
            return 0;
        }
    }

    class Player
    {
        private int name;
        private bool isPlayerOne;

        public Player()
        {
            name = 1;
            isPlayerOne = true;
        }

        public Player(int n, bool playerone)
        {
            name = n;
            isPlayerOne = playerone;
        }
    }
}
