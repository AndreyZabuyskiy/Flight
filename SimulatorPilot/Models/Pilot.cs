using System;
using System.Collections.Generic;

/*
 * Для использования ускорения
 * в свойствах терминала в настройках нужно убрать флажок
 * "Разрешить сочетание клавишь с CONTROL"
 */


namespace SimulatorPilot
{
    class Pilot
    {
        public string Name { get; set; }
        Dictionary<ConsoleKey, EAction> Instructions { get; set; }
        Dictionary<ConsoleKey, EAction> SignificantlyInstructions { get; set; }

        public Pilot(string name)
        {
            Name = name;

            Instructions = new Dictionary<ConsoleKey, EAction>
            {
                { ConsoleKey.LeftArrow, EAction.ReduceSpeead },
                { ConsoleKey.RightArrow, EAction.InereasaSpeead },
                { ConsoleKey.UpArrow, EAction.IncreaseHeight },
                { ConsoleKey.DownArrow, EAction.ReduceHeight }
            };

            SignificantlyInstructions = new Dictionary<ConsoleKey, EAction>
            {
                { ConsoleKey.LeftArrow, EAction.SignificantlyReduceSpeead },
                { ConsoleKey.RightArrow, EAction.SignificantlyInereasaSpeead },
                { ConsoleKey.UpArrow, EAction.SignificantlyIncreaseHeight },
                { ConsoleKey.DownArrow, EAction.SignificantlyReduceHeight }
            };
        }

        public EAction GiveCommand()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                var _instructions =
                    key.Modifiers == ConsoleModifiers.Control ?
                    SignificantlyInstructions : Instructions;

                foreach (var item in _instructions)
                {
                    if(item.Key == key.Key)
                    {
                        return item.Value;
                    }
                }
            }
        }
    }
}
