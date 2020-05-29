using System;
using System.Collections.Generic;

namespace SimulatorPilot
{
    class Simulator
    {
        public delegate void FlyHandler(Plane plane);
        public event FlyHandler FlyCnange;
        public event Action ShowHandler;

        public Plane MyPlane { get; set; } = new Plane();
        public List<Dispatcher> Dispatchers { get; set; }

        public Simulator()
        {
            Dispatchers = new List<Dispatcher>
            {
                new Dispatcher
                {
                    Name = "First",
                    WeatherCorrection = new Random().Next(-200, 200)
                },
                new Dispatcher
                {
                    Name = "Second",
                    WeatherCorrection = new Random().Next(-200, 200)
                }
            };

            SignDispatchers();
        }
        private void SignDispatchers()
        {
            foreach (var d in Dispatchers)
            {
                FlyCnange += d.Work;
                ShowHandler += d.Print;
            }
        }

        public void Flight()
        {
            while (!MyPlane.IsFlightCompleted)
            {
                try
                {
                    Move();
                }
                catch (PlaneCrashedException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
                catch (FinesOverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
                catch (ImproperLandingException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
                catch (ZeroValueException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArithmeticMeanTooLargeException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }
        private void Move()
        {
            MyPlane.Show(CalculateRecommendedHeight(), CalculateArithmeticPenalty());
            ShowHandler();
            MyPlane.Flight();
            FlyCnange.Invoke(MyPlane);
        }

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
