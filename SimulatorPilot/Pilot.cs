using System;
using System.Collections.Generic;
using System.Text;

namespace SimulatorPilot
{
    class Pilot
    {
        public string Name { get; set; }

        public Pilot(string name)
        {
            Name = name;
        }

        public EAction GiveCommand()
        {
            ConsoleKeyInfo keyInfo;
            EAction eAction;

            while (true)
            {
                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    eAction = EAction.ReduceSpeead;
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    eAction = EAction.InereasaSpeead;
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    eAction = EAction.IncreaseHeight;
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    eAction = EAction.ReduceHeight;
                    break;
                }
            }

            return eAction;
        }
    }
}
