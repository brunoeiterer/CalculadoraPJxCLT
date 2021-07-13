using System.Collections.Immutable;

namespace PJxCLTCalculator {
    public class DASCalculator {
        private const double firstBracket = 180000;
        private const double secondBracket = 360000;
        private const double thirdBracket = 720000;
        private const double fourthBracket = 1800000;
        private const double fifthBracket = 3600000;

        private ImmutableDictionary<int, ImmutableDictionary<int, double>> bracketAliquotMap;

        public DASCalculator() {
            var annexToBracketToAliquotMapBuilder = ImmutableDictionary.CreateBuilder<int, ImmutableDictionary<int, double>>();

            var annex1BracketToAliquotMapBuilder = ImmutableDictionary.CreateBuilder<int, double>();
            annex1BracketToAliquotMapBuilder.Add(1, 0.04);
            annex1BracketToAliquotMapBuilder.Add(2, 0.073);
            annex1BracketToAliquotMapBuilder.Add(3, 0.095);
            annex1BracketToAliquotMapBuilder.Add(4, 0.107);
            annex1BracketToAliquotMapBuilder.Add(5, 0.143);
            annex1BracketToAliquotMapBuilder.Add(6, 0.19);
            annexToBracketToAliquotMapBuilder.Add(1, annex1BracketToAliquotMapBuilder.ToImmutableDictionary());

            var annex2BracketToAliquotMapBuilder = ImmutableDictionary.CreateBuilder<int, double>();
            annex2BracketToAliquotMapBuilder.Add(1, 0.045);
            annex2BracketToAliquotMapBuilder.Add(2, 0.078);
            annex2BracketToAliquotMapBuilder.Add(3, 0.1);
            annex2BracketToAliquotMapBuilder.Add(4, 0.112);
            annex2BracketToAliquotMapBuilder.Add(5, 0.147);
            annex2BracketToAliquotMapBuilder.Add(6, 0.3);
            annexToBracketToAliquotMapBuilder.Add(2, annex2BracketToAliquotMapBuilder.ToImmutableDictionary());

            var annex3BracketToAliquotMapBuilder = ImmutableDictionary.CreateBuilder<int, double>();
            annex3BracketToAliquotMapBuilder.Add(1, 0.06);
            annex3BracketToAliquotMapBuilder.Add(2, 0.112);
            annex3BracketToAliquotMapBuilder.Add(3, 0.135);
            annex3BracketToAliquotMapBuilder.Add(4, 0.16);
            annex3BracketToAliquotMapBuilder.Add(5, 0.21);
            annex3BracketToAliquotMapBuilder.Add(6, 0.33);
            annexToBracketToAliquotMapBuilder.Add(3, annex3BracketToAliquotMapBuilder.ToImmutableDictionary());

            var annex4BracketToAliquotMapBuilder = ImmutableDictionary.CreateBuilder<int, double>();
            annex4BracketToAliquotMapBuilder.Add(1, 0.045);
            annex4BracketToAliquotMapBuilder.Add(2, 0.09);
            annex4BracketToAliquotMapBuilder.Add(3, 0.102);
            annex4BracketToAliquotMapBuilder.Add(4, 0.14);
            annex4BracketToAliquotMapBuilder.Add(5, 0.22);
            annex4BracketToAliquotMapBuilder.Add(6, 0.33);
            annexToBracketToAliquotMapBuilder.Add(4, annex4BracketToAliquotMapBuilder.ToImmutableDictionary());

            var annex5BracketToAliquotMapBuilder = ImmutableDictionary.CreateBuilder<int, double>();
            annex5BracketToAliquotMapBuilder.Add(1, 0.155);
            annex5BracketToAliquotMapBuilder.Add(2, 0.18);
            annex5BracketToAliquotMapBuilder.Add(3, 0.195);
            annex5BracketToAliquotMapBuilder.Add(4, 0.205);
            annex5BracketToAliquotMapBuilder.Add(5, 0.23);
            annex5BracketToAliquotMapBuilder.Add(6, 0.305);
            annexToBracketToAliquotMapBuilder.Add(5, annex5BracketToAliquotMapBuilder.ToImmutableDictionary());

            bracketAliquotMap = annexToBracketToAliquotMapBuilder.ToImmutableDictionary();
        }

        public double calculateDAS(double grossIncome, double rFactor, int annex) {
            if(annex == 5 && rFactor >= 28) {
                annex = 3;
            }

            if(grossIncome <= firstBracket) {
                return grossIncome * bracketAliquotMap[annex][1];
            }
            else if(grossIncome <= secondBracket) {
                return grossIncome * bracketAliquotMap[annex][2];
            }
            else if(grossIncome <= thirdBracket) {
                return grossIncome * bracketAliquotMap[annex][3];
            }
            else if(grossIncome <= fourthBracket) {
                return grossIncome * bracketAliquotMap[annex][4];
            }
            else if(grossIncome <= fifthBracket) {
                return grossIncome * bracketAliquotMap[annex][5];
            }
            else {
                return grossIncome * bracketAliquotMap[annex][6];
            }
        }
    }
}