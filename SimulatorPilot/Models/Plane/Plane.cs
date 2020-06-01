using System;
using System.Collections.Generic;

namespace SimulatorPilot.Models.Plane
{
    partial class Plane
    {
        public int Speed { get; set; }
        public int Height { get; set; }
        public Pilot Pilot { get; set; }
        public bool IsFlightCompleted { get; set; }
        public bool IsReachedMaxSpeed { get; set; }
        public int AverageFines { get; set; }

        Dictionary<EAction, Action> Actions { get; set; }

        private const string PATH_TO_PLANE_IMAGE = "plane.txt";
        private const int MAX_SPEED = 100;

        public Plane(string pilotName)
        {
            Initialize(pilotName);
        }

        public void ResetSettings()
        {
            Speed = 0;
            Height = 0;
            IsFlightCompleted = false;
            IsReachedMaxSpeed = false;
            AverageFines = 0;
        }
    }
}
