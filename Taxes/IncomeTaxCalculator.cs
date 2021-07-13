namespace PJxCLTCalculator {
    public class IncomeTaxCalculator {
        private const double INSSFirstBracket = 1100;
        private const double INSSSecondBracket = 2203.48;
        private const double INSSThirdBracket = 3305.22;
        private const double INSSFourthBracket = 6433.57;

        private const double INSSFirstBracketAliquot = 0.075;
        private const double INSSSencondBracketAliquot = 0.09;
        private const double INSSThirdBracketAliquot = 0.12;
        private const double INSSFourthBracketAliquot = 0.14;

        private const double INSSOwnerSalaryAliquot = 0.11;

        private const double IRRFFirstBracket = 1903.98;
        private const double IRRFSecondBracket = 2826.65;
        private const double IRRFThirdBracket = 3751.05;
        private const double IRRFFourthBracket = 4664.68;

        private const double IRRFSecondBracketDeductible = 142.80;
        private const double IRRFThirdBracketDeductible = 354.80;
        private const double IRRFFourthBracketDeductible = 636.13;
        private const double IRRFFifthBracketDeductible = 869.36;

        private const double IRRFSecondBracketAliquot = 0.075;
        private const double IRRFThirdBracketAliquot = 0.15;
        private const double IRRFFourthBracketAliquot = 0.225;
        private const double IRRFFifthBracketAliquot = 0.275;

        public double calculateINSS(double grossIncome) {
            double INSS = 0;
            double rest = grossIncome - INSSFirstBracket;
            if(rest > 0) {
                INSS += INSSFirstBracket * INSSFirstBracketAliquot; 
            }
            else {
                INSS += grossIncome * INSSFirstBracketAliquot;
                return INSS;
            }

            rest -= INSSSecondBracket - INSSFirstBracket;
            if(rest > 0) {
                INSS += (INSSSecondBracket - INSSFirstBracket) * INSSSencondBracketAliquot;
            }
            else {
                INSS += (rest + (INSSSecondBracket - INSSFirstBracket)) * INSSSencondBracketAliquot;
                return INSS;
            }

            rest -= INSSThirdBracket - INSSSecondBracket;
            if(rest > 0) {
                INSS += (INSSThirdBracket - INSSSecondBracket) * INSSThirdBracketAliquot;
            }
            else {
                INSS += (rest + (INSSThirdBracket - INSSSecondBracket)) * INSSThirdBracketAliquot;
                return INSS;
            }

            rest -= INSSFourthBracket - INSSThirdBracket;
            if(rest > 0) {
                INSS += (INSSFourthBracket - INSSThirdBracket) * INSSFourthBracketAliquot;
            }
            else {
                INSS += (rest + (INSSFourthBracket - INSSThirdBracket)) * INSSFourthBracketAliquot;
            }

            return INSS;
        }

        public double calculateOwnerSalaryINSS(double grossIncome) {
            return grossIncome * INSSOwnerSalaryAliquot;
        }

        public double calculateIRRF(double grossIncome, double INSS) {
            grossIncome -= INSS;

            if(grossIncome <= IRRFFirstBracket) {
                return 0;
            }
            else if(grossIncome <= IRRFSecondBracket) {
                return (grossIncome * IRRFSecondBracketAliquot) - IRRFSecondBracketDeductible;
            }
            else if(grossIncome <= IRRFThirdBracket) {
                return (grossIncome * IRRFThirdBracketAliquot) - IRRFThirdBracketDeductible;
            }
            else if(grossIncome <= IRRFFourthBracket) {
                return (grossIncome * IRRFFourthBracketAliquot) - IRRFFourthBracketDeductible;
            }
            else {
                return (grossIncome * IRRFFifthBracketAliquot) - IRRFFifthBracketDeductible;
            }
        }
    }
}