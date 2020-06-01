using System;

namespace SimulatorPilot
{
    class PlaneCrashedException : Exception
    {
        public override string Message => "Самолёт разбился из-за отсутствия скорости во время полёта!!!";
    }

    class FinesOverflowException : Exception
    {
        public override string Message => "Сумма штрафов от одного из диспетчеров превысила 1000!!!";
    }

    class WrongLandingException : Exception
    {
        public override string Message => "Самолет призимлился не набрав максимальной высоты!!!";
    }

    class DefaultValueException : Exception
    {
        public override string Message => "Значение по умолчанию!!!";
    }

    class ArithmeticMeanTooLargeException : Exception
    {
        public override string Message => "Слишком большое среднее арифметическое!!!";
    }

    class OpenMenuException : Exception { }

    class FlightCancellationException : Exception
    {
        public override string Message => "Полет прерван!!!";
    }
}
