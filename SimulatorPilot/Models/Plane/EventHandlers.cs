namespace SimulatorPilot.Models.Plane
{
    partial class Plane
    {
        private void ActionIncreaseSpeed()
        {
            if (Speed < MAX_SPEED)
                Speed += 50;
        }

        private void ActionReduceSpeed()
        {
            if (Speed == 0)
                throw new DefaultValueException();

            if (Speed > 0)
                Speed -= 50;
        }

        private void ActionIncreaseHeight()
        {
            Height += 250;
        }

        private void ActionReduceHeight()
        {
            if (Height == 0)
                throw new DefaultValueException();

            if (Height > 0)
                Height -= 250;
        }

        private void ActionSignificantlyIncreaseSpeed()
        {
            if (Speed < MAX_SPEED)
                Speed += 150;
        }

        private void ActionSignificantlyReduceSpeed()
        {
            if (Speed == 0)
                throw new DefaultValueException();

            if (Speed > 0)
                Speed -= 150;
        }

        private void ActionSignificantlyIncreaseHeight()
        {
            Height += 500;
        }

        private void ActionSignificantlyReduceHeight()
        {
            if (Height == 0)
                throw new DefaultValueException();

            if (Height > 0)
                Height -= 500;
        }
    }
}
