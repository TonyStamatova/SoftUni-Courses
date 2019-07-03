namespace P03_JediGalaxy
{
    using System;

    public class Player
    {
        public Player(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }
        public int Col { get; private set; }

        public bool IsStillPlaying(int endingRow, Predicate<int> colCondition)
        {
            bool colPositionIsValid = colCondition(this.Col);

            if (this.Row >= endingRow && colPositionIsValid)
            {                
                return true;
            }

            return false;
        }

        public bool IsInBounds(int rows, int cols)
        {
            if (this.Row >= 0 && this.Col >= 0 && this.Row < rows && this.Col < cols)
            {
                return true;
            }

            return false;
        }

        public void Move(int rowShift, int colShift)
        {
            this.Row += rowShift;
            this.Col += colShift;
        }
    }
}
