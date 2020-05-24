using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SimulatorPilot
{
    class Plane
    {
        public event Action Victory;

        public int Speed { get; set; } = 0;
        public int Height { get; set; } = 0;
        public Pilot MyPilot { get; set; } = new Pilot("I");
        public bool IsFlightCompleted { get; set; } = false;
        public bool IsReachMaximumSpeed { get; set; } = false;
        public int TotalFines { get; set; }
        public int MaxSpeed { get; } = 1000;

        private string Path = "plane.txt"; 

        public void Flight()
        {
            Victory += ShowVictory;

            switch (MyPilot.GiveCommand())
            {
                case EAction.InereasaSpeead:
                {
                    if(Speed < MaxSpeed)
                    {
                        Speed += 50;
                    }
                    
                    break;
                }

                case EAction.ReduceSpeead:
                {
                    Speed -= 50;
                    break;
                }

                case EAction.IncreaseHeight:
                {
                    Height += 250;
                    break;
                }

                case EAction.ReduceHeight:
                {
                    Height -= 250;
                    break;
                }
            }

            if (Speed == MaxSpeed)
            {
                IsReachMaximumSpeed = true;
            }

            if (Height == 0 && Speed == 0 && !IsReachMaximumSpeed)
            {
                Console.Clear();
                throw new LandedWithoutGainingMaximumHeightException();
            }

            if (Height == 0 && Speed == 0 && IsReachMaximumSpeed)
            {
                IsFlightCompleted = true;
                Victory.Invoke();
            }

            Console.Clear();
            IsCorrectly();
        }

        public void Show()
        {
            Console.Clear();

            Console.WriteLine($"Текущая скорость: {Speed}\n" +
                $"Текущая высота: {Height}");

            PrintPlane();
        }
        private void PrintPlane()
        {
            string[] content = File.ReadAllLines(Path);

            foreach (var buff in content)
            {
                Console.WriteLine(buff);
            }
        }

        private void ShowVictory()
        {
            Console.Clear();
            Console.WriteLine("Полет успешно завершен!");
            Console.ReadLine();
        }

        private void IsCorrectly()
        {
            if (Speed == 0 && Height > 0)
            {
                throw new PlaneCrashedException();
            }

            if (Speed < 0)
            {
                throw new PlaneCrashedException();
            }

            if (Height < 0)
            {
                throw new PlaneCrashedException();
            }
        }
    }
}
