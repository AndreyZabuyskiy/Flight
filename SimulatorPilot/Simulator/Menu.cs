using System;
using System.Collections.Generic;
using System.Text;

namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        private bool Action()
        {
            Print();

            if (int.TryParse(Console.ReadLine(), out int command))
            {
                switch (command)
                {
                    case 0:
                        return false;

                    case 1 when Dispatchers.Count < 5:
                        Dispatchers.Add(new Dispatcher(GetName(), Plane));
                        break;

                    case 2 when Dispatchers.Count > 2:
                        RemoveDispatcher();
                        break;
                }
            }

            return true;
        }
        private void Print()
        {
            PrintDispatchers();

            if (Dispatchers.Count < 5)
                Console.WriteLine("[1] Добавить;");

            if (Dispatchers.Count > 2)
                Console.WriteLine("[2] Удалить;");

            Console.Write("[0] Выход\n->");
        }
        private void RemoveDispatcher()
        {
            while (true)
            {
                PrintDispatchers();
                Console.Write("Выбирите порядковый номер:\n->");

                if (int.TryParse(Console.ReadLine(), out int idx))
                {
                    try
                    {
                        idx--;
                        Dispatchers.RemoveAt(idx);
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Диспетчера по данному номеру не найдено!");
                        Console.ReadLine();
                    }
                }
            }
        }

        private void PrintDispatchers()
        {
            int iterator = 1;

            Console.Clear();

            foreach (var dis in Dispatchers)
            {
                Console.WriteLine($"{iterator++}. {dis.Name}: {dis.Penalty}");
            }
            Console.WriteLine();
        }
    }
}
