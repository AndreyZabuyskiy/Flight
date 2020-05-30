using System;
using System.Collections.Generic;
using System.Text;

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
                catch (ZeroValueException) { }
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
            Plane.Show(CalculateRecommendedHeight());
            ShowHandler();
            Plane.Flight();
            FlyCnange.Invoke(Plane);
        }
    }
}
