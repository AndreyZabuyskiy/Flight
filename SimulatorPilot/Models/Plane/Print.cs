using System;
using System.Collections.Generic;
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

        private void ShowVictory()
        {
            Console.Clear();
            Console.WriteLine("Симулируемый полёт успешно сдан!");
            PrintPlane();
        }

        public void ShowInfoException(Exception ex)
        {
            Console.Clear();

            Console.WriteLine($"Текущая скорость {Speed}км/час, высота: {Height}м\n" +
                $"Среднее значение штрафов: {AverageFines}\n\n" +
                $"{ex.Message}\n");

            PrintPlane();
            Console.WriteLine();

            Console.WriteLine("Полёт провален, пилот был признан не годным\n");
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
    }
}
