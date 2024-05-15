namespace _2048
{
     class Game
    {
        public Board GameBoard { get; set; }
        public GameStatus GameStatus { get; set; }
        public int Points { get; protected set; }

        public Game() 
        {
        }

        public void Move(Direction direction)
        {
            GameBoard.Move(direction);
        }
    }
}
