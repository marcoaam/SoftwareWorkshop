namespace ProductionCode.Day2
{
    public class Probability
    {
        internal double Chance;
        private const int _maximumChance = 100;

        public Probability(double chanceValue)
        {
            Chance = ConvertToPercentage(chanceValue);
        }

        private double ConvertToPercentage(double chanceValue)
        {
            if (chanceValue < 1)
                return (chanceValue * 100);
            return chanceValue;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof (Probability)) return false;

            var probability = obj as Probability;
            return Chance.Equals(probability.Chance);
        }

        public Probability Inverse()
        {
            var inverseChance = _maximumChance - Chance;
            return new Probability(inverseChance);
        }

        public Probability And(Probability probability)
        {
            var combinedChance = (Chance * probability.Chance) / _maximumChance;
            return new Probability(combinedChance);
        }

        public Probability Or(Probability probability)
        {
            var inversedProbability = probability.Inverse();
            return Inverse().And(inversedProbability).Inverse();
        }
    }
}