using System;
using System.Collections.Generic;
using SimulatorPilot.Models.Plane;

namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        public event Action<Plane> FlightStateChange;
        public event Action DispatchersShowState;
        public event Action RepeatFlight;

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
