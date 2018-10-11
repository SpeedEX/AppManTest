namespace BingoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputService = new InputService();
            var checkerService = new BingoCheckerService();
            var outputService = new OutputService();

            bool[][] bingoMatrix = inputService.InputBingo();
            bool isBingo = checkerService.IsBingo(bingoMatrix);
            outputService.ShowResult(isBingo);
        }
    }
}
