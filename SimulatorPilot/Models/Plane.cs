using System;
using System.Collections.Generic;
using System.IO;

namespace SimulatorPilot
{
    class Plane
    {
        public event Action Victory;

        public int Speed { get; set; } = 0;
        public int Height { get; set; } = 0;
        public Pilot Pilot { get; set; }
        public bool IsFlightCompleted { get; set; } = false;
        public bool IsReachMaximumSpeed { get; set; } = false;
        public int AverageFines { get; set; }

        Dictionary<EAction, Action> Actions { get; set; }

        private readonly string PathImageFile = "plane.txt";
        private const int MAX_SPEED = 1000;

        public Plane()
        {
            Victory += ShowVictory;
            Actions = new Dictionary<EAction, Action>
            {
                { EAction.InereasaSpeead, ActionInereasaSpeead },
                { EAction.ReduceSpeead, ActionReduceSpeead },
                { EAction.IncreaseHeight, ActionIncreaseHeight },
                { EAction.ReduceHeight, ActionReduceHeight },
                { EAction.SignificantlyInereasaSpeead, ActionSignificantlyInereasaSpeead },
                { EAction.SignificantlyReduceSpeead, ActionSignificantlyReduceSpeead },
                { EAction.SignificantlyIncreaseHeight, ActionSignificantlyIncreaseHeight },
                { EAction.SignificantlyReduceHeight, ActionSignificantlyReduceHeight },
                { EAction.OpenMenu, () => throw new OpenMenuException() }
            };
        }

        public Plane(string name)
        {
            Pilot = new Pilot(name);
            Victory += ShowVictory;
            Actions = new Dictionary<EAction, Action>
            {
                { EAction.InereasaSpeead, ActionInereasaSpeead },
                { EAction.ReduceSpeead, ActionReduceSpeead },
                { EAction.IncreaseHeight, ActionIncreaseHeight },
                { EAction.ReduceHeight, ActionReduceHeight },
                { EAction.SignificantlyInereasaSpeead, ActionSignificantlyInereasaSpeead },
                { EAction.SignificantlyReduceSpeead, ActionSignificantlyReduceSpeead },
                { EAction.SignificantlyIncreaseHeight, ActionSignificantlyIncreaseHeight },
                { EAction.SignificantlyReduceHeight, ActionSignificantlyReduceHeight },
                { EAction.OpenMenu, () => throw new OpenMenuException() }
            };
        }

        public void Flight()
        {
            try
            {
                Actions[Pilot.GiveCommand()]();
            }
            catch (ZeroValueException ex)
            {
                throw ex;
            }
            catch(KeyNotFoundException ex)
            {
                throw ex;
            }


            Console.Clear();

            CheckCorrectly();
            CheckMaximumHeight();
            CheckForTouchdown();
        }

        public void Show(int recommendedHeight)
        {
            Console.Clear();

            Console.WriteLine($"\t\t\tИмя пилота: {Pilot.Name}\n" +
                $"Текущая скорость: {Speed}" +
                $"\t\tСреднее арифметическое штрафов: {AverageFines}\n" +
                $"Текущая высота: {Height}" +
                $"\t\tРекомендуемая высота: {recommendedHeight}");

            PrintPlane();

            Console.WriteLine("[1] Открыть меню с диспетчерами\n");
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
            if (Speed == MAX_SPEED)
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
            if (Speed < MAX_SPEED)
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
        private void ActionSignificantlyInereasaSpeead()
        {
            if (Speed < MAX_SPEED)
            {
                Speed += 150;
            }
        }
        private void ActionSignificantlyReduceSpeead()
        {
            if (Speed == 0)
            {
                throw new ZeroValueException();
            }

            if (Speed > 0)
            {
                Speed -= 150;
            }
        }
        private void ActionSignificantlyIncreaseHeight()
        {
            Height += 500;
        }
        private void ActionSignificantlyReduceHeight()
        {
            if (Height == 0)
            {
                throw new ZeroValueException();
            }

            if (Height > 0)
            {
                Height -= 500;
            }
        }
    }
}
