using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Phonebook.Requests
{
    public class CreateRequest
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
