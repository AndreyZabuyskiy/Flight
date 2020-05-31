using System;
using SimulatorPilot.Models.Plane;

namespace SimulatorPilot
{
    class Dispatcher
    {
        public string Name { get; set; }
        public int WeatherCorrection { get; set; }
        public int Penalty { get; set; }
        public int RecommendedHeight { get; set; }

        public Dispatcher(string name)
        {
            Name = name;
            WeatherCorrection = new Random().Next(-200, 200);
        }
        public Dispatcher(string name, Plane plane)
        {
            Name = name;
            WeatherCorrection = new Random().Next(-200, 200);
            Penalty = plane.AverageFines;
            RecommendedHeight = GetReccomendHeight(plane);
        }
        
        public void Work(Plane plane)
        {
            RecommendedHeight = GetReccomendHeight(plane);
            WriteOutFine(plane);
        }

        private int GetReccomendHeight(Plane plane)
        {
            return 6 * plane.Speed - WeatherCorrection;
        }

        private void WriteOutFine(Plane plane)
        {
            if (plane.Height - RecommendedHeight > 1000 || RecommendedHeight - plane.Height > 1000)
            {
                throw new FinesOverflowException();
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

        public void Print()
        {
            Console.WriteLine($"Диспетчер {Name}, штрафные очки: {Penalty}, " +
                $"рекомендуемая высота {RecommendedHeight}м");
        }
    }
}
