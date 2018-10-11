using System.Linq;

namespace BingoGame
{
    public class BingoCheckerService
    {
        public bool IsBingo(bool[][] array)
        {
            return HorizantalCheck(array) || VerticalCheck(array);
        }

        private static bool VerticalCheck(bool[][] array)
        {
            return array
                .SelectMany(row =>
                {
                    return row.Select((cellValue, colNum) => new { colNum, cellValue });
                })
                .GroupBy(x => x.colNum)
                .Any(group => group.All(cell => cell.cellValue == true));
        }

        private static bool HorizantalCheck(bool[][] array)
        {
            return array.Any(row => row.All(cell => cell == true));
        }
    }
}
