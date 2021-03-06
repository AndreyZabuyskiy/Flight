﻿using System;
using System.Collections.Generic;
using SimulatorPilot.Models.Plane;

namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        public void Run()
        {
            StartFlight();
            CompletionFlighMenu();
        }

        public void StartFlight()
        {
            while (!Plane.IsFlightCompleted)
            {
                try
                {
                    FlightProcess();
                }
                catch (OpenMenuException)
                {
                    OpenDispatchersMenu();
                }
                catch (KeyNotFoundException) { }
                catch (DefaultValueException) { }
                catch (Exception ex)
                {
                    Plane.ShowInfoException(ex);
                    break;
                }
            }
        }

        private void FlightProcess()
        {
            Plane.AverageFines = CalculateArithmeticPenalty();
            Plane.ShowFlightInfo(CalculateRecommendedHeight());
            DispatchersShowState();
            Plane.ChangeFlightState();
            FlightStateChange(Plane);
        }
    }
}
