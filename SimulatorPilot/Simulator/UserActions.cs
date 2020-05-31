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

        private bool DispatchersMenu()
        {
            ShowActionsForDispatchersMenu();

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
                        RemoveDispatcherMenu();
                        break;
                }
            }

            return true;
        }
        private string GetName()
        {
            Console.Clear();
            Console.Write("Введите имя:\n->");

            return Console.ReadLine();
        }
    }
}
