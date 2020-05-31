using System;

namespace SimulatorPilot.Models.Plane
{
    partial class Plane
    {
        private void CrashCheck()
        {
            if (Speed == 0 && Height > 0
                || Speed < 0
                || Height < 0)
            {
                throw new PlaneCrashedException();
            }
        }

        private void ReachedMaxHeightCheck()
        {
            if (Speed == MAX_SPEED)
            {
                IsReachedMaxSpeed = true;
            }
        }

        private void EndFlightCheck()
        {
            if (Height == 0 && Speed == 0 && !IsReachedMaxSpeed)
            {
                Console.Clear();
                throw new WrongLandingException();
            }

            if (Height == 0 && Speed == 0 && IsReachedMaxSpeed)
            {
                IsFlightCompleted = true;
                Victory.Invoke();
            }
        }
    }
}
