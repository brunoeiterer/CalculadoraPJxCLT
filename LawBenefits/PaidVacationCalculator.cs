namespace PJxCLTCalculator {
    public class PaidVacationCalculator {
        private const double paidVacationAliquot = 3;

        public double calculatePaidVacation(double grossIncome) {
            return grossIncome + (grossIncome / paidVacationAliquot);
        }
    }
}