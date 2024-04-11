using avhH60Common.Models;

namespace avhH60Common.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Province { get; set; }
        public string? CreditCard { get; set; }

        public CustomerDTO() { }
        public CustomerDTO(Customer customer) {
            CustomerId = customer.CustomerId;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            PhoneNumber = customer.PhoneNumber;
            Province = customer.Province;
            CreditCard = customer.CreditCard;
        }
    }
}
