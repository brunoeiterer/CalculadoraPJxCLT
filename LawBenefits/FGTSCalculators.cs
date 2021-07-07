namespace PJxCLTCalculator {
    public class FGTSCalculator {
        private const double FGTSAliquot = 0.08;

        public double calculateFGTS(double grossIncome) {
            return grossIncome * FGTSAliquot;
        }
    }
}