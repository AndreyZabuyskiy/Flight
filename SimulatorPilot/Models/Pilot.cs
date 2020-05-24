using System;
using System.Collections.Generic;
using System.Text;

namespace SimulatorPilot
{
    class Pilot
    {
        public string Name { get; set; }
        Dictionary<ConsoleKey, EAction> InstructionSet { get; set; }

        public Pilot(string name)
        {
            Name = name;

            InstructionSet = new Dictionary<ConsoleKey, EAction>
            {
                { ConsoleKey.LeftArrow, EAction.ReduceSpeead },
                { ConsoleKey.RightArrow, EAction.InereasaSpeead },
                { ConsoleKey.UpArrow, EAction.IncreaseHeight },
                { ConsoleKey.DownArrow, EAction.ReduceHeight }
            };
        }

        public EAction GiveCommand()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                foreach(var item in InstructionSet)
                {
                    if(item.Key == keyInfo.Key)
                    {
                        return item.Value;
                    }
                }
            }
        }
    }
}
