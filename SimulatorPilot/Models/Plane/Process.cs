using System;
using System.Collections.Generic;

namespace SimulatorPilot.Models.Plane
{
    partial class Plane
    {
        public void ChangeFlightState()
        {
            try
            {
                Actions[Pilot.GiveCommand()]();
            }
            catch (DefaultValueException ex)
            {
                throw ex;
            }
            catch (KeyNotFoundException ex)
            {
                throw ex;
            }


            Console.Clear();

            CrashCheck();
            ReachedMaxHeightCheck();
            EndFlightCheck();
        }
    }
}
