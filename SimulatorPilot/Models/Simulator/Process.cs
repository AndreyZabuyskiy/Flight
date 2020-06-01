using System;
using System.Collections.Generic;
using SimulatorPilot.Models.Plane;

namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        public void Start()
        {
            StartFlight();

            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Write("[1] Начать полет снова;\n" +
                    "[2] Завершить;\n->");
                keyInfo = Console.ReadKey();

                if(keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                    RepeatFlight.Invoke();

            } while (keyInfo.Key != ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad0);
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
                    Console.Clear();
                    Console.WriteLine(ex.Message);
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
            FlightStateChange.Invoke(Plane);
        }
    }
}
