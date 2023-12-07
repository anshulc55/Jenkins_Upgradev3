using NUnit.Framework;

namespace Pi.Math.Tests
{
    [TestFixture]
    public class MachinFormulaTests
    {
        private const string PI = "3.14159265358979323846";

        [Test]
        public void PiTo6Dp()
        {
            var pi = MachinFormula.Calculate(6).ToString();
            Assert.AreEqual(PI.Substring(0, 8), pi);
        }

        [Test]
        public void PiTo20Dp()
        {
            var pi = MachinFormula.Calculate(20).ToString();
            Assert.AreEqual(PI, pi);
        }
    }
}