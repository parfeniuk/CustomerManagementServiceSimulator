namespace CustomerManagementServiceSimulator.WebAPI.Configuration
{
    public class CustomerCreationSettingsOptions
    {
        public int MinAge { get; set; }

        public int MaxAge { get; set; }

        public int MinCustomerNumberPerRequest { get; set; }

        public int MaxCustomerNumberPerRequest { get; set; }
    }
}
