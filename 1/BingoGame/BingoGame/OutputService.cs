using System;

namespace BingoGame
{
    public class OutputService
    {
        public void ShowResult(bool isBingo)
        {
            if (isBingo)
            {
                Console.WriteLine("Bingo");
            }
            else
            {
                Console.WriteLine("Not Bingo");
            }
        }
    }
}
