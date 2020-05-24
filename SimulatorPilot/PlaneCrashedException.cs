using System;
using System.Collections.Generic;
using System.Text;

namespace SimulatorPilot
{
    class PlaneCrashedException : Exception
    {
        public PlaneCrashedException() : base("Самолет разбился!!!") { }
    }

    class FinesOverflowException : Exception
    {
        public FinesOverflowException() : base("Самолет набрал слишком много штрафов!!!") { }
    }

    class LandedWithoutGainingMaximumHeightException : Exception
    {
        public LandedWithoutGainingMaximumHeightException() : base("Самолет призимлился не набрав максимальной высоты!!!") { }
    }
}
