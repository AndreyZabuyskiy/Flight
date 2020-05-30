using System;
using System.Collections.Generic;

namespace SimulatorPilot
{
    class Simulator
    {
        public delegate void FlyHandler(Plane plane);
        public event FlyHandler FlyCnange;
        public event Action ShowHandler;

        public Plane Plane { get; set; }
        public List<Dispatcher> Dispatchers { get; set; }

        public Simulator()
        {
            Initialization();
        }
        private void Initialization()
        {
            FillPlane();
            FillDispatchers();
            SignDispatchers();
        }
        private void FillPlane()
        {
            Console.Write("Имя пилота:\n->");
            Plane = new Plane(Console.ReadLine());
        }
        private void FillDispatchers()
        {
            int count = GetCountDispatchers();
            Dispatchers = new List<Dispatcher>();

            for(int i = 0; i < count; ++i)
            {
                Console.Clear();
                Console.Write($"Имя диспетчера #{i + 1}\n->");
                Dispatchers.Add(new Dispatcher(Console.ReadLine()));
            }
        }
        private int GetCountDispatchers()
        {
            while(true)
            {
                Console.Clear();
                Console.Write("Введите количество диспетчеров (2 - 5)\n->");

                if (int.TryParse(Console.ReadLine(), out int count))
                {
                    if (count > 1 && count < 6)
                    {
                        return count;
                    }
                }
            }
        }
        private void SignDispatchers()
        {
            foreach (var d in Dispatchers)
            {
                FlyCnange += d.Work;
                ShowHandler += d.Print;
            }
        }
        private void UnsubscribeDispatchers()
        {
            foreach (var dispatcher in Dispatchers)
            {
                FlyCnange -= dispatcher.Work;
                ShowHandler -= dispatcher.Print;
            }
        }

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
                catch (KeyNotFoundException)
                {
                    Console.Clear();
                }
                catch (ZeroValueException ex)
                {
                    Console.WriteLine(ex.Message);
                }
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

        public int CalculateRecommendedHeight()
        {
            int TotalHeight = 0;

            foreach (var dis in Dispatchers)
            {
                TotalHeight += dis.RecommendedHeight;
            }

            return TotalHeight / Dispatchers.Count;
        }
        public int CalculateArithmeticPenalty()
        {
            int totalPenalty = 0;

            foreach (var dis in Dispatchers)
            {
                totalPenalty += dis.Penalty;
            }

            return totalPenalty / Dispatchers.Count;
        }


        private void MenuDispatchers()
        {
            UnsubscribeDispatchers();
            while (Action()) ;
            SignDispatchers();
        }
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
            while(true)
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
                    catch(ArgumentOutOfRangeException)
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
        private string GetName()
        {
            Console.Clear();
            Console.Write("Введите имя:\n->");

            return Console.ReadLine();
        }
    }
}
