using System;
using System.Collections.Generic;
using System.Text;

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

    class LandingDoesNotMeetConditions : Exception
    {
        public override string Message => "Самолет призимлился не набрав максимальной высоты!!!";
    }
}
