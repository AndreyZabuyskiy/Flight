using System;
using System.Collections.Generic;

namespace SimulatorPilot.Models.Plane
{
    partial class Plane
    {
        public event Action Victory;

        public int Speed { get; set; } = 0;
        public int Height { get; set; } = 0;
        public Pilot Pilot { get; set; }
        public bool IsFlightCompleted { get; set; } = false;
        public bool IsReachedMaxSpeed { get; set; } = false;
        public int AverageFines { get; set; }

        Dictionary<EAction, Action> Actions { get; set; }

        private const string PATH_TO_PLANE_IMAGE = "plane.txt";
        private const int MAX_SPEED = 1000;

        public Plane(string pilotName)
        {
            Initialize(pilotName);
        }
    }
}
