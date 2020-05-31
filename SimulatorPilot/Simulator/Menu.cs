using System;

namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        private void OpenDispatchersMenu()
        {
            UnsubscribeDispatchers();
            while (DispatchersMenu()) ;
            SubscribeDispatchers();
        }
        private void ShowActionsForDispatchersMenu()
        {
            ShowDispatchersList();

            if (Dispatchers.Count < 5)
                Console.WriteLine("[1] Добавить;");

            if (Dispatchers.Count > 2)
                Console.WriteLine("[2] Удалить;");

            Console.Write("[0] Выход\n->");
        }
        private void RemoveDispatcherMenu()
        {
            while (true)
            {
                ShowDispatchersList();
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

        private void ShowDispatchersList()
        {
            int iterator = 1;

            Console.Clear();

            foreach (var dispatcher in Dispatchers)
            {
                Console.WriteLine($"{iterator++}. {dispatcher.Name}: {dispatcher.Penalty}");
            }
            Console.WriteLine();
        }
    }
}
