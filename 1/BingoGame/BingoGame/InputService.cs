using System;
using System.Collections.Generic;
using System.Linq;

namespace BingoGame
{
    public class InputService
    {
        public bool[][] InputBingo()
        {
            Console.Write("Input: ");

            var inputLine = Console.ReadLine();

            IEnumerable<int> filledCells = SplitLineToNumber(inputLine);

            bool[][] bingoMatrix = FilledCellsToMatrix(filledCells);

            return bingoMatrix;
        }

        private static bool[][] FilledCellsToMatrix(IEnumerable<int> filledCells)
        {
            var filledCellHash = new HashSet<int>(filledCells);

            bool[][] bingoMatrix = Enumerable.Range(1, 5)
                .Select(rowNumber =>
                {
                    return Enumerable.Range(1, 5)
                            .Select(colNum => filledCellHash.Contains(MatrixPosToNumber(rowNumber, colNum)))
                            .ToArray();
                })
                .ToArray();

            return bingoMatrix;
        }

        private static IEnumerable<int> SplitLineToNumber(string inputLine)
        {
            return inputLine
                .Replace("[", "")
                .Replace("]", "")
                .Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(numText => int.Parse(numText));
        }

        private static int MatrixPosToNumber(int row, int col)
        {
            return (row - 1) * 5 + col;
        }
    }
}
