using System;
using System.Collections.Generic;

namespace SimulatorPilot.Models.Plane
{
    partial class Plane
    {
        private void Initialize(string pilotName)
        {
            Pilot = new Pilot(pilotName);
            Victory += ShowVictory;
            InitializeActions();
        }

        private void InitializeActions()
        {
            Actions = new Dictionary<EAction, Action>
            {
                { EAction. IncreaseSpeed, ActionInereasaSpeead },
                { EAction.ReduceSpeed, ActionReduceSpeead },
                { EAction.IncreaseHeight, ActionIncreaseHeight },
                { EAction.ReduceHeight, ActionReduceHeight },
                { EAction.SignificantlyIncreaseSpeed, ActionSignificantlyInereasaSpeead },
                { EAction.SignificantlyReduceSpeed, ActionSignificantlyReduceSpeead },
                { EAction.SignificantlyIncreaseHeight, ActionSignificantlyIncreaseHeight },
                { EAction.SignificantlyReduceHeight, ActionSignificantlyReduceHeight },
                { EAction.OpenMenu, () => throw new OpenMenuException() }
            };
        }
    }
}
