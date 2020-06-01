using System;

namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        private void OpenDispatchersMenu()
        {
            UnsubscribeDispatchers();
            DispatchersMenu();
            SubscribeDispatchers();
        }

        private void ShowActionsForDispatchersMenu()
        {
            ShowDispatchersList();

            if (Dispatchers.Count < MAX_COUNT_DISPETCHER)
                Console.WriteLine("[1] Добавить;");

            if (Dispatchers.Count > MIN_COUNT_DISPETCHER)
                Console.WriteLine("[2] Удалить;");

            Console.Write("[0] Выход\n->");
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

        private void ShowUserGreeting()
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();

                Console.Write("   Добро пожаловать в Airplane Simulator.\n\n" +
                    "   Задача пилота - взлететь на самолёте, набрать максимальную скорость 1000км/час," +
                    "после чего посадить самолёт\n\n" +
                    "   Процесс полёта будут контролировать диспетчеры,\n" +
                    "предоставляя указания по показателям высоты/скорости.\n" +
                    "Если разница от рекомендуемых диспетчерами показателями\n" +
                    "будет сильно отличатся - пилоту будут начисляться штрафные баллы.\n" +
                    "Если пилот набирает более 1000 штрафных баллов от любого из дисетчеров,\n" +
                    "то полёт прекратится, а пилот будет признан не годным к полётам.\n\n" +
                    "   Управление самолётом осуществляется с помощью стрелочек на клавиатуре.\n" +
                    "Пример: -> - Увеличить скорость на 50км/ч, CTRL + -> - Увеличить скорость на 150км/ч\n\n" +
                    "   Если нужно вызвать меню с диспетчерами, нажмите[1]\n\n" +
                    "   Для корректного использования функции ускорения зайдите в настройки терминала\n" +
                    "   Для подробной информации нажмите кнопку \'1\'\n\n" +
                    "   Для продолжения нажмите Enter");

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                    ShowTerminalSettings();

            } while (keyInfo.Key != ConsoleKey.Enter);
        }

        private void ShowTerminalSettings()
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();

                Console.WriteLine("Шаг 1: зайти в свойство терминала;\n" +
                    "Шаг 2: выбрать вкладку настройки;\n" +
                    "Шаг 3: убрать галочку \"Разрешить сочитание клавиш с CONTROL\"\n\n" +
                    "   Для продолжения нажмите Enter");

                keyInfo = Console.ReadKey();

            } while (keyInfo.Key != ConsoleKey.Enter);
        }
    }
}
