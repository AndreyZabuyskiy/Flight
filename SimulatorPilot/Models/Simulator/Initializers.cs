using System;
using System.Collections.Generic;
using SimulatorPilot.Models.Plane;

namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        private void Initialization()
        {
            InitializePlane();
            InitializeDispatchers();
            SubscribeDispatchers();
        }

        private void InitializePlane()
        {
            string namePilot;
            do
            {
                Console.Clear();
                Console.Write("Имя пилота:\n->");
                namePilot = Console.ReadLine();
            } while (namePilot.Trim().Equals(""));

            Plane = new Plane(namePilot);
        }

        private void InitializeDispatchers()
        {
            int count = EnterCountDispatcher();
            Dispatchers = new List<Dispatcher>();

            for (int i = 0; i < count; ++i)
            {
                Dispatchers.Add(new Dispatcher(GetDispatcherName(i + 1)));
            }

            ShowUserGreeting();
        }

        private void SubscribeDispatchers()
        {
            foreach (var dispatcher in Dispatchers)
            {
                FlightStateChange += dispatcher.Work;
                DispatchersShowState += dispatcher.Print;
            }
        }

        private void UnsubscribeDispatchers()
        {
            foreach (var dispatcher in Dispatchers)
            {
                FlightStateChange -= dispatcher.Work;
                DispatchersShowState -= dispatcher.Print;
            }
        }
    }
}
