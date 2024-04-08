using System.ComponentModel;

namespace CustomerManagementServiceSimulator.WebAPI.Models
{
    public class CustomerCreateModel
    {
        [Description("The last customer sequential Id in the Database Customers table")]
        public int LastId { get; set; }
    }
}
