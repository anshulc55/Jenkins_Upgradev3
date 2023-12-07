using NUnit.Framework;
using PowerArgs;

namespace Pi.Runtime.Tests
{
    [TestFixture]
    public class ArgumentsTests
    {
        [Test]
        public void Defaults()
        {
            var arguments = Args.Parse<Arguments>(new string[0]);
            Assert.AreEqual(20, arguments.DecimalPlaces);
            Assert.AreEqual(RunMode.Console, arguments.Mode);
            Assert.AreEqual("/pi.txt", arguments.OutputPath);
        }

        [Test]
        public void DecimalPlaces()
        {
            var arguments = Args.Parse<Arguments>(new string[] { "-dp", "10" });
            Assert.AreEqual(10, arguments.DecimalPlaces);
        }

        [Test]
        public void Unknown()
        {
            var arguments = Args.Parse<Arguments>(new string[] { "-unk", "own"});
            Assert.IsNotNull(arguments);
        }
    }
}