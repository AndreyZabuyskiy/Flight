using System;
using System.IO;

namespace SimulatorPilot.Models.Plane
{
    partial class Plane
    {
        public void ShowFlightInfo(int recommendedHeight)
        {
            Console.Clear();

            Console.WriteLine($"\t\t\tИмя пилота: {Pilot.Name}\n\n" +
                $"Текущая скорость: {Speed}" +
                $"\t\tСреднее арифметическое штрафов: {AverageFines}\n" +
                $"Текущая высота: {Height}" +
                $"\t\tРекомендуемая высота: {recommendedHeight}");

            if (IsReachedMaxSpeed)
                Console.WriteLine("\nМаксимальная скорость достигнута, посадите самолёт!\n");

            PrintPlane();

            Console.WriteLine("[1] Открыть меню с диспетчерами\n" +
                "[0] Завершить полет\n");
        }

        private void PrintPlane()
        {
            string[] content = File.ReadAllLines(PATH_TO_PLANE_IMAGE);

            Console.WriteLine();
            foreach (var buff in content)
            {
                Console.WriteLine(buff);
            }
            Console.WriteLine();
        }

        private void ShowVictory()
        {
            Console.Clear();
            Console.WriteLine("Полет успешно завершен!");
            Console.ReadLine();
        }
    }
}
