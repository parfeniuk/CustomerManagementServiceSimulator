using System.ComponentModel.DataAnnotations;

namespace CustomerManagementServiceSimulator.WebAPI.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        public int Age { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
