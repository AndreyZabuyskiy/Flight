using System;

namespace SimulatorPilot
{
    class PlaneCrashedException : Exception
    {
        public override string Message => "Самолет разбился!!!";
    }

    class FinesOverflowException : Exception
    {
        public override string Message => "Самолет набрал слишком много штрафов!!!";
    }

    class ImproperLandingException : Exception
    {
        public override string Message => "Самолет призимлился не набрав максимальной высоты!!!";
    }

    class ZeroValueException : Exception
    {
        public override string Message => "Нулевое значение!!!";
    }
}
