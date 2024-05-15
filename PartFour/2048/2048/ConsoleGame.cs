﻿namespace _2048
{
    class ConsoleGame
    {

        public void StartGame()
        {
            Console.WriteLine("Welcome to 2048 :)");
            Console.WriteLine("In order to start a game press any key except ESC unless you want to quit ");
            ConsoleKeyInfo userChoice = Console.ReadKey();
            Console.WriteLine();
            if (userChoice.Key == ConsoleKey.Escape)
                Console.WriteLine("Good bye :)");
            Game CurrentGame = new Game();
            while (CurrentGame.GameStatus != GameStatus.Lose && CurrentGame.GameStatus != GameStatus.Win)
            {
                Direction userDirection = GetDirection();
                CurrentGame.Move(userDirection);
            }
        }
        private Direction GetDirection()
        {
            Direction userDirectionChoice = new Direction();
            Console.WriteLine("Press on the Arrows in your keyboard to make a move");
            ConsoleKeyInfo directionChoice = Console.ReadKey();
            Console.WriteLine();
            while (directionChoice.Key != ConsoleKey.UpArrow &&
                   directionChoice.Key != ConsoleKey.DownArrow &&
                   directionChoice.Key != ConsoleKey.RightArrow &&
                   directionChoice.Key != ConsoleKey.LeftArrow)
            {
                Console.WriteLine("Please press only on the Arrows in your keyboard to make a move");
                directionChoice = Console.ReadKey();
                Console.WriteLine();
            }
            if (directionChoice.Key == ConsoleKey.UpArrow)
                userDirectionChoice = Direction.Up;
            if (directionChoice.Key == ConsoleKey.DownArrow)
                userDirectionChoice = Direction.Down;
            if (directionChoice.Key == ConsoleKey.RightArrow)
                userDirectionChoice = Direction.Right;
            if (directionChoice.Key == ConsoleKey.LeftArrow)
                userDirectionChoice = Direction.Left;
            return userDirectionChoice;
        }





    }
}
