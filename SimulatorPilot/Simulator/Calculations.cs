using System;
using System.Collections.Generic;
using System.Text;

namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        public int CalculateRecommendedHeight()
        {
            int TotalHeight = 0;

            foreach (var dis in Dispatchers)
            {
                TotalHeight += dis.RecommendedHeight;
            }

            return TotalHeight / Dispatchers.Count;
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
