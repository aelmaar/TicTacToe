using System;
namespace TicTacToe
{
public class Game {
    public string[,] board = new string[3,3] {{".", ".", "."},{".", ".", "."},{".", ".", "."}};

    // add X or O to the board
    public void addToBoard(int x, int y, string symbol) {
        board[x-1, y-1] = symbol;
    }
    // we will print the board everytime a player will add X or O to the board
    public void printBoard() {
        int row, col;
        string a, b, c;
        Console.Write("     1");
        Console.Write("     2");
        Console.WriteLine("     3");
        for (row = 0, col = 0; row < 3; row++) {
            a = board[row,col];
            b = board[row,col+1];
            c = board[row,col+2];
            Console.WriteLine("  ___________________");
            Console.WriteLine($"  |     |     |     |");
            Console.Write(row+1);
            Console.WriteLine($" |  {a}  |  {b}  |  {c}  |");
            Console.WriteLine($"  |     |     |     |");
        }
        Console.WriteLine("  ___________________");
    }
    // we will check row by row if they are equal to XXX or OOO
    public bool checkRows() {
        int row, col;
        string checkRow;

        for (row = 0, col = 0; row < 3; row++) {
            checkRow = board[row,col] + board[row,col+1] + board[row,col+2];
            if (checkRow == "XXX" || checkRow == "OOO") {
                return true;
            }
        }
        return false;
    }
    // we will check col by col if they are equal to XXX or OOO
    public bool checkColumns() {
        int row, col;
        string checkCol;

        for (row = 0, col = 0; col < 3; col++) {
            checkCol = board[row,col] + board[row+1,col] + board[row+2,col];
            if (checkCol == "XXX" || checkCol == "OOO") {
                return true;
            }
        }
        return false;
    }
    // we will check too diagonals if they are equal to XXX or OOO
    public bool checkDiags() {
        string diagOne, diagTwo;

        diagOne = board[0, 0] + board[1, 1] + board[2, 2];
        diagTwo = board[0, 2] + board[1, 1] + board[2, 0];

        if (diagOne == "XXX" 
            || diagOne == "OOO" 
            || diagTwo == "XXX" 
            || diagTwo == "OOO")
            return true;
        return false;
    }
    // everytime a player will play we will check if he won
    public bool IsWinning() {
        if (checkRows() || checkColumns() || checkDiags())
            return true;
        return false;
    }
}
}