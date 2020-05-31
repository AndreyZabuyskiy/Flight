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
            int idx;

            do
            {
                ShowDispatchersList();
                Console.Write("Выберите порядковый номер:\n" +
                    "[0] Назад;\n->");

                if (!int.TryParse(Console.ReadLine(), out idx)) continue;

                try
                {
                    Dispatchers.RemoveAt(--idx);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Неверный порядковый номер диспетчера!\n");
                }
            } while (!(idx == -1 || Dispatchers.Count <= MIN_COUNT_DISPETCHER));
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
