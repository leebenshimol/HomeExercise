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
            Points = 2040;
        }

        public void Move(Direction direction)
        {
            int makeAMove = GameBoard.MoveByDirection(direction);
            if (makeAMove == -1)
                GameStatus = GameStatus.Lose;
            else
                Points += makeAMove;
            if (Points >= 2048)
                GameStatus = GameStatus.Win;

        }

        private void CheckGameStatus()
        {
            if (Points >= 2048)
                GameStatus = GameStatus.Win;

        }
    }
}
