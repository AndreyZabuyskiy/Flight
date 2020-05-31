using System;

namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        private int EnterCountDispatcher()
        {
            int count;
            do
            {
                Console.Clear();
                Console.Write("Введите количество диспетчеров (2 - 5)\n->");

                int.TryParse(Console.ReadLine(), out count);
            } while (!(count >= MIN_COUNT_DISPETCHER && count <= MAX_COUNT_DISPETCHER));

            return count;
        }

        private void DispatchersMenu()
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                ShowActionsForDispatchersMenu();
                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.NumPad1 when Dispatchers.Count < 5:
                        Dispatchers.Add(new Dispatcher(GetName(), Plane));
                        break;

                    case ConsoleKey.D1 when Dispatchers.Count < 5:
                        Dispatchers.Add(new Dispatcher(GetName(), Plane));
                        break;

                    case ConsoleKey.NumPad2 when Dispatchers.Count > 2:
                        RemoveDispatcherMenu();
                        break;

                    case ConsoleKey.D2 when Dispatchers.Count > 2:
                        RemoveDispatcherMenu();
                        break;
                }

            } while (!(keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad0));
        }

        private string GetName()
        {
            Console.Clear();
            Console.Write("Введите имя:\n->");

            return Console.ReadLine();
        }
    }
}
