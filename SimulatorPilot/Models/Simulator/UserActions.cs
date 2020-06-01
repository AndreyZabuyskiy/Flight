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
        
        private string GetDispatcherName(int serialNumber)
        {
            string dispatcherName;

            do
            {
                Console.Clear();
                Console.Write($"Имя диспетчера #{serialNumber}\n->");
                dispatcherName = Console.ReadLine();
            } while (dispatcherName.Trim().Equals(""));

            return dispatcherName;
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
                    case ConsoleKey.D1 when Dispatchers.Count < 5:
                        AddNewDispatcher();
                        break;

                    case ConsoleKey.NumPad2 when Dispatchers.Count > 2:
                    case ConsoleKey.D2 when Dispatchers.Count > 2:
                        RemoveDispatcherMenu();
                        break;
                }

            } while (!(keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad0));
        }

        private void AddNewDispatcher()
        {
            string nameDispatcher;

            do
            {
                Console.Clear();
                Console.Write("Имя нового диспетчера:\n" +
                    "[0] Назад;\n->");

                nameDispatcher = Console.ReadLine();
            } while (nameDispatcher.Trim().Equals(""));

            if (!nameDispatcher.Equals("0"))
                Dispatchers.Add(new Dispatcher(nameDispatcher, Plane));
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

        private void CompletionFlighMenu()
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Write("\n[1] Начать полет снова;\n" +
                    "[0] Завершить;\n->");
                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                    RepeatFlight();

            } while (!(keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad0));
        }
    }
}
