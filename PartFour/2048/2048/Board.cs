namespace _2048
{
     class Board
    {
        public int[,] Data { get;  protected set; }

        public Board()
        {
            Data = new int[4,4];
            for (int row = 0; row < Data.Length; row++)
            {
                for (int col = 0; col < Data.Length; col++)
                {
                    Data[row, col] = 0;
                }
            }
            AddRandomSquare();
            AddRandomSquare();
            
        }

        public int Move(Direction direction) 
        {
            return 0;
        }


        private void MoveByDirection(Direction direction) 
        {
            if (direction == Direction.Up) 
            {
                for(int row = 1; row < Data.Length;row++)
                {
                    for(int col = 0; col < Data.Length; col ++) 
                    {
                        if (Data[row, col] != 0)
                        {
                            if (Data[row - 1, col] == 0)
                            {
                                Data[row - 1, col] = Data[row, col];
                                Data[row, col] = 0;
                            }
                            else if (Data[row - 1, col] == Data[row, col])
                            {
                                Data[row - 1, col] = 2 * Data[row, col];
                                Data[row, col] = 0;
                            }
                        }
                    }
                }
            }
            if (direction == Direction.Down)
            {
                for (int row = Data.Length - 2; row >= 0; row--)
                {
                    for (int col = 0; col < Data.Length; col++)
                    {
                        if (Data[row, col] != 0)
                        {
                            if (Data[row - 1, col] == 0)
                            {
                                Data[row - 1, col] = Data[row, col];
                                Data[row, col] = 0;
                            }
                        }
                    }
                }
            }
            if (direction == Direction.Left)
            {
                for (int row = 0; row < Data.Length; row++)
                {
                    for (int col = 1; col < Data.Length; col++)
                    {
                        if (Data[row, col] != 0)
                        {
                            if (Data[row, col - 1] == 0)
                            {
                                Data[row, col - 1] = Data[row, col];
                                Data[row, col] = 0;
                            }
                        }
                    }
                }
            }
            if(direction == Direction.Right)
            {
                for (int row = 0; row < Data.Length; row++)
                {
                    for (int col = Data.Length - 2; col >= 0; col--)
                    {
                        if (Data[row, col] != 0)
                        {
                            if (Data[row, col - 1] == 0)
                            {
                                Data[row, col - 1] = Data[row, col];
                                Data[row, col] = 0;
                            }
                        }
                    }
                }
            }
        }

        private void Merge(int row, int col)
        {
        }

        private void AddRandomSquare()
        {
            Random random = new();
            int squareValue = random.Next(0, 2);
            if (squareValue == 0)
                squareValue = 2;
            else if (squareValue == 1)
                squareValue = 4;
            int row = random.Next(0, Data.Length);
            int col = random.Next(0, Data.Length);
            Data[row, col] = squareValue;
        }
    }
}
