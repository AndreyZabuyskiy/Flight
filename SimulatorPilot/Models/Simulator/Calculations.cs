namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        public int CalculateRecommendedHeight()
        {
            int totalHeight = 0;

            foreach (var dis in Dispatchers)
            {
                totalHeight += dis.RecommendedHeight;
            }

            return totalHeight / Dispatchers.Count;
        }

        public int CalculateArithmeticPenalty()
        {
            int totalPenalty = 0;

            foreach (var dis in Dispatchers)
            {
                totalPenalty += dis.Penalty;
            }

            return totalPenalty / Dispatchers.Count;
        }
    }
}
