﻿using System;
using System.Collections.Generic;

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
                catch (ImproperLandingException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
                catch (ZeroValueException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void SignDispatchers()
        {
            ShowDispatcherHandler += MyPlane.Show;

            foreach (var d in Dispatchers)
            {
                FlyCnange += d.FlyChangeNotify;
                ShowDispatcherHandler += d.Print;
            }
        }

        private void Move()
        {
            ShowDispatcherHandler();
            MyPlane.Flight();
            FlyCnange.Invoke(MyPlane);
        }
    }
}
