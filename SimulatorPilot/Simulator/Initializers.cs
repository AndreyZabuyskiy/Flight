using System;
using System.Collections.Generic;
using SimulatorPilot.Models.Plane;

namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        private void Initialization()
        {
            FillPlane();
            FillDispatchers();
            SubscribeDispatchers();
        }
        private void FillPlane()
        {
            Console.Write("Имя пилота:\n->");
            Plane = new Plane(Console.ReadLine());
        }
        private void FillDispatchers()
        {
            int count = GetCountDispatchers();
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
            foreach (var d in Dispatchers)
            {
                FlyChange += d.Work;
                ShowHandler += d.Print;
            }
        }
        private void UnsubscribeDispatchers()
        {
            foreach (var dispatcher in Dispatchers)
            {
                FlyChange -= dispatcher.Work;
                ShowHandler -= dispatcher.Print;
            }
        }
    }
}
