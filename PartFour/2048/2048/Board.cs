namespace _2048
{
    class Board
    {
        public int[,] Data { get; protected set; }

        public Board()
        {
            Data = new int[4, 4];
            for (int row = 0; row < Data.GetLength(0); row++)
            {
                for (int col = 0; col < Data.GetLength(0); col++)
                {
                    Data[row, col] = 0;
                }
            }
            AddRandomSquareInEmptyPlace();
            AddRandomSquareInEmptyPlace();
            PrintGameBoard();

        }

        public int Move(Direction direction)
        {
            int points = 0;
            for (int goOverAllBoard = 0; goOverAllBoard < Data.GetLength(0); goOverAllBoard++)
            {
                if (direction == Direction.Up)
                    for (int row = 1; row < Data.GetLength(0); row++)
                        for (int col = 0; col < Data.GetLength(0); col++)
                            if (Data[row, col] != 0)
                            {
                                MoveAndUpdate(row, col, row - 1, col);
                                points += Merge(row, col, row - 1, col);
                            }

                if (direction == Direction.Down)
                    for (int row = Data.GetLength(0) - 2; row >= 0; row--)
                        for (int col = 0; col < Data.GetLength(0); col++)
                            if (Data[row, col] != 0)
                            {
                                MoveAndUpdate(row, col, row + 1, col);
                                points += Merge(row, col, row + 1, col);
                            }

                if (direction == Direction.Left)
                    for (int row = 0; row < Data.GetLength(0); row++)
                        for (int col = 1; col < Data.GetLength(0); col++)
                            if (Data[row, col] != 0)
                            {
                                MoveAndUpdate(row, col, row, col - 1);
                                points += Merge(row, col, row, col - 1);
                            }

                if (direction == Direction.Right)
                    for (int row = 0; row < Data.GetLength(0); row++)
                        for (int col = Data.GetLength(0) - 2; col >= 0; col--)
                            if (Data[row, col] != 0)
                            {
                                MoveAndUpdate(row, col, row, col + 1);
                                points += Merge(row, col, row, col + 1);
                            }

            }
            AddRandomSquareInEmptyPlace();
            PrintGameBoard();
            return points;
        }
        private int Merge(int row, int col, int nextRow, int nextCol)
        {
            if (Data[row, col] == Data[nextRow, nextCol])
            {
                Data[nextRow, nextCol] = 2 * Data[row, col];
                Data[row, col] = 0;
                return Data[nextRow, nextCol];
            }
            return 0;
        }

        private void MoveAndUpdate(int row, int col, int nextRow, int nextCol)
        {
            if (Data[nextRow, nextCol] == 0)
            {
                Data[nextRow, nextCol] = Data[row, col];
                Data[row, col] = 0;
            }
        }

        public bool IsLose()
        {
            if (BoardIsFull())
            {
                if (IsThereAnotherMove() == false)
                {
                    return true;
                }  
            }
            return false;
        }
        private bool IsThereAnotherMove()
        {

            for (int index = 0; index < Data.GetLength(0) - 1; index++)
            {
                int col = Data.GetLength(0) - 1;
                if ((Data[index, col] == Data[index + 1, col]) || Data[index, col] == Data[index, col - 1])
                {
                    return true;
                }
                int row = Data.GetLength(0) - 1;
                if ((Data[row, index] == Data[row - 1, index]) || Data[row, index] == Data[row, index + 1])
                {
                    return true;
                }
            }
            for (int row = 0; row < Data.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < Data.GetLength(0) - 1; col++)
                {
                    if ((Data[row, col] == Data[row + 1, col]) || Data[row, col] == Data[row, col + 1])
                        return true;
                }
            }
            return false;
        }

        private bool BoardIsFull()
        {
            for (int row = 0; row < Data.GetLength(0); row++)
            {
                for (int col = 0; col < Data.GetLength(0); col++)
                {
                    if (Data[row, col] == 0)
                        return false;
                }
            }
            return true;
        }

        private void AddRandomSquareInEmptyPlace()
        {
            if(BoardIsFull() == false)
            {
                Random random = new();
                int squareValue = random.Next(0, 2);
                if (squareValue == 0)
                    squareValue = 2;
                else if (squareValue == 1)
                    squareValue = 4;
                int row = random.Next(0, Data.GetLength(0));
                int col = random.Next(0, Data.GetLength(0));
                while (Data[row, col] != 0)
                {
                    row = random.Next(0, Data.GetLength(0));
                    col = random.Next(0, Data.GetLength(0));
                }
                Data[row, col] = squareValue;
            }
         
        }

        public void PrintGameBoard()
        {
            for (int row = 0; row < Data.GetLength(0); row++)
            {
                for (int col = 0; col < Data.GetLength(0); col++)
                {
                    if (Data[row, col] == 0)
                        Console.Write("    -    ");
                    else
                        Console.Write("    " + Data[row, col] + "    ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
