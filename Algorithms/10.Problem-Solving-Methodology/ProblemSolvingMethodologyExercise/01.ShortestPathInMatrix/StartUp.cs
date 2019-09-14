namespace _01.ShortestPathInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int[,] matrix;
        private static int[,] distances;
        private static PriorityQueue<Cell> queue;

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new int[rows, cols];
            FillInMatrixValues(matrix);

            distances = new int[matrix.GetLength(0), matrix.GetLength(1)];
            FillDistancesMatrixWithMaxValues();
            queue = new PriorityQueue<Cell>();
            CalculateDistance();

            List<int> result = ReconstructPath();

            Console.WriteLine($"Length: {result.Sum()}");
            Console.WriteLine($"Path: {string.Join(" ", result)}");
        }

        private static void FillDistancesMatrixWithMaxValues()
        {
            for (int i = 0; i < distances.GetLength(0); i++)
            {
                for (int j = 0; j < distances.GetLength(1); j++)
                {
                    distances[i, j] = int.MaxValue;
                }
            }
        }

        private static List<int> ReconstructPath()
        {
            List<int> path = new List<int>();
            int row = matrix.GetLength(0) - 1;
            int col = matrix.GetLength(1) - 1;
            path.Add(matrix[row, col]);

            int previousRow = -1;
            int previousCol = -1;

            while (row != 0 || col != 0)
            {
                int previous = int.MaxValue;
                previous = FindPrevious(row - 1, col, previous, ref previousRow,  ref previousCol);
                previous = FindPrevious(row, col - 1, previous, ref previousRow,  ref previousCol);
                previous = FindPrevious(row + 1, col, previous, ref previousRow,  ref previousCol);
                FindPrevious(row, col + 1, previous, ref previousRow, ref previousCol);
                row = previousRow;
                col = previousCol;
                path.Add(matrix[row, col]);
            }

            path.Reverse();
            return path;
        }

        private static int FindPrevious(int row, int col, int previous, ref int previousRow, ref int previousCol)
        {
            if (PositionIsValid(row, col) && distances[row, col] < previous)
            {
                previous = distances[row, col];
                previousRow = row;
                previousCol = col;
            }

            return previous;
        }

        private static void CalculateDistance()
        {
            Cell start = new Cell(0, 0);
            start.Distance = matrix[0, 0];
            distances[0, 0] = matrix[0, 0];
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                Cell current = queue.ExtractMin();
                int row = current.Row;
                int col = current.Col;
                int currentDistance = distances[row, col];

                UpdateChildDistance(row + 1, col, currentDistance);
                UpdateChildDistance(row, col + 1, currentDistance);
                UpdateChildDistance(row - 1, col, currentDistance);
                UpdateChildDistance(row, col - 1, currentDistance);
            }
        }


        private static void UpdateChildDistance(int row, int col, int currentDistance)
        {
            if (!PositionIsValid(row, col))
            {
                return;
            }

            int currentlyCalculated = matrix[row, col] + currentDistance;

            if (currentlyCalculated < distances[row, col])
            {
                distances[row, col] = currentlyCalculated;
                Cell cell = new Cell(row, col);
                cell.Distance = currentlyCalculated;
                queue.Enqueue(cell);
            }
        }

        private static bool PositionIsValid(int row, int col)
        {
            if (IndexIsValid(row, matrix, 0)
                && IndexIsValid(col, matrix, 1))
            {
                return true;
            }

            return false;
        }

        private static bool IndexIsValid(int index, int[,] matrix, int dimension)
        {
            if (index >= 0 && index < matrix.GetLength(dimension))
            {
                return true;
            }

            return false;
        }

        private static void FillInMatrixValues(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }
    }

    public class Cell : IComparable<Cell>
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }
                             
        public int Col { get; private set; }

        public int Distance { get; set; }

        public int CompareTo(Cell other)
        {
            return this.Distance.CompareTo(other.Distance);
        }

        public override bool Equals(object obj)
        {
            return obj is Cell cell &&
                   Row == cell.Row &&
                   Col == cell.Col;
        }

        public override int GetHashCode()
        {
            var hashCode = 1084646500;
            hashCode = hashCode * -1521134295 + Row.GetHashCode();
            hashCode = hashCode * -1521134295 + Col.GetHashCode();
            return hashCode;
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private Dictionary<T, int> searchCollection;
        private List<T> heap;

        public PriorityQueue()
        {
            this.heap = new List<T>();
            this.searchCollection = new Dictionary<T, int>();
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public T ExtractMin()
        {
            var min = this.heap[0];
            var last = this.heap[this.heap.Count - 1];
            this.searchCollection[last] = 0;
            this.heap[0] = last;
            this.heap.RemoveAt(this.heap.Count - 1);
            if (this.heap.Count > 0)
            {
                this.HeapifyDown(0);
            }

            this.searchCollection.Remove(min);

            return min;
        }

        public T PeekMin()
        {
            return this.heap[0];
        }

        public void Enqueue(T element)
        {
            if (!this.searchCollection.ContainsKey(element))
            {
                this.searchCollection.Add(element, this.heap.Count);
                this.heap.Add(element);
            }

            this.HeapifyUp(this.heap.Count - 1);
        }

        private void HeapifyDown(int i)
        {
            var left = (2 * i) + 1;
            var right = (2 * i) + 2;
            var smallest = i;

            if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = left;
            }

            if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = right;
            }

            if (smallest != i)
            {
                T old = this.heap[i];
                this.searchCollection[old] = smallest;
                this.searchCollection[this.heap[smallest]] = i;
                this.heap[i] = this.heap[smallest];
                this.heap[smallest] = old;
                this.HeapifyDown(smallest);
            }
        }

        private void HeapifyUp(int i)
        {
            var parent = (i - 1) / 2;
            while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
            {
                T old = this.heap[i];
                this.searchCollection[old] = parent;
                this.searchCollection[this.heap[parent]] = i;
                this.heap[i] = this.heap[parent];
                this.heap[parent] = old;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        public void DecreaseKey(T element)
        {
            int index = this.searchCollection[element];
            this.HeapifyUp(index);
        }
    }
}
