namespace PJxCLTCalculator {
    public class ThirteenthSalaryCalculator {
        public double calculateThirteenthSalary(double grossIncome) {
            double thirteenthSalaryFirstPart = grossIncome / 2;

            IncomeTaxCalculator incomeTaxCalculator = new IncomeTaxCalculator();
            double INSS = incomeTaxCalculator.calculateINSS(grossIncome);
            double IRRF = incomeTaxCalculator.calculateIRRF(grossIncome, INSS);

            double thirteenthSalarySecondPart = (grossIncome / 2) - INSS - IRRF;

            return thirteenthSalaryFirstPart + thirteenthSalarySecondPart;
        }
    }
}