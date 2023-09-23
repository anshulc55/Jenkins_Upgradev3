using System.Numerics;
using System.Text;

namespace Pi.Math
{
    public class HighPrecision
    {
        private static BigInteger denom;
        private static int precision;
        private static int slop = 4;
        private BigInteger num;

        public HighPrecision(BigInteger numerator, BigInteger denominator)
        {
            // public constructor rescales numerator as needed
            num = (HighPrecision.denom * numerator) / denominator;
        }

        private HighPrecision(BigInteger numerator)
        {
            // private constructor for when we already know the scaling
            num = numerator;
        }

        public static int Precision
        {
            get { return precision; }
            set
            {
                HighPrecision.precision = value;
                denom = BigInteger.Pow(10, HighPrecision.precision + slop);  // leave some buffer
            }
        }

        public bool IsZero
        {
            get { return num.IsZero; }
        }

        public BigInteger Numerator
        {
            get { return num; }
        }

        public BigInteger Denominator
        {
            get { return HighPrecision.denom; }
        }

        public static HighPrecision operator *(int left, HighPrecision right)
        {
            // no need to resale when multiplying by an int
            return new HighPrecision(right.num * left);
        }

        public static HighPrecision operator *(HighPrecision left, HighPrecision right)
        {
            // a/D * b/D = ab/D^2 = (ab/D)/D
            return new HighPrecision((left.num * right.num) / HighPrecision.denom);
        }

        public static HighPrecision operator /(HighPrecision left, int right)
        {
            // no need to rescale when dividing by an int
            return new HighPrecision(left.num / right);
        }

        public static HighPrecision operator +(HighPrecision left, HighPrecision right)
        {
            // when we know the denominators are the same, can just add the numerators
            return new HighPrecision(left.num + right.num);
        }

        public static HighPrecision operator -(HighPrecision left, HighPrecision right)
        {
            // when we know the denominators are the same, can just subtract the numerators
            return new HighPrecision(left.num - right.num);
        }

        public override string ToString()
        {
            // Convert num to a string and insert the decimal point
            string numString = num.ToString();
            int integerDigits = numString.Length - HighPrecision.Precision;
        
            if (integerDigits <= 0)
            {
                // Add leading zeros if necessary
                numString = "0" + numString.PadLeft(-integerDigits + HighPrecision.Precision + 1, '0');
            }
            else
            {
                // Insert the decimal point
                numString = numString.Insert(integerDigits, ".");
            }
        
            return numString;
        }
    }
}
