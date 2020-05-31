using System;
using System.Collections.Generic;
using SimulatorPilot.Models.Plane;

namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        public void Flight()
        {
            while (!Plane.IsFlightCompleted)
            {
                try
                {
                    Move();
                }
                catch (OpenMenuException)
                {
                    MenuDispatchers();
                }
                catch (KeyNotFoundException) { }
                catch (DefaultValueException) { }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }
        private void Move()
        {
            Plane.AverageFines = CalculateArithmeticPenalty();
            Plane.ShowFlightInfo(CalculateRecommendedHeight());
            ShowHandler();
            Plane.ChangeFlightState();
            FlyChange.Invoke(Plane);
        }
    }
}
