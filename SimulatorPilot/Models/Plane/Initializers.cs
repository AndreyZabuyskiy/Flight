using System;
using System.Collections.Generic;

namespace SimulatorPilot.Models.Plane
{
    partial class Plane
    {
        private void Initialize(string pilotName)
        {
            Pilot = new Pilot(pilotName);
            InitializeActions();
        }

        private void InitializeActions()
        {
            Actions = new Dictionary<EAction, Action>
            {
                { EAction. IncreaseSpeed, ActionIncreaseSpeed },
                { EAction.ReduceSpeed, ActionReduceSpeed },
                { EAction.IncreaseHeight, ActionIncreaseHeight },
                { EAction.ReduceHeight, ActionReduceHeight },
                { EAction.SignificantlyIncreaseSpeed, ActionSignificantlyIncreaseSpeed },
                { EAction.SignificantlyReduceSpeed, ActionSignificantlyReduceSpeed },
                { EAction.SignificantlyIncreaseHeight, ActionSignificantlyIncreaseHeight },
                { EAction.SignificantlyReduceHeight, ActionSignificantlyReduceHeight },
                { EAction.OpenMenu, () => throw new OpenMenuException() },
                { EAction.FlightCancellation, () => throw new FlightCancellationException() }
            };
        }
    }
}
