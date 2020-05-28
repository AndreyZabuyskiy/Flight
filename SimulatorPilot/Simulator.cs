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
            Dispatchers = new List<Dispatcher>();
            Dispatchers.Add(new Dispatcher
            {
                Name = "First",
                WeatherCorrection = new Random().Next(-200, 200)
            });
            Dispatchers.Add(new Dispatcher
            {
                Name = "Second",
                WeatherCorrection = new Random().Next(-200, 200)
            });

            SignDispatchers();
        }
        private void SignDispatchers()
        {
            ShowHandler += MyPlane.Show;

            foreach (var d in Dispatchers)
            {
                FlyCnange += d.FlyChangeNotify;
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
            ShowHandler();
            MyPlane.Flight();
            FlyCnange.Invoke(MyPlane);
            MyPlane.CalculateArithmeticMean();
        }
    }
}
