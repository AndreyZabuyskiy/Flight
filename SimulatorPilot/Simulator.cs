using System;
using System.Collections.Generic;
using System.Text;

namespace SimulatorPilot
{

    class Simulator
    {
        public delegate void FlyHandler(Plane plane);
        public event FlyHandler FlyCnange;
        public event Action ShowDispatcherHandler;

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
                catch (LandedWithoutGainingMaximumHeightException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }

        private void SignDispatchers()
        {
            foreach (var d in Dispatchers)
            {
                FlyCnange += d.FlyChangeNotify;
                ShowDispatcherHandler += d.Print;
            }
        }

        private void Move()
        {
            MyPlane.Show();
            ShowDispatcherHandler();
            MyPlane.Flight();
            FlyCnange.Invoke(MyPlane);
        }
    }
}
