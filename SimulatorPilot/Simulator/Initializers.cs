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
            Console.Write("Имя пилота:\n->");
            Plane = new Plane(Console.ReadLine());
        }
        private void InitializeDispatchers()
        {
            int count = EnterCountDispatcher();
            Dispatchers = new List<Dispatcher>();

            for (int i = 0; i < count; ++i)
            {
                Console.Clear();
                Console.Write($"Имя диспетчера #{i + 1}\n->");
                Dispatchers.Add(new Dispatcher(Console.ReadLine()));
            }
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
