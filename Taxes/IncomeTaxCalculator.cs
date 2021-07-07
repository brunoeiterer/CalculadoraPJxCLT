namespace PJxCLTCalculator {
    public class IncomeTaxCalculator {
        private const double INSSFirstBracket = 1751.81;
        private const double INSSSecondBracket = 2919.72;
        private const double INSSThirdBracket = 5839.45;

        private const double INSSFirstBracketAliquot = 0.08;
        private const double INSSSencondBracketAliquot = 0.09;
        private const double INSSThirdBracketAliquot = 0.11;
        private const double INSSFourthBracketValue = 642.34;

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
            if(grossIncome <= INSSFirstBracket) {
                return grossIncome * INSSFirstBracketAliquot;
            }
            else if(grossIncome <= INSSSecondBracket) {
                return grossIncome * INSSSencondBracketAliquot;
            }
            else if(grossIncome <= INSSThirdBracket) {
                return grossIncome * INSSThirdBracketAliquot;
            }
            else {
                return INSSFourthBracketValue;
            }
        }

        public double calculateIRRF(double grossIncome) {
            if(grossIncome <= IRRFFirstBracket) {
                return 0;
            }
            else if(grossIncome <= IRRFSecondBracket) {
                return (grossIncome - IRRFSecondBracketDeductible) * IRRFSecondBracketAliquot;
            }
            else if(grossIncome <= IRRFThirdBracket) {
                return (grossIncome - IRRFThirdBracketDeductible) * IRRFThirdBracketAliquot;
            }
            else if(grossIncome <= IRRFFourthBracket) {
                return (grossIncome - IRRFFourthBracketDeductible) * IRRFFourthBracketAliquot;
            }
            else {
                return (grossIncome - IRRFFifthBracketDeductible) * IRRFFifthBracketAliquot;
            }
        }
    }
}