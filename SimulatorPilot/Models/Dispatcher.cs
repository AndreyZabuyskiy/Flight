using System;

namespace SimulatorPilot
{
    class Dispatcher
    {
        public string Name { get; set; }
        public int WeatherCorrection { get; set; }
        public int Penalty { get; set; } = 0;
        private int RecommendedHeight { get; set; }

        public void FlyChangeNotify(Plane plane)
        {
            RecommendedHeight = GetReccomendHeight(plane);
            WriteOutFine(plane);
        }
        private void WriteOutFine(Plane plane)
        {
            if (plane.Height - RecommendedHeight > 1000 || RecommendedHeight - plane.Height > 1000)
            {
                Penalty += 1000;
            }
            else if (plane.Height - RecommendedHeight > 600 || RecommendedHeight - plane.Height > 600)
            {
                Penalty += 50;
            }
            else if (plane.Height - RecommendedHeight > 300 || RecommendedHeight - plane.Height > 300)
            {
                Penalty += 25;
            }

            if(Penalty >= 1000)
            {
                throw new FinesOverflowException();
            }
        }
        private int GetReccomendHeight(Plane plane)
        {
            return 6 * plane.Speed - WeatherCorrection;
        }

        public void Print()
        {
            Console.WriteLine($" {Name}: штраф. баллов: {Penalty}\n" +
                $"[Рекомендуемая высота: {RecommendedHeight}]");
        }
    }
}
