using System;
using NUnit.Framework;
using ProductionCode.Day2;

namespace ProductionCode.Tests.Day2Tests
{
    [TestFixture]
    public class ProbabilityTests
    {
        [Test]
        public void ShouldCompareTwoProbabilitiesObjects()
        {
            var chancesPercentage = 50;
            var probabilityOne = new Probability(chancesPercentage);
            var probabilityTwo = new Probability(chancesPercentage);

            Assert.IsTrue((probabilityOne).Equals(probabilityTwo));
        }

        [Test]
        public void ShouldInverseAProbabilityChances()
        {
            var probabilityOne = new Probability(25);
            var probabilityTwo = new Probability(75);

            Assert.IsTrue((probabilityOne.Inverse()).Equals(probabilityTwo));
        }

        [Test]
        public void ShouldAcceptChancesInFractionForm()
        {
            var firstChances = (double) Decimal.Divide(1, 4);
            var secondChances = (double) Decimal.Divide(3, 4);

            var probabilityOne = new Probability(firstChances);
            var probabilityTwo = new Probability(secondChances);

            Assert.IsTrue((probabilityOne.Inverse()).Equals(probabilityTwo));
        }

        [Test]
        public void ShouldCalculateChancesOfOneAndAnotherfProbabilitiesFromHappening()
        {
            var firstChances = 40;
            var secondChances = 25;
            var expectedChances = 10;

            var probabilityOne = new Probability(firstChances);
            var probabilityTwo = new Probability(secondChances);
            var expectedProbability = new Probability(expectedChances);

            Assert.IsTrue((probabilityOne.And(probabilityTwo)).Equals(expectedProbability));
        }

        [Test]
        public void ShouldCalculateChancesOfOneOrAnotherProbabilitiesFromHappening()
        {
            var firstChances = 40;
            var secondChances = 25;
            var expectedChances = 55;

            var probabilityOne = new Probability(firstChances);
            var probabilityTwo = new Probability(secondChances);
            var expectedProbability = new Probability(expectedChances);

            Assert.IsTrue((probabilityOne.Or(probabilityTwo)).Equals(expectedProbability));
        }
    }
}
