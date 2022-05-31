using System;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            string playerOne, playerTwo, repeat;
            
            repeat = "Y";
            while (repeat == "Y" || repeat == "y") {
                Console.Write("Player One X/O: ");
                playerOne = Console.ReadLine().ToUpper();
                // we check if the player one choose only X or O
                while (playerOne != "X" && playerOne != "O") {
                    Console.Write("Choose only X or O: ");
                    playerOne = Console.ReadLine().ToUpper();
                }
                // if the player one choose X the player two gets O and vice versa :)
                if (playerOne == "X")
                    playerTwo = "O";
                else
                    playerTwo = "X";
                while (true) {
                    int[] XYOne, XYTwo;
                    // player one plays
                    Console.Write("Player One add x/y positions separated by a space: ");
                    XYOne = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
                    // check if the position that player one want to add to the board is empty
                    while (game.board[XYOne[0]-1,XYOne[1]-1] != ".") {
                        Console.Write("Add to the right positions x/y separated by a space: ");
                        XYOne = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
                    }
                    game.addToBoard(XYOne[0], XYOne[1], playerOne);
                    game.printBoard();
                    // if player one wins we congratulate him :)
                    if (game.IsWinning()) {
                        Console.WriteLine("Congratulations, Player One wins");
                        break;
                    }
                    // player two plays
                    Console.Write("Player Two add x/y positions separated by a space: ");
                    XYTwo = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
                    // check if the position that player two want to add to the board is empty
                    while (game.board[XYTwo[0]-1,XYTwo[1]-1] != ".") {
                        Console.Write("Add to the right positions x/y separated by a space: ");
                        XYTwo = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
                    }
                    game.addToBoard(XYTwo[0], XYTwo[1], playerTwo);
                    game.printBoard();
                    // if player two wins we congratulate him :)
                    if (game.IsWinning()) {
                        Console.WriteLine("Congratulations, Player Two wins");
                        break;
                    }
                }
                // clear all the board
                for (int i=0;i<9;i++) game.board[i%3,i/3]="."; 
                Console.Write("Do you wanna repeat the game ? Y/N: ");
                repeat = Console.ReadLine();
            }
            Console.WriteLine("Have fun :)");
        }
    }
}