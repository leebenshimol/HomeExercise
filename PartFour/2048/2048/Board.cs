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
            AddRandomSquare();
            AddRandomSquare();
            PrintGameBoard();

        }

        public int Move(Direction direction)
        {
            MoveByDirection(direction);
            AddRandomSquareAfterMove();
            return 0;
        }


        public int MoveByDirection(Direction direction)
        {
            if (BoardIsFull())
            {
                if (!ThereIsAnotherMove())
                {
                    return -1;
                }
            }
            int countEmptyCells = 1;
            int points = 0;
            if (direction == Direction.Up)
            {
                while (countEmptyCells <= Data.GetLength(0))
                {
                    for (int row = 1; row < Data.GetLength(0); row++)
                    {
                        for (int col = 0; col < Data.GetLength(0); col++)
                        {
                            if (Data[row, col] != 0)
                            {
                                if (Data[row - 1, col] == 0)
                                {
                                    Data[row - 1, col] = Data[row, col];
                                    Data[row, col] = 0;
                                }
                                if ((Data[row, col] == Data[row - 1, col]))
                                {
                                    Data[row - 1, col] = 2 * Data[row, col];
                                    Data[row, col] = 0;
                                    points += Data[row - 1, col];
                                }

                            }
                        }
                    }
                    countEmptyCells++;
                }
            }
            if (direction == Direction.Down)
            {
                while (countEmptyCells <= Data.GetLength(0))
                {
                    for (int row = Data.GetLength(0) - 2; row >= 0; row--)
                    {
                        for (int col = 0; col < Data.GetLength(0); col++)
                        {
                            if (Data[row, col] != 0)
                            {
                                if (Data[row + 1, col] == 0)
                                {
                                    Data[row + 1, col] = Data[row, col];
                                    Data[row, col] = 0;
                                }
                                if ((Data[row, col] == Data[row + 1, col]))
                                {
                                    Data[row + 1, col] = 2 * Data[row, col];
                                    Data[row, col] = 0;
                                    points += Data[row + 1, col];
                                }
                            }
                        }
                    }
                    countEmptyCells++;
                }

            }
            if (direction == Direction.Left)
            {
                while (countEmptyCells <= Data.GetLength(0))
                {

                    for (int row = 0; row < Data.GetLength(0); row++)
                    {
                        for (int col = 1; col < Data.GetLength(0); col++)
                        {
                            if (Data[row, col] != 0)
                            {
                                if (Data[row, col - 1] == 0)
                                {
                                    Data[row, col - 1] = Data[row, col];
                                    Data[row, col] = 0;
                                }
                                if ((Data[row, col] == Data[row, col - 1]))
                                {
                                    Data[row, col - 1] = 2 * Data[row, col];
                                    Data[row, col] = 0;
                                    points += Data[row, col - 1];
                                }
                            }
                        }
                    }
                    countEmptyCells++;

                }
            }
            if (direction == Direction.Right)
            {
                while (countEmptyCells <= Data.GetLength(0))
                {
                    for (int row = 0; row < Data.GetLength(0); row++)
                    {
                        for (int col = Data.GetLength(0) - 2; col >= 0; col--)
                        {
                            if (Data[row, col] != 0)
                            {
                                if (Data[row, col + 1] == 0)
                                {
                                    Data[row, col + 1] = Data[row, col];
                                    Data[row, col] = 0;
                                }
                                if ((Data[row, col] == Data[row, col + 1]))
                                {
                                    Data[row, col + 1] = 2 * Data[row, col];
                                    Data[row, col] = 0;
                                    points += Data[row, col + 1];
                                }
                            }
                        }
                    }
                    countEmptyCells++;
                }
            }
            AddRandomSquareAfterMove();
            PrintGameBoard();
            return points;
        }

        private void Merge()
        {

        }
        

        private bool ThereIsAnotherMove()
        {
            for (int row = 0; row < Data.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < Data.GetLength(0) - 1; col++)
                {
                    if ((Data[row, col] != Data[row + 1,col]) && Data[row, col] != Data[row, col + 1])
                        return false;

                }
            }
            return true;
                

        }

        private bool BoardIsFull()
        {
            for (int row = 0; row < Data.GetLength(0); row++)
            {
                for (int col = 0; col < Data.GetLength(0); col++)
                {
                    if ((Data[row, col] == 0))
                        return false;
                }
            }
            return true;
        }
        private void AddRandomSquare()
        {
            Random random = new();
            int squareValue = random.Next(0, 2);
            if (squareValue == 0)
                squareValue = 2;
            else if (squareValue == 1)
                squareValue = 4;
            int row = random.Next(0, Data.GetLength(0));
            int col = random.Next(0, Data.GetLength(0));
            Data[row, col] = squareValue;
        }

        private void AddRandomSquareAfterMove()
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

        public void PrintGameBoard()
        {
            for (int row = 0; row < Data.GetLength(0); row++)
            {
                for (int col = 0; col < Data.GetLength(0); col++)
                {
                    if (Data[row, col] == 0)
                        Console.Write("-|");
                    else
                        Console.Write(Data[row, col] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
    }
}
