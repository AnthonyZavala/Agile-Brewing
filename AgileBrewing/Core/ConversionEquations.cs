using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class ConversionEquations
    {
        public static decimal BrixToSg(decimal brix)
        {
            decimal sg = (brix / (258.6m - ((brix / 258.2m) * 227.1m))) + 1;
            decimal roundedSG = decimal.Round(sg, 3);

            return roundedSG;
        }

        public static decimal SgToBrix(decimal sg)
        {
            decimal brix = (((182.4601m * sg - 775.6821m) * sg + 1262.7794m) * sg - 669.5622m);
            decimal roundedBrix = decimal.Round(brix, 1);

            return roundedBrix;
        }

        public static decimal SpecificGravityAbv(decimal og, decimal fg)
        {
            if (og > 1.060m)
            {
                return HighGravityABV(og, fg);
            }
            else
            {
                return StandardGravityAbv(og, fg);
            }
        }

        public static decimal BrixAbv(decimal originalBrix, decimal finalBrix)
        {
            decimal og = BrixToSg(originalBrix);
            decimal fg = 1.001843m - 0.002318474m * originalBrix
                - 0.000007775m * (originalBrix * originalBrix)
                - 0.000000034m * (originalBrix * originalBrix * originalBrix)
                + 0.00574m * finalBrix
                + 0.00003344m * (finalBrix * finalBrix)
                + 0.000000086m * (finalBrix * finalBrix * finalBrix);

            return SpecificGravityAbv(og, fg);
        }

        private static decimal StandardGravityAbv(decimal og, decimal fg)
        {
            decimal abv = (og - fg) * 131.25m;
            decimal roundedABV = decimal.Round(abv, 1);

            return roundedABV;
        }

        private static decimal HighGravityABV(decimal og, decimal fg)
        {
            decimal abv = (76.08m * (og - fg) / (1.775m - og)) * (fg / 0.794m);
            decimal roundedABV = decimal.Round(abv, 1);

            return roundedABV;
        }
    }
}
