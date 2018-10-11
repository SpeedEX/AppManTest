namespace FormulaCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputService = new InputService();
            var calculator = new CalculationService();
            var outputService = new OutputService();


            string inputLine = inputService.GetInput();
            double answer = calculator.Calculate(inputLine);
            outputService.ShowResult(answer);
        }
    }
}
