using System;
using System.Collections.Generic;
using System.Text;

namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        public delegate void FlyHandler(Plane plane);
        public event FlyHandler FlyChange;
        public event Action ShowHandler;

        public Plane Plane { get; set; }
        public List<Dispatcher> Dispatchers { get; set; }

        private const int MAX_COUNT_DISPETCHER = 5;
        private const int MIN_COUNT_DISPETCHER = 2;

        public Simulator()
        {
            Initialization();
        }
    }
}
