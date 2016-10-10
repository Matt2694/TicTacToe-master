using System;
using TicTacToe.Services;

namespace TicTacToeCLI{

    class Program{

        IGameWinnerService _gameWinnerService = new GameWinnerService();
        private char[,] _gameBoard = new char[3, 3]{ { ' ', ' ', ' '},
                                                     { ' ', ' ', ' '},
                                                     { ' ', ' ', ' '}};
        private string rules = "Players alternate turns(e.g. P1, P2, P1, P2)\n" +
                "Player 1 is X, and Player 2 is O\n" +
                "Type the coordinates of the box you would like to place your mark in," +
                "\nAlways type the coordinate in order of row followed by column\n" +
                "For example, to put a mark in the top left box, you would type A1\n";
        private string gameBoard;
        
        static void Main(string[] args){

            Program myProgram = new Program();
            myProgram.Run();
        }

        public void Run(){

            bool running = true;
            string choice = "";
            UpdateGameBoard();
            ShowMenu(gameBoard);
            char symbol;
            int turn = 1;
            int player;
            do{
                Console.Clear();
                if (turn % 2.0 == 0){
                    symbol = 'O';
                    player = 2;
                }
                else{
                    symbol = 'X';
                    player = 1;
                }
                DisplayBoard(gameBoard, player);
            GetResponse:
                choice = GetUserChoice();
                if(DetermineLocation(choice)){
                    Console.WriteLine("\nThere is already a mark there," +
                                      " please place your mark in a different square\n");
                    goto GetResponse;
                }
                switch (choice){
                    case "a1": _gameBoard[0,0] = symbol; break;
                    case "a2": _gameBoard[0,1] = symbol; break;
                    case "a3": _gameBoard[0,2] = symbol; break;
                    case "b1": _gameBoard[1,0] = symbol; break;
                    case "b2": _gameBoard[1,1] = symbol; break;
                    case "b3": _gameBoard[1,2] = symbol; break;
                    case "c1": _gameBoard[2,0] = symbol; break;
                    case "c2": _gameBoard[2,1] = symbol; break;
                    case "c3": _gameBoard[2,2] = symbol; break;
                    case "end": running = false; break;
                    default: Console.WriteLine("\nInvalid input, please input a valid coordinate\n"); goto GetResponse;
                }
                UpdateGameBoard();
                turn++;
                if (_gameWinnerService.Validate(_gameBoard) != ' '){
                    Console.Clear();
                    Console.WriteLine(gameBoard);
                    string winner = "";
                    switch (_gameWinnerService.Validate(_gameBoard)){
                        case 'X': winner = "Player 1"; break;
                        case 'O': winner = "Player 2"; break;
                        default: winner = "No one"; break;
                    }
                    Console.WriteLine("\nCongratulations, " + winner +
                                      " wins!\n\n\nPress any key to close the game");
                    Console.ReadKey();
                    running = false;
                }
                else if (turn == 10){
                    Console.Clear();
                    Console.WriteLine(gameBoard);
                    Console.WriteLine("It was a draw\n\nPress any key to end the program");
                    Console.ReadKey();
                    running = false;
                }
            } while (running);
        }

        private bool DetermineLocation(string input){

            if(input == "end"){
                return false;
            }
            string coord1 = input.Substring(0,1);
            string coord2 = input.Substring(1);
            int firstElement = 0;
            int secondElement = 0;
            switch (coord1){
                case "a": firstElement = 0; break;
                case "b": firstElement = 1; break;
                case "c": firstElement = 2; break;
                default: return false;
            }
            switch (coord2){
                case "1": secondElement = 0; break;
                case "2": secondElement = 1; break;
                case "3": secondElement = 2; break;
                default: return false;
            }
            return !(_gameBoard[firstElement, secondElement] == ' ');
        }

        private void DisplayBoard(string gameBoard, int playerNum){

            Console.WriteLine(rules + "\nType end to close the program\n" + gameBoard +
                "\nPlease input the move for Player " + playerNum + "\n");
        }

        private string GetUserChoice(){

            string input = Console.ReadLine().ToLower();
            return input;
        }

        private void UpdateGameBoard(){

            gameBoard = "\n\n    1   2   3\n\nA   " + _gameBoard[0, 0] + " │ " + _gameBoard[0, 1] +
                                " │ " + _gameBoard[0, 2] + " \n" + "   ───┼───┼───\nB   " + _gameBoard[1, 0] +
                                " │ " + _gameBoard[1, 1] + " │ " + _gameBoard[1, 2] + " \n" +
                                "   ───┼───┼───\nC   " + _gameBoard[2, 0] + " │ " + _gameBoard[2, 1] +
                                " │ " + _gameBoard[2, 2] + "\n\n";
        }

        private void ShowMenu(string gameBoard){

            Console.WriteLine("Tic Tac Toe\n\nRules:\n" + rules +
                "The game board looks like this:\n\n" + gameBoard + 
                "\n\nPress any key to continue...\n");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
