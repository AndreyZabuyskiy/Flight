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
        public Pilot Pilot { get; set; } = new Pilot("I");
        public bool IsFlightCompleted { get; set; } = false;
        public bool IsReachMaximumSpeed { get; set; } = false;
        public int TotalFines { get; set; } = 0;
        public int MaxSpeed { get; } = 1000;

        Dictionary<EAction, Action> Actions { get; set; }

        private readonly string PathImageFile = "plane.txt"; 

        public Plane()
        {
            Victory += ShowVictory;

            Actions = new Dictionary<EAction, Action>
            {
                { EAction.InereasaSpeead, ActionInereasaSpeead },
                { EAction.ReduceSpeead, ActionReduceSpeead },
                { EAction.IncreaseHeight, ActionIncreaseHeight },
                { EAction.ReduceHeight, ActionReduceHeight }
            };
        }

        public void Flight()
        {
            try
            {
                Actions[Pilot.GiveCommand()]();
            }
            catch(ZeroValueException ex)
            {
                throw ex;
            }

            Console.Clear();

            CheckCorrectly();
            CheckMaximumHeight();
            CheckForTouchdown();
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
            string[] content = File.ReadAllLines(PathImageFile);

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

        private void CheckCorrectly()
        {
            if (Speed == 0 && Height > 0
                || Speed < 0 
                || Height < 0)
            {
                throw new PlaneCrashedException();
            }
        }
        private void CheckMaximumHeight()
        {
            if (Speed == MaxSpeed)
            {
                IsReachMaximumSpeed = true;
            }
        }
        private void CheckForTouchdown()
        {
            if (Height == 0 && Speed == 0 && !IsReachMaximumSpeed)
            {
                Console.Clear();
                throw new ImproperLandingException();
            }

            if (Height == 0 && Speed == 0 && IsReachMaximumSpeed)
            {
                IsFlightCompleted = true;
                Victory.Invoke();
            }
        }

        private void ActionInereasaSpeead()
        {
            if (Speed < MaxSpeed)
            {
                Speed += 50;
            }
        }
        private void ActionReduceSpeead()
        {
            if(Speed == 0)
            {
                throw new ZeroValueException();
            }

            if(Speed > 0)
            {
                Speed -= 50;
            }
        }
        private void ActionIncreaseHeight()
        {
            Height += 250;
        }
        private void ActionReduceHeight()
        {
            if(Height == 0)
            {
                throw new ZeroValueException();
            }

            if(Height > 0)
            {
                Height -= 250;
            }
        }
    }
}
