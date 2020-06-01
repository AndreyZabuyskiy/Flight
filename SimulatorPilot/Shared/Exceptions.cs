using System;

namespace SimulatorPilot
{
    class PlaneCrashedException : Exception
    {
        public override string Message => "Самолет разбился!!!";
    }

    class FinesOverflowException : Exception
    {
        public override string Message => "Самолет набрал слишком много штрафов от диспетчера!!!";
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
