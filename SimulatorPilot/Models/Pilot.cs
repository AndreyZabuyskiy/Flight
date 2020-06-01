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
                { ConsoleKey.LeftArrow, EAction.ReduceSpeed },
                { ConsoleKey.RightArrow, EAction. IncreaseSpeed },
                { ConsoleKey.UpArrow, EAction.IncreaseHeight },
                { ConsoleKey.DownArrow, EAction.ReduceHeight },
                { ConsoleKey.D1, EAction.OpenMenu},
                { ConsoleKey.NumPad1, EAction.OpenMenu},
                { ConsoleKey.D0, EAction.FlightCancellation},
                { ConsoleKey.NumPad0, EAction.FlightCancellation}
            };
            
            SignificantlyInstructions = new Dictionary<ConsoleKey, EAction>
            {
                { ConsoleKey.LeftArrow, EAction.SignificantlyReduceSpeed },
                { ConsoleKey.RightArrow, EAction.SignificantlyIncreaseSpeed },
                { ConsoleKey.UpArrow, EAction.SignificantlyIncreaseHeight },
                { ConsoleKey.DownArrow, EAction.SignificantlyReduceHeight }
            };
        }

        public EAction GiveCommand()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            var _instructions =
                key.Modifiers == ConsoleModifiers.Control ?
                SignificantlyInstructions : Instructions;

            return _instructions[key.Key];
        }
    }
}
