namespace _2048
{
     class Game
    {
        public Board GameBoard { get; set; }
        public GameStatus GameStatus { get; set; }
        public int Points { get; protected set; }

        public Game() 
        {
            GameBoard = new Board();
            GameStatus = new GameStatus();
            GameStatus = GameStatus.Idle;
            Points = 0;
        }

        public void Move(Direction direction)
        {
            if (GameStatus == GameStatus.Idle) 
            {
                if (GameBoard.IsLose())
                {
                    GameBoard.PrintGameBoard();
                    GameStatus = GameStatus.Lose;
                }
                    
                else if (IsWin())
                    GameStatus = GameStatus.Win;
                else
                {
                    Points += GameBoard.Move(direction);
                    Console.WriteLine("Points --> " + Points + "\n");
                }
            }

        }

        private bool IsWin()
        {
            for (int row = 0; row < GameBoard.Data.GetLength(0) - 1; row++)
                for (int col = 0; col < GameBoard.Data.GetLength(0) - 1; col++)
                    if ((GameBoard.Data[row, col] == 2048))
                        return true;
            return false;
        }

    }
}
