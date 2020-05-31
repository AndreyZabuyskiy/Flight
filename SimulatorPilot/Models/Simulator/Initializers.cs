using System;
using System.Collections.Generic;
using SimulatorPilot.Models.Plane;

namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        private void Initialization()
        {
            InitializePlane();
            InitializeDispatchers();
            SubscribeDispatchers();
        }

        private void InitializePlane()
        {
            string namePilot;
            do
            {
                Console.Clear();
                Console.Write("Имя пилота:\n->");
                namePilot = Console.ReadLine();
            } while (namePilot.Equals(""));

            Plane = new Plane(namePilot);
        }

        private void InitializeDispatchers()
        {
            int count = EnterCountDispatcher();
            Dispatchers = new List<Dispatcher>();

            for (int i = 0; i < count; ++i)
            {
                Console.Clear();
                Console.Write($"Имя диспетчера #{i + 1}\n->");
                Dispatchers.Add(new Dispatcher(Console.ReadLine()));
            }

            PrintUserGreeting();
        }

        private void SubscribeDispatchers()
        {
            foreach (var dispatcher in Dispatchers)
            {
                FlightStateChange += dispatcher.Work;
                DispatchersShowState += dispatcher.Print;
            }
        }

        private void UnsubscribeDispatchers()
        {
            foreach (var dispatcher in Dispatchers)
            {
                FlightStateChange -= dispatcher.Work;
                DispatchersShowState -= dispatcher.Print;
            }
        }

        private void PrintUserGreeting()
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
                    "   Для корректного использования ускорения зайдите в настройки терминала\n" +
                    "   Для подробной информации нажмите \'1\'\n\n" +
                    "   Для продолжения нажмите Enter");

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                    PrintTerminalSettings();

            } while (keyInfo.Key != ConsoleKey.Enter);
        }

        private void PrintTerminalSettings()
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

            } while (!(keyInfo.Key == ConsoleKey.Enter));
        }
    }
}
