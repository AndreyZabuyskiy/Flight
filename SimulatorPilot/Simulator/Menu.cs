using System;
using System.Collections.Generic;
using System.Text;

namespace SimulatorPilot.Simulator
{
    partial class Simulator
    {
        public void Flight()
        {
            while (!Plane.IsFlightCompleted)
            {
                try
                {
                    Move();
                }
                catch (OpenMenuException)
                {
                    MenuDispatchers();
                }
                catch (KeyNotFoundException) { }
                catch (ZeroValueException) { }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }
        private void Move()
        {
            Plane.AverageFines = CalculateArithmeticPenalty();
            Plane.Show(CalculateRecommendedHeight());
            ShowHandler();
            Plane.Flight();
            FlyCnange.Invoke(Plane);
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
