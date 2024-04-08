namespace CustomerManagementServiceSimulator.WebAPI.Configuration
{
    public class SimulatorSettingsOptions
    {
        public int IterationsNumber { get; set; }

        public int DelayBetweenIterationsInMilliseconds { get; set; }

        public int ParallelTasksNumber { get; set; }

        public int DelayBetweenParallelTasksInMilliseconds { get; set; }

        public int MinCustomerNumberPerRequest { get; set; }

        public int MaxCustomerNumberPerRequest { get; set; }
    }
}
